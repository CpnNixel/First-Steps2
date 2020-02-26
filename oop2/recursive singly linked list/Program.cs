using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first element to create a recursive singly linked list\n");

            RList kek = new RList(Convert.ToInt32(Console.ReadLine()));
           
            while (true)
            {
                ShowMenu();
                int x = Convert.ToInt32(Console.ReadLine());
               
                
                switch (x)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine();
                        kek.Print(kek);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("\n Enter the element you wanna insert");
                        kek.Add(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("List looks like this:");
                        kek.Print(kek);
                        Console.WriteLine("\n Enter the postion you wanna insert");
                        int pos = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the number you wanna insert");
                        int num = Convert.ToInt32(Console.ReadLine());
                        kek.AddAtRec(pos, num, kek);
                        break;
                    case 4:
                        Console.WriteLine("\n Enter the position you wanna delete");
                        int pos2 = Convert.ToInt32(Console.ReadLine());
                        kek.DeleteAtRec(pos2, kek); 
                        break;
                    case 5:
                        kek.DeleteAbleByTwo(kek);
                        break;
                    case 6:
                        Console.WriteLine();
                        kek.RecInvPrint1(kek);
                        Console.WriteLine();
                        kek.RecInvPrint2(kek);
                        break;
                    case 7:
                        Console.WriteLine("\nEnter the key you wanna get link to");
                        int key = Convert.ToInt32(Console.ReadLine());
                        kek.Print(kek.SearchByKey(key, kek));
                        break;
                    case 8:
                        kek.Print(kek);
                        Console.WriteLine("\nEnter element FROM");
                        int _from = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter element TO");
                        int _to = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The minimal number is");
                        Console.WriteLine(kek[_from, _to, kek]);
                        break;
                }


                //1,3 , 5, 8, 16, 24, 35, 40, 55
            }
            
        }
        //5. Не рекурсивний метод додавання нового елемента останнім у список;
        //8. Рекурсивний метод додавання нового елемента n-ним у список;
        //16. Рекурсивний метод видалення n-ного за рахунком елемента;
        //24. Метод видалення всіх парних за значенням елементів;
        //35. Рекурсивний метод друку елементів списку у зворотному порядку у стовпець;
        //40. Метод пошуку елемента із заданим значенням (результат - посилання на знайдений елемент);
        //55. Індексатор з двома параметрами, що дозволяє знайти мінімальне значення
        //    серед значень елементів, розташованих між елементами із заданими номерами.
        static void ShowMenu()
        {
            Console.WriteLine("\nPress 1 to Print the list");
            Console.WriteLine("Press 2 to execute 5. \n \t\tНе рекурсивний метод додавання нового елемента останнiм у список;");
            Console.WriteLine("Press 3 to execute 8. \n \t\tРекурсивний метод додавання нового елемента n-ним у список");
            Console.WriteLine("Press 4 to execute 16. \n \t\tРекурсивний метод видалення n-ного за рахунком елемента");
            Console.WriteLine("Press 5 to execute 24. \n \t\tМетод видалення всiх парних за значенням елементiв");
            Console.WriteLine("Press 6 to execute 35. \n \t\tРекурсивний метод друку елементiв списку у зворотному порядку у стовпець");
            Console.WriteLine("Press 7 to execute 40. \n \t\tМетод пошуку елемента iз заданим значенням (результат - посилання на знайдений елемент");
            Console.WriteLine("Press 8 to execute 55. \n \t\tІндексатор з двома параметрами, що дозволяє знайти мiнiмальне значення\n\t\tсеред значень елементiв, розташованих мiж елементами iз заданими номерами.");
            Console.WriteLine("Press 0 to exit");
        }
    }
}
