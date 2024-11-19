using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Main
    {
        static void Main(string[] args)
        {
            Student student = new Student(new Person("Иван", "Иванов", new DateTime(2000, 1, 1)), Education.Bachelor, 101);
            Console.WriteLine("Метод ToShortString(): " + student.ToShortString());

            Console.WriteLine("Specialist: " + student[Education.Specialist]);
            Console.WriteLine("Bachelor: " + student[Education.Bachelor]);
            Console.WriteLine("SecondEducation: " + student[Education.SecondEducation]);

            student.Person = new Person("Анна", "Смирнова", new DateTime(1999, 5, 23));
            student.Education = Education.Specialist;
            student.GroupNumber = 202;
            Console.WriteLine("Полная информация: " + student.ToString());

            student.AddExams(
                new Exam("Математика", 5, new DateTime(2023, 6, 1)),
                new Exam("Физика", 4, new DateTime(2023, 6, 2)),
                new Exam("Химия", 3, new DateTime(2023, 6, 3))
            );
            Console.WriteLine("После добавления экзаменов: " + student.ToString());

            Console.WriteLine("Введите количество строк и столбцов для массивов, разделенные запятой или пробелом:");
            var input = Console.ReadLine();
            var parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int nrow = int.Parse(parts[0]);
            int ncolumn = int.Parse(parts[1]);
            Console.WriteLine($"Количество строк: {nrow}, Количество столбцов: {ncolumn}");

            int totalElements = nrow * ncolumn;
            Exam[] oneDimArray = new Exam[totalElements];
            Exam[,] twoDimArray = new Exam[nrow, ncolumn];
            Exam[][] jaggedArray = new Exam[nrow][];

            for (int i = 0; i < totalElements; i++)
            {
                oneDimArray[i] = new Exam();
            }

            for (int i = 0; i < nrow; i++)
            {
                jaggedArray[i] = new Exam[ncolumn];
                for (int j = 0; j < ncolumn; j++)
                {
                    twoDimArray[i, j] = new Exam();
                    jaggedArray[i][j] = new Exam();
                }
            }

            int operationsCount = 1000;

            int startTick = Environment.TickCount;
            for (int k = 0; k < operationsCount; k++)
            {
                for (int i = 0; i < oneDimArray.Length; i++)
                {
                    oneDimArray[i].Grade = k % 5 + 1;
                }
            }
            int timeOneDim = Environment.TickCount - startTick;

            startTick = Environment.TickCount;
            for (int k = 0; k < operationsCount; k++)
            {
                for (int i = 0; i < nrow; i++)
                {
                    for (int j = 0; j < ncolumn; j++)
                    {
                        twoDimArray[i, j].Grade = k % 5 + 1;
                    }
                }
            }
            int timeTwoDim = Environment.TickCount - startTick;

            startTick = Environment.TickCount;
            for (int k = 0; k < operationsCount; k++)
            {
                for (int i = 0; i < nrow; i++)
                {
                    for (int j = 0; j < ncolumn; j++)
                    {
                        jaggedArray[i][j].Grade = k % 5 + 1;
                    }
                }
            }
            int timeJagged = Environment.TickCount - startTick;

            Console.WriteLine($"Время выполнения операций с одномерным массивом: {timeOneDim} мс");
            Console.WriteLine($"Время выполнения операций с двумерным прямоугольным массивом: {timeTwoDim} мс");
            Console.WriteLine($"Время выполнения операций с двумерным ступенчатым массивом: {timeJagged} мс");
        }
    }
}

