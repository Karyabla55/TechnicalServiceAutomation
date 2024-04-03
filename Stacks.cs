using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServiceAutomation
{
    public class Stacks<T>
    {
        private T[] data;
        private int size;
        private int capacity;


        //Default Stack
        public Stacks()
        {
            capacity = 10;
            data = new T[capacity];
            size = 0;
        }
        public Stacks(int capacity)
        {
            this.capacity = capacity;
            data = new T[this.capacity];
            size = 0;
        }

        public void Push(T item)
        {
            if (size == capacity)
            {
                return;
            }
            data[size] = item;
            size++;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            size--;
            return data[size];
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return data[size - 1];
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
    }
}
