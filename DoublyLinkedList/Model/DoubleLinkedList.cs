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

        public DoubleLinkedList(T data) => SetHeadItem(data);    


        #endregion

        #region Методы
        /// <summary>Добавить данные в конец списка.</summary>
        /// <param name="data">Элемент.</param>
        public void InsertEnd(T data) 
        {
            if (Count == 0)
            {
                SetHeadItem(data);
            }
            else
            {
                var item = new DoubleLinkedItem<T>(data);  // Создаем ячейку.
                Tail.Next = item; // У последнего элемента меняем ссылку на созданный элемент.
                item.Previous = Tail; // У созданной ячейки меняем ссылку на предыдущий элемент.
                Tail = item; //и меняем ссылку на последний элемент на созданную ячейку
                Count++;
            }
        }

        /// <summary>Добавить данные в начало списка.</summary>
        /// <param name="data">Элемент.</param>
        public void InsertBegin(T data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
            }
            else
            {
                var item = new DoubleLinkedItem<T>(data);  // Создаем ячейку.
                Head.Previous = item; // У последнего элемента меняем ссылку на созданный элемент.
                item.Next = Head; // У созданной ячейки меняем ссылку на предыдущий элемент.
                Head = item; //и меняем ссылку на последний элемент на созданную ячейку
                Count++;
            }
        }

        /// <summary>Очистка списка. </summary>
        public void Clear() { }

        /// <summary>Удалить первое вхождение в список. </summary>
        /// <param name="data">Элемент.</param>
        public void Remove() { }

        /// <summary>Установка заголовка.</summary>
        /// <param name="data">Элемент.</param>
        private void SetHeadItem(T data)
        {
            
            var item = new DoubleLinkedItem<T>(data);   // Создаем ячейку.
            Head = item;
            Tail = item;
            Count = 1;
        }
        #endregion
    }
}
