using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MultiThreadedSearch
{
    class Program
    {
        //flag for the case we didn't found anything
        static bool found = false;

        //this method called when the Search Func Out Of the Thread
        public static void SearchFuncOutOfThread(object args)
        {      
            object[] array = args as object[];
            List<string> text = (List<string>)array[0]; // the full text
            string toSearch = (string)array[1]; // the word we search
            int startedRow = (int)array[2]; // the row in the text we are looking
            int delta = (int)array[3];
            int charIndex = (int)array[4]; // the index of the first char that match to the toSearch

            string line = text[startedRow] + "\n";
            if (line[charIndex] == toSearch[0])
            {
                int lineNumJump = startedRow;
                bool flagForSearchingWord = true;
                //bool flagForOutOfThread = false;
                int deltaJump = charIndex;
                int indexInToSearch = 0;
                while (lineNumJump < text.Count)
                {
                    while (indexInToSearch < toSearch.Length)//while to remember the last place/char we were in the word 
                    {
                        if (deltaJump >= line.Length)
                        {
                            break;
                        }

                        if (!(line[deltaJump] == toSearch[indexInToSearch]))
                        {
                            flagForSearchingWord = false;
                            break;
                        }
                        deltaJump = deltaJump + delta + 1;// maybe don't need the plus one but if not then i need to think if delta is 0;
                        indexInToSearch++;
                    }
                    if (flagForSearchingWord)
                    {
                        if (deltaJump >= line.Length)
                        {
                            lineNumJump++;
                            if (lineNumJump >= text.Count)
                            {
                                // flagForOutOfThread = true;
                                break;//check if needed
                            }


                            //the left of the jump
                            deltaJump = deltaJump - line.Length;
                            //update the line to be the next line
                            line = text[lineNumJump] + "\n";
                            //check for a word that spread on the other lines
                            continue;
                        }
                        else
                        {

                            Console.WriteLine(String.Format("[{0},{1}]", (startedRow).ToString(), (charIndex).ToString()));
                            found = true;
                            break;


                        }

                    }
                    else { break; }

                }

            }


            }


        public static void SearchFunc(object args)
        {
            object[] array = args as object[];
            List<string> text = (List<string>)array[0];
            string toSearch = (string)array[1];
            int startedRow = (int)array[2];
            int delta = (int)array[3];
            List<string> fullText = (List<string>)array[4];


           // Console.WriteLine("start " + startedRow + "range " + (startedRow + text.Count -1));

            //will count the identical char of the toSearch string in the line 
            for (int j = 0; j < text.Count; j++)
            {
                string line = text[j] + "\n"; // i did it becuase the split made us remove the \n help us.
                int i = 0;
                for (; i < line.Length; i++)
                {

                        if (line[i] == toSearch[0])
                        {
                        //if the first char is the same as the string we will do the next steps:
                        //we will do a flagForSearchingWord to sign us if we found unmatched char 
                        // and another flagForOutOfThread that will sign if we might have the word complite but in other thread
                        //loop till we have more lines:
                        //we will loop that go on the search word and checks by jump of delta on the text 
                        //if all the char were true but didnt complite the word the deltajump will remain the deltaJump = deltaJump-line.Length;
                        //and we jump to next line
                        // if we see that we out of thread send to another func that will go threw the lines that the search word can be on the fullText
                            int lineNumJump = j;
                            bool flagForSearchingWord = true;
                            bool flagForOutOfThread = false;
                            int deltaJump = i;
                            int indexInToSearch = 0;
                            while(lineNumJump<text.Count){
                                while (indexInToSearch < toSearch.Length)//while to remember the last place/char we were in the word 
                                {
                                    if (deltaJump >= line.Length)
                                    {
                                        break;
                                    }

                                    if (!(line[deltaJump] == toSearch[indexInToSearch]))
                                    {
                                        flagForSearchingWord = false;
                                        break;
                                    }
                                    deltaJump = deltaJump + delta +1;// maybe don't need the plus one but if not then i need to think if delta is 0;
                                    indexInToSearch++;
                                }
                                if (flagForSearchingWord)
                                {
                                    if (deltaJump >= line.Length)
                                    {
                                        lineNumJump++;
                                        if (lineNumJump >= text.Count)
                                        {
                                            flagForOutOfThread = true;
                                            break;//check if needed
                                        }


                                        //the left of the jump
                                        deltaJump = deltaJump-line.Length;
                                        //update the line to be the next line
                                        line = text[lineNumJump] + "\n";
                                        //check for a word that spread on the other lines
                                    continue;
                                    }
                                    else
                                    {  
                                        Console.WriteLine(String.Format("[{0},{1}]", (startedRow + j).ToString(), (i).ToString()));
                                    found = true;
                                    break;
                                }

                                }
                            else { break; }
                                
                            }
                            if (flagForOutOfThread) {
                                SearchFuncOutOfThread(new object[] { fullText, toSearch, j + startedRow, delta, i });
                                break;//check if needed
                        }
                        }
                    }

                }          
                
            }
                            

        public static void SearchWithThread(string textURL, string toSearch, int nThreads, int delta)
        {
            //the file we will write to him if we want
            //StreamWriter sW = new StreamWriter("SearchWithThread.txt", true);

            //textURL to text
            string text = null;
            try
            {
                text = File.ReadAllText(textURL).Replace("\r", "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            //just for the tests
            //string text = textURL.Replace("\r", "");

            //first i will split the text so it will be easy to work
            List<string> textByLines = new List<string>(text.Split('\n'));

            // i will check how much each section of text each thread will work on.
            int startLineIndex = 0;
            if (nThreads <= 0)
            {
                return;
            }
            // to fix situation when there is nuumber that not dived exactly all the range
            int linesEachThread = textByLines.Count / nThreads;

            Thread[] threads = new Thread[nThreads];


               //we will make nThreads each with its owen section 
            for (int i = 0; i < nThreads; i++)
            {
                
                //for the case that the text not divide right 
                if (i == nThreads - 1 && (startLineIndex + linesEachThread-1) < textByLines.Count-1)
                {
                    linesEachThread = textByLines.Count -1 - (startLineIndex + linesEachThread) + linesEachThread; // i want to add the range that left to the end for the last thread
                }


                int x = startLineIndex;// the thread can change the original value so i will save it in var so it wount change when sending and making another threads
                int y = linesEachThread;

                //Console.WriteLine(" Before start " + startLineIndex + "range " + (startLineIndex + y-1));
                List<string> textToSend = textByLines.GetRange(x, y);
                Thread thread = new Thread(() => SearchFunc(new object[] { textToSend, toSearch, x, delta, textByLines }));
                
                threads[i] = thread;
                threads[i].Start();

                startLineIndex = startLineIndex + linesEachThread;
            }

            // join on all the text
            for (int j = 0; j< nThreads; j++)
            {
                threads[j].Join();
            }

            if (!found)
            {
                Console.WriteLine("Not found.");
            }
            

        }

        static void Main(string[] args)
        {
            string textFile;
            string toSearch;
            int nThreads;
            int delta;
            bool goodInput = false;

            if (args.Length == 4)
            {
                // make the path to be raw replace("\", "\\")
                
                textFile = @args[0];
                toSearch = args[1];// the string we neeed to search for 

                //try to parse to check if the input of the number is correct
                if (Int32.TryParse(args[2], out int result) && Int32.TryParse(args[3], out int d))
                {
                    nThreads = result;
                    delta = d;
                    Program.SearchWithThread(textFile, toSearch, nThreads, delta);
                    goodInput = true;
                } }


            if (!goodInput) // if the input not good it will print to console
            {
                Console.WriteLine("Input Not Good!");
            }
            


            // Tests for us!

           //string text1 = "Contents CHA\n" + "CHAPTER I.Down the CHAPTER Rabbit - HoleCHA\r\n" + "TCHAPTER II.    The Pool of Tears\n" + "CHAPTERCHAPTER III.   A Caucus-Race and a Long TaleCHA";

            //string path = "C:\Users\ofek2\Desktop\Work2\MultiThreadedSearch\checkFileThreading.txt";

           // Program.SearchWithThread(text1, "CT", 1, 3);// "checkFileThreading.txt"  
            //Program.SearchWithThread("checkFileThreading.txt", "CHAPTER", 10, 0);
            /*for (int i = 0; i < outOfThreds.Count; i++)
            {
                Console.WriteLine(outOfThreds[i][0].ToString() + outOfThreds[i][1].ToString());
            }*/
        }
    }
}

