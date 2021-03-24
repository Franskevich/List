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
                Node current = _root;            // создаем переменную которая будет шагать по спискам
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
                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;            // delatm shag
                }
                current.Value = value;

            }
        }
                                                       // реверс листа за 1 прямой проход использую 2 доп переменные

        private Node _root;                               // nachalo i konets spiska
        private Node _tail;



        //1 добавление значения в конец
        public void AddAtTheEnd(int value)
        {
            Length++;
            _tail.Next = new Node(value);                        //из конца создать новый элемент и сказать чtо 
                                                                    //это наш новый хвост
            _tail = _tail.Next;                                    // в хвосте точно лежит нал!!! ничего не перетрется
        }                                                           //новый хвост в следующем созданном ноду, а там пустота
        public void RemoveFirst()
        {
            _root = _root.Next;
        }

        //2 добавление значения в начало
        public void AddAtTheBegining(int value)
        {
            Length++;
            Node NewNode = new Node(value); 
            NewNode.Next = _root;          
        }


        //6 удаление по индексу
        public void RemoveByIndex(int index)
        {
            Node current = _root;                                                   //заводим ~ карэнт равную руту с сылкой на 1 ноду

            for (int i = 1; i < index - 1; i++)
            {
                current = current.Next;                                         //нужно перепресвоить ссылку
            }
            current.Next = current.Next.Next;                          // сначала выполняется действие справа от равно мы еще не стерли старый некст
        }                                                                //--ленгх записать kak?
                                                                      // цикл законче - удаляем "ячейку"
                                                                      //а в карен некст кладется  ссылка на хвост 
        //
        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
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
                return " "+String.Empty;
            }
        }
        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            } 
            Node currentThis = this._root;                       // зыс это ссылка на объект который вызвал этот метод
            Node currentList = list._root;                       // одна ~ бежит по нашему листу, другая по тому который передали
                                                                 //зыс это экспектед
            
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

        public LinkedList()                                        //pust constr
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public LinkedList(int value)                                //конструтко по 1 элементу
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
        public LinkedList(int[] values)                               //constructor dliy massiva
        {
            Length = values.Length;

            if (values.Length != 0)                            //если длина массива который мы передали равно нулю , то мы ELSE создаем такой же список только пустой
            {                                                 //ЕСЛИ НЕТ - у тэйла хранится в поле некст ссылка на следующую ноду
                                                             //  и мы имеем возможность обратиться к этому полю некст, 
                _root = new Node(values[0]);                // сейчас в нем нал( а может ссылка на новую ноду)
                _tail = _root;

                for (int i = 0; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;                      // 2 элемента с рут1 и тэйл2. Внутри тэйл некст храниться ссылка на 3 ноду- обрезаем ссылку хвоста со 2 перекидываем  на 3ью (через tmp) в 3 лежит нул
                                                            //mojno zamenit na add
                }                                          //otbit oshibki null ne dolzjen byt
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
    }
}
//частые ошибки теряются руты, тейлы, и зацикливание