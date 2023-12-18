using System;
using static System.Console;
using System.Collections.Generic;

namespace AdvancedListManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            DLList list = new DLList();
            OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                WriteLine("1. Create random list");
                WriteLine("2. Add the first item to the list");
                WriteLine("3. Add the last item to the list");
                WriteLine("4. Add an item to the list by number between the first and last item");
                WriteLine("5. Delete the first item in the list");
                WriteLine("6. Delete the last item in the list");
                WriteLine("7. Delete an item in the list by number between the first and last item");
                WriteLine("8. Laboratory task");
                WriteLine("9. Exit");
                Write("input the number of the action you want to perform on the list : "); int n = int.Parse(ReadLine());
                int el;
                if (n == 1)
                {
                    WriteLine();
                    for (int i = 0; i < rnd.Next(3, 20); i++)
                    {
                        list.AddLast(Convert.ToString(rnd.Next(1, 100)));
                    }
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 2)
                {
                    Clear();
                    Write("input element : "); el = int.Parse(ReadLine());
                    list.AddFirst(el.ToString());
                    WriteLine();
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 3)
                {
                    Clear();
                    Write("input element :"); el = int.Parse(ReadLine());
                    list.AddLast(el.ToString());
                    WriteLine();
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 4)
                {
                    Clear();
                    Write("input idex of element :"); int nomer = int.Parse(ReadLine());
                    Write("input element :"); el = int.Parse(ReadLine());
                    list.AddToPosition(el.ToString(), nomer);
                    WriteLine();
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 5)
                {
                    Clear();
                    list.DeleteFirst();
                    WriteLine();
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 6)
                {
                    Clear();
                    list.DeleteLast();
                    WriteLine();
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 7)
                {
                    Clear();
                    Write("input idex of element :"); int nomer = int.Parse(ReadLine());
                    WriteLine();
                    list.DeleteAtPosition(nomer);
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }

                else if (n == 8)
                {
                    Clear();
                    WriteLine("Add a new node after the middle node, if listed an even number of nodes, otherwise in front of the head of the list");
                    Write("input element :"); el = int.Parse(ReadLine());
                    WriteLine();
                    list.TaskLab(int.Parse(el.ToString()));
                    WriteLine("*********************************************");
                    list.Print();
                    WriteLine();
                    WriteLine("*********************************************");
                    WriteLine();
                }
                else if (n == 9)
                {
                    break;
                }
                else
                {
                    WriteLine("incorrect number");
                }
            }
        }
    }
    class DLList
    {

        static DLNode tail;
        public class DLNode
        {
            public string data;
            public DLNode next;
            public DLNode prev;
            public DLNode(string data)
            {
                this.data = data;
            }
            public DLNode(string data, DLNode next, DLNode prev)
            {
                this.data = data;
                this.next = next;
                this.prev = prev;
            }
        }
        public DLList()
        {
            tail = null;
        }
        public void AddFirst(string data)
        {
            AddLast(data);
            tail = tail.prev;

        }
        public void AddLast(string data)
        {

            DLNode node = new DLNode(data);
            if (tail == null)
            {
                tail = node;
                tail.prev = tail.next = tail;
            }
            else
            {
                node.next = tail.next;
                tail.next.prev = node;
                node.prev = tail;
                tail.next = node;
                tail = node;
            }
        }
        public void AddToPosition(string data, int position)
        {
            if (position <= 0)
            {
                WriteLine("incorrect index");
            }
            else if (position == 1 || tail == null)
            {
                AddFirst(data);
            }
            if (tail == tail.next)
            {
                AddLast(data);
            }
            DLNode Node = new DLNode(data);
            DLNode current = tail.next;
            int counter = 1;
            while (counter != position - 1)
            {
                current = current.next;
                counter++;
                if (current == tail && counter == position - 1)
                {
                    AddLast(data);

                }
                else if (current == tail.next)
                {
                    WriteLine("incorrect index");

                }
            }
            DLNode next = current.next;
            current.next = Node;
            Node.prev = current;
            Node.next = next;
            next.prev = Node;
        }
        public void Print()
        {
            if (tail == null)
            {
                WriteLine("list is empty");
            }
            else
            {
                DLNode current = tail.next;
                string text = "";
                bool flag = false;
                while (!flag)
                {

                    text = text + " " + current.data;
                    current = current.next;
                    if (current == tail.next)
                    {
                        flag = true;
                    }
                }
                Write(text);
            }
        }
        public void Print1()
        {
            if (tail == null)
            {
                WriteLine("list is empty");
            }
            else
            {
                DLNode current = tail;
                string text = "";
                bool flag = false;
                while (!flag)
                {

                    text = text + " " + current.data;
                    current = current.prev;
                    if (current == tail)
                    {
                        flag = true;
                    }
                }
                Write(text);
            }
        }
        public void DeleteFirst()
        {
            if (tail == null)
            {
                WriteLine("Erorr");
            }
            else if (tail.next == tail)
            {
                tail = null;
                WriteLine("the first item was successfully removed");
            }
            else
            {
                tail.next = tail.next.next;
                tail.next.prev = tail;
                WriteLine("the first item was successfully removed");
            }
        }
        public void DeleteLast()
        {
            if (tail == null)
            {
                WriteLine("Erorr");
            }
            else if (tail == tail.next)
            {
                tail = null;
                WriteLine("the last item was successfully removed");
            }
            else
            {
                tail.next.prev = tail.prev;
                tail.prev.next = tail.next;
                tail = tail.prev;
                WriteLine("the last item was successfully removed");
            }
        }
        public void DeleteAtPosition(int position)
        {
            if (tail == null)
            {
                WriteLine("Erorr");
            }
            else if (tail == tail.next)
            {
                tail = null;
            }
            if (position <= 0)
            {
                WriteLine("list is already empty");
            }
            else if (position == 1)
            {
                DeleteFirst();
            }
            DLNode current = tail.next;
            int counter = 1;
            while (counter != position - 1)
            {
                current = current.next;
                counter++;
                if (current == tail && counter == position - 1)
                {
                    DeleteLast();
                }
                else if (current == tail.next)
                {
                    WriteLine("list is already empty");
                }
            }
            DLNode next = current.next.next;
            current.next = next;
            next.prev = current;
        }
        public void TaskLab(int el)
        {
            if (tail == null)
            {
                AddFirst(el.ToString());
            }
            DLNode current = tail.next;
            bool flag = false;
            int count = 0;
            while (current != tail.next || !flag)
            {
                flag = true;
                count++;
                current = current.next;
            }
            if (count % 2 == 0)
            {
                AddToPosition(el.ToString(), count / 2 + 1);
            }
            else
            {
                AddFirst(el.ToString());
            }
        }
    }
}