using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class Node
    {                  //значение и ссылка на др ноду
        public int Value { get; set; }

        public Node Next;

        public Node(int value)// конструктор /нода не может быть пустой, присваиваем значение 
        {
            Value = value; //cvoistva = parametru

            Next = null;// v lubuy переменную хранящую ссылки можно положить нал
            // если не положить будет нул, в с№ плохо пользоваться значениями по умолчанию
        }// реверс листа за 1 прямой проход использую 2 доп переменные
    }
}
