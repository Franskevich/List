using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }     // полезная длина свойство
        private int[] _array;                  //фактический массив,  не видимый пользователю

// индексатор
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

//увеличение длины массива
        private void UpSize(int n=1)
        {
            int newlength = (int)((_array.Length + n) * 1.33d);
            int[] tmpArray = new int[newlength];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }
     
// уменьшение длины массива
        private void DownSize()
        {
            int newlength = (int)(_array.Length * 0.67d + 1);
            int[] tmpArray = new int[newlength];
            for (int i = 0; i < newlength; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

//1 добавление значения в конец
        public void AddLast(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();                   // *1.33+1
            }
            _array[Length] = value;
            Length++;                            //и длина и последний индекс вносимого значения
        }
     
//2 добавить значение в начало
        public void AddFirst(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length];          //пересоздаем массив
            tmpArray[0] = value;
            for (int i = 0; i < _array.Length-1; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            Length++;
        }

//3 добавление значения по индексу
        public void AddValueByIndex(int value, int index) //narushen single responsobility сделать метод мув с
        {
            MoveByIndex(index);
            _array[index] = value;
        }
//
        private void MoveByIndex(int index)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            int[] tmpArray = new int[_array.Length + 1];
            
            for (int i = 0; i < _array.Length; i++)
            {
                if (i < index)
                {
                    tmpArray[i] = _array[i];
                }
                else
                {
                    tmpArray[i + 1] = _array[i];
                }
            }
            tmpArray[index] = 0;
            _array = tmpArray;
            Length++;
        }


//4 удаление из конца 1 элемента
        public void RemoveLast()
        {// ogranichit dostup polzovately srabotaet))
            int n = 1;
            RemoveLastElements(n);
        }

//5 удаление из начала одного элемента
        public void RemoveFirst()               // перенести в массиве 123 всё на 1 шаг вперед будет быстрее. Так же сделать в ремоут(делит) индекс
        {
            int n = 1;
            RemoveFirstN(n);

            if (Length <= (_array.Length / 2))
            {
                DownSize(); //zavisit ot novoi Length! umenshaem dlinu do nego
            }
        }
//6 удаление по индексу одного элемента
        public void RemoveByIndex(int index)// не создвать лишний массив а присваивать в этом массиве сдедующие значения
        {// отбить ошибки -900
            
            int n = 1;
            RemoveByIndexNElements(index, n);
            if (Length < (_array.Length / 2))
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
            Length -= n;
            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }

//8 удаление из начала N элементов 
        public void RemoveFirstN(int n)
        {
            int[] tmpArray = new int[_array.Length];
            for (int i = n; i < _array.Length; i++)        //!!!всю длину двигать не надо, достаточно полезной длины потому что дальше все равно нули нам на них плевать
            {
                tmpArray[i - n] = _array[i];
            }
            _array = tmpArray;

            Length-=n;
            if (Length <= (_array.Length / 2))
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

            for (int i = index; i < Length-n; i++)
            {
                _array[i] = _array[i + n];
            }

            Length -= n;
            if (Length < (_array.Length / 2))
            {
                DownSize();
            }
        }
//10 вернуть длину
        public int GetLength()
        {
            return Length;
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
            for (int i = 0; i < Length-1; i++)   // return _array[index]; ...
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
            for (int i = 0; i< (Length/2); i++)// обращайте внимание что мы все реверсы делаем с точки зрения клиента, а не по реальной длине
            {
                tmpArrayX = _array[i];
                int x = Length - i - 1;
                _array[i] = _array[x];
                _array[x] = tmpArrayX;
            }
        }
//15 поиск значения максимального элемента
        public int GetMax()
        {
            int max = _array[0];
            for (int i = 1; i<Length; i++)
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
            for(int i=0; i<Length; i++)
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
            for (int i = 0; i < Length; i++)
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
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] <  _array[min])
                {
                    min = i;
                }
            }
            return min;
        }

//19 Сортировка по возрастанию
        public void SortByAcsending()
        {
            int tmp;
            for (int i=0; i < Length; i ++)
            {
                for (int j = i + 1; j < Length; j++)
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
        public void SortByDescending()
        {
            int tmp;
            for (int i=0; i<Length; i ++)
            {
                for (int j = i + 1; j<Length; j++)
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
            for (int i = 0; i < Length; i++)
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
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);                   
                }
            }
        }

        //23.1 Конструктор по умолчанию
        public ArrayList() // pustoi construktor
        {
            Length = 0;// dlina dlia polzovately
            _array = new int[10];
        }

        //23.2 Конструктор на основе 1 элемента
        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[1] {value};
        }

        //23.3 конструктор на основе массива
        public ArrayList(int[]array)
        {                        
            Length = array.Length;
            _array = array;
            UpSize();
        }

        //24 добавление нашего списка в конец
        public void AddArrayListAtTheEnd (ArrayList ListOne)
        {          
            for (int i = 0; i < ListOne.Length; i++)
            {
                if (Length == _array.Length)
                {
                    UpSize();
                }
                _array[Length] = ListOne[i];
                Length++;
            }
        }

        //25 добавление списка в начало
        public void AddArrayListAtTheBegining(ArrayList ListOne)
        {
            for (int i = 0; i <= ListOne.Length; i++)
            {
                if (Length + ListOne.Length >= _array.Length)
                {
                    UpSize(ListOne.Length);
                }
                 _array[Length + ListOne.Length-i -1]= _array[Length-i-1];
            }
            for (int i = 0; i < ListOne.Length; i++)
            {
                _array[i] = ListOne[i];
                Length++;
            }            
        }

        //26 добавление списка по индексу
        
        public void AddArrayListByIndex(int index, ArrayList ListOne)
        {
            for (int i = 0; i<ListOne.Length; i++)
            {
                if (Length == _array.Length)
                {
                    UpSize();
                }
                MoveByIndex(i+index);
                _array[i+index] = ListOne[i];
            }
        }


        public override string ToString()
        {
            string s = "";
            for(int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
            }
            return s;
        }
        public override bool Equals(object obj)//kак он будет сравнивать элементы что бы асерт работал
        {
            ArrayList arrayList = (ArrayList)obj;
            if (this.Length != arrayList.Length)
            {
                return false;
            }
            for(int i=0; i<Length; i++)
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
