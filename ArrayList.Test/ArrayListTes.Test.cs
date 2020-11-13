using DataStructure;
using NUnit.Framework;
using System;


namespace ArrayListTest.Test
{ 
    public class TestsArrayList
    {

        int[] arrayMock;

        void SetMock(int n)
        {
            switch (n)
            {
                case 1:
                    arrayMock = new int[] { 1, 2, 4, 6, 3 };
                    break;
                case 2:
                    arrayMock = new int[] { 3, 0, 4, 2 };
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



        [TestCase(1, new int[] { 1, 2, 4, 6, 3 })]
        [TestCase(2, new int[] { 3, 0, 4, 2 })]

        public void ArrayListTest(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 2, new int[] { 1, 2, 4, 6, 3, 2 })]
        [TestCase(2, 7, new int[] { 3, 0, 4, 2, 7 })]

        public void AddTest(int n, int number, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.Add(number);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 3, new int[] { 3, 1, 2, 4, 6, 3 })]
        [TestCase(2, 5, new int[] { 5, 3, 0, 4, 2 })]

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




        [TestCase(1, new int[] { 2, 4, 6, 3 })]
        [TestCase(2, new int[] { 0, 4, 2 })]
        [TestCase(4, new int[] { 3, 6, 3, 12, 13, 23 })]

        public void RemoveFromStart(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.RemoveFromStart();

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 1, new int[] { 1, 4, 6, 3 })]
        [TestCase(2, 2, new int[] { 3, 0, 2 })]
        [TestCase(4, 0, new int[] { 3, 6, 3, 12, 13, 23 })]

        public void RemoveFromIndexItem(int n, int index, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.RemoveFromIndexItem(index);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 1, 2)]
        [TestCase(2, 2, 4)]
        [TestCase(4, 0, 1)]

        public void AccessByIndex(int n, int i, int expectedNumber)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            int expected = expectedNumber;
            int result = actual[i];

            Assert.AreEqual(expected, result);
        }



        [TestCase(1, new int[] { 3, 6, 4, 2, 1 })]
        [TestCase(2, new int[] { 2, 4, 0, 3 })]
        [TestCase(4, new int[] { 23, 13, 12, 3, 6, 3, 1 })]

        public void Reverse(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 1)]
        [TestCase(2, 0)]

        public void GetMinItem(int n, int expMin)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            int expected = expMin;
            int result = actual.GetMinItem();

            Assert.AreEqual(expected, result);
        }




        [TestCase(1, 6)]
        [TestCase(2, 4)]

        public void GetMaxItem(int n, int expMax)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            int expected = expMax;
            int result = actual.GetMaxItem();

            Assert.AreEqual(expected, result);
        }




        [TestCase(1, 3)]
        [TestCase(2, 2)]

        public void GetMaxIndexTest(int n, int expMaxIndex)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            int expected = expMaxIndex;
            int result = actual.GetMaxIndex();

            Assert.AreEqual(expected, result);
        }




        [TestCase(1, 0)]
        [TestCase(2, 1)]

        public void GetMinIndexTest(int n, int expMinIndex)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            int expected = expMinIndex;
            int result = actual.GetMinIndex();

            Assert.AreEqual(expected, result);
        }



        [TestCase(1, new int[] { 1, 2, 3, 4, 6 })]
        [TestCase(2, new int[] { 0, 2, 3, 4 })]
        [TestCase(4, new int[] { 1, 3, 3, 6, 12, 13, 23 })]

        public void SortLayout(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.SortLayout();

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, new int[] { 6, 4, 3, 2, 1 })]
        [TestCase(2, new int[] { 4, 3, 2, 0 })]
        [TestCase(4, new int[] { 23, 13, 12, 6, 3, 3, 1 })]

        public void SortDescending(int n, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.SortDescending();

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, new int[] { 12, 2 }, new int[] { 12, 2, 1, 2, 4, 6, 3 })]
        [TestCase(2, new int[] { 1, 4 }, new int[] { 1, 4, 3, 0, 4, 2 })]
        [TestCase(4, new int[] { 23, 13 }, new int[] { 23, 13, 1, 3, 6, 3, 12, 13, 23 })]

        public void AddArrayStart(int n, int[] array, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.AddArrayStart(array);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, new int[] { 12, 2 }, new int[] { 1, 2, 4, 6, 3, 12, 2 })]
        [TestCase(2, new int[] { 1, 4 }, new int[] { 3, 0, 4, 2, 1, 4 })]
        [TestCase(4, new int[] { 23, 13 }, new int[] { 1, 3, 6, 3, 12, 13, 23, 23, 13 })]

        public void AddArrayEnd(int n, int[] array, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.AddArrayEnd(array);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, new int[] { 12, 2 }, 1, new int[] { 1, 12, 2, 2, 4, 6, 3 })]
        [TestCase(2, new int[] { 1, 4 }, 0, new int[] { 1, 4, 3, 0, 4, 2 })]
        [TestCase(4, new int[] { 23, 13 }, 4, new int[] { 1, 3, 6, 3, 23, 13, 12, 13, 23 })]

        public void AddArrayByIndex(int n, int[] array, int index, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.AddArrayByIndex(array, index);

            Assert.AreEqual(expected, actual);
        }





        [TestCase(1, 2, new int[] { 1, 2, 4 })]
        [TestCase(4, 3, new int[] { 1, 3, 6, 3})]

        public void RemoveEndItems(int n, int quantity, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.RemoveEndItems(quantity);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 2, new int[] { 4, 6, 3 })]
        [TestCase(2, 1, new int[] { 0, 4, 2 })]

        public void RemoveSrartItems(int n, int quantity, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.RemoveSrartItems(quantity);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(1, 2, 2, new int[] { 1, 2, 3 })]
        [TestCase(2, 1, 1, new int[] { 3, 4, 2 })]

        public void RemoveFromIndexItems(int n, int index, int quantity, int[] expArr)
        {
            SetMock(n);
            ArrayList actual = new ArrayList(arrayMock);
            ArrayList expected = new ArrayList(expArr);
            actual.RemoveFromIndexItems(index, quantity);

            Assert.AreEqual(expected, actual);
        }

        //NegativeTests:

        [TestCase(new int[] { })]

        public void ArrayListNegative(int[] array)
        {
            try
            {
                ArrayList actual = new ArrayList(array);
            }
            catch
            {
                Assert.Pass();
            }

        }





        [TestCase(1, -2, 3)]
        [TestCase(2, 12, 2)]

        public void AddItemByIndexNegative(int index, int n, int value)
        {
            try
            {
                SetMock(n);
                ArrayList actual = new ArrayList(arrayMock);
                actual.AddItemByIndex(index, value);
            }
            catch
            {
                Assert.Pass();
            }

        }




        [TestCase(1, -2)]
        [TestCase(2, 12)]

        public void AccessByIndexNegative(int n, int i)
        {
            try
            {
                SetMock(n);
                ArrayList actual = new ArrayList(arrayMock);
                actual.AccessByIndex(i);
            }
            catch
            {
                Assert.Pass();
            }

        }




        [TestCase(1, new int[] { 1, 2, 3 }, -2)]
        [TestCase(2, new int[] { 1, 2, 23, 5, 3 }, 12)]

        public void AddArrayByIndexNegative(int n, int[] array, int i)
        {
            try
            {
                SetMock(n);
                ArrayList actual = new ArrayList(arrayMock);
                actual.AddArrayByIndex(array, i);
            }
            catch
            {
                Assert.Pass();
            }

        }


        [TestCase(1, -2)]
        [TestCase(2, 12)]

        public void RemoveEndItemsNegative(int n, int quantity)
        {
            try
            {
                SetMock(n);
                ArrayList actual = new ArrayList(arrayMock);
                actual.RemoveEndItems(quantity);
            }
            catch
            {
                Assert.Pass();
            }
        }




        [TestCase(1, 17)]
        [TestCase(2, 12)]

        public void RemoveSrartItemsNegative(int n, int quantity)
        {
            try
            {
                SetMock(n);
                ArrayList actual = new ArrayList(arrayMock);
                actual.RemoveSrartItems(quantity);
            }
            catch
            {
                Assert.Pass();
            }
        }




        [TestCase(1, -1, 17)]
        [TestCase(2, 15, 12)]

        public void RemoveFromIndexItemsNegative(int n, int index, int quantity)
        {
            try
            {
                SetMock(n);
                ArrayList actual = new ArrayList(arrayMock);
                actual.RemoveFromIndexItems(quantity);
            }
            catch
            {
                Assert.Pass();
            }
        }
    }
}
    
