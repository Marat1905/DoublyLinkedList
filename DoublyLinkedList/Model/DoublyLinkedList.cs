
using System;
using System.Collections;

namespace DoublyLinkedList.Model
{
    /// <summary>Двусвязный список.</summary>
    public class DoublyLinkedList<T>:IEnumerable<T>
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
        //public DoublyLinkedList(T data) => SetHeadItem(data);    


        #endregion

        #region Методы

        /// <summary>Поиск элемента.</summary>
        /// <param name="data">Элемент.</param>
        public DoublyLinkedItem<T> Find(T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                   return current;
                }
                else
                {
                    current = current.Next;
                }
            }
            return null;
        }


        /// <summary>Добавить данные в конец списка.</summary>
        /// <param name="data">Элемент.</param>
        public DoublyLinkedItem<T> InsertEnd(T data) 
        {    
            DoublyLinkedItem<T> result = new DoublyLinkedItem<T>(this,data);         // Создаем ячейку.
            if (_head == null)
                SetHeadItem(result);
            else
                InsertNodeEnd(result);
            return result;
        }

        /// <summary>Добавить данные в конец списка.</summary>
        /// <param name="data">Элемент.</param>
        public void InsertEnd(DoublyLinkedItem<T> data)
        {
            ValidateNewItem(data);

            if (_head == null)
                SetHeadItem(data);
            else
                InsertNodeEnd(data);

            data.List = this;
        }
        /// <summary>Добавить данные в начало списка.</summary>
        /// <param name = "data" > Элемент.</ param >
        public DoublyLinkedItem<T> InsertBegin(T data)
        {
            DoublyLinkedItem<T> result = new DoublyLinkedItem<T>(this,data);     // Создаем ячейку.
            if (_head == null)
                SetHeadItem(result);
            else
                InsertNodeBegin(result);
            return result;
        }

        /// <summary>Добавить данные в начало списка.</summary>
        /// <param name="data">Элемент.</param>
        public void InsertBegin(DoublyLinkedItem<T> data)
        {
            ValidateNewItem(data);

            if (_head == null)
                SetHeadItem(data);
            else
                InsertNodeBegin(data);
            data.List = this;
        }
        /// <summary>Вставить данные после искомого элемента.</summary>
        /// <param name="target">После какого значения вставить.</param>
        /// <param name="data">Элемент вставки.</param>
        public DoublyLinkedItem<T> InsertAfter(DoublyLinkedItem<T> target,T data)
        {
            ValidateItem(target);          
            var result = new DoublyLinkedItem<T>(this, data);         // Создаем ячейку.

            InsertNodeAfter(target, result);
            return result;
        }



        /// <summary>Вставить данные после искомого элемента.</summary>
        /// <param name="target">После какого значения вставить.</param>
        /// <param name="data">Элемент</param>
        /// <returns></returns>
        public DoublyLinkedItem<T> InsertAfter(DoublyLinkedItem<T> target, DoublyLinkedItem<T> data)
        {
            ValidateItem(target);
            ValidateNewItem(data);
            InsertNodeAfter(target, data);
            return data;
        }

        /// <summary>Очистка списка. </summary>
        public void Clear() 
        {
            _tail = null;
            _head = null; 
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
                        _head = current.Next;
                    }   
                    if(current.Next!=null) // Если это не конец списка.
                         current.Next.Previous =current.Previous;
                    else
                    {
                        _tail = current.Previous;
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
        /// <summary>Проверка элемента принадлежит списку </summary>
        /// <param name="data">Элемент.</param>
        /// <exception cref="Exception"></exception>
        internal void ValidateItem(DoublyLinkedItem<T> data)
        {
            if (this != data.List)
            {
                // TODO: Надо будет подобрать исключение
                throw new Exception("Производится вставка элемента не из этого списка");
            }
        }
        /// <summary>Проверка что элемент не принадлежит списку </summary>
        /// <param name="data">Элемент.</param>
        /// <exception cref="Exception"></exception>
        internal void ValidateNewItem(DoublyLinkedItem<T> data)
        {
            if (data.List != null)
            {
                // TODO: Надо будет подобрать исключение
                throw new Exception("Производится вставка не пустого элемента.");
            }
        }

        /// <summary>Установка заголовка.</summary>
        /// <param name="data">Элемент.</param>
        private void SetHeadItem(DoublyLinkedItem<T> data)
        {
            _head = data;
            _tail= data;
            _count ++;
        }
        /// <summary>Метод добавления в конец списка.</summary>
        private void InsertNodeEnd(DoublyLinkedItem<T> result)
        {
            Tail.Next = result;                        // У последнего элемента меняем ссылку на созданный элемент.
            result.Previous = Tail;                    // У созданной ячейки меняем ссылку на предыдущий элемент.
            _tail = result;                             //и меняем ссылку на последний элемент на созданную ячейку
            _count++;
        }
        /// <summary>Метод добавления в начало списка.</summary>
        private void InsertNodeBegin(DoublyLinkedItem<T> result)
        {
            Head.Previous = result;                      // У первого элемента меняем предыдущую ссылку на созданный элемент.
            result.Next = Head;                          // У созданной ячейки меняем ссылку следующего элемента на первый элемент.
            _head = result;                               //и делаем первым элементом созданную ячейку.
            _count++;
        }
        /// <summary>Вставить данные после искомого элемента </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        private void InsertNodeAfter(DoublyLinkedItem<T> target, DoublyLinkedItem<T> data)
        {
            var current = Head;
            while (current != null)
            {
                if (Equals(current.Data, target.Data))
                {
                    data.Next = current.Next;                   // Созданной ячейке присваиваем ссылку на следующий элемент
                    data.Previous = current;                    // Созданной ячейке присваиваем ссылку на предыдущий элемент
                    if (current.Next != null)                    //
                    {
                        current.Next.Previous = data;           // У следующего элемента предыдущую ссылку на созданный элемент
                    }
                    else
                    {
                        _tail = data;                            // Указываем что это конец
                    }
                    current.Next = data;                        // у текущего элемента следующий ссылку меняем на созданный элемент
                    _count++;
                    break;

                }
                else
                {
                    current = current.Next;
                }
            }
        }

        // <summary>Получение перечисления всех элементов двусвязного списка. </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current!=null)
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
