using DataAccessLayer;
using Model;
using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClothingStore.ConsoleApp
{
    internal class Program
    {
        private static Logic.Logic _logic = new Logic.Logic(new EntityRepository<Clothing>());
        private static Random rnd = new Random();
        private static int _balance = rnd.Next(10000, 20001);

        static void Main(string[] args)
        {
            if (_logic.GetCatalog().Count == 0)
            {
                _logic.FilledTable();
            }

            while (true)
            {
                ClearScreen();
                Console.WriteLine("\tДобро пожаловать в магазин одежды!\n");
                Console.WriteLine("Введите номер действия:");
                Console.WriteLine("\t[1] Каталог");
                Console.WriteLine("\t[2] Собрать корзину");
                Console.WriteLine("\t[3] История покупок");
                Console.WriteLine("\t[0] Завершить покупки");
                Console.Write("\nВаш выбор: ");

                switch (ReadInput())
                {
                    case "1":
                        ShowCatalog();
                        break;
                    case "2":
                        AssembleBasket();
                        break;
                    case "3":
                        ShowHistory();
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
        /// Экран каталога: показывает список товаров и позволяет добавить, изменить или удалить товар
        /// </summary>
        private static void ShowCatalog()
        {
            while (true)
            {
                ClearScreen();
                PrintHeader("КАТАЛОГ");
                var list = _logic.GetCatalog();
                PrintTable(list);

                Console.WriteLine("\n\t[1] Добавить");
                Console.WriteLine("\t[2] Изменить");
                Console.WriteLine("\t[3] Удалить");
                Console.WriteLine("\t[0] Назад");
                Console.Write("\nВаш выбор: ");

                switch (ReadInput())
                {
                    case "1":
                        AddClothing();
                        break;
                    case "2":
                        ChangeClothing(list);
                        break;
                    case "3":
                        RemoveClothing(list);
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
        /// Добавляет новый товар в каталог. Артикул присваивается автоматически
        /// </summary>
        private static void AddClothing()
        {
            ClearScreen();
            PrintHeader("ДОБАВЛЕНИЕ ОДЕЖДЫ");

            string name;
            ClothingCategory category;
            ClothingSize size;
            int price;
            if (!ReadClothingData(out name, out category, out size, out price))
            {
                return;
            }

            _logic.AddClothing(name, category, size, price);
            Console.WriteLine("\nТовар успешно добавлен в ассортимент магазина!");
            Pause();
        }

        /// <summary>
        /// Изменяет выбранный товар (артикул сохраняется)
        /// </summary>
        /// <param name="clothes">Список товаров, отображаемый в каталоге</param>
        private static void ChangeClothing(List<Clothing> clothes)
        {
            if (clothes.Count == 0)
            {
                Console.WriteLine("В каталоге нет товаров.");
                Pause();
                return;
            }

            Clothing item = AskItem("Введите артикул товара, который хотите изменить", clothes);
            if (item == null)
            {
                return;
            }

            ClearScreen();
            PrintHeader("ИЗМЕНЕНИЕ ОДЕЖДЫ");
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

            _logic.ChangeClothing(new Clothing(item.Id, name, category, size, price));
            Console.WriteLine("\nТовар успешно изменен!");
            Pause();
        }

        /// <summary>
        /// Удаляет выбранный товар из каталога
        /// </summary>
        /// <param name="clothes">Список товаров, отображаемый в каталоге</param>
        private static void RemoveClothing(List<Clothing> clothes)
        {
            if (clothes.Count == 0)
            {
                Console.WriteLine("В каталоге нет товаров.");
                Pause();
                return;
            }

            Clothing item = AskItem("Введите артикул товара для удаления", clothes);
            if (item == null)
            {
                return;
            }

            if (_logic.GetClothingById(item.Id) != null)
            {
                _logic.RemoveClothing(item.Id);
                Console.WriteLine("Товар удален!");
            }
            else
            {
                Console.WriteLine("Невозможно найти товар");
            }
            Pause();
        }

        /// <summary>
        /// Экран сборки корзины. Товар, добавленный в корзину, временно убирается из каталога;
        /// при выходе без оплаты все товары возвращаются в каталог
        /// </summary>
        private static void AssembleBasket()
        {
            List<Clothing> basket = new List<Clothing>();
            bool filterOn = false;
            ClothingSize filterSize = ClothingSize.XS;

            while (true)
            {
                ClearScreen();
                PrintHeader("СБОРКА КОРЗИНЫ");
                Console.WriteLine("Чтобы добавить товар в корзину, выберите 'Добавить', а после 'Ок'.\n");

                List<Clothing> catalog;
                if (filterOn)
                {
                    var allClothesFromDb = _logic.GetCatalog();
                    catalog = allClothesFromDb.Where(c => c.Size == filterSize).ToList();
                    Console.WriteLine("Каталог (фильтр по размеру: " + filterSize + "):");
                }
                else
                {
                    catalog = _logic.GetCatalog();
                    Console.WriteLine("Каталог:");
                }
                catalog = catalog.Where(c => !basket.Any(b => b.Id == c.Id)).ToList();
                PrintTable(catalog);

                Console.WriteLine("\nКорзина:");
                PrintTable(basket);
                Console.WriteLine("\nИтого: " + CalculateTheTotal(basket) + " руб.");

                Console.WriteLine("\n\t[1] Добавить в корзину");
                Console.WriteLine("\t[2] Отмена (вернуть последний товар в каталог)");
                Console.WriteLine("\t[3] Фильтровать по размеру");
                Console.WriteLine("\t[4] Ок (оплатить)");
                Console.WriteLine("\t[0] Назад");
                Console.Write("\nВаш выбор: ");

                switch (ReadInput())
                {
                    case "1":
                        {
                            if (catalog.Count == 0)
                            {
                                Console.WriteLine("Нет товаров для добавления!");
                                Pause();
                                break;
                            }
                            Clothing item = AskItem("Введите артикул товара для добавления в корзину", catalog);
                            if (item != null && _logic.GetClothingById(item.Id) != null)
                            {
                                basket.Add(item);
                            }
                            break;
                        }
                    case "2":
                        {
                            if (basket.Count == 0)
                            {
                                Console.WriteLine("В корзине ничего нет!");
                                Pause();
                            }
                            else
                            {
                                Clothing last = basket[basket.Count - 1];
                                _logic.AddClothing(last.Name, last.Category, last.Size, last.Price);
                                basket.RemoveAt(basket.Count - 1);
                            }
                            break;
                        }
                    case "3":
                        AskSizeFilter(ref filterOn, ref filterSize);
                        break;
                    case "4":
                        if (TryPay(basket))
                        {
                            return;
                        }
                        break;
                    case "0":
                        foreach (Clothing item in basket)
                        {
                            item.IsSold = false;
                            _logic.ChangeClothing(item);
                        }
                        basket.Clear();
                        return;
                    default:
                        Console.WriteLine("Ввод неверный! Попробуйте снова.");
                        Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Оплачивает корзину: проверяет, что она не пуста и хватает средств, спрашивает подтверждение,
        /// списывает деньги и переносит товары в историю покупок
        /// </summary>
        /// <param name="basket">Корзина</param>
        /// <returns>true, если покупка совершена</returns>
        private static bool TryPay(List<Clothing> basket)
        {
            if (basket.Count == 0)
            {
                Console.WriteLine("Корзина пуста! Добавьте товары в корзину.");
                Pause();
                return false;
            }

            int total = CalculateTheTotal(basket);
            if (_balance < total)
            {
                Console.WriteLine("Недостаточно средств!");
                Pause();
                return false;
            }

            Console.WriteLine("\nСумма покупки составляет: " + total + " руб.");
            Console.Write("Оплатить? (1 - Да, любой другой ввод - Нет): ");
            if (ReadInput() != "1")
            {
                return false;
            }

            try
            {
                _logic.Buy(basket);
                _balance -= total;
                basket.Clear();
                Console.WriteLine("\nПоздравляем с покупкой! Ваш баланс: " + _balance + " руб.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при оплате: {ex.Message}");
            }
            Pause();
            return true;
        }

        /// <summary>
        /// Считает сумму покупки
        /// </summary>
        /// <param name="basket">Корзина</param>
        /// <returns>Сумма цен всех товаров в корзине</returns>
        private static int CalculateTheTotal(List<Clothing> basket)
        {
            int count = 0;
            for (int i = 0; i < basket.Count; i++)
            {
                count += basket[i].Price;
            }
            return count;
        }

        /// <summary>
        /// Позволяет включить фильтр по размеру, сменить размер или показать все размеры
        /// </summary>
        /// <param name="filterOn">Включен ли фильтр</param>
        /// <param name="filterSize">Размер, по которому фильтруется каталог</param>
        private static void AskSizeFilter(ref bool filterOn, ref ClothingSize filterSize)
        {
            Array sizes = Enum.GetValues(typeof(ClothingSize));

            Console.WriteLine("\nФильтровать по размеру:");
            for (int i = 0; i < sizes.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ") " + sizes.GetValue(i));
            }
            Console.WriteLine("\t" + (sizes.Length + 1) + ") Показать все размеры");
            Console.Write("Ваш выбор (0 - отмена): ");

            int n;
            if (!int.TryParse(ReadInput(), out n) || n < 0 || n > sizes.Length + 1)
            {
                Console.WriteLine("Неверный пункт меню.");
                Pause();
                return;
            }

            if (n == 0)
            {
                return;
            }
            if (n == sizes.Length + 1)
            {
                filterOn = false;
            }
            else
            {
                filterOn = true;
                filterSize = (ClothingSize)sizes.GetValue(n - 1);
            }
        }

        /// <summary>
        /// Экран истории покупок: показывает купленные товары и позволяет вернуть товар в магазин
        /// </summary>
        private static void ShowHistory()
        {
            while (true)
            {
                ClearScreen();
                PrintHeader("ИСТОРИЯ ПОКУПОК");
                var purchasedList = _logic.GetPurchased();
                PrintTable(purchasedList);

                Console.WriteLine("\n\t[1] Вернуть товар");
                Console.WriteLine("\t[0] Назад");
                Console.Write("\nВаш выбор: ");

                switch (ReadInput())
                {
                    case "1":
                        {
                            if (purchasedList.Count == 0)
                            {
                                Console.WriteLine("Вы еще ничего не купили.");
                                Pause();
                                break;
                            }

                            Clothing item = AskItem("Введите артикул товара для возврата", purchasedList);
                            if (item != null)
                            {
                                _logic.ReturnToStore(item.Id);
                                _balance += item.Price;
                                Console.WriteLine("\nТовар '" + item.Name + "' возвращен! " + item.Price +
                                    " руб. возвращены на баланс. Ваш баланс: " + _balance + " руб.");
                                Pause();
                            }
                            break;
                        }
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
        /// Запрашивает название, категорию, размер и цену товара. На любом шаге можно ввести 0 для отмены
        /// </summary>
        /// <returns>true, если все данные введены; false, если пользователь отменил ввод</returns>
        private static bool ReadClothingData(out string name, out ClothingCategory category, out ClothingSize size, out int price)
        {
            name = null;
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
                    return null;
                }
                if (text.Length == 0)
                {
                    Console.WriteLine("Название вещи не может быть пустым.");
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
                if (text.Length == 0)
                {
                    Console.WriteLine("Цена товара не может быть пустой.");
                    continue;
                }
                int price;
                if (!int.TryParse(text, out price) || price <= 0)
                {
                    Console.WriteLine("Цена товара должна быть только положительным числом.");
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
                    return (T)values.GetValue(n - 1);
                }
                Console.WriteLine("Неверный пункт меню. Попробуйте еще раз.");
            }
        }

        /// <summary>
        /// Просит ввести артикул и находит товар в переданном списке
        /// (аналог выбора строки в таблице WinForms)
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
                    return null;
                }

                int id;
                if (!int.TryParse(text, out id))
                {
                    Console.WriteLine("Неверный ввод, артикул должен быть числом.");
                    continue;
                }

                Clothing item = source.Find(c => c.Id == id);
                if (item == null)
                {
                    Console.WriteLine("Товар с таким артикулом не найден в списке.");
                    continue;
                }
                return item;
            }
        }


        /// <summary>
        /// Выводит заголовок экрана и текущий баланс (в WinForms баланс показан на каждой форме)
        /// </summary>
        /// <param name="title">Название экрана</param>
        private static void PrintHeader(string title)
        {
            Console.WriteLine("--- " + title + " --- | Ваш баланс: " + _balance + " руб.\n");
        }

        /// <summary>
        /// Выводит список одежды таблицей (аналог DataGridView)
        /// </summary>
        /// <param name="list">Список одежды, который нужно вывести</param>
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
                // консоль перенаправлена - очищать нечего
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

