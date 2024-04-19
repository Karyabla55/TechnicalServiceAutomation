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
            data = new LinkList<T>();
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
            return data.root.Data;
        }
        public Node<T> PeekNode()
        {
            if (size == 0)
            {
                return null;
            }
            return data.root;
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
        public bool IsFull()
        {
            if(size == capacity)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public int getCapacity()
        {
            return capacity;
        }
        public int getSize()
        {
            return size;
        }
    }
}
