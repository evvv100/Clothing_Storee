using DataAccessLayer;
using Logic;
using Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClothingStore.ConsoleApp
{
    /// <summary>
    /// Главный класс консольного приложения: одна таблица товаров склада с добавлением,
    /// изменением, удалением и фильтрами по размеру и категории.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// DI контейнер
        /// </summary>
        public static IKernel Kernel { get; private set; }
        /// <summary>
        /// Выбранный фильтр по размеру. null - фильтр выключен.
        /// </summary>
        private static ClothingSize? _sizeFilter = null;

        /// <summary>
        /// Выбранный фильтр по категории. null - фильтр выключен.
        /// </summary>
        private static ClothingCategory? _categoryFilter = null;

        /// <summary>
        /// Точка входа в программу. Показывает таблицу товаров и обрабатывает команды пользователя.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            Kernel = new StandardKernel(new SimpleConfigModule());
            IClothingQuery _query = Kernel.Get<IClothingQuery>();
            IClothingCommand _command = Kernel.Get<IClothingCommand>();
            IClothingFilter _filter = Kernel.Get<IClothingFilter>();
            if (_query.GetAll().Count == 0)
            {
                if (_command is Logic.Logic concreteLogic)
                {
                    concreteLogic.FilledTable();
                }
            }

            while (true)
            {
                ClearScreen();
                Console.WriteLine("--- СКЛАД ТОВАРОВ ---\n");
                Console.WriteLine("Фильтры: размер - " + (_sizeFilter.HasValue ? _sizeFilter.Value.ToString() : "все") +
                                  ", категория - " + (_categoryFilter.HasValue ? _categoryFilter.Value.ToString() : "все") + "\n");

                List<Clothing> list = GetFilteredList(_filter, _query);
                PrintTable(list);

                Console.WriteLine("\n\t[1] Добавить");
                Console.WriteLine("\t[2] Изменить");
                Console.WriteLine("\t[3] Удалить");
                Console.WriteLine("\t[4] Фильтр по размеру");
                Console.WriteLine("\t[5] Фильтр по категории");
                Console.WriteLine("\t[6] Сбросить фильтры");
                Console.WriteLine("\t[0] Выход");
                Console.Write("\nВаш выбор: ");

                switch (ReadInput())
                {
                    case "1":
                        AddClothing(_command);
                        break;
                    case "2":
                        ChangeClothing(list, _command);
                        break;
                    case "3":
                        RemoveClothing(list, _command);
                        break;
                    case "4":
                        AskFilter("Размер", ref _sizeFilter);
                        break;
                    case "5":
                        AskFilter("Категория", ref _categoryFilter);
                        break;
                    case "6":
                        _sizeFilter = null;
                        _categoryFilter = null;
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ввод неверный! Попробуйте снова.");
                        Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Возвращает товары склада с учетом включенных фильтров (оба фильтра применяются одновременно)
        /// </summary>
        /// <param name="_filter">Интерфейс фильтрации товаров</param>
        /// <param name="_query">Интерфейс для чтения товаров</param>
        /// <returns></returns>
        private static List<Clothing> GetFilteredList(IClothingFilter _filter, IClothingQuery _query)
        {
            List<Clothing> list = _query.GetAll();
            if (_sizeFilter.HasValue)
            {
                list = _filter.FilterBySize(list, _sizeFilter.Value);
            }
            if (_categoryFilter.HasValue)
            {
                list = _filter.FilterByCategory(list, _categoryFilter.Value);
            }
            return list;
        }

        /// <summary>
        /// Просит выбрать значение фильтра или выключить его
        /// </summary>
        /// <typeparam name="T">Тип перечисления (ClothingCategory или ClothingSize)</typeparam>
        /// <param name="title">Заголовок списка</param>
        /// <param name="filter">Значение фильтра. null - фильтр выключен</param>
        private static void AskFilter<T>(string title, ref T? filter) where T : struct
        {
            Array values = Enum.GetValues(typeof(T));
            Console.WriteLine("\n" + title + ":");
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ") " + values.GetValue(i));
            }
            Console.WriteLine("\t" + (values.Length + 1) + ") Все (выключить фильтр)");
            Console.Write("Ваш выбор (0 - отмена): ");

            int n;
            if (!int.TryParse(ReadInput(), out n) || n < 0 || n > values.Length + 1)
            {
                Console.WriteLine("Неверный пункт меню.");
                Pause();
                return;
            }
            if (n == 0)
            {
                return;
            }
            if (n == values.Length + 1)
            {
                filter = null;
            }
            else
            {
                filter = (T)values.GetValue(n - 1)!;
            }
        }

        /// <summary>
        /// Добавляет новый товар на склад. Артикул присваивается автоматически
        /// </summary>
        /// <param name="_command">Интерфейс для добавления товаров</param>
        private static void AddClothing(IClothingCommand _command)
        {
            ClearScreen();
            Console.WriteLine("--- ДОБАВЛЕНИЕ ТОВАРА ---\n");
            string name;
            ClothingCategory category;
            ClothingSize size;
            int price;
            if (!ReadClothingData(out name, out category, out size, out price))
            {
                return;
            }
            _command.AddClothing(name, category, size, price);
            Console.WriteLine("\nТовар добавлен!");
            Pause();
        }

        /// <summary>
        /// Изменяет выбранный товар (артикул сохраняется)
        /// </summary>
        /// <param name="clothes">Список товаров, отображаемый в таблице</param>
        /// <param name="_command">Интерфейс для изменения товаров</param>
        private static void ChangeClothing(List<Clothing> clothes, IClothingCommand _command)
        {
            if (clothes.Count == 0)
            {
                Console.WriteLine("В таблице нет товаров.");
                Pause();
                return;
            }
            Clothing item = AskItem("Введите артикул товара, который хотите изменить", clothes);
            if (item == null)
            {
                return;
            }

            ClearScreen();
            Console.WriteLine("--- ИЗМЕНЕНИЕ ТОВАРА ---\n");
            Console.WriteLine("Артикул товара: " + item.Id + " (не изменяется)");
            Console.WriteLine("Сейчас: {0} | {1} | {2} | {3} руб.\n", item.Name, item.Category, item.Size, item.Price);

            string name;
            ClothingCategory category;
            ClothingSize size;
            int price;
            if (!ReadClothingData(out name, out category, out size, out price))
            {
                return;
            }
            _command.ChangeClothing(new Clothing(item.Id, name, category, size, price));
            Console.WriteLine("\nТовар изменен!");
            Pause();
        }

        /// <summary>
        /// Удаляет выбранный товар со склада
        /// </summary>
        /// <param name="clothes">Список товаров, отображаемый в таблице</param>
        /// <param name="_command">Интерфейс для удаления товаров</param>
        private static void RemoveClothing(List<Clothing> clothes, IClothingCommand _command)
        {
            if (clothes.Count == 0)
            {
                Console.WriteLine("В таблице нет товаров.");
                Pause();
                return;
            }
            Clothing item = AskItem("Введите артикул товара для удаления", clothes);
            if (item == null)
            {
                return;
            }
            _command.RemoveClothing(item.Id);
            Console.WriteLine("Товар удален!");
            Pause();
        }

        /// <summary>
        /// Запрашивает название, категорию, размер и цену товара. На любом шаге можно ввести 0 для отмены
        /// </summary>
        /// <returns>true, если все данные введены; false, если пользователь отменил ввод</returns>
        private static bool ReadClothingData(out string name, out ClothingCategory category, out ClothingSize size, out int price)
        {
            name = null!;
            category = default(ClothingCategory);
            size = default(ClothingSize);
            price = 0;

            name = AskName();
            if (name == null)
            {
                return false;
            }
            ClothingCategory? c = AskEnum<ClothingCategory>("Категория");
            if (!c.HasValue)
            {
                return false;
            }
            category = c.Value;
            ClothingSize? s = AskEnum<ClothingSize>("Размер");
            if (!s.HasValue)
            {
                return false;
            }
            size = s.Value;
            int? p = AskPrice();
            if (!p.HasValue)
            {
                return false;
            }
            price = p.Value;
            return true;
        }

        /// <summary>
        /// Запрашивает название товара (не может быть пустым)
        /// </summary>
        /// <returns>Название или null, если ввод отменен</returns>
        private static string AskName()
        {
            while (true)
            {
                Console.Write("Название (0 - отмена): ");
                string text = ReadInput();
                if (text == "0")
                {
                    return null!;
                }
                if (text.Length == 0)
                {
                    Console.WriteLine("Название товара не может быть пустым.");
                    continue;
                }
                return text;
            }
        }

        /// <summary>
        /// Запрашивает цену товара (только положительное целое число)
        /// </summary>
        /// <returns>Цена или null, если ввод отменен</returns>
        private static int? AskPrice()
        {
            while (true)
            {
                Console.Write("Цена (0 - отмена): ");
                string text = ReadInput();
                if (text == "0")
                {
                    return null;
                }
                int price;
                if (!int.TryParse(text, out price) || price <= 0)
                {
                    Console.WriteLine("Цена товара должна быть положительным числом.");
                    continue;
                }
                return price;
            }
        }

        /// <summary>
        /// Показывает значения перечисления списком и просит выбрать одно из них
        /// </summary>
        /// <typeparam name="T">Тип перечисления (ClothingCategory или ClothingSize)</typeparam>
        /// <param name="title">Заголовок списка</param>
        /// <returns>Выбранное значение или null, если ввод отменен</returns>
        private static T? AskEnum<T>(string title) where T : struct
        {
            Array values = Enum.GetValues(typeof(T));
            while (true)
            {
                Console.WriteLine(title + ":");
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine("\t" + (i + 1) + ") " + values.GetValue(i));
                }
                Console.Write("Ваш выбор (0 - отмена): ");
                string text = ReadInput();
                if (text == "0")
                {
                    return null;
                }
                int n;
                if (int.TryParse(text, out n) && n >= 1 && n <= values.Length)
                {
                    return (T)values.GetValue(n - 1)!;
                }
                Console.WriteLine("Неверный пункт меню. Попробуйте еще раз.");
            }
        }

        /// <summary>
        /// Просит ввести артикул и находит товар в переданном списке
        /// </summary>
        /// <param name="prompt">Текст приглашения</param>
        /// <param name="source">Список, из которого можно выбрать товар</param>
        /// <returns>Выбранный товар или null, если ввод отменен</returns>
        private static Clothing AskItem(string prompt, List<Clothing> source)
        {
            while (true)
            {
                Console.Write("\n" + prompt + " (0 - назад): ");
                string text = ReadInput();
                if (text == "0")
                {
                    return null!;
                }
                int id;
                if (!int.TryParse(text, out id))
                {
                    Console.WriteLine("Неверный ввод, артикул должен быть числом.");
                    continue;
                }
                Clothing item = source.Find(c => c.Id == id)!;
                if (item == null)
                {
                    Console.WriteLine("Товар с таким артикулом не найден в таблице.");
                    continue;
                }
                return item;
            }
        }

        /// <summary>
        /// Выводит список товаров таблицей
        /// </summary>
        /// <param name="list">Список товаров, который нужно вывести</param>
        private static void PrintTable(List<Clothing> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }
            Console.WriteLine("{0,-9}{1,-26}{2,-12}{3,-8}{4}", "Артикул", "Название", "Категория", "Размер", "Цена (руб.)");
            Console.WriteLine(new string('-', 66));
            foreach (Clothing item in list)
            {
                Console.WriteLine("{0,-9}{1,-26}{2,-12}{3,-8}{4}", item.Id, item.Name, item.Category, item.Size, item.Price);
            }
        }

        /// <summary>
        /// Читает строку с консоли и обрезает пробелы по краям
        /// </summary>
        private static string ReadInput()
        {
            return (Console.ReadLine() ?? "").Trim();
        }

        /// <summary>
        /// Очищает экран консоли
        /// </summary>
        private static void ClearScreen()
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {

            }
        }

        /// <summary>
        /// Ждет нажатия любой клавиши, чтобы пользователь успел прочитать сообщение
        /// </summary>
        private static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey(true);
        }
    }
}

