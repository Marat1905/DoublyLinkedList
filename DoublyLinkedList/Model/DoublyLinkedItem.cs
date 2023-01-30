using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoublyLinkedList.Model;
/// <summary> Ячейка двусвязного списка.</summary>
internal class DoublyLinkedItem<T>
{
    #region Поля
    /// <summary>Данные хранимые в ячейке списка</summary>
    private T _data;

    #endregion

    #region Свойства
    /// <summary>Данные хранимые в ячейке списка</summary>
    public T Data
    {
        get { return _data; }
        set 
        {
            if(value == null)          
                throw new ArgumentNullException(nameof(value), "Значение не может быть null. ");           
            _data = value;
        }
    }

    /// <summary>Ссылка на предыдущий элемент списка</summary>
    public DoublyLinkedItem<T> Previous { get; internal set; }
    
    /// <summary>Ссылка на следующий элемент списка</summary>
    public DoublyLinkedItem<T> Next { get; internal set; }

    #endregion

    #region Конструктор
    public DoublyLinkedItem(T data)
    {
        Data = data;
    }
    #endregion

    #region Методы
    /// <summary>Удаление ссылок.</summary>
    public void Nullified()
    {
        Previous = null;
        Next = null;
    }
    public override string ToString() => Data.ToString();

    #endregion



}

