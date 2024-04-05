using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServiceAutomation
{
    public class Stacks<T>
    {
        private LinkList<T> data;
        private int size;
        private int capacity;


        //Default Stack
        public Stacks()
        {
            capacity = 10;
            size = 0;
        }
        public Stacks(int capacity)
        {
            this.capacity = capacity;
            size = 0;
        }

        public void Push(T item)
        {
            if (size == capacity)
            {
                return;
            }
            data.addToHead(item);
            size++;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T Data = data.root.Data;
            data.ExtractToHead();
            size--;
            return Data ;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return data.lastData();
        }

        public bool IsEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void getCapacity()
        {
            Console.WriteLine(this.capacity);
        }
    }
}
