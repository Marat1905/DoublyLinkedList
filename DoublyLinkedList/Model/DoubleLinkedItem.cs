using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Model;
/// <summary> Ячейка двусвязного списка.</summary>

internal class DoubleLinkedItem<T>
{
    #region Свойства
    /// <summary>Данные хранимые в ячейке списка</summary>
    public T Data { get; set; }

    /// <summary>Ссылка на предыдущий элемент списка</summary>
    public DoubleLinkedItem<T> Previous { get; set; }

    /// <summary>Ссылка на следующий элемент списка</summary>
    public DoubleLinkedItem<T> Next { get; set; }
    #endregion

    #region Конструктор
    public DoubleLinkedItem(T data)
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

