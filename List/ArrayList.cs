using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class ArrayList
    {
        public int Length { get; private set; }
        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }
        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            _array[Length] = value;
            Length++;
        }
        public void UpSize()
        {
            int newlength = (int)(_array.Length * 1.33d + 1);
            int[] tmpArray = new int[newlength];
            for (int i =0; i<_array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
        public void DownSize()
        {
            int newlength = (int)(_array.Length * 0.67d + 1);
            int[] tmpArray = new int[newlength];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        public void AddFirst(int value)
        {
            if (Length==_array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];//пересоздаем массив
            tmpArray[0] = value;
            for (int i = 0; i< _array.Length; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            Length++;
        }
        public void AddIndex(int value, int index) //narushen single responsobility сделать метод мув с
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];// начнет с 15 копировать исправить
            tmpArray[index] = value;
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            Length++;
        }

        public void RemoveLast()
        {// ogranichit dostup polzovately srabotaet))
            Length--;
            if (Length<=(_array.Length/2))
            {
                DownSize();
            }
        }
        public void RemoveFirst()// перенести в массиве 123 всё на 1 шаг вперед будет быстрее. Так же сделать в ремоут(делит) индекс
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = _array.Length; i>0; i--) //!!!всю длину двигать не надо, достаточно полезной длины потому что дальше все равно нули нам на них плевать
            {
                tmpArray[i - 1] = _array[i];
            }
            _array = tmpArray;

            Length--;
            if (Length<=(_array.Length/2))
            {
                DownSize(); //zavisit ot novoi Length! umenshaem dlinu do nego
            }
        }
        public void RemoveByIndex(int index)// не создвать лишний массив а присваивать в этом массиве сдедующие значения
        {// отбить ошибки -900
            int[] tmpArray = new int[_array.Length];
            for (int i=0; i< index; i++)
            {
                tmpArray[i] = _array[i];
            }
            for (int i = index - 1; i<_array.Length - 1; i++)//
            {
                tmpArray[i] = _array[i + 1];//
            }
            _array = tmpArray;

            Length--;
            if (Length <=(_array.Length/2))
            {
                DownSize();
            }
        }
        public void RemoveLastElements(int n)
        public void RemoveFirstN(int n)
        public void RemoveIndexN(int index, int n)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = 0; i < index - 1; i++)
            {
                tmpArray[i] = _array[index + n];
            }
            _array = tmpArray;
            Length -= n;
            if (Length<=(_array.Length/2))
            {
                DownSize();
            }
        }
        public int GetIndex(int index)
        {
            return _array[index]; // pravilo izbutochnosti
        }
        public int GetElementByIndex(int index)
        {
            return _array[index];
        }
        public int GetIndexByValue(int x)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)// return _array[index]; ...
            {
                if (_array[i] ==x)
                {
                    index = i + 1;
                    break;
                }               
            }
            return index;
        }
        public void ChangeValueByIndexN(int index, int value)
        {
            _array[index - 1] = value;
        }

        public void Reverse()
        {
            int tmpArrayX;
            for (int i = 0; i< (Length/2); i++)// обращайте внимание что мы все реверсы делаем с точки зрения клиента, а не по реальной длине
            {
                tmpArrayX = _array[i];
                int x = Length - i - 1;
                _array[i] = _array[x];
                _array[x] = tmpArrayX;
            }
        }
        public int GetMax()
        {
            int max = _array[0];
            for (int i =1; i<Length; i++)
            {
                if (_array[i]>max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        public int GetMin()
        public int GetMaxIndex()
        public int GetMinIndex()

        public void SortByIncrease()
        {
            int tmp;
            for (int i=0; i < Length; i ++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i] > _array[j])
                    {
                        tmp = array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }
                
            
            }
        }
        public void SortByDecrease()
        public int RemoveFirstByValue (int x)
        public int RemoveAllX(int x)
    }
}
