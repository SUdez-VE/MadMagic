using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMadMagic.Models
{
    public class Spell
    {
        /// <summary>
        /// ID Объекта логики заклинания в DB/Redis
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// Название логики заклинания? (Опционально)
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Строка части логики, происходящей при сотворении заклинания
        /// </summary>
        public string? OnCast { get; set; }
        /// <summary>
        /// Логика передвижения снаряда (если есть) или определения попадания
        /// </summary>
        public string? MoveLogic { get; set; }
        /// <summary>
        /// Логика, происходящая при каждом сдвиге снаряда (если есть)
        /// </summary>
        public string? OnMove { get; set; }
        /// <summary>
        /// Логика при попадании
        /// </summary>
        public string? OnHit { get; set; }
        /// <summary>
        /// Скорость снаряда (-1 = Instant, 0 = Стоит на месте)
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Количество отскоков снаряда от стен/объектов (если есть)
        /// </summary>
        public int Bounce { get; set; }
        /// <summary>
        /// Размер снаряда в клетках (если есть)
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Количество зарядов снаряда (уменьшаются при ударе или другой логике)
        /// </summary>
        public int Charges { get; set; }
        /// <summary>
        /// true или false значение, определяющее, видим ли снаряд объекта изначально.
        /// </summary>
        public string? Visible { get; set; }
        /// <summary>
        /// Строка типа заклинания
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// Путь к изображения снаряда заклинания (если есть)
        /// </summary>
        public string? PathToImage { get; set; }
    }
}