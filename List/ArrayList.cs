using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ArrayList
    {
        
        public int L { get; private set; } // длина свойство
        private int[] _array;                  //фактический массив  не видимый пользователю
        0// индексатор
        public int this[int index]
        {
            get 
            {
                if (index < 0 || index > L-1)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            { 
                if(index < 0 || index > L - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }
        //ArrayList a = new ArrayList(10);
        //a[1] = 234;
        //    int g = a[13];
        //a.SetValueAtIndex(3, 13);
        public ArrayList() // pustoi construktor
        {
            L = 0;// dlina dlia polzovately
            _array = new int[10];
        }
        //1 добавление значения в конец
        public void Add(int value)
        {
            if (L == _array.Length)
            {
                UpSize();// *1.33+1
            }
            _array[L] = value;
            L++; //и длина и последний индекс вносимого значения
        }
        //увеличение длины массива
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
        // уменьшение длины массива
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
        //2 добавить значение в начало
        public void AddFirst(int value)
        {
            if (L==_array.Length)
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
            L++;
        }
        //3 добавление значения по индексу
        public void AddByIndex(int value, int index) //narushen single responsobility сделать метод мув с
        {
            if (L == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];   // начнет с 15 копировать исправить
            tmpArray[index] = value;
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            L++;
        }
        //4
        public void RemoveLast()
        {// ogranichit dostup polzovately srabotaet))
            L--;
            if (L<=(_array.Length/2))
            {
                DownSize();
            }
        }
        //5
        public void RemoveFirst()// перенести в массиве 123 всё на 1 шаг вперед будет быстрее. Так же сделать в ремоут(делит) индекс
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = _array.Length; i>0; i--) //!!!всю длину двигать не надо, достаточно полезной длины потому что дальше все равно нули нам на них плевать
            {
                tmpArray[i - 1] = _array[i];
            }
            _array = tmpArray;

            L--;
            if (L<=(_array.Length/2))
            {
                DownSize(); //zavisit ot novoi Length! umenshaem dlinu do nego
            }
        }
        //6
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

            L--;
            if (L <=(_array.Length/2))
            {
                DownSize();
            }
        }
        //7
        public void RemoveLastElements(int n)
        //8
        public void RemoveFirstN(int n)
        //9
        public void RemoveIndexN(int index, int n)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = 0; i < index - 1; i++)
            {
                tmpArray[i] = _array[index + n];
            }
            _array = tmpArray;
            L -= n;
            if (L<=(_array.Length/2))
            {
                DownSize();
            }
        }
        //10
        public int GetIndex(int index)
        {
            return _array[index]; // pravilo izbutochnosti
        }
        //11
        public int GetElementByIndex(int index)
        {
            return _array[index];
        }
        //12
        public int GetIndexByValue(int x)
        {
            int index = -1;
            for (int i = 0; i < L; i++)// return _array[index]; ...
            {
                if (_array[i] ==x)
                {
                    index = i + 1;
                    break;
                }               
            }
            return index;
        }
        //13
        public void ChangeValueByIndexN(int index, int value)
        {
            _array[index - 1] = value;
        }
        //14
        public void Reverse()
        {
            int tmpArrayX;
            for (int i = 0; i< (L/2); i++)// обращайте внимание что мы все реверсы делаем с точки зрения клиента, а не по реальной длине
            {
                tmpArrayX = _array[i];
                int x = L - i - 1;
                _array[i] = _array[x];
                _array[x] = tmpArrayX;
            }
        }
        //15
        public int GetMax()
        {
            int max = _array[0];
            for (int i =1; i<L; i++)
            {
                if (_array[i]>max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        //16       
        public int GetMin()
        //17
        public int GetMaxIndex()
        //18
        public int GetMinIndex()
        //19
        public void SortByIncrease()
        {
            int tmp;
            for (int i=0; i < L; i ++)
            {
                for (int j = i + 1; j < L; j++)
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
        //20
        public void SortByDecrease()
        //21
        public int RemoveFirstByValue (int x)
        //22
        public int RemoveAllX(int x)
    }
}
