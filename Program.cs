using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atsd_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            var queue = new PriorityQueue();
            int n = 100;
            do
            {
                
                Console.WriteLine("1. add item to the list");
  
                Console.WriteLine("2. delete item from the list");

                Console.WriteLine("3. use heapSort");

                Console.WriteLine("4. enqueue (queue)");

                Console.WriteLine("5. deque (queue)");

                Console.WriteLine("6. peek(queue)");
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    Console.WriteLine("How many items do you want to add ?\n");
                    int count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the items \n");
                    for (int i = 0; i < count; i++)
                    {
                        heap.addItem(Convert.ToInt32(Console.ReadLine()));
                    }
                    heap.print();
                }
                else if (n == 2)
                {
                    Console.WriteLine("Enter the number you want to delete\n");
                    int num = Convert.ToInt32(Console.ReadLine());
                    heap.deleteItem(num);
                    heap.print();
                }
                else if (n == 3)
                {
                    Console.WriteLine("Using heapsort ... ");
                    heap.sort();
                    heap.print();
                }
                else if (n == 4)
                {
                    Console.WriteLine("Enter item to enqueue \n");
                    int count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter it's priority to enqueue \n");
                    int prior = Convert.ToInt32(Console.ReadLine());
                    queue.enqueue(count,prior);
                    queue.print();
                }
                else if (n == 5)
                {
                    queue.dequeue();
                    queue.print();
                }
                else if (n == 6)
                {
                    queue.Peek();
                    queue.print();
                }
            } while (n != 0);

                Console.ReadLine();
        }

    }
    public class Heap
    {
        protected int max;
        protected int last;
        protected int[] array;
        public Heap(int n)
        {
            max = n + 1;
            last = 0;
            array = new int[max];
        }
        public Heap()
        {
            max = 11;
            last = 0;
            array = new int[max];
        }
        public bool isFull()
        {
            return (last == max - 1);
        }
        public bool isEmpty()
        {
            return (last == 0);
        }
        public int size()
        {
            return (last);
        }
        public void print()
        {
            Console.WriteLine("\nList contents:");
            if (last == 0)
                Console.WriteLine("\nList is empty");
            else
            {
                for (int i = 1; i <= last; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine(" ");
        }
        public void addItem(int item)
        {
            if (isFull())
                Console.WriteLine("list is full");
            array[++last] = item;
        }
        public int search(int item)
        {
            for (int i = 1; i <= last; i++)
                if (array[i] == item)
                    return i;
            return -1;
        }
        public int deleteItem(int item)
        {
            int k = search(item);
            if (k == -1)
            {
                Console.WriteLine("item is not in the list");
            }
            int dataReturned = array[k];
            array[k] = array[last--];
            return dataReturned;    
        }

        protected void swap(int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
        void settleRoot(int root, int end)
        {
            int child, unsettled = root;
            while (2 * unsettled <= end)
            {
                if (2 * unsettled < end && array[2 * unsettled + 1] > array[2 * unsettled])
                    child = 2 * unsettled + 1;
                else
                    child = 2 * unsettled;
                if (array[unsettled] < array[child])
                {
                    swap(unsettled, child);
                    unsettled = child;
                }
                else
                    break;
            }
        }
        public void sort()
        {
            for (int i = last / 2; i >= 1; i--)
                settleRoot(i, last);
            for (int heapEnd = last - 1; heapEnd >= 1; heapEnd--)
            {
                swap(1, heapEnd + 1);
                settleRoot(1, heapEnd);
            }
        }
    }

    class PriorityQueue
    {
        const int MAX_SIZE = 100;
        public struct Elem
        {
            public int val;
            public int priority;
            public Elem(int v = 0, int p = 0)
            {
                val = v;
                priority = p;
            }
        }
        public Elem[] array = new Elem[MAX_SIZE];
        int size;

        void up(int i)
        {
            while (i != 0 && array[i].priority > array[(i - 1) / 2].priority)
            {
                swap(array[i], array[(i - 1) / 2]);
                i = (i - 1) / 2;
            }
        }
        void down(int i)
        {
            while (i < size / 2)
            {
                int maxI = 2 * i + 1;
                if (2 * i + 2 < size && array[2 * i + 2].priority > array[2 * i + 1].priority)
                    maxI = 2 * i + 2;
                if (array[i].priority >= array[maxI].priority)
                    return;
                swap(array[i], array[maxI]);
                i = maxI;
            }
        }
        public PriorityQueue()
        {
            size = 0;
        }

        public void enqueue(int value, int priority)
        {
            array[size++] = new Elem(value, priority);
            up(size - 1);
        }

        public Elem dequeue()
        {
            swap(array[0], array[--size]);
            down(0);
            return array[size];
        }

        bool isEmpty()
        {
            return size == 0;
        }
        void swap(Elem a, Elem b)
        {
            Elem temp = array[Array.IndexOf(array,a)];
            array[Array.IndexOf(array, a)] = array[Array.IndexOf(array, b)];
            array[Array.IndexOf(array, b)] = temp;
        }
        public void print()
        {
            for (int i = 0; i < size;i++)
            {
                Console.Write(array[i].val + " ");
            }
            Console.WriteLine(" ");
        }
        public int Peek()
        {
            return array[0].val;
        }
    };
}

