using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2
{
    class RList
    {
        public int data;
        public RList next;

        public RList(int i, RList n)
        {
            data = i;
            next = n;
        }
        public RList(int i)
        {
            data = i;
            next = null;
        }
        public RList(RList n)
        {
            data = n.data;
            next = n.next;
        }
        public RList()
        {
            data = default(int);
            next = null;
        }

            //add last
        public void Add(int num)
        {
            if (next == null)
                next = new RList(num);
            else
            {
                RList kek = next;

                while (kek.next != null)
                    kek = kek.next;
                kek.next = new RList(num);
            }
        }
        //подсчет кол-ва элементов в листе
        public static int Counter(RList rl)
        {
            int count = 1;
            while (rl.next != null)
            {
                count++;
                rl = rl.next;
            }
            return count;
        }
        //8. Рекурсивний метод додавання нового елемента n-ним у список;
        public void AddAtRec(int pos, int num,RList rl)
        {
            if(pos<1 || pos > Counter(rl))
            {
                throw new Exception("Введенная позиция меньше 1 или больше кол-ва элементов листа");
            }
            if (pos == Counter(rl))
            {
                while (rl.next != null)
                {
                    rl = rl.next;
                }
                rl.next = new RList(num);
                return;
            }
            if(pos == 1)
            {
                int temp = rl.data;
                rl.data = num;
                RList lel = new RList(temp);
                lel.next = rl.next;
                rl.next = lel;
            }
            else
            {
                pos--;
                AddAtRec(pos, num, rl.next);
            }
        }
        //16. Рекурсивний метод видалення n-ного за рахунком елемента;
        public void DeleteAtRec(int pos, RList rl)
        {
            //проверка
            if (pos < 1 || pos > Counter(rl))
            {
                throw new Exception("Введенная позиция меньше 1 или больше кол-ва элементов листа");
            }
            //последний элемент
            if (pos == Counter(rl))
            {
                while (rl.next.next != null)
                {
                    rl = rl.next;
                }
                rl.next = null;
                return;
            }
            //первый элемент
            if (pos == 1)
            {
                while (rl.next.next != null)
                {
                    rl.data = rl.next.data;
                    rl = rl.next;
                }
                rl.data = rl.next.data;
                rl.next = null;
            }
            else
            {
                pos--;
                DeleteAtRec(pos, rl.next);
            }
        }
        //24. Метод видалення всіх парних за значенням елементів;
        public RList DeleteAbleByTwo(RList rl)
        {
            RList kek = rl;
            RList prev = null;

            if (kek == null)
            {
                return prev;
            }
            if (kek.next == null)
            {
                if (kek.data % 2 == 0)
                {
                    return null;
                }
            }
            while (kek != null)
            {
                if (kek.data % 2 == 0)
                {
                    if (prev == null)
                    {
                        rl = rl.next;
                        kek = rl;
                    }
                    else
                    {
                        prev.next = kek.next;
                        kek = kek.next;
                    }
                }
                else
                {
                    prev = kek;
                    kek = kek.next;
                }
            }
            return rl;
        }

        //35. Рекурсивний метод друку елементів списку у зворотному порядку у стовпець;
        //принт начиная с первого
        public void RecInvPrint1(RList rl)
        {
            if (rl.next == null)
            {
                Console.WriteLine(rl.data);
            }
            else
            {

                Console.WriteLine(rl.data);
                RecInvPrint1(rl.next);
            }
        }
        //принт начиная с последнеого
        public void RecInvPrint2(RList rl)
        {
            if (rl.next == null)
            {
                Console.WriteLine(rl.data);
            }
            else
            {
                RecInvPrint2(rl.next);
                Console.WriteLine(rl.data);
            }
        }
        //40. Метод пошуку елемента із заданим значенням(результат - посилання на знайдений елемент);
        public RList SearchByKey(int key, RList rl)
        {
            while (rl.next!=null)
            {
                if (rl.data == key)
                {
                    return rl;
                }
                rl = rl.next;
            }
            return rl;
        }
        public static void deleteEl(RList rl)
        {
            while (rl.next.next != null)
            {
                rl.data = rl.next.data;
                rl = rl.next;
            }
            rl.data = rl.next.data;
            rl.next = null;
        }
        //55.Індексатор з двома параметрами, що дозволяє знайти мінімальне значення
        //серед значень елементів, розташованих між елементами із заданими номерами.

        public int this[int i, int j, RList rl]
        {
            get
            {
                int count = 0;
                int cou = 0;
                //обрезаем конец листа
                RList temp = CutJ(j-1, rl);
                //обрезаем начало листа
                temp = Cut(i, temp);
                //находим минимальое число в промежутке
                return finmin(temp);
            }
        }
        
        

        
        public  static RList Cut(int i, RList rl)
        {

            int count = 0;
            while (rl.next != null)
            {
                count++;
                if (count == i)
                {
                    return new RList(rl.next);
                }
                rl = rl.next;
            }
            return new RList();

        }
        public static RList CutJ(int j, RList rl)
        {
            int count = 0;
            RList temp = new RList(rl.data);
            while (count != j)
            {
                count++;
                RList lul = new RList(rl.next.data);
                lul.next = temp;
                temp = lul;
                rl = rl.next;
            }

            return Reverse(temp);
        }
        public static RList Reverse(RList rl)
        {
            dynamic n = null;
            while (rl != null)
            {
                RList temp = rl.next;
                rl.next = n;
                n = rl;
                rl = temp;
            }
            rl = n;
            
            return rl;

        }
      
        
        public static int finmin(RList LR)
        {
            int min = 10000;
            while (LR.next != null)
            {
                if (LR.data < min)
                {
                    min = LR.data;
                }
                LR = LR.next;
            }
            //на случай если последний элемент наименьший
            if (LR.data < min)
            {
                min = LR.data;
            }
            return min;
        }

        //1,3 , 5, 8, 16, 24, 35, 40, 55
        public void Print(RList kek)
        {
            Console.WriteLine();
            if (kek.next == null)
            {
                Console.Write(" "+kek.data+" ");
            }
            else
            {
                Print(kek.next);
                Console.Write(" "+kek.data+" ");
            }

        }
    }
}
