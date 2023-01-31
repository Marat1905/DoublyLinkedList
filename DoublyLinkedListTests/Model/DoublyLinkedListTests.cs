using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Model.Tests
{
    [TestClass()]
    public class DoublyLinkedListTests
    {
        List<string> list = new List<string>();

        [TestInitialize]
        public void Init()
        {
            list.Clear();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.Add("f");
        }

        //[TestMethod()]
        //public void DoublyLinkedListTest()
        //{



        //    //Arrange
        //    // Act
        //    //Assert
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void FindTest()
        {
            //Arrange
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
            DoublyLinkedItem<string> Item = new DoublyLinkedItem<string>(doublyLinkedList, "d");
            // Act
            doublyLinkedList.InsertEnd("a");
            doublyLinkedList.InsertEnd("b");
            doublyLinkedList.InsertEnd("c");
            doublyLinkedList.InsertEnd("d");
            //Assert
            var find = doublyLinkedList.Find("d");
            Assert.AreEqual(find.ToString(), Item.ToString());
        }

        [TestMethod()]
        public void InsertEndTest()
        {
            //Arrange
            DoublyLinkedList<string> doublyLinkedList=new DoublyLinkedList<string>();
            // Act
            doublyLinkedList.InsertEnd("a");
            doublyLinkedList.InsertEnd("b");
            doublyLinkedList.InsertEnd("c");
            doublyLinkedList.InsertEnd("d");
            doublyLinkedList.InsertEnd("e");
            doublyLinkedList.InsertEnd("f");
            //Assert
            int i = 0;
            foreach (var item in doublyLinkedList) 
            {
                var f = item.ToString();
                var g = list[i].ToString();
                Assert.AreEqual(item.ToString(), list[i].ToString());
                i++;
            }
        }



        [TestMethod()]
        public void InsertBeginTest()
        {
            //Arrange
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
            // Act
            doublyLinkedList.InsertBegin("f");
            doublyLinkedList.InsertBegin("e");
            doublyLinkedList.InsertBegin("d");
            doublyLinkedList.InsertBegin("c");
            doublyLinkedList.InsertBegin("b");
            doublyLinkedList.InsertBegin("a");
            //Assert
            int i = 0;
            foreach (var item in doublyLinkedList)
            {
                var f = item.ToString();
                var g = list[i].ToString();
                Assert.AreEqual(item.ToString(), list[i].ToString());
                i++;
            }
        }

        [TestMethod()]
        public void InsertAfterTest()
        {
            //Arrange
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string> ();
            DoublyLinkedItem<string> target = new DoublyLinkedItem<string>(doublyLinkedList, "b");
            DoublyLinkedItem<string> target1 = new DoublyLinkedItem<string>(doublyLinkedList, "c");
            DoublyLinkedItem<string> item = new DoublyLinkedItem<string>("d");
            // Act
            doublyLinkedList.InsertEnd("a");
            doublyLinkedList.InsertEnd("b");
            doublyLinkedList.InsertEnd("e");
            doublyLinkedList.InsertEnd("f");

            doublyLinkedList.InsertAfter(target, "c");
            doublyLinkedList.InsertAfter(target1,item );

            //Assert
            int i = 0;
            foreach (var data in doublyLinkedList)
            {
                var f = data.ToString();
                var g = list[i].ToString();
                Assert.AreEqual(data.ToString(), list[i].ToString());
                i++;
            }
        }


        [TestMethod()]
        public void RemoveTest()
        {
            //Arrange
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
            // Act
            doublyLinkedList.InsertEnd("a");
            doublyLinkedList.InsertEnd("b");
            doublyLinkedList.InsertEnd("c");
            doublyLinkedList.InsertEnd("d");
            doublyLinkedList.InsertEnd("e");
            doublyLinkedList.InsertEnd("f");

            doublyLinkedList.Remove("c");
            list.Remove("c");
            //Assert
            int i = 0;
            foreach (var data in doublyLinkedList)
            {
                var f = data.ToString();
                var g = list[i].ToString();
                Assert.AreEqual(data.ToString(), list[i].ToString());
                i++;
            }
        }


    }
}