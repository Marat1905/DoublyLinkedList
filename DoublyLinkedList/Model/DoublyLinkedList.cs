﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Model
{
    /// <summary>Двусвязный список.</summary>
    internal class DoublyLinkedList<T>:IEnumerable<T>
    {
        #region Поля
        /// <summary>Количество элементов в списке. </summary>
        private int _count;
        /// <summary>Ссылка на первый элемент.</summary>
        private DoublyLinkedItem<T> _head;
        /// <summary>Ссылка на последний элемент.</summary>
        private DoublyLinkedItem<T> _tail;
        #endregion

        #region Свойства

        /// <summary>Ссылка на первый элемент.</summary>
        public DoublyLinkedItem<T> Head=> _head;

        /// <summary>Ссылка на последний элемент.</summary>
        public DoublyLinkedItem<T> Tail=> _tail;

        /// <summary>Количество элементов в списке. </summary>
        public int Count => _count;
        #endregion

        #region Конструкторы
        /// <summary>Двусвязный список.</summary>
        public DoublyLinkedList() { }

        /// <summary>Двусвязный список.</summary>
        /// <param name="data"></param>
        public DoublyLinkedList(T data) => SetHeadItem(data);    


        #endregion

        #region Методы
        /// <summary>Добавить данные в конец списка.</summary>
        /// <param name="data">Элемент.</param>
        public void InsertEnd(T data) 
        {
            if (_count == 0)
            {
                SetHeadItem(data);
            }
            else
            {
                var item = new DoublyLinkedItem<T>(data);  // Создаем ячейку.
                Tail.Next = item; // У последнего элемента меняем ссылку на созданный элемент.
                item.Previous = Tail; // У созданной ячейки меняем ссылку на предыдущий элемент.
                Tail = item; //и меняем ссылку на последний элемент на созданную ячейку
                _count++;
            }
        }

        /// <summary>Добавить данные в начало списка.</summary>
        /// <param name="data">Элемент.</param>
        public void InsertBegin(T data)
        {
            if (Count == 0) 
                SetHeadItem(data);          
            else
            {
                var item = new DoublyLinkedItem<T>(data);  // Создаем ячейку.
                Head.Previous = item;                      // У первого элемента меняем предыдущую ссылку на созданный элемент.
                item.Next = Head;                          // У созданной ячейки меняем ссылку следующего элемента на первый элемент.
                Head = item;                               //и делаем первым элементом созданную ячейку.
                _count++;
            }
        }

        /// <summary>Вставить данные после искомого элемента.</summary>
        /// <param name="target">После какого значения вставить.</param>
        /// <param name="data">Элемент вставки.</param>
        public void InsertAfter(T target,T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(target))
                {
                   var item= new DoublyLinkedItem<T>(data);     // Создаем ячейку.
                    item.Next = current.Next;                   // Созданной ячейке присваиваем ссылку на следующий элемент
                    item.Previous= current;                     // Созданной ячейке присваиваем ссылку на предыдущий элемент
                    if(current.Next != null)                    //
                    {
                        current.Next.Previous = item;           // У следующего элемента предыдущую ссылку на созданный элемент
                    }
                    else
                    {
                        Tail = item;                            // Указываем что это конец
                    }
                    current.Next = item;                        // у текущего элемента следующий ссылку меняем на созданный элемент
                    _count++;
                    return;

                }
                else
                {
                    current = current.Next;
                }
            }
        }

        /// <summary>Очистка списка. </summary>
        public void Clear() 
        {
            Tail = null;
            Head= null; 
            _count = 0;
        }

        /// <summary>Удалить первое вхождение в список. </summary>
        /// <param name="data">Элемент.</param>
        public void Remove(T data) 
        {
            var current = Head;
            while (current!=null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null) // Если это не начало списка.
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }   
                    if(current.Next!=null) // Если это не конец списка.
                         current.Next.Previous=current.Previous;
                    else
                    {
                        Tail = current.Previous;
                        Tail.Next = null;
                    }
                    
                    current=null;
                    _count--;
                    return;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        /// <summary>Установка заголовка.</summary>
        /// <param name="data">Элемент.</param>
        private void SetHeadItem(T data)
        {
            
            var item = new DoublyLinkedItem<T>(data);   // Создаем ячейку.
            Head = item;
            Tail = item;
            _count = 1;
        }
        // <summary>Получение перечисления всех элементов двусвязного списка. </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {

            var current = Head;
            for (int i = 0; i < Count; i++)
            {
                yield return current;
                current = current.Next;
            }

        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }


        #endregion
    }
}
