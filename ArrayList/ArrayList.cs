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
                if (i >= Length || i < 0)
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
            _array = new int[9];
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
                _array = new int[(int)(array.Length * _NumberLayoutPlace)];
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
                if (index == 0)
                {
                    DisplacementRight(index);
                    _array[index] = value;
                }
                else if (index == Length)
                {
                    _array[index] = value;
                }
                else if (Length == 0)
                {
                    _array[0] = value;
                }
                else
                {
                    for (int i = Length; i > index; i--)
                    {
                        _array[i] = _array[i - 1];
                    }
                    _array[index] = value;
                }

                Length++;
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
        public void RemoveFromEnd(int number = 1)
        {
            if (_array.Length > Length / 2 - number)
            {
                DecreaseLength();
            }
            RemoveFromIndexItem(Length - 1);
        }

        //Удаление из начала одного массива
        public void RemoveFromStart()
        {
            if (_array.Length <= Length / 2 - 1)
            {
                DecreaseLength();
            }

            RemoveFromIndexItem(0);
        }

        //Удаление по индексу элемента Переписать!!!
        public void RemoveFromIndexItem(int index)
        {
            if(index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_array.Length <= Length / 2 - 1)
                {
                    DecreaseLength();
                }

                if (index == 0)
                {
                    for (int i = 0; i < Length - 1; i++)
                    {
                        _array[i] = _array[i + 1];
                    }
                }
                else if (index == Length - 1)
                {
                    Length--;
                }
                else
                {
                    int[] newArray = new int[_array.Length - 1];
                    for (int i = 0; i < index; i++)
                    {
                        newArray[i] = _array[i];
                    }

                    for (int j = index + 1; j < Length; j++)
                    {
                        newArray[j - 1] = _array[j];
                    }
                    _array = newArray;
                }

                Length--;
            }
            
        }

        //Доступ по индексу
        public int AccessByIndex(int i)
        {
            if (i > Length || i < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _array[i];
            }
        }

        //Доступ по значению
        public int AccessByValue(int value)
        {
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    index = i;
                }
            }
            return index;
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
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        //Поиск значения минимального элемента
        public int GetMinItem()
        {
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] <= min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        //Поиск индекса максимального значения элемента
        public int GetMaxIndex()
        {
            int IndexMaxItem = 0;
            int maxItem = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxItem)
                {
                    IndexMaxItem = i;
                }
            }
            return IndexMaxItem;
        }

        //Поиск индекса минимального значения элемента
        public int GetMinIndex()
        {
            int indexMinItem = 0;
            int minItem = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] <= minItem)
                {
                    indexMinItem = i;
                }
            }
            return indexMinItem;
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
            for (int i = 0; i < array.Length; i++)
            {
                _array[Length] = array[i];
                Length++;
            }
        }

        //добавление массива в начало
        public void AddArrayStart(int[] array)
        {
            if (_array.Length <= Length + array.Length)
            {
                IncreaseLength();
            }

            for (int i = 0; i < array.Length; i++)
            {
                AddStart(array[i]);
            }
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
                    DisplacementRight(index);
                    _array[index] = array[i];
                    Length++;
                }
            }
        }

        //удаление из конца N элементов
        public void RemoveEndItems(int quantity = 1)
        {
            if (quantity > Length || quantity < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_array.Length <= Length / 2 - 1)
                {
                    DecreaseLength();
                }

                RemoveFromIndexItem(Length - quantity);
            }
        }

        //удаление из начала N элементов
        public void RemoveSrartItems(int quantity)
        {
            if (quantity > Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_array.Length <= Length / 2 - 1)
                {
                    DecreaseLength();
                }

                for (int i = 0; i < quantity; i++)
                {
                    RemoveFromIndexItem(0);
                }
            }
        }

        //удаление по индексу N элементов
        public void RemoveFromIndexItems(int index, int quantity = 1)
        {
            if (index > Length || index < 0 || quantity > Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < quantity; i++)
                {
                    if (_array.Length <= Length / 2 - 1)
                    {
                        DecreaseLength();
                    }

                    if (index == 0)
                    {
                        for (int k = 0; k < Length - 1; k++)
                        {
                            _array[k] = _array[k + 1];
                        }
                    }
                    else if (index == Length)
                    {
                        Length--;
                    }
                    else
                    {
                        int[] newArray = new int[_array.Length - 1];
                        for (int j = 0; j < index; j++)
                        {
                            newArray[j] = _array[j];
                        }

                        for (int l = index + 1; l < Length; l++)
                        {
                            newArray[l - 1] = _array[l];
                        }
                        _array = newArray;
                    }

                    Length--;
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
            int newLenght = _array.Length;
            while (newLenght <= Length + number)
            {
                newLenght = (int)(Length * _NumberLayoutPlace + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        //Метод уменьшения длины массива
        private void DecreaseLength(int number = 1)
        {
            int newLength = _array.Length;
            while (newLength >= 2 * (Length - number))
            {
                newLength = newLength * 2 / 3 + 1;
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        //Смещение значений в право
        private void DisplacementRight(int index)
        {
            for (int j = Length; j > index; j--)
            {
                _array[j] = _array[j - 1];
            }
        }
    }
}