using DataStructure;
using NUnit.Framework;
using System;
using System.Linq;


namespace ArrayListTest
{
    public class TestsArrayList
    {
        
        int[] arrayMock;
        //int[] expMock;
        void SetMock(int n)
        {
            switch (n)
            {
                case 1:
                    arrayMock = new int[] { 1, 2, 4, 6, 3 };
                    break;
                case 2:
                    arrayMock = new int[] { 3, 0 , 4, 2 };
                    break;
                case 3:
                    arrayMock = new int[] { 12, 43 };
                    break;
                case 4:
                    arrayMock = new int[] { 1, 3, 6, 3, 12, 13, 23 };
                    break;
                default:
                    break;
            }
        }

        //void expectedMock(int m)
        //{
        //    switch (m)
        //    {
        //        case 1:
        //            expMock = new int[] { 1, 2, 4, 6, 3 };
        //            break;
        //        case 2:
        //            expMock = new int[] { 3, 0, 4, 2 };
        //            break;
        //        case 3:
        //            expMock = new int[] { 12, 43 };
        //            break;
        //        case 4:
        //            expMock = new int[] { 1, 3, 6, 3, 12, 13, 23 };
        //            break;
        //        default:
        //            break;
        //    }
        //}



        [TestCase (1, new int[] { 1, 2, 4, 6, 3 })]
        [TestCase (2, new int[] { 3, 0, 4, 2 })]

        public void ArrayListTest(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected =  new ArrayList(expArr);
            
            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 2, new int[] { 1, 2, 4, 6, 3, 2 })]
        [TestCase(2, 7, new int[] { 1, 2, 7 })]

        public void AddTest(int n, int number, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.Add(number);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 3, new int[] { 3, 1, 2, 4, 6, 3 })]
        [TestCase(3, 5, new int[] { 5, 12, 43 })]

        public void AddStartTest(int n, int number, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.AddStart(number);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 3, 17, new int[] { 1, 2, 4, 17, 6, 3 })]
        [TestCase(2, 0, 2, new int[] { 2, 3, 0, 4, 2 })]

        public void AddItemByIndexTest(int n, int index, int value, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.AddItemByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, new int[] { 1, 2, 4, 6 })]
        [TestCase(2, new int[] { 3, 0, 4 })]
        [TestCase(3, new int[] { 12 })]

        public void RemoveFromEndTest(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.RemoveFromEnd();

            Assert.AreEqual(expected, actual);
        }






    }
    
}