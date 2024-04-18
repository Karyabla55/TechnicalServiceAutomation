using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServiceAutomation
{
    //Kullanılmıyor
    public class Queues<T>
    {

        public Node<T> head;
        public Node<T> tail;

        public Queues()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T value = head.Data;
            head = head.next;
            if (head == null)
            {
                tail = null;
            }
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return head.Data;
        }
    }
}
