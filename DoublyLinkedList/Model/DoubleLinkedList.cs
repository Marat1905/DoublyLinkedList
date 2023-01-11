using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Model
{
    /// <summary>Двусвязный список.</summary>
    internal class DoubleLinkedList<T>
    {
        #region Свойства
        /// <summary>Ссылка на первый элемент.</summary>
        public DoubleLinkedItem<T> Head { get; set; }

        /// <summary>Ссылка на последний элемент.</summary>
        public DoubleLinkedItem<T> Tail { get; set; }

        /// <summary>Количество элементов в списке. </summary>
        public int Count { get; set; }
        #endregion

        #region Конструкторы
        public DoubleLinkedList() { }


        #endregion

        #region Методы
        /// <summary>Добавить данные в конец списка.</summary>
        /// <param name="data">Элемент.</param>
        public void Add(T data) 
        {
            var item = new DoubleLinkedItem<T>(data);

        }

        /// <summary>Очистка списка. </summary>
        public void Clear() { }

        /// <summary>Удалить первое вхождение в список. </summary>
        /// <param name="data">Элемент.</param>
        public void Remove() { }    

        #endregion
    }
}
