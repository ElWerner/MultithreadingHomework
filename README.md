# MultithreadingHomework
Multithreading Homework Tasks

1.	Write a program, which creates a chain of four Tasks. First Task – creates an array of 10 random integer. Second Task – multiplies this array with another random integer. Third Task – sorts this array by ascending. Fourth Task – calculates the average value. All this tasks should print the values to console
2.	Write a program which creates two threads and a shared collection: the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding. Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
3.	Create a Task and attach continuations to it according to the following criteria:
•	Continuation task should be executed regardless of the result of the parent task.
•	Continuation task should be executed when the parent task finished without success.
•	Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation
•	Continuation task should be executed outside of the thread pool when the parent task would be cancelled.
