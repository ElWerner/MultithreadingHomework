using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Write a program which creates two threads and a shared collection: the first one should add 10 elements into
//the collection and the second should print all elements in the collection after each adding. Use Thread, ThreadPool
//or Task classes for thread creation and any kind of synchronization constructions.
namespace MultithreadingHomework
{
    public class ShareCollectionTask
    {
        private static List<int> _list;
        private static object _lockObj = new object();

        public ShareCollectionTask()
        {
            _list = new List<int>();
        }

        public void StartThreads()
        {
            ThreadPool.QueueUserWorkItem(AppendCollection);

            ThreadPool.QueueUserWorkItem(PrintArrayToConsole);
        }

        private void AppendCollection(object state)
        {
            for (int i = 1; i < 11; i++)
            {
                lock (_lockObj)
                {
                    _list.Add(i);
                }

                Thread.Sleep(50);
            }
        }


        private void PrintArrayToConsole(object state)
        {
            int currentCount = -1;

            while(_list.Count != 10)
            {
                lock(_lockObj)
                {
                    if (currentCount != _list.Count)
                    {
                        for (int i = 0; i < _list.Count; i++)
                        {
                            Console.Write(_list[i]);
                        }
                        Console.WriteLine();

                        currentCount = _list.Count;
                    }
                }
            }
        }
    }
}
