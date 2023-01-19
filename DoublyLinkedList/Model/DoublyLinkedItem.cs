using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Model;
/// <summary> Ячейка двусвязного списка.</summary>
internal class DoublyLinkedItem<T>
{
    #region Поля
    /// <summary>Данные хранимые в ячейке списка</summary>
    private T _data;
    /// <summary>Ссылка на предыдущий элемент списка</summary>
    private DoublyLinkedItem<T> _previous;
    /// <summary>Ссылка на следующий элемент списка</summary>
    private DoublyLinkedItem<T> _next;
    #endregion

    #region Свойства
    /// <summary>Данные хранимые в ячейке списка</summary>
    public T Data
    {
        get { return _data; }
        set { _data = value; }
    }

    /// <summary>Ссылка на предыдущий элемент списка</summary>
    public DoublyLinkedItem<T> Previous
    {
        get { return _previous; }
        //set { _previous = value; }
    }
    
    /// <summary>Ссылка на следующий элемент списка</summary>
    public DoublyLinkedItem<T> Next
    {
        get { return _next; }
        //set { _next = value; }
    }

    #endregion

    #region Конструктор
    public DoublyLinkedItem(T data)
    {
        if(data == null) throw new ArgumentNullException(nameof(data), "Значение не может быть null. ");
        if(data is T result)
        {
            Data = result;
        }
        else
        {
            throw new ArgumentException(nameof(data), "Преобразование не допустимо. ");
        }
       
    }
    #endregion

    #region Методы
    public override string ToString() => Data.ToString();
    #endregion



}

