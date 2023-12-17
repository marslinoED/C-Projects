using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Node
    {
        public int Data;
        public Node Next;
        public Node prev;
    }
    class SingleLinkedList
    {
        Node Head;
        public void InsertAtBeginning(int data) 
        {
            Node temp=new Node();
            temp.Data=data;
            temp.Next=Head;
            Head = temp;


        }
        public void InsertAtEnd(int data)
        {   Node temp=new Node();
            temp.Data=data;
            if (Head == null)
            {
                Head = temp;
                return;
            
            }
            Node p=Head;
            while (p.Next!=null)
            { 
                p=p.Next;
            }
            p.Next = temp;
            temp.Next = null;
        }
        public void InsertAfter(int data,int item) 
        {
            Node temp =new Node();
            temp.Data=data;
            Node p=Head;
            while (p!=null)
            {
                if (p.Data==item)
                {
                    temp.Next = p.Next;
                    p.Next = temp;
                    return;
                }                
                p = p.Next;
            }
            Console.WriteLine("{0} not present in the list\n", item);
        }
        public void InsertBefor(int data,int item)
        {
            Node temp = new Node();
            temp.Data = data;
            if (Head==null)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            if (Head.Data==data)
            {
                temp.Next = Head.Next;
                Head = temp;
                return;
            }
            Node p = Head;
            while (p!=null)
            {
                if (p.Next.Data==item)
                {
                    temp.Next = p.Next;
                    p.Next = temp;
                    return;
                }
                p = p.Next;
            }
            Console.WriteLine("{0} not present in the list\n", item);
        }
        public void InsertAtGivenPosition(int data,int pos)
        {
            if (pos==1)
            {
                InsertAtBeginning(data);
                return;
            }
            Node temp = new Node();
            temp.Data = data;
            Node p = Head;
            for (int i = 1; i < pos-1 && p!=null; i++)
            {
                p = p.Next;
            }
            if (p==null)
            {
                Console.WriteLine("There are less than {} elements\n", pos);
            }
            else
            {
                temp.Next = p.Next;
                p.Next = temp;
            }
        }
        public void PrintSingle()
        {
            Node p = Head;
            while (p!=null)
            {
               Console.WriteLine(p.Data + " ");
               p = p.Next;
            }
            Console.WriteLine();
        }
        public void Count()
        {
            int count = 0;
            Node p = Head;
            while (p!=null)
            {
                count++;
                p = p.Next;
            }
            Console.WriteLine(count);
        }
        public void Search(int data)
        {
            Node p = Head;
            for (int i = 1; p!=null ; i++)
            {
                if (p.Data==data)
                {
                    Console.WriteLine("Item {0} found at position {1}", data,i);
                    return;
                }
                p = p.Next;
            }
            Console.WriteLine("Item {0} not found in list\n", data);

        }
        public void DeleteNode(int data)
        {
            if (Head==null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (Head.Data==data)
            {
               Head = Head.Next;
               return;
            }
            Node p = Head;
            while (p.Next!=null)
            {
                if (p.Next.Data==data)
                {
                    p.Next = p.Next.Next;
                    return;

                }
                p = p.Next;

            }
            Console.WriteLine("Element {0} not found", data);
        }
        
            






    }
    class DoubleLikedList
    {
        Node Head;
        public void InsertAtFirst(int data)
        {
            Node temp =new Node();
            temp.Data = data;
            if (Head==null)
            {
                temp.Next = null;
                temp.prev = null;
                Head = temp;
            }
            else
            {
                temp.prev = null;
                temp.Next = Head;
                Head.prev = temp;
                Head = temp;   
            }
        }
        public void InsertAtLast(int data)
        {
            Node temp = new Node();
            if (Head==null)
            {
                Head.prev = null;
                Head.Next = null;
                Head = temp;
            }
            else
            {
                Node p = Head;
                while (p.Next!=null)
                {
                    p = p.Next;
                }
                temp.prev = p;
                temp.Next = null;
                p.Next = temp;

            }
        }
        public void InsertAfter(int data,int item)
        {
            if (Head==null)
            {
                Console.WriteLine("list is empty");
                return;
            }
            Node temp = new Node();
            temp.Data = data;
            Node p = Head;
            while (p!=null)
            {
                if (p.Data==item)
                {
                    if (p.Next==null)
                    {
                        temp.prev = p;
                        temp.Next = null;
                        p.Next = temp;
                        return;
                    }
                    temp.prev = p;
                    temp.Next = p.Next;
                    p.Next.prev = temp;
                    p.Next = temp;
                    return;
                }
                p = p.Next;
            }
            Console.WriteLine(data + "N F");

        }
        public void InsertBefore(int data,int item)
        {
            if (Head==null)
            {
                Console.WriteLine("List is empty!");
                return;

            }
            if (Head.Data==item)
            {
                InsertAtFirst(data);
                return;

            }
            Node temp = new Node();
            temp.Data = data;
            Node p = Head;
            while (p!=null)
            {
                if (p.Next.Data==item)
                {
                    temp.Next = p.Next;
                    temp.prev = p;
                    p.Next.prev = temp;
                    p.Next = temp;
                    return;
                }
                p = p.Next;
            }
            Console.WriteLine(data + " N F");

        }
        public void InsertAtGivenPosition(int data,int position)
        {
            if (position<1)
            {
                Console.WriteLine("invaild pos");
                return;
            }
            if (position == 1)
            {
                InsertAtFirst(data);
                return;
            }
            Node temp = new Node();
            Node p = Head;
            for (int i = 1; i < position - 1 && p != null; i++)
            {
                p = p.Next;
            }
            if (p==null)
            {  
                Console.WriteLine("Position not vaild");
                return;
            }
            if (p.Next==null)
            {
                temp.prev = p;
                temp.Next = null;
                p.Next = temp;
                return;
            }
            temp.prev = p;
            temp.Next = p.Next;
            p.Next.prev = temp;
            p.Next = temp;
        }
        public void PrintDouble()
        {
            if (Head==null)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            Node p = Head;
            while (p!=null)
            {
                Console.WriteLine( p.Data+" " );
                p = p.Next;
            }
            Console.WriteLine();
        }
        public void Count()
        {
            if (Head==null)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            int count = 0;
            Node p = Head;
            while (p!=null)
            {
                count++;
                p = p.Next;
            }
            Console.WriteLine("count = " + count);
        }
        public void Search(int data)
        {
            if (Head==null)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            Node p = Head;
            int pos = 0;
            while (p!=null)
            {
                if (p.Data==data)
                {
                    Console.WriteLine(data+"Found at "+pos);
                }
                p = p.Next;
                pos++;
            }
            Console.WriteLine("N F");
        }
        public void DeleteNode(int data)
        {
            if (Head==null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (Head.Data==data)
            {
                Head = Head.Next;
                if (Head==null)
                {
                    return;
                }
                Head.prev = null;
                return;
            }
            Node p = Head;
            while (p.Next != null)
            {
                if (p.Data == data)
                {
                    p.prev.Next = p.Next;
                    p.Next.prev = p.prev;
                    return;
                }
                p = p.Next;
            }
            if (p.Data==data)
            {
                p.prev.Next = null;
                return;
            }
            Console.WriteLine("N F");
        }

    }
    class CircularLinkedList
    {
        Node last;
        public void InsertFirst(int data)
        {
            Node temp = new Node();
            temp.Data = data;
            if (last==null)
            {
                last = temp;
                last.Next = last;
            }
            else
            {
                temp.Next = last.Next;
                last.Next = temp;
            }
        }
        public void InsertLast(int data)
        {
            Node temp = new Node();
            if (last==null)
            {
                last = temp;
                last.Next = last;
            }
            else
            {
                temp.Next = last.Next;
                last.Next = temp;
                last = temp;
            }
        }
        public void PrintCircular()
        {
            if (last==null)
            {
                Console.WriteLine("Empty");
                return;
            }
            Node p = last.Next;
            while (p!=last)
            {
                Console.WriteLine(p.Data+" ");
                p = p.Next;
            }
            Console.WriteLine(p.Data);
        }
        public void Count()
        {
            if (last == null)
            {
                Console.WriteLine("Empty");
                return;
            }
            Node p = last;
            int count = 1;
            while (p.Next != last)
            {
                count++;
                p = p.Next;
            }
            Console.WriteLine(count);
        }
        public void Search(int data)
        {
            if (last == null)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            Node p = last.Next;
            while (p!=last)
            {
                if (p.Data==data)
                {
                    Console.WriteLine(data+ " Found");
                    return;
                }
                p = p.Next;
            }
            if (p.Data==data)
            {
                Console.WriteLine(data+" Found");
                return;
            }
            Console.WriteLine("N F");
        }
        public void DeleteFirst()
        {
            if (last==null)
            {
                Console.WriteLine("List is empty");
            }
            else if (last.Next==last)
            {
                last = null;
            }
            else
            {
                last.Next = last.Next.Next;
            }      
        }
        public void DeleteLast()
        {
            if (last==null)
            {
                Console.WriteLine("List Is Empty");
            }
            else if (last.Next==last)
            {
                last = null;
            }
            else
            {
                Node p = last.Next;
                while (p.Next!=last)
                {
                    p = p.Next;
                }
                p.Next = last.Next;
                last = p;
            }
        }
    }
    class StackArray
    {
        int top;
        int[] data;
        public StackArray(int size)
        {
            data = new int[size];
            top = -1;
        }
        public bool isEmpty()
        {
            if (top==-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isFull()
        {
            if (top==data.Length-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Size()
        {
            return top + 1;
        }
        public void Push(int x)
        {
            if (isFull())
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            top++;
            data[top] = x;
        }
        public int Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack underflow");
                return int.MinValue;
            }
            int x = data[top];
            top--;
            return x;
        }
        public int peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return int.MinValue;
            }          
            return data[top];
        }
        public void Display()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            Console.WriteLine("Stack is : ");
            for (int i = top; i >=0; i--)
            {
                Console.WriteLine(data[top]);
            }

        }
    }
    class StackLinkedList
    {
        Node top;
        public StackLinkedList()
        {
            top = null;
        }
        public bool isEmpty()
        {
            if (top==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Push(int data)
        {
            Node temp = new Node();
            temp.Data = data;
            temp.Next = top;
            top = temp;  
        }
        public int Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return int.MinValue;
            }
            int data = top.Data;
            top = top.Next;
            return data;
        }
        public int Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return int.MinValue;
            }
            int data = top.Data;
            return data; 
        }
        public void Display()
        {
            if (isEmpty())
            {
                Console.WriteLine("stack is empty!");
                return;
            }
            Console.WriteLine("Stack is : ");
            Node p = top;
            while (p!=null)
            {
                Console.WriteLine(p.Data);
                p = p.Next;
            }
        }
        public int Size()
        {
            if (isEmpty())
            {
                Console.WriteLine("stack is empty");
                return 0;
            }
            int count = 0;
            Node p = top;
            while (p!=null)
            {
                count++;
                p = p.Next;
            }
            return count;
        }
    }
    class QueueArray
    {
        int front;
        int rear;
        int[] data;
        public QueueArray(int size)
        {
            front = rear = -1;
            data = new int [size];
        }
        public bool isEmpty()
        {
            if (front==-1 ||front==rear+1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isFull()
        {
            if (rear==data.Length-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Size()
        {
            if (isEmpty())
            {
                return 0;
            }
            return rear - front + 1;
        }
        public void Enqueue(int item)
        {
            if (isFull())
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            if (front==-1)
            {
                front = 0;
            }
            rear++;
            data[rear] = item;
        }
        public int Dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue Underflow");
                return int.MinValue;
            }
            int item = data[front];
            front++;
            return item;
        }
        public int Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue Underflow");
                return int.MinValue;
            }
            return data[front];
        }
        public void Display()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
            }
            for (int i = 0; i <= rear; i++)
            {
                Console.WriteLine(data[i]+" ");
            }
            Console.WriteLine();
        }
    }
    class QueueLinkedList
    {
        Node front;
        Node rear;
        public QueueLinkedList()
        {
            front = rear = null;
        }
        public bool isEmpty()
        {
            if (front==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Enqueue(int data)
        {
            Node temp = new Node();
            temp.Data = data;
            if (isEmpty())
            {
                front =rear= temp;
            }
            else
            {
                rear.Next = temp;
                rear = temp;
            }
        }
        public int Dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Underflow");
                return int.MinValue;
            }
            int data = front.Data;
            front = front.Next;
            return data;
        }
        public int Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return int.MinValue;
            }
            return front.Data;
        }
        public void Display()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            Console.WriteLine("Queue Element : ");
            Node p = front;
            while (p!=null)
            {
                Console.WriteLine(p.Data+" ");
                p = p.Next;
            }
            Console.WriteLine();
        }
        public int Size()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }
            int count = 0;
            Node p = front;
            while (p!=null)
            {
                count++;
                p = p.Next;
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
