using System;
using System.Collections.Generic;
using System.Linq;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] line = Console.ReadLine().Split();
            int n = int.Parse(line[0]);
            int k = int.Parse(line[1]);
            byte[] kOfStudents = new byte[n + 1];
            int[] students = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                kOfStudents[i] = byte.Parse(Console.ReadLine());
                students[i] = i + 1;
            }
            students[n] = 1;//Т.е. след като стигнем до последния индекс, започваме да броим от елемента, който стои на първия индекс
            int counter = 1;//Започваме от индекс 1, където е първия ученик, все едно него вече сме го преброили
            //PrintStudents(students);
            for (int i = 1; i <= n - 1; i++)
            {//Трябва да махнем точно n - 1 ученика, за да остане последния
                for (int j = 2; j < k; j++)
                {//К неможе да е по малко от 2, а ако е равно на 2 то counter-а вече сочи към индекса на елемента, който да вземем
                    //Този цикъл ще се изпълни колкото е разликата между K и 2
                    counter = students[counter];//Взимаме следващите индекси до К - 1
                    //Т.е. брояча ни пази индеса на ученика, който пази индекса на следващия ученик
                }
                //Взимаме индекса, към който сочи counter-a и "премахваме" ученика на него
                int removeStudentIndex = students[counter];
                k = kOfStudents[removeStudentIndex];//Запазваме К-номера на ученика
                students[counter] = students[removeStudentIndex];
                //Ученика до който е стигнал брояча просто взима адреса, 
                //към който е сочил ученика който сме извадили, щом не се реферира, 
                //то "извадения" ученик няма и да се преброява
                counter = students[removeStudentIndex];//Брояча преброява следващия елемент след "извадения"
            }
            Console.WriteLine(counter);
        }

        static int GetNumbers(string input)
        {
            int y = 0;
            for (int i = 0; i < input.Length; i++)
            {
                y = y * 10 + (input[i] - '0');
            }
            return y;
        }
    }
}