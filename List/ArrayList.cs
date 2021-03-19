using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ArrayList
    {

        public int L { get; private set; } // длина свойство
        private int[] _array;                  //фактический массив,  не видимый пользователю
// индексатор
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > L - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index > L - 1)
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
            for (int i = 0; i < _array.Length; i++)
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
            for (int i = 0; i < newlength; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

//2 добавить значение в начало
        public void AddFirst(int value)
        {
            if (L == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];//пересоздаем массив
            tmpArray[0] = value;
            for (int i = 0; i < _array.Length; i++)
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
            int[] tmpArray = new int[_array.Length];
            for (int i = _array.Length; i > index; i--)
            {
                tmpArray[i + 1] = _array[i];
            }
            tmpArray[index] = value;
            _array = tmpArray;
            L++;
        }

//4 удаление из конца 1 элемента
        public void RemoveLast()
        {// ogranichit dostup polzovately srabotaet))
            int n = 1;
            RemoveLastElements(n);
        }

//5 удаление из начала одного элемента
        public void RemoveFirst()// перенести в массиве 123 всё на 1 шаг вперед будет быстрее. Так же сделать в ремоут(делит) индекс
        {
            int n = 1;
            RemoveFirstN(n);
            L -= n;
            if (L <= (_array.Length / 2))
            {
                DownSize(); //zavisit ot novoi Length! umenshaem dlinu do nego
            }
        }
//6 удаление по индексу одного элемента
        public void RemoveByIndex(int index)// не создвать лишний массив а присваивать в этом массиве сдедующие значения
        {// отбить ошибки -900
            
            int n = 1;

            RemoveByIndexNElements(index, n);

            // L -= 1;

            if (L < (_array.Length / 2))
            {
                DownSize();
            }
        }
//7 удаление из конца N элементов
        public void RemoveLastElements(int n)
        {          // ogranichit dostup polzovately srabotaet))
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Значение не может быть отрицательным, либо равным нулю");
            }
            L -= n;
            if (L <= (_array.Length / 2))
            {
                DownSize();
            }
        }

//8 удаление из начала N элементов 
        public void RemoveFirstN(int n)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = n; i > _array.Length; i++) //!!!всю длину двигать не надо, достаточно полезной длины потому что дальше все равно нули нам на них плевать
            {
                tmpArray[i - n] = _array[i];
            }
            _array = tmpArray;

            L--;
            if (L <= (_array.Length / 2))
            {
                DownSize(); //zavisit ot novoi Length! umenshaem dlinu do nego
            }
        }
//9 удаление по индексу N элементов
        public void RemoveByIndexNElements(int index, int n)
        {
            //int[] tmpArray = new int[_array.Length];
            //for (int i = index; i < L-n; i++)
            //{               
            //    tmpArray[i] = _array[i+n];
            //}

            //for (int i=0; i<index; i++)
            //{
            //    tmpArray[i] = _array[i];
            //}
            //_array = tmpArray;

            for (int i = index; i < L-n; i++)
            {
                _array[i] = _array[i + n];
            }

            L -= n;
            if (L < (_array.Length / 2))
            {
                DownSize();
            }
        }
//10 вернуть длину
        public int GetLength()
        {
            return L;
        }

//11 доступ по индексу
        public int GetElementByIndex(int index)
        {
            return _array[index]; // правило избыточности
        }
//12 первый индекс по значению
        public int GetFirstIndexByValue(int x)
        {
            int index = 0;
            for (int i = 0; i < L-1; i++)   // return _array[index]; ...
            {
                if (_array[i] == x)
                {
                    index = i;
                    break;
                }               
            }
            return index;
        }
//13 изменение по индексу
        public void ChangeValueByIndex(int index, int value)
        {
            _array[index] = value;
        }
//14 реверс
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
//15 поиск значения максимального элемента
        public int GetMax()
        {
            int max = _array[0];
            for (int i = 1; i<L; i++)
            {
                if (_array[i]>max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

//16    поиск значения минимального элемента   
        public int GetValueOfMinElement(int n)
        {
            int min=_array[0];
            for(int i=0; i<L; i++)
            {
                if(_array[i]<min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

//17 поиск индекс максмального элемента
        public int GetIndexOfMaxValue(int n)
        {
            int max = 0;
            for (int i = 0; i < L; i++)
            {
                if (_array[i] > _array[max])
                {
                    max = i;
                }
            }
            return max;
        }

//18 поиск индекс минимального элемента
        public int GetIndexOfMinValue()
        {
            int min = 0;
            for (int i = 0; i < L; i++)
            {
                if (_array[i] <  _array[min])
                {
                    min = i;
                }
            }
            return min;
        }

//19 Сортировка по возрастанию
        public void SortByIncrease()
        {
            int tmp;
            for (int i=0; i < L; i ++)
            {
                for (int j = i + 1; j < L; j++)
                {
                    if (_array[i] > _array[j])
                    {
                        tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }                      
            }
        }

//20 Сортировка по убыванию
        public void SortByDecrease()
        {
            int tmp;
            for (int i=0; i<L; i ++)
            {
                for (int j = i + 1; j<L; j++)
                {
                    if (_array[i] < _array[j])
                    {
                        tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }                      
            }
        }

//21 удаление по значению первого (?вернуть индекс)
        //public int RemoveFirstByValue (int x)
        public void RemoveByValueFirst(int value)// не создвать лишний массив а присваивать в этом массиве сдедующие значения
        {
            for (int i = 0; i < L; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);
                    return;
                }
            }
        }
            

//22 Удаление по значению всех(?вернуть кол-во)
        public void RemoveByValueAll(int value)
        {
            for (int i = 0; i < L; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);                   
                }
            }
        }


        //23.1 Конструктор по умолчанию

        //23.2 Конструктор на основе 1 элемента

        //23.3 конструктор на основе массива
        public ArrayList(int[]array)
        {                        
            L = array.Length;
            _array = array;
            UpSize();
        }


        //24 дообавлеение нашего списка в конец

        //25 добавление списка в начало

        //26 добавление списка по индексу
        AddArrayListAtIndex



        public override string ToString()
        {
            string s = "";
            for(int i = 0; i < L; i++)
            {
                s += _array[i] + " ";
            }
            return s;
        }
        public override bool Equals(object obj)//kак он будет сравнивать элементы что бы асерт работал
        {
            ArrayList arrayList = (ArrayList)obj;
            if (this.L != arrayList.L)
            {
                return false;
            }
            for(int i=0; i<L; i++)
            {
                if (this._array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
