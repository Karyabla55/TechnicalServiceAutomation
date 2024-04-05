using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TechnicalServiceAutomation
{
    public class LinkList<T>
    {
        public Node<T> root;

        public LinkList()
        {
            this.root = null;
        }

        public void addToLast(T Data)
        {
            Node<T> newNode = new Node<T>(Data);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node<T> ither = root;
                while (ither.next != null)
                {
                    ither = ither.next;
                }

                ither.next = newNode;
            }
        }

        public void addToHead(T Data)
        {
            Node<T> newNode = new Node<T>(Data);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node<T> temp = root;
                newNode.next = temp;
                root = newNode;
            }
        }

        public void AddToBetween(T Data, int DataLocation)
        {
            Node<T> newNode = new Node<T>(Data);
            if (root == null)
            {
                root = newNode;
            }
            else if (DataLocation == 0)
            {
                addToHead(Data);
            }
            else
            {
                Node<T> ither = root;
                for (int i = 0; i <= DataLocation - 2; i++)
                {
                    ither = ither.next;
                    if (ither.next.next == null)
                    {
                        addToLast(Data);
                        return;
                    }
                }
                newNode.next = ither.next;
                ither.next = newNode;
            }
        }
        public void ExtractToHead()
        {
            if (root == null || root.next == null)
            {
                return;
            }
            else
            {
                root = root.next;
            }
        }
        public void ExtractToLast()
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Node<T> ither = root;
                while (ither.next.next != null) { ither = ither.next; }
                ither.next = null;

            }
        }
        public void ExtractToBetween(int DataLocation)
        {
            if (root == null)
            {
                root = null;
            }
            else if (DataLocation == 0)
            {
                ExtractToHead();
            }
            else
            {
                Node<T> ither = root;
                for (int i = 0; i <= DataLocation - 2; i++)
                {
                    ither = ither.next;
                    if (ither.next == null)
                    {
                        ExtractToLast();
                        return;
                    }
                    ither.next = ither.next.next;
                }
                
            }

        }

        public T lastData()
        {
            if(root == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            Node<T> ither = root;
            while (ither.next != null) { ither = ither.next; }
            return ither.Data;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = root;
            while (current != null)
            {
                yield return current.Data;
                current = current.next;
            }
        }
    }

}
