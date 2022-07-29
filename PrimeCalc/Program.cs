using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace PrimeCalc
{
    class Program
    {
        
        public static void PrimeHelper(long startF, long endF)
        {

            bool isPrime = true;

            for (long num = startF; num <= endF; num++)
            {
                //if num is 0,1 its not a prime 
                if (num == 1 || num == 0)
                {
                    continue;
                }
                //2 is a prime 
                else if (num == 2)
                {
                    //just for the code to be readable not really needed
                    isPrime = true;
                }
                // we can make the function quiker by remove the cases that already moudulu by 2
                else if (num > 2 && num%2 == 0)
                {
                    isPrime = false;
                }
                //check if there is a divisor in the range till the sqrt of the number
                else {
                    long maxDivisor = (long)Math.Floor(Math.Sqrt(num));

                    for (int i = 3; i <= 1+maxDivisor ; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }      

                if (isPrime)
                {   
                    //if prime we will print to console 
                    if (num != 0 && num != 1)
                    {
                        Console.WriteLine("Thread [" + Thread.CurrentThread.ManagedThreadId.ToString() + "]: " + num.ToString());
                    }
                }
                else
                {
                    isPrime = true;
                    continue;
                }
            }
        }

        
        
        public static void PrimeCalc(long N,long M,long nThreads)
        {
            bool flag = true;
            if (M<N || M>long.MaxValue || N<0 || nThreads > long.MaxValue || nThreads<=0 || nThreads > M-N)
            {
                flag = false;
                Console.WriteLine("inputs not correct");
            }
            if (flag)
            {
                long start = N;
                //the range each thread will check 
                long range = (M - N) / nThreads;

                //array to save the threads for the join at the end 
                Thread[] threads = new Thread[nThreads];

                for (int i = 0; i < nThreads; i++)
                {
                    long end = start + range - 1;

                    //i a matter of the thread not divde in a correct way.
                    if ( i == nThreads - 1 &&  end < M)
                    {
                        end = end + (M - end);
                    }

                    long x = start;
                    long y = end;
                    //making new thread and sending the function of finding the prime number in the range 
                    Thread thread = new Thread(() => Program.PrimeHelper(x,y));
                    threads[i] = thread;
                    
                    thread.Start();
                   
                    start = start + range; //  to update the start for the next thread we will make 
                }

                for (int j = 0; j < nThreads; j++)
                {
                    threads[j].Join();// join on all the thread so we wount miss any thread
                }

                }
        }

        static void Main(string[] args)
        {

           // PrimeCalc(0, 1000000, 10);

            if (Int64.TryParse(args[0], out long N) && Int64.TryParse(args[1], out long M) && Int64.TryParse(args[2], out long nThreads))
            {
                PrimeCalc(N, M, nThreads);
               
            }
            else
            {
                Console.WriteLine("inputs not correct");
            }
            

        }
    }
}
