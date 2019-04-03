using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingHomework
{
    public class Program
    {
        public delegate void PrintArray(int[] array);

        public static void Main(string[] args)
        {
            //Task 1
            ChainTask chainTask = new ChainTask();
            chainTask.RunChain();

            //Task 2
            //ShareCollectionTask shareCollectionTask = new ShareCollectionTask();
            //shareCollectionTask.StartThreads();

            //Task 3 - 1
            ContinuationTask continuationTask = new ContinuationTask();
            continuationTask.Task1();

            //Task 3 - 2
            //continuationTask.Task2();

            //Task 3 - 3
            //continuationTask.Task3();

            //Task 3 - 4
            //continuationTask.Task4();

            Console.ReadLine();
        }
    }
}
