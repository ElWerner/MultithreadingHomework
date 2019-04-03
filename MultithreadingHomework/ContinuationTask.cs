using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingHomework
{
    public class ContinuationTask
    {
        //Continuation task should be executed regardless of the result of the parent task.
        public void Task1()
        {
            var cancelToken = new CancellationTokenSource();
            var token = cancelToken.Token;

            var task = Task.Run( () => 
            {
                Console.WriteLine("Parent Task starting");

                cancelToken.Cancel();
                token.ThrowIfCancellationRequested();

                Console.WriteLine("Task wasn't cancelled.");

            }, token);

            var task2 = task.ContinueWith((antecedent) =>
            {
                Console.WriteLine("Continuation task starting regardless of the result of the parent task");

                Thread.Sleep(100);

                Console.WriteLine("Continuation task finishing");
            }, TaskContinuationOptions.None);
        }

        //Continuation task should be executed when the parent task finished without success.
        public void Task2()
        {
            var cancelToken = new CancellationTokenSource();
            var token = cancelToken.Token;

            var task = Task.Run(() =>
            {
                Console.WriteLine("Parent Task starting");

                throw new ArgumentNullException();

            }, token);

            var task2 = task.ContinueWith((antecedent) =>
            {
                Console.WriteLine("Continuation task starting when parent task faild");

                Thread.Sleep(100);

                Console.WriteLine("Continuation task finishing");
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        static int i = 1;
        static object lockObj = new object();
        //Continuation task should be executed when the parent task would be finished with fail 
        //and parent task thread should be reused for continuation
        public void Task3()
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine($"Parent Task starting in thread {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(100);
                throw new Exception();
            });


            var task2 = task.ContinueWith((antecedent) =>
            {
                Console.WriteLine($"Continuation task starting when parent task faild in thread {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(100);

                Console.WriteLine("Continuation task finishing");
            }, TaskContinuationOptions.ExecuteSynchronously);
        }

        //Continuation task should be executed outside of the thread pool when the parent task would be cancelled
        public void Task4()
        {
            var cancelToken = new CancellationTokenSource();
            var token = cancelToken.Token;

            var task = Task.Run(() =>
            {
                Console.WriteLine("Parent Task starting");

                cancelToken.Cancel();
                token.ThrowIfCancellationRequested();

                Console.WriteLine("Task wasn't cancelled.");

            }, token);

            var task2 = task.ContinueWith((antecedent) =>
            {
                Console.WriteLine("Continuation task starting when parent task faild");

                Thread.Sleep(100);

                Console.WriteLine("Continuation task finishing");
            }, TaskContinuationOptions.LongRunning | TaskContinuationOptions.OnlyOnCanceled);
        }
    }
}
