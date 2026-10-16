using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Определяет базовый интерфейс для всех доменных объектов (сущностей), имеющих уникальный идентификатор.
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор объекта.
        /// </summary>
        int Id { get; set; }
    }
}
