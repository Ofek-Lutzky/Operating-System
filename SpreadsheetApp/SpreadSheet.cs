using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpreadsheetApp
{
    

    class SpreadSheet
    {
        public static List<List<string>> spreadsheet = new List<List<string>>();
        private int rows;
        private int cols;
        private int users;

        private static Semaphore semaphoreLimit; // check the intial


        public SpreadSheet(int nRows, int nCols, int nUsers = -1)
        { // nUsers used for setConcurrentSearchLimit, -1 mean no limit.
            // construct a nRows*nCols spreadsheet
            this.rows = nRows;
            this.cols = nCols;
            this.users = nUsers;

            setConcurrentSearchLimit(users);


            for (int i = 0; i < this.rows; i++)
            {
                spreadsheet.Add(new List<string>());

                for (int j = 0; j < cols; j++)
                {
                    spreadsheet[i].Add("");
                }
            }


        }

        public int getCols()
        {
            return this.cols;
        }
        public int getRows()
        {
            return this.rows;
        }

        public String getCell(int row, int col)
        {


            string cellData = null;
            try
            {
                if (row < 0 || col < 0 || row >= this.rows || col >= this.cols)
                {

                    throw new Exception("Get wrong index");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            semaphoreLimit.WaitOne();
            Console.WriteLine("Get " + Thread.CurrentThread.ManagedThreadId + " A");

            if (spreadsheet[row][col] != null)
                try
                {
                    lock (spreadsheet[row][col])
                    {

                        try
                        {
                            cellData = spreadsheet[row][col];
                            //if (cellData == null || cellData == "")
                            //    throw new Exception("cell is empty");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("1 " + e.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("1 " + e.Message);
                }
            semaphoreLimit.Release();
            Console.WriteLine("Get " + Thread.CurrentThread.ManagedThreadId + " R");


            return cellData;

        }
        public void setCell(int row, int col, String str)
        {
            try
            {
                if (row < 0 || col < 0 || row >= this.rows || col >= this.cols)
                {
                    throw new Exception("Set wrong index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            semaphoreLimit.WaitOne();
            Console.WriteLine("Set " + Thread.CurrentThread.ManagedThreadId + " A");

            if (spreadsheet[row][col] != null)
                try
                {
                    lock (spreadsheet[row][col])
                    {

                        try
                        {
                            spreadsheet[row][col] = str;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("2 " + e.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("2 " + e.Message);
                }
            Console.WriteLine("Set " + Thread.CurrentThread.ManagedThreadId + " R");
            semaphoreLimit.Release();
            //break;

        }




        public Tuple<int, int> searchString(String str)
        {
            Tuple<int, int> result = null;

            semaphoreLimit.WaitOne();

            Console.WriteLine("Search " + Thread.CurrentThread.ManagedThreadId + " A");

            int row, col;
            int r, c;
            // return first cell indexes that contains the string (search from first row to the last row)
            for (int i = 0; i < this.rows; i++)
            {
                r = i;

                for (int j = 0; j < this.cols; j++)
                {
                    c = j;
                    try
                    {
                        if (spreadsheet[r][c] != null)
                            lock (spreadsheet[r][c])
                            {
                                try
                                {
                                    if (spreadsheet[r][c] == (str))
                                    {

                                        row = i;
                                        col = j;
                                        result = new Tuple<int, int>(row, col);

                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("3 " + e.Message);
                                }

                            }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("3 " + e.Message);
                    }

                }
            }

            if (result == null)
            {
                semaphoreLimit.Release();
                throw new Exception("searchString " + str + "String not Found");
            }


            semaphoreLimit.Release();
            Console.WriteLine("Search " + Thread.CurrentThread.ManagedThreadId + " R");

            //break;


            return result;
        }

        public void exchangeRows(int row1, int row2) // maybe lock the all sheet so if i need to change col it wount happen ,,same to columns change
        {


            try
            {
                if (row1 < 0 || row2 < 0 || row1 >= this.rows || row2 >= this.rows)
                {
                    //outOfRange = true;
                    throw new Exception("Wrong index, out of range");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // exchange the content of row1 and row2
            semaphoreLimit.WaitOne();
            int index = 0;



            Console.WriteLine("exchangeRows " + Thread.CurrentThread.ManagedThreadId + " A");


            for (int i = 0; i < cols; i++)
            {
                String temp = null;
                try
                {
                    if (spreadsheet[row2][i] != null)
                        lock (spreadsheet[row2][i])
                        {
                            try
                            {
                                temp = spreadsheet[row2][i];
                                spreadsheet[row2][i] = spreadsheet[row1][i];
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("4.1 " + e.Message);
                            }
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine("4.1 " + e.Message);
                }

                try
                {
                    if (spreadsheet[row1][i] != null)

                        lock (spreadsheet[row1][i])
                        {
                            try
                            {
                                spreadsheet[row1][i] = temp;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("4.2 " + e.Message);
                            }
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine("4.2 " + e.Message);
                }
            }

            semaphoreLimit.Release();
            Console.WriteLine("exchangeRows " + Thread.CurrentThread.ManagedThreadId + " R");

        }


        public void exchangeCols(int col1, int col2)
        {
            try
            {
                if (col1 < 0 || col2 < 0 || col1 >= this.cols || col2 >= this.cols)
                {
                    throw new Exception("Wrong index, out of range");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            semaphoreLimit.WaitOne();
            // exchange the content of col1 and col2

            int index = 0;

            //int index = 0;
            Console.WriteLine("exchangeCols " + Thread.CurrentThread.ManagedThreadId + " A");



            for (int i = 0; i < rows; i++)
            {
                String temp = null;

                try
                {
                    if (spreadsheet[i][col2] != null)

                        lock (spreadsheet[i][col2])
                        {
                            try
                            {
                                temp = spreadsheet[i][col2];
                                spreadsheet[i][col2] = spreadsheet[i][col1];
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("5.1 " + e.Message);
                            }
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine("5.1 " + e.Message);
                }
                try
                {
                    if (spreadsheet[i][col1] != null)

                        lock (spreadsheet[i][col1])
                        {
                            try
                            {
                                spreadsheet[i][col1] = temp;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("5.2 " + e.Message);
                            }
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine("5.2 " + e.Message);
                }
            }



            semaphoreLimit.Release();
            Console.WriteLine("exchangeCols " + Thread.CurrentThread.ManagedThreadId + " R");

        }

        public int searchInRow(int row, String str)
        {
            int col = -1;

            try
            {
                if (row < 0 || row >= this.rows)
                {
                    throw new Exception("Wrong index, out of range");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // exchange the content of row1 and row2
            semaphoreLimit.WaitOne();

            Console.WriteLine("searchInRow " + Thread.CurrentThread.ManagedThreadId + " A");

            // perform search in specific row
            int index = 0;
            for (int i = 0; i < cols; i++)
            {
                index = i;

                try
                {
                    if (spreadsheet[row][index] != null)

                        lock (spreadsheet[row][index])
                        {
                            try
                            {
                                if (spreadsheet[row][index] == str)
                                {

                                    col = index;

                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("6.1 " + e.Message);
                            }
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine("6.1 " + e.Message);
                }

            }

            semaphoreLimit.Release();
            Console.WriteLine("searchInRow " + Thread.CurrentThread.ManagedThreadId + " R");



            if (col == -1)
                throw new Exception("searchInRow " + str + " String not Found");

            return col;
        }

        public int searchInCol(int col, String str)
        {
            int row = -1;


            try
            {
                if (col < 0 || col >= this.cols)
                {
                    throw new Exception("Wrong index, out of range");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            semaphoreLimit.WaitOne();

            Console.WriteLine("searchInCol " + Thread.CurrentThread.ManagedThreadId + " A");


            // perform search in specific col

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                index = i;
                try
                {

                    lock (spreadsheet[index][col])
                    {
                        try
                        {
                            if (spreadsheet[index][col] == str)
                            {

                                row = index;

                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("7.1 " + e.Message);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("7.1 " + e.Message);
                }




            }
            semaphoreLimit.Release();
            Console.WriteLine("searchInCol " + Thread.CurrentThread.ManagedThreadId + " R");



            if (row == -1)
                throw new Exception("searchInCol" + str + "String not Found");


            return row;
        }

        public Tuple<int, int> searchInRange(int col1, int col2, int row1, int row2, String str)
        {
            Tuple<int, int> result = null;

            int r, c;
            try
            {

                if (row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0 || row1 >= this.rows || row2 >= this.rows || col1 >= this.cols || col2 >= this.cols || (col1 > col2) || (row1 > row2))
                {
                    //outOfRange = true;
                    throw new Exception("Wrong index, out of range" + col2.ToString() + row2.ToString());
                    // break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("8.1 " + e.Message);
            }

            semaphoreLimit.WaitOne();


            // perform search within spesific range: [row1:row2,col1:col2] 
            //includes col1,col2,row1,row2
            for (int i = row1; i <= row2; i++)
            {
                r = i;

                for (int j = col1; j <= col2; j++)
                {
                    c = j;
                    try
                    {
                        if (spreadsheet[r][c] != null)
                            lock (spreadsheet[r][c])
                            {
                                try
                                {
                                    if (spreadsheet[r][c] == (str))
                                    {

                                        result = new Tuple<int, int>(r, c);

                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("8.1 " + e.Message);
                                }
                            }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("8.1 " + e.Message);
                    }
                }
            }




            semaphoreLimit.Release();

            if (result == null)
                throw new Exception("searchInRange" + str + "Not Found in range");


            return result;
        }

        public void addRow(int row1)
        {

            //add a row after row1

            // i think that the aquire writer is enuf for me! it will be valid just if there is no other operation going
            // we can do it more effiecient by lock just the rows after check in the continue*****************
            try
            {
                if (row1 < 0 || row1 >= this.rows)
                {
                    throw new Exception("Set wrong index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            semaphoreLimit.WaitOne();

            Console.WriteLine("addRow " + Thread.CurrentThread.ManagedThreadId + " A");
            try
            {
                lock (spreadsheet)
                {
                    try
                    {

                        List<string> arr = new List<string>();
                        for (int i = 0; i < this.cols; i++)
                        {
                            arr.Add("");
                        }

                        spreadsheet.Insert(row1, arr);



                        this.rows++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("9.1 " + e.Message);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("9.1 " + e.Message);
            }

            semaphoreLimit.Release();
            Console.WriteLine("addRow " + Thread.CurrentThread.ManagedThreadId + " R");

            //break;

        }


        public void addCol(int col1)
        {

            Console.WriteLine("addCol " + Thread.CurrentThread.ManagedThreadId + " A");

            // i think that the aquire writer is enuf for me! it will be valid just if there is no other operation going
            //add a column after col1
            try
            {
                if (col1 < -1 || col1 >= this.cols)
                {
                    throw new Exception("Set wrong index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            semaphoreLimit.WaitOne();


            try
            {

                lock (spreadsheet)
                {
                    try
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            int index = j;
                            spreadsheet[index].Insert(col1, "");
                        }


                        this.cols++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("10.1 " + e.Message);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("10.1 " + e.Message);
            }


            semaphoreLimit.Release();
            Console.WriteLine("addCol " + Thread.CurrentThread.ManagedThreadId + " R");


        }



        public Tuple<int, int>[] findAll(String str, bool caseSensitive)
        {
            List<Tuple<int, int>> founders = new List<Tuple<int, int>>();
            Tuple<int, int>[] result = null;
            int r, c;
            bool sensative = caseSensitive;

            semaphoreLimit.WaitOne();

            Console.WriteLine("findAll " + Thread.CurrentThread.ManagedThreadId + " A");


            // perform search and return all relevant cells according to caseSensitive paramc
            if (!sensative)
            {

                // return first cell indexes that contains the string (search from first row to the last row)
                for (int i = 0; i < this.rows; i++)
                {
                    r = i;

                    for (int j = 0; j < this.cols; j++)
                    {
                        c = j;
                        try
                        {
                            //if(spreadsheet[r][c] != null)
                            lock (spreadsheet[r][c])
                            {
                                try
                                {
                                    if (spreadsheet[r][c] != null)
                                    {
                                        if (spreadsheet[r][c].ToLower() == (str.ToLower()))
                                        {

                                            founders.Add(new Tuple<int, int>(r, c));

                                        }

                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("11.1 " + e.Message);
                                }

                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("11.1 " + e.Message);
                        }
                    }
                }
            }
            else
            {

                // return first cell indexes that contains the string (search from first row to the last row)
                for (int i = 0; i < this.rows; i++)
                {
                    r = i;

                    for (int j = 0; j < this.cols; j++)
                    {

                        c = j;
                        try
                        {
                            if (spreadsheet[r][c] != null)
                                lock (spreadsheet[r][c])
                                {
                                    try
                                    {
                                        if (spreadsheet[r][c] == (str))
                                        {

                                            founders.Add(new Tuple<int, int>(r, c));

                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("11.2 " + e.Message);
                                    }
                                }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("11.2 " + e.Message);
                        }

                    }
                }
            }

            //SpreadSheetMutex.WaitOne();
            if (founders.Count == 0)
            {

                semaphoreLimit.Release();
                throw new Exception("findAll string to find: " + str + " Not Found");

            }

            int index = 0;
            result = new Tuple<int, int>[founders.Count];
            for (int i = 0; i < founders.Count; i++)
            {
                index = i;
                result[index] = founders[index];
            }
            //SpreadSheetMutex.ReleaseMutex();

            semaphoreLimit.Release();
            Console.WriteLine("findAll " + Thread.CurrentThread.ManagedThreadId + " R");

            return result; //Check for not found in
        }


        public void setAll(String oldStr, String newStr, bool caseSensitive)
        {
            int r, c;

            semaphoreLimit.WaitOne();

            Console.WriteLine("setAll " + Thread.CurrentThread.ManagedThreadId + " A");

            // perform search and return all relevant cells according to caseSensitive paramc
            if (!caseSensitive)
            {
                // return first cell indexes that contains the string (search from first row to the last row)
                for (int i = 0; i < this.rows; i++)
                {
                    r = i;
                    for (int j = 0; j < this.cols; j++)
                    {
                        c = j;

                        try
                        {
                            if (spreadsheet[r][c] != null)
                                lock (spreadsheet[r][c])
                                {
                                    try
                                    {
                                        if (spreadsheet[r][c] != null)
                                        {

                                            if (spreadsheet[r][c].ToLower() == (oldStr.ToLower()))
                                            {

                                                spreadsheet[r][c] = newStr;

                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("12.1 " + e.Message);
                                    }

                                }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("12.1 " + e.Message);
                        }
                    }
                }
            }
            else
            {
                // return first cell indexes that contains the string (search from first row to the last row)
                for (int i = 0; i < this.rows; i++)
                {
                    r = i;

                    for (int j = 0; j < this.cols; j++)
                    {

                        c = j;

                        try
                        {
                            if (spreadsheet[r][c] != null)

                                lock (spreadsheet[r][c])
                                {
                                    try
                                    {
                                        if (spreadsheet[r][c] == (oldStr))
                                        {

                                            spreadsheet[r][c] = newStr;

                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("12.2 " + e.Message);
                                    }

                                }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("12.2 " + e.Message);
                        }
                    }

                }
            }

            semaphoreLimit.Release();
            Console.WriteLine("setAll " + Thread.CurrentThread.ManagedThreadId + " R");


        }

        public Tuple<int, int> getSize()
        {
            int nRows = -1;
            int nCols = -1;
            try
            {
                semaphoreLimit.WaitOne();
                try
                {
                    lock (spreadsheet)
                    {
                        nRows = this.rows;
                        nCols = this.cols;
                        // return the size of the spreadsheet in nRows, nCols
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("13 " + e.Message);
                }
                semaphoreLimit.Release();

            }
            catch (Exception e)
            {
                Console.WriteLine("13" + e.Message);
            }

            return new Tuple<int, int>(nRows, nCols); //Check for not found in
        }


        public void setConcurrentSearchLimit(int nUsers)
        {
            // this function aims to limit the number of users that can perform the search operations concurrently.
            // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
            // In this case additional search operations will wait for existing search to finish.
            // This function is used just in the creation
            if (nUsers == -1 || nUsers <= 0)
            {
                semaphoreLimit = new Semaphore(10, 10);
            }
            else
            {
                semaphoreLimit = new Semaphore(nUsers, nUsers);
            } //check for the number already inside the search 

            //SemaphoreSlim slim = new SemaphoreSlim(1, nUsers);
            //slim.CurrentCount == int  ****************************** check about this

            // to do decerease cases 

        }

        public void save(String fileName)
        {
            try
            {
                lock (spreadsheet)
                {
                    try
                    {
                        // i think that the aquire writer is enuf for me! it will be valid just if there is no other operation going
                        int r, c;


                        // save the spreadsheet to a file fileName.
                        // you can decide the format you save the data. There are several options.
                        var CurrentDirectory = Directory.GetCurrentDirectory();
                        //StreamWriter file = new StreamWriter(CurrentDirectory + "\\" + fileName + ".csv");

                        //double[,] data = new double[this.rows, this.cols];

                        using (StreamWriter outfile = new StreamWriter(@CurrentDirectory + "\\" + fileName + ".csv"))
                        {
                            for (int i = 0; i < this.rows; i++)
                            {
                                string content = "";
                                for (int j = 0; j < this.cols; j++)
                                {
                                    content += spreadsheet[i][j] + ",";
                                }
                                outfile.WriteLine(content);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        public void load(String fileName)
        {
            try
            {
                lock (spreadsheet)
                {
                    try
                    {
                        // i think that the aquire writer is enuf for me! it will be valid just if there is no other operation going

                        // load the spreadsheet from fileName
                        // replace the data and size of the current spreadsheet with the loaded data
                        int row = 0;
                        int col = 0;

                        var CurrentDirectory = Directory.GetCurrentDirectory();
                        using (var reader = new StreamReader(@CurrentDirectory + "\\" + fileName + ".csv"))
                        {
                            List<string> listA = new List<string>();
                            List<string> listB = new List<string>();

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                row++;
                                if (values.Length > col)
                                {
                                    col = values.Length;
                                }

                            }
                        }
                        spreadsheet = null;
                        spreadsheet = new List<List<string>>();
                        for (int i = 0; i < row; i++)
                        {
                            spreadsheet.Add(new List<string>());

                            for (int j = 0; j < col; j++)
                            {
                                spreadsheet[i].Add(null);
                            }
                        }
                        // spreadsheet = new string[row][col];


                        //updatre the calue of the row and column
                        this.rows = row;
                        this.cols = col;

                        using (var reader2 = new StreamReader(@CurrentDirectory + "\\" + fileName + ".csv"))
                        {
                            int index = 0;
                            while (!reader2.EndOfStream)
                            {
                                string[] Line = reader2.ReadLine().Split(",");
                                for (int column = 0; column < col; column++)
                                {
                                    spreadsheet[index][column] = Line[column];
                                }
                                //Row++;
                                index++;
                            }
                            //spreadsheet = matrix;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
