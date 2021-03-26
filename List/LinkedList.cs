using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }

        public int this[int index]                // индексатор
        {                                         //лучше создать привaтный индекс GetNodeByIndex (который возвращает карэнт) но не в сортировках
            get
            {
                Node current = _head;            // создаем переменную которая будет шагать по спискам
                                                 // что бы найти что-то между 1 и последним
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;      // delaem shag. переприсваивая текущей переменной ссылку на следующую ноду
                }                                // переменная сбоку (проводница)
                                                 //нужен эксепшен индекс аутофрэйндж
                return current.Value;
            }
            set
            {
                Node current = _head;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;            // delatm shag
                }
                current.Value = value;
            }
        }
        
        private Node _head;                               // nachalo i konets spiska
        private Node _tail;
        int counter;

        

        //1 добавление значения в конец
        public void AddAtTheEnd(int value)
        {
            Length++;
            _tail.Next = new Node(value);                        //из конца создать новый элемент и сказать чtо 
                                                                 //это наш новый хвост
            _tail = _tail.Next;                                    // в хвосте точно лежит нал!!! ничего не перетрется
        }           //новый хвост в следующем созданном ноду, а там пустота
        

        //2 добавление значения в начало
        public void AddAtTheBegining(int value)
        {
            Length++;
            Node NewNode = new Node(value);
            NewNode.Next = _head;
            _head = NewNode;
        }

        //добавление значения по индексу


        //3 движение по индексу

        //4 удаление из конца одного элемента
        public void RemoveLast()
        {
            Node cur = _head;

            while (!(cur.Next is null))
            {
                cur = cur.Next;
            }

            _tail = cur;
            Length--;
        }
        //5 удаление из начала одного элемента
        public void RemoveFirst()
        {           
            if (_head == null)
            {
                throw new NullReferenceException("ссылки нет");
            }
            _head = _head.Next;
            Length--;            
        }



        //6 удаление по индексу одного элемента
        public void RemoveByIndex(int index)
        {
            Node current = _head;                                                   //заводим ~ карэнт равную руту с сылкой на 1 ноду

            for (int i = 1; i < index - 1; i++)
            {
                current = current.Next;                                         //нужно перепресвоить ссылку
            }
            current.Next = current.Next.Next;
            Length--;                                              // сначала выполняется действие справа от равно мы еще не стерли старый некст
        }                                                                //--ленгх записать kak?
                                                                         // цикл законче - удаляем "ячейку"
                                                                         //а в карен некст кладется  ссылка на хвост 

        //7 удаление из конца N элементов
        public void RemoveLastElements(int n)
        {          
            Node cur;
            for (int i = 1; i < Length-n-1; i++)
            {
                cur = _tail; 
            }
            Length -= n;           
        }

        //8 удаление из начала N элементов
        //9 удаление по индексу N элементов
        //10 вернуть длину


        //11 доступ по индексу
        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node cur;
            if (index == Length - 1)
            {
                cur = _tail;
            }
            else
            {
                cur = _head;
                for (int i = 1; i <= index; i++)
                {
                    cur = cur.Next;
                }                
            }
            return cur;
        }
              
        //12 первый индекс по значению
        //13 изменение по индексу


        //14 реверс

        public void Reverse()
        {
            Node pre = null;
            Node current = _head;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = pre;
                pre = current;
                current = next;
            }
            _head = pre;
            _tail = current;
        }

        //15 поиск значения максимального элемента

        //16 поиск значения минимального элемента
        //17 поиск индекса максимального элемента
       
        //18 поиск индекса минимального элемента
        //19 сортировка по возрастанию
        public void SortByAcsending()
        {
            Node iNode = _head;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value > jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }
        //20 сортировка по убыванию
        public void SortSortByDescending()
        {
            Node iNode = _head;
        int tmp;
            for (int i = 0; i<Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j<Length; j++)
                {
                    if (iNode.Value<jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }
        //21 удаление по значению первого


        //22 удаление по значению всех

        public LinkedList()                                        //pust constr
        {
            Length = 0;
            _head = null;
            _tail = null;
        }
        public LinkedList(int value)                                //конструтко по 1 элементу
        {
            Length = 1;
            _head = new Node(value);
            _tail = _head;
        }
        public LinkedList(int[] values)                               //constructor dliy massiva
        {
            Length = values.Length;

            if (values.Length != 0)                            //если длина массива который мы передали равно нулю , то мы ELSE создаем такой же список только пустой
            {                                                 //ЕСЛИ НЕТ - у тэйла хранится в поле некст ссылка на следующую ноду
                                                              //  и мы имеем возможность обратиться к этому полю некст, 
                _head = new Node(values[0]);                // сейчас в нем нал( а может ссылка на новую ноду)
                _tail = _head;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;                      // 2 элемента с рут1 и тэйл2. Внутри тэйл некст храниться ссылка на 3 ноду- обрезаем ссылку хвоста со 2 перекидываем  на 3ью (через tmp) в 3 лежит нул
                                                             //mojno zamenit na add
                }                                          //otbit oshibki null ne dolzjen byt
            }
            else
            {
                _head = null;
                _tail = null;
            }
        }

        //
        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _head;
                string s = current.Value + " ";                       // может не работать - может быть пустой
                                                                      // надо возвращать пустую стрингу, а как?
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";                         // записать в стринг текстовое представление объекта
                }

                return s;
            }
            else
            {
                return " " + String.Empty;
            }
        }
        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }
            Node currentThis = this._head;                       // зыс это ссылка на объект который вызвал этот метод
            Node currentList = list._head;                       // одна ~ бежит по нашему листу, другая по тому который передали
                                                                //зыс это экспекте
            do
            {
                if (currentThis.Value != currentList.Value)       //сравнили 1 конкретный элемент, ноду по значениям
                {
                    return false;
                }
                currentList = currentList.Next;                    //и шагнули вперед
                currentThis = currentThis.Next;
            }                                                        //index out of range ex-on      первое if вынести отдельно и если не равно скидывать
            while (!(currentThis.Next is null));

            return true;
        }                                                            // сортировка вставка i mergesort


        //24 добавление списка в конец
        //25 добавление списка в начало
        //26 добавление списка по индексу

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

//частые ошибки теряются руты, тейлы, и зацикливание