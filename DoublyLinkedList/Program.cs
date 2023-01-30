// See https://aka.ms/new-console-template for more information

using DoublyLinkedList.Model;


DoublyLinkedList<int> dblLinkedList = new();
DoublyLinkedItem<int> node10 = new DoublyLinkedItem<int>(11);
dblLinkedList.InsertBegin(6);
dblLinkedList.InsertBegin(7);
dblLinkedList.InsertBegin(8);
dblLinkedList.InsertBegin(9);
dblLinkedList.InsertBegin(10);
dblLinkedList.InsertBegin(node10);

Print(dblLinkedList);


dblLinkedList.Clear();

Console.ReadLine();


DoublyLinkedItem<int> node = new DoublyLinkedItem<int>(4);
DoublyLinkedItem<int> node1 = new DoublyLinkedItem<int>(11);
dblLinkedList.InsertEnd(1);
dblLinkedList.InsertEnd(2);
dblLinkedList.InsertEnd(3);
dblLinkedList.InsertEnd(4);
dblLinkedList.InsertEnd(6);
dblLinkedList.InsertEnd(7);
dblLinkedList.InsertEnd(8);
dblLinkedList.InsertEnd(9);
dblLinkedList.InsertEnd(10);
dblLinkedList.InsertEnd(node1);
dblLinkedList.InsertAfter(node1, 12);
//dblLinkedList.InsertAfter(node, 5);
//dblLinkedList.InsertAfter(new DoublyLinkedItem<int>(1), 0);


//var t= dblLinkedList.Find(11);

//DoublyLinkedList<int> dblLinkedList1 = new();
//dblLinkedList1.InsertEnd(1);
//dblLinkedList1.InsertEnd(2);
//dblLinkedList1.InsertEnd(t);

//Print(dblLinkedList1);


Print(dblLinkedList);


Console.ReadLine();

dblLinkedList.Remove(1);    // Удаляем в начале списка

dblLinkedList.Remove(5);    // Удаляем в середине списка

dblLinkedList.Remove(10);   // Удаляем в конце списка


Print(dblLinkedList);

Console.ReadLine();

static void Print(DoublyLinkedList<int> dblLinkedList)
{
    Console.WriteLine();
    foreach (DoublyLinkedItem<int> item in dblLinkedList)
    {
        Console.WriteLine($"Значение:{item}; предыдущий: {item.Previous?.ToString() ?? "нет"}; следующий: {item.Next?.ToString() ?? "нет"};");
    }
}