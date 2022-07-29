using System;
using System.Collections.Generic;
using System.Threading;

namespace Simulator
{
    class Program
    {
        static int fileNum = 0;
        static void Main(string[] args)
        {
            if (!Int32.TryParse(args[0],out int result) || !Int32.TryParse(args[1], out int result1) || !Int32.TryParse(args[2], out int result2) || !Int32.TryParse(args[3], out int result3) || !Int32.TryParse(args[4], out int result4))
            {
                Console.WriteLine("Input is not valid!");
                return;
            }
            int rows = Int32.Parse(args[0]);
            int cols = Int32.Parse(args[1]);
            int nThreads = Int32.Parse(args[2]);
            int nOperations = Int32.Parse(args[3]);
            int mssleep = Int32.Parse(args[4]);

            runThreads(rows, cols, nThreads, nOperations, mssleep);
            
        }


        private static void runThreads(int row, int col, int nThreads, int nOperations, int mssleep)
        {
            SpreadSheet s = new SpreadSheet(row, col, nThreads);

            //s.load(*FileName*);

            Thread[] threads = new Thread[nThreads];

            for (int i= 0; i<nThreads; i++) // making thread for users  
            {
                threads[i] = new Thread(() => operationsPeek(s ,row, col, nOperations, mssleep));
                threads[i].Start();
                Thread.Sleep(mssleep);
            }

            for (int i = 0; i < nThreads; i++) // join
            {
                threads[i].Join();
            }

        }

        private static void operationsPeek(SpreadSheet s, int row, int col, int nOperations, int mssleep)
        {
            int[] opertionToDo = new int[nOperations];
            Random rnd = new Random();

            for (int i = 0; i < opertionToDo.Length; i++)
            {
                opertionToDo[i] = rnd.Next(1, 14); // 1-13
            }

            int r, c;
            for (int i = 0; i < opertionToDo.Length; i++) // join
            {
                r = rnd.Next(0, row);
                c = rnd.Next(0, col);

                switch (opertionToDo[i])
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("getCell " + Thread.CurrentThread.ManagedThreadId + " Start Function");
                            string cell = s.getCell(r, c);
                            Console.WriteLine(cell);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        try { 
                        Console.WriteLine("setCell " + Thread.CurrentThread.ManagedThreadId + " Start Function");
                        s.setCell(r, c, r.ToString());
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        try { 
                        Console.WriteLine("searchString " + Thread.CurrentThread.ManagedThreadId + " Start Function");
                        Tuple<int,int> T = s.searchString(r.ToString());
                        Console.WriteLine("R: " +T.Item1.ToString()+ "C: " + T.Item2.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        try { 
                        Console.WriteLine("exchangeRows " + Thread.CurrentThread.ManagedThreadId + " Start Function");
                        int rr = rnd.Next(0, row);
                        s.exchangeRows(r, rr);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("exchangeCols " + Thread.CurrentThread.ManagedThreadId + " Start Function");
                            int rc = rnd.Next(0, col);
                            s.exchangeCols(c, rc);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("searchInRow " + Thread.CurrentThread.ManagedThreadId + " Start Function");
                            int index = s.searchInRow(r, r.ToString());
                            Console.WriteLine(index.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            Console.WriteLine("searchInRow " + Thread.CurrentThread.ManagedThreadId + " Start Function"); 
                            int index = s.searchInRow(c, c.ToString());
                            Console.WriteLine(index.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 8:
                        try
                        {
                            Console.WriteLine("searchInRange " + Thread.CurrentThread.ManagedThreadId + " Start Function");

                            int rr1 = rnd.Next(r, row);
                            int rc1 = rnd.Next(c, col);

                            Tuple<int, int> T = s.searchInRange(c, rc1, r, rr1, rr1.ToString());
                            Console.WriteLine("R: " + T.Item1.ToString() + "C: " + T.Item2.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 9:
                        try
                        {
                            Console.WriteLine("addRow " + Thread.CurrentThread.ManagedThreadId + " Start Function");

                            s.addRow(r);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 10:
                        try { 
                        Console.WriteLine("addCol " + Thread.CurrentThread.ManagedThreadId + " Start Function");

                        s.addCol(c);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 11:
                        try { 
                        Console.WriteLine("findAll " + Thread.CurrentThread.ManagedThreadId + " Start Function");

                        bool[] arr = new bool[] { true, false };
                        bool rndBool = arr[rnd.Next(0, 2)];
                        Tuple<int,int>[] TA = s.findAll(r.ToString(), rndBool);
                            Console.WriteLine("findAll length" + TA.Length.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 13:
                        try { 
                        Console.WriteLine("setAll " + Thread.CurrentThread.ManagedThreadId + " Start Function");

                        bool[] arr1 = new bool[] { true, false };
                        bool rndBool1 = arr1[rnd.Next(0, 2)];
                        s.setAll(r.ToString(), c.ToString(), rndBool1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 14:
                        try { 
                        Console.WriteLine("getSize " + Thread.CurrentThread.ManagedThreadId + " Start Function");

                        s.getSize();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    //default:
                    //    // code block
                    //    break;
                }
                Thread.Sleep(mssleep);


            }
            //s.save("temp" + fileNum.ToString());
            //fileNum++;
            //Thread.Sleep(500);
        }





        //SpreadSheet s = new SpreadSheet(rows, cols, nThreads);

        //***********************************************************
        //SpreadSheet s = new SpreadSheet(4, 4, 3);

        //// Add to cell
        //s.setCell(0, 0, "hello");
        //s.setCell(3, 2, "findMe");
        ////Print value in cell
        //Console.WriteLine(s.getCell(0, 0));
        //// Search string in cell
        //Console.WriteLine(s.searchString("findMe")); // 3,2
        //Console.WriteLine(s.searchString("fi")); // -1,-1
        //// change rows + search
        //s.exchangeRows(0, 3);
        //Console.WriteLine(s.searchString("findMe")); // 0,2
        //// change cols + search
        //s.exchangeCols(0, 3);
        //Console.WriteLine(s.searchString("hello")); // 3,3
        ////search in row get col
        //Console.WriteLine(s.searchInRow(0, "findMe")); // 2
        //// search in col get row
        //Console.WriteLine(s.searchInCol(2, "findMe")); // 0
        //// Search in range
        //Console.WriteLine(s.searchInRange(0, 3, 2, 3, "hello")); // 3,3
        //Console.WriteLine(s.searchInRange(0, 2, 2, 2, "hello")); // -1,-1
        //// add new row
        //s.addRow(0);
        //s.addRow(0);
        //// add new col
        //s.addCol(0);
        //s.addCol(0);
        //// Find all
        //Tuple<int, int>[] ret = s.findAll("Hello", true);
        //Console.WriteLine(ret[0]); // -1,-1
        //Tuple<int, int>[] ret1 = s.findAll("Hello", false);
        //Console.WriteLine(ret1[0]); // find 5,5
        //// change all cell
        //s.setAll("Hello", "olleh", true); // no change
        //s.setAll("findme", "olleh", false); // change
        //// Get size
        //Console.WriteLine(s.getSize()); // 6,6
        //// Save to CSV
        ////s.save("test");
        //////Load from CSV
        ////s.load("test");

        //*********************************************************

        //private void run(SharableSpreadSheet s, int nThreads, int nOperations, int mssleep)
        //{

        //}




    }
}



//Thread[] threadsSet = new Thread[8];
//Thread[] threadsGet = new Thread[8];
//string[] gets = new string[8];

//Thread[] threadsSearch = new Thread[8];
//Tuple<int, int>[] tuples = new Tuple<int, int>[8];
//Thread[] threadsExchangeRow = new Thread[8];
//Thread[] threadsExchangeCol = new Thread[8];
//Thread[] threadsSearchRow = new Thread[8];
//int[] searchRow = new int[8];
//Thread[] threadsSearchCol = new Thread[8];
//int[] searchCol = new int[8];
//Tuple<int, int>[] tuplesInRange = new Tuple<int, int>[8];
//Thread[] threadsSearchInRange = new Thread[8];
//Thread[] threadsAddRow = new Thread[8];
//Thread[] threadsAddCol = new Thread[8];
//Thread[] threadsFindAll = new Thread[8];
//List<Tuple<int, int>[]> results = new List<Tuple<int, int>[]>();
//Thread[] threadsSetAll = new Thread[8];



//for (int i = 0; i < 8; i++)
//{
//    int num = i;
//    threadsSet[num] = new Thread(() => s.setCell(num, num, num.ToString()));
//    threadsSet[num].Start();


//    int num1 = i;
//    threadsGet[num1] = new Thread(() => gets[num1] = s.getCell(num1, num1));
//    threadsGet[num1].Start();



//    int num2 = i;
//    threadsSearch[num2] = new Thread(() => tuples[num2] = s.searchString(num2.ToString()));
//    threadsSearch[num2].Start();
//    ////Thread.Sleep(50);

//    ///////////////////////////////////////////////////////// Do Something 
//    if (num2 % 2 == 0)
//    {
//        int num3 = i;
//        threadsExchangeRow[i] = new Thread(() => s.exchangeRows(num3, num3 + 1));
//        threadsExchangeRow[i].Start();
//        Thread.Sleep(50);

//        int num4 = i;
//        threadsExchangeCol[i] = new Thread(() => s.exchangeCols(num4, num4 + 1));
//        threadsExchangeCol[i].Start();
//        Thread.Sleep(50);

//    }
//    ////////////////////////////////////////////////////////////

//    int num5 = i;
//    threadsSearchRow[num5] = new Thread(() => searchRow[num5] = s.searchInRow(num5, num5.ToString()));
//    threadsSearchRow[num5].Start();

//    int n = i;
//    threadsSearchCol[n] = new Thread(() => searchCol[n] = s.searchInCol(n, n.ToString()));
//    threadsSearchCol[n].Start();
//    ////Thread.Sleep(500);

//    int num6 = i;
//    threadsSearchInRange[num6] = new Thread(() => tuplesInRange[num6] = s.searchInRange(num6, num6 + 1, num6, num6 + 1, num6.ToString()));
//    threadsSearchInRange[num6].Start();
//    ////Thread.Sleep(500);


//    if (i % 3 == 0)
//    {
//        int num7 = i;
//        threadsAddRow[num7] = new Thread(() => s.addRow(num7));
//        threadsAddRow[num7].Start();
//        //Thread.Sleep(50);


//        threadsAddCol[num7] = new Thread(() => s.addCol(num7));
//        threadsAddCol[num7].Start();
//        //Thread.Sleep(50);
//    }

//    int num8 = i;
//    threadsFindAll[num8] = new Thread(() => results.Add(s.findAll(num8.ToString(), false)));
//    threadsFindAll[num8].Start();
//    //Thread.Sleep(50);

//    threadsSetAll[num8] = new Thread(() => s.findAll(num8.ToString(), false));
//    threadsSetAll[num8].Start();

//}


//for (int i = 0; i < 8; i++)
//{

//    threadsSet[i].Join();
//    threadsGet[i].Join();
//    Console.WriteLine(gets[i]);
//    threadsSearch[i].Join();
//    //
//    if (i % 2 == 0)
//    {
//        threadsExchangeRow[i].Join();
//        threadsExchangeCol[i].Join();
//    }



//    threadsSearchRow[i].Join();
//    threadsSearchCol[i].Join();
//    threadsSearchInRange[i].Join();
//    if (i % 3 == 0)
//    {
//        threadsAddRow[i].Join();
//        threadsAddCol[i].Join();
//    }
//    threadsFindAll[i].Join();
//    threadsSetAll[i].Join();


//    Console.WriteLine(tuples[i]);

//    Console.WriteLine(searchRow[i]);
//    Console.WriteLine(searchCol[i]);

//    Console.WriteLine(tuplesInRange[i]);

//    if (results[i] != null)
//        Console.WriteLine(results[i].Length);

//                // Thread.Sleep(500);