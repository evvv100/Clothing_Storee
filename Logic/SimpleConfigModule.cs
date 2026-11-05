using DataAccessLayer;
using Model;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Конфигурация механизма внедрения зависимостей, связывает абстракции с их реальными реализациями в коде
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        /// <summary>
        /// Регистрация настроек создания объектов в контейнере зависимостей
        /// </summary>
        public override void Load()
        {
            Bind<IClothingCommand, IClothingQuery, IClothingFilter>()
            .To<Logic>()
            .InSingletonScope();

            Bind<IRepository<Clothing>>().To<EntityRepository<Clothing>>().InSingletonScope();
        }
    }
}
