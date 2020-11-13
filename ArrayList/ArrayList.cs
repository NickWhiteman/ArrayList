using System;
using System.Linq;

namespace DataStructure
{
    public class ArrayList
    {
        //Длина 
        public int Length { get; private set; }

        private int[] _array;
        private double _NumberLayoutPlace = 1.33d;

        //Перегрузка индекса
        public int this[int i]
        {
            get
            {
                if (i > Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
        }

        //Конструктор
        public ArrayList()
        {
            _array = new int[3];
            Length = 0;
        }

        public ArrayList(int[] array)
        {
            if(array.Length == 0)
            {
                throw new Exception("Your array is empty enter values");
            }
            else
            {
                _array = new int[array.Length];
                Length = array.Length;
                Array.Copy(array, _array, array.Length);
            }
        }

        public ArrayList(int i)
        {
            _array = new int[i];
            Length = 0;
        }

        //Добавление элемента в конец 
        public void Add(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }
            AddItemByIndex(Length, value);
        }

        //Переформирование метода Assert.Equals для тестов
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Добавляем элемент в начале списака
        public void AddStart(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }

            AddItemByIndex(0, value);
        }

        //Добавление значения по индексу
        public void AddItemByIndex(int index, int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }

            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index == Length)
                {
                    _array[index] = value;
                    Length++;
                }
                else
                {
                    Length++;
                    DisplacementRight(index);
                    _array[index] = value;
                }

            }
        }

        //Получить длину списка
        public int GetLength()
        {
            int count = 0;
            for (int i = 0; i < Length; i++)
            {
                count++;
            }
            return count;
        }

        //Удаление c конца однин элемент
        public void RemoveFromEnd()
        {
            if (_array.Length / 2  >= Length)
            {
                DecreaseLength();
            }
            Length--;
        }

        //Удаление из начала одного массива
        public void RemoveFromStart()
        {

            RemoveFromIndexItem(0);
            if (_array.Length / 2 >= Length)
            {
                DecreaseLength();
            }
        }

        //Удаление по индексу элемента 
        public void RemoveFromIndexItem(int index)
        {
            if(index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {


                if (index == Length - 1)
                {
                    Length--;
                }
                else
                {
                    DisplacementLeft(index);
                    Length--;
                }


                if (_array.Length / 2 >= Length)
                {
                    DecreaseLength();
                }
            }
            
        }

        public void RemoveFromItem(int item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == item)
                {
                    RemoveFromIndexItem(i);
                    DisplacementLeft(i);
                    Length--;
                }
            }
        }

        //Доступ по индексу
        public int AccessByIndex(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int Access = _array[index];
                for (int i = 0; i < _array.Length; i++)
                {
                    if (Access == _array[i])
                        Access = _array[i];
                }
                return Access;
            }
        }

        //Доступ по значению
        public int AccessByValue(int value)
        {
            int returnArr = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (value == _array[i])
                {
                    returnArr = _array.Length;
                }
            }
            return returnArr;
            
        }

        //Реверс
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int item = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = item;
            }
        }

        //Поиск значения максимального элемента
        public int GetMaxItem()
        {
            int maxIndex = 0;
            int max = _array[maxIndex];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    maxIndex = i;
                    max = _array[maxIndex];
                }
            }
            return max;
        }

        //Поиск значения минимального элемента
        public int GetMinItem()
        {
            int index = 0;
            int min = _array[index];
            for (int i = 0; i < Length; i++)
            {
                if (min > _array[i])
                {
                    index = i;
                    min = _array[index];
                }
            }
            return min;
        }

        //Поиск индекса максимального значения элемента
        public int GetMaxIndex()
        {
            int IndexMaxItem = 0;
            int maxItem = _array[IndexMaxItem];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxItem)
                {
                    IndexMaxItem = i;
                    maxItem = _array[IndexMaxItem];
                }
            }
            return IndexMaxItem;
        }

        //Поиск индекса минимального значения элемента
        public int GetMinIndex()
        {
            int minIndex = 0;
            int minItem = _array[minIndex];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < minItem)
                {
                    minIndex = i;
                    minItem = _array[minIndex];
                }
            }
            return minIndex;
        }

        //Сортировка по возрастанию
        public void SortLayout()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length - 1; j++)
                {
                    if (_array[j] > _array[j + 1])
                    {
                        int item = _array[j + 1];
                        _array[j + 1] = _array[j];
                        _array[j] = item;
                    }
                }
            }
        }

        //Сортировка по убыванию
        public void SortDescending()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length - 1; j++)
                {
                    if (_array[j] < _array[j + 1])
                    {
                        int item = _array[j + 1];
                        _array[j + 1] = _array[j];
                        _array[j] = item;
                    }
                }
            }
        }

        //добавление массива в конец
        public void AddArrayEnd(int[] array)
        {
            if (_array.Length <= Length + array.Length)
            {
                IncreaseLength();
            }
            AddArrayByIndex(array, Length);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    _array[Length] = array[i];
            //    Length++;
            //}
        }

        //добавление массива в начало
        public void AddArrayStart(int[] array)
        {
            if (_array.Length <= Length + array.Length)
            {
                IncreaseLength();
            }

            AddArrayByIndex(array, 0);
        }

        //добавление массива по индексу
        public void AddArrayByIndex(int[] array, int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_array.Length <= Length + array.Length)
                {
                    IncreaseLength();
                }

                for (int i = 0; i < array.Length; i++)
                {
                    Length ++;
                    DisplacementRight(index);
                    _array[index] = array[i];
                    index++;
                }
            }
        }

        //удаление из конца N элементов
        public void RemoveEndItems(int quantity = 1)
        {
            if (quantity > Length-1 || quantity <= 0)
            {
                throw new Exception("There are fewer items in the list than you want to delete, or you used  0,  int quantity != 0, quantuty > 0");
            }
            else
            {
                RemoveFromIndexItems(Length - 1, quantity);
                if (_array.Length / 2 >= Length)
                {
                    DecreaseLength();
                }
            }
        }

        //удаление из начала N элементов
        public void RemoveSrartItems(int quantity)
        {
            if (quantity > Length)
            {
                throw new IndexOutOfRangeException("There are fewer items in the list than you want to delete! quantity != Length");
            }
            else
            {
                RemoveFromIndexItems(0, quantity);
                if (_array.Length / 2 >= Length)
                {
                    DecreaseLength();
                }
            }
        }

        //удаление по индексу N элементов
        public void RemoveFromIndexItems(int index, int quantity = 1)
        {
            if (index > Length - 1 || index < 0 || quantity > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
               
                if (index == 0)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        for (int k = 0; k < Length - 1; k++)
                        {
                            _array[k] = _array[k + 1];
                        }
                        Length--;
                    }
                }
                else if (index == Length - 1)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        Length--;
                    }
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        DisplacementLeft(index);
                        Length--;
                    }

                }

                if (_array.Length / 2 >= Length)
                {
                    DecreaseLength();
                }

            }
        }

        public override string ToString()
        {
            return string.Join(", ", _array.Take(Length));
        }

        // Метод который увеличивает длину массива
        private void IncreaseLength(int number = 1)
        {
            int newLength = _array.Length;
            while (newLength <= Length + number)
            {
                newLength = (int)(newLength * 1.33 + 1);
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }

        //Метод уменьшения длины массива
        private void DecreaseLength(int number = 1)
        {
            int newLength = Length;

            while (newLength > _array.Length / 2 - 1) //- number))
            {
                newLength = (newLength * 2) / (3 + 1);
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, newArray.Length);
            _array = newArray;
        }

        //Смещение значений в право
        private void DisplacementRight(int index)
        {
            for (int j = Length - 1; j > index; j--)
            {
                _array[j] = _array[j - 1];
            }
        }

        private void DisplacementLeft(int index)
        {
            for (int j = index; j < Length-1; j++)
            {
                _array[j] = _array[j + 1];
            }
        }
    }
}