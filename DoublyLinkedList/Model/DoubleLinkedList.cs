using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Model
{
    /// <summary>Двусвязный список.</summary>
    internal class DoubleLinkedList<T>:IEnumerable<T>
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
        /// <summary>Двусвязный список.</summary>
        public DoubleLinkedList() { }

        /// <summary>Двусвязный список.</summary>
        /// <param name="data"></param>
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
                SetHeadItem(data);          
            else
            {
                var item = new DoubleLinkedItem<T>(data);  // Создаем ячейку.
                Head.Previous = item;                      // У первого элемента меняем предыдущую ссылку на созданный элемент.
                item.Next = Head;                          // У созданной ячейки меняем ссылку следующего элемента на первый элемент.
                Head = item;                               //и делаем первым элементом созданную ячейку.
                Count++;
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
                   var item= new DoubleLinkedItem<T>(data);     // Создаем ячейку.
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
                    Count++;
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
            Count= 0;
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
                    Count--;
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
            
            var item = new DoubleLinkedItem<T>(data);   // Создаем ячейку.
            Head = item;
            Tail = item;
            Count = 1;
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
