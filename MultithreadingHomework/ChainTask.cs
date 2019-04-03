using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MultithreadingHomework.Program;

//Write a program, which creates a chain of four Tasks.First Task – creates an array of 10 random integer.
//Second Task – multiplies this array with another random integer.Third Task – sorts this array by ascending.Fourth
//Task – calculates the average value. All this tasks should print the values to console
namespace MultithreadingHomework
{
    public class ChainTask
    {
        private Random _rand;

        public ChainTask()
        {
            _rand = new Random();
        }

        public void RunChain()
        {
            var task1 = Task.Run(() =>
            {
                int[] array = new int[10];

                for (int i = 0; i < 10; i++)
                {
                    array[i] = _rand.Next(1, 20);
                }
                PrintArrayToConsole(array);

                return array;
            });

            var task2 = task1.ContinueWith(antecedent =>
            {
                int[] array = antecedent.Result;

                int someIntToMultipleArray = _rand.Next(1, 10);

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] *= someIntToMultipleArray;
                }
                PrintArrayToConsole(array);

                return array;
            });

            var task3 = task2.ContinueWith(antecedent =>
            {
                int[] array = antecedent.Result;

                Array.Sort<int>(array);

                PrintArrayToConsole(array);

                return array;
            });

            var task4 = task3.ContinueWith(antecedent =>
            {
                int[] array = antecedent.Result;

                double average = array.Average();

                Console.WriteLine(average);
            });
        }

        private void PrintArrayToConsole(int[] array)
        {
            foreach (var item in  array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
