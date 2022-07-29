using System;
using System.Threading;

namespace ThreadedBinarySearchTree
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    ThreadedBinarySearchTree tree = new ThreadedBinarySearchTree();

        //    //simulation

        //    Thread[] threadsInsert = new Thread[100];
        //    Thread[] threadsPrint = new Thread[100];
        //    Thread[] threadsDelete = new Thread[100];
        //    Thread[] threadsSearch = new Thread[100];
        //    Thread[] threadsClear = new Thread[100];

        //    bool[] toprint = new bool[100];

        //    for (int i = 0; i < 100; i++)
        //    {
        //        int num = i;
        //        threadsInsert[i] = new Thread(() => tree.add(num));
        //        threadsInsert[i].Start();

        //        if (i % 2 == 0)
        //        {
        //            int num1 = i;
        //            threadsDelete[i] = new Thread(() => tree.remove(num1));
        //            threadsDelete[i].Start();
        //        }


        //        threadsSearch[i] = new Thread(() => toprint[num] = tree.search(num));
        //        threadsSearch[i].Start();

        //        if (i % 49 == 0)
        //        {
        //            threadsClear[i] = new Thread(() => tree.clear());
        //            threadsClear[i].Start();
        //        }

        //        threadsPrint[i] = new Thread(() => tree.print());
        //        threadsPrint[i].Start();

        //    }


        //    for (int i = 0; i < 100; i++)
        //    {
        //        threadsInsert[i].Join();
        //        if (i % 2 == 0)
        //        {
        //            threadsDelete[i].Join();
        //        }
        //        threadsSearch[i].Join();
        //        if (i % 49 == 0)
        //        {
        //            threadsClear[i].Join();
        //        }

        //        Console.WriteLine(toprint[i]);

        //        threadsPrint[i].Join();


        //    }
        //    tree.print();


            //ThreadedBinarySearchTree tbst = new ThreadedBinarySearchTree();
            //tbst.add(75);
            //tbst.add(57);
            //tbst.add(7);
            //tbst.add(75);
            //tbst.add(90);
            //tbst.add(32);
            //tbst.add(7);
            //tbst.add(44);
            //tbst.add(60);
            //tbst.add(86);
            //tbst.add(93);
            //tbst.add(99);

            //Console.WriteLine("after add, number of nodes");

            //tbst.print();
            //Console.WriteLine("");
            //tbst.remove(5);
            //tbst.remove(75);
            //Console.WriteLine("");
            //Console.WriteLine("after remove");
            //tbst.print();
            //Console.WriteLine("\n");

            //tbst.clear();
            //Console.WriteLine("clear all nodes");
            //tbst.print();
            //Console.WriteLine("\n\tTest2\n");

            ///////////////////////////////////////////////////////////////


            //tbst.add(3);
            //tbst.add(23);
            //tbst.add(0);
            //tbst.add(201);
            //tbst.add(5);
            //tbst.add(40);
            //tbst.add(1);
            //tbst.add(-15);
            //tbst.add(89);
            //Console.WriteLine("after add");
            //tbst.print();
            //Console.WriteLine("");

            //Console.WriteLine("search 75: {0}", tbst.search(75));
            //Console.WriteLine("search 40: {0}", tbst.search(40));
            //tbst.clear();
            //Console.WriteLine("clear all number of nodes ");
            //tbst.print();

            //Console.WriteLine("\n\tTest3\n");

            //Random r = new Random();
            //bool ret;
            //bool ret1;
            //bool ret2;
            //for (int j = 0; j < 40; j++)
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread thread = new Thread(() => tbst.add(r.Next(5000)));
            //        thread.Start();
            //    }

            //    tbst.add(3);
            //    ret = false;
            //    ret1 = false;
            //    ret2 = false;
            //    for (int i = 0; i < 1; i++)
            //    {
            //        Thread thread = new Thread(() => tbst.add(100));
            //        thread.Start();
            //        Thread newThread1 = new Thread(() => ret = tbst.search(100));
            //        newThread1.Start();
            //        Thread newThread2 = new Thread(() => tbst.remove(100));
            //        newThread2.Start();
            //        Thread newThread3 = new Thread(() => ret1 = tbst.search(100));
            //        newThread3.Start();
            //        Thread newThread4 = new Thread(() => tbst.remove(r.Next(5000)));
            //        newThread4.Start();
            //        Thread newThread7 = new Thread(() => tbst.clear());
            //        newThread7.Start();
            //        Thread newThread5 = new Thread(() => tbst.add(7));
            //        newThread5.Start();
            //        Thread newThread6 = new Thread(() => ret2 = tbst.search(1));
            //        newThread6.Start();
            //    }
            //    Thread.Sleep(1000);
            //    Console.WriteLine(ret);
            //    Console.WriteLine(ret1);
            //    Console.WriteLine(ret2);
            //    tbst.print();
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread thread = new Thread(() => tbst.add(r.Next(5000)));
            //    thread.Start();
            //}

            //tbst.add(3);
            //ret = false;
            //ret1 = false;
            //ret2 = false;
            //for (int i = 0; i < 1; i++)
            //{
            //    Thread thread = new Thread(() => tbst.add(100));
            //    thread.Start();
            //    Thread newThread1 = new Thread(() => ret = tbst.search(100));
            //    newThread1.Start();
            //    Thread newThread2 = new Thread(() => tbst.remove(100));
            //    newThread2.Start();
            //    Thread newThread3 = new Thread(() => ret1 = tbst.search(100));
            //    newThread3.Start();
            //    Thread newThread4 = new Thread(() => tbst.remove(r.Next(5000)));
            //    newThread4.Start();
            //    Thread newThread7 = new Thread(() => tbst.clear());
            //    newThread7.Start();
            //    Thread newThread5 = new Thread(() => tbst.add(7));
            //    newThread5.Start();
            //    Thread newThread6 = new Thread(() => ret2 = tbst.search(1));
            //    newThread6.Start();
            //}
            //Thread.Sleep(1000);
            //Console.WriteLine(ret);
            //Console.WriteLine(ret1);
            //Console.WriteLine(ret2);
            //tbst.print();

        
            public static int nThreads;
            public static int nOperations;
            public static int mssleep;
            public static Thread[] threads;
            public static ThreadedBinarySearchTree tree;
            static void Main(string[] args)
            {
                nThreads = 500;
                nOperations = 10;
                mssleep = 10;
                threads = new Thread[nThreads];
                tree = new ThreadedBinarySearchTree();

                for (int i = 0; i < nThreads; i++)
                {
                    threads[i] = new Thread(() => { ThreadWork(); });
                }
                foreach (Thread th in threads) { th.Start(); }
                foreach (Thread th in threads) { th.Join(); }
            }

            private static void ThreadWork()
            {
                int num;
                int threadId = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < nOperations; i++)
                {
                    Random myRand = new Random();
                    //########################################
                    int Operations = myRand.Next(5);
                    //########################################
                    switch (Operations)
                    {
                        case 0: //add
                            num = myRand.Next(100);
                            tree.add(num);
                            Console.WriteLine("Thread[{0}]: add--------the num {1}", threadId, num);
                            break;
                        case 1: //clear
                            tree.clear();
                            Console.WriteLine("Thread[{0}]: clear------the tree", threadId);
                            break;
                        case 2: //remove
                            num = myRand.Next(100);
                            tree.remove(num);
                            Console.WriteLine("Thread[{0}]: remove-----try to remove the num {1}", threadId, num);
                            break;
                        case 3: //search
                            num = myRand.Next(100);
                            bool b = tree.search(num);
                            if (b)
                            {
                                Console.WriteLine("Thread[{0}]: search-----find the num {1}", threadId, num);
                            }
                            else
                            {
                                Console.WriteLine("Thread[{0}]: search-----Notfind the num {1}", threadId, num);
                            }
                            break;
                        case 4: //print
                            tree.print();
                            Console.WriteLine("Thread[{0}]: print-----print the tree", threadId);
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(mssleep);
                }
            }
        }
    }

