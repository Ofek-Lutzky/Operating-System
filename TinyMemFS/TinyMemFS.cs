using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

class TinyMemFSClass
{ //private static int numOfEncreapt = 0;
    public Dictionary<String, MyFile> MyTiny;

    private Dictionary<String, MyFile> MyTinyHidden;


    public TinyMemFSClass()
    {
        // constructor
        MyTiny = new Dictionary<string, MyFile>();
        MyTinyHidden = new Dictionary<string, MyFile>();
    }
    public bool add(String fileName, String fileToAdd)
    {
        // fileName - The name of the file to be added to the file system
        // fileToAdd - The file path on the computer that we add to the system
        // return false if operation failed for any reason
        // Example:
        // add("name1.pdf", "C:\\Users\\user\Desktop\\report.pdf")
        // note that fileToAdd isn't the same as the fileName
        try
        {
            lock (MyTiny)
            {
                if (!File.Exists(fileToAdd)) // maybe add checks if it is already inside our hash 
                {
                    throw new Exception();
                }

                byte[] data = File.ReadAllBytes(fileToAdd); // get the data in bytes

                FileInfo fileInfo = new FileInfo(fileToAdd); // getting the file info

                long size = fileInfo.Length;
                Tuple<double, DateTime, byte[], int> Info =
                    new Tuple<double, DateTime, byte[], int>(fileInfo.Length / 1024, fileInfo.CreationTime, data, 0); // making a new tuple to save in the system

                MyFile toAdd = new MyFile(fileName);
                toAdd.MyTiny = Info;

                MyTiny.Add(fileName, toAdd); // add to the hash 
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }
    public bool remove(String fileName)
    {
        // fileName - remove fileName from the system
        // this operation releases all allocated memory for this file
        // return false if operation failed for any reason
        // Example:
        // remove("name1.pdf")

        lock (MyTiny)
        {
            if (!MyTiny.ContainsKey(fileName))
            {
                return false;
            }

            MyTiny.Remove(fileName);
        }



        return true;
    }
    public List<String> listFiles()
    {
        // The function returns a list of strings with the file information in the system
        // Each string holds details of one file as following: "fileName,size,creation time"
        // Example:{
        // "report.pdf,630KB,Friday, ‎May ‎13, ‎2022, ‏‎12:16:32 PM",
        // "table1.csv,220KB,Monday, ‎February ‎14, ‎2022, ‏‎8:38:24 PM" }
        // You can use any format for the creation time and date
        List<String> files = new List<string>();
        try
        {
            lock (MyTiny)
            {
                foreach (string key in MyTiny.Keys)
                {

                    files.Add(key + "," + MyTiny[key].MyTiny.Item1 + "," + MyTiny[key].MyTiny.Item2 + "," + BytesToString(MyTiny[key].MyTiny.Item3) + "," + MyTiny[key].MyTiny.Item4);
                }
            }
        }
        catch (Exception)
        {
            return files;
        }

        return files;
    }
    public bool save(String fileName, String fileToAdd)
    {
        // this function saves file from the TinyMemFS file system into a file in the physical disk
        // fileName - file name from TinyMemFS to save in the computer
        // fileToAdd - The file path to be saved on the computer
        // return false if operation failed for any reason
        // Example:
        // save("name1.pdf", "C:\\tmp\\fileName.pdf")
        if (!MyTiny.ContainsKey(fileName))
        {
            return false;
        }

        // if the file already encrypt it is ok! save it as it is
        //IO writing

        try
        {
            lock (MyTiny)
            {
                File.WriteAllBytes(fileToAdd, MyTiny[fileName].MyTiny.Item3);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }


        return true;
    }
    public bool encrypt(String key)
    {
        // key - Encryption key to encrypt the contents of all files in the system 
        // You can use an encryption algorithm of your choice
        // return false if operation failed for any reason
        // Example:
        // encrypt("myFSpassword")

        if (key == null)
        {
            return false;
        }
        try
        {
            lock (MyTiny)
            {

                foreach (string k in MyTiny.Keys)
                {

                    byte[] dataInOfLast = MyTiny[k].MyTiny.Item3; // take the last encrypt of the specific

                    byte[] dataAfterE = encryptOneHelper(key, dataInOfLast); // doing first time incript with key given

                    int number = MyTiny[k].MyTiny.Item4 + 1;

                    MyTiny[k].MyTiny = new Tuple<double, DateTime, byte[], int>(dataAfterE.Length / 1024, MyTiny[k].MyTiny.Item2, dataAfterE, number);

                }

                foreach (string k in MyTinyHidden.Keys)
                {

                    byte[] dataInOfLast = MyTinyHidden[k].MyTiny.Item3; // take the last encrypt of the specific

                    byte[] dataAfterE = encryptOneHelper(key, dataInOfLast); // doing first time incript with key given

                    int number = MyTinyHidden[k].MyTiny.Item4 + 1;

                    MyTinyHidden[k].MyTiny = new Tuple<double, DateTime, byte[], int>(dataAfterE.Length / 1024, MyTinyHidden[k].MyTiny.Item2, dataAfterE, number);

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }


        return true;
    }


    public bool decrypt(String key)
    {
        // fileName - Decryption key to decrypt the contents of all files in the system 
        // return false if operation failed for any reason
        // Example:
        // decrypt("myFSpassword")

        bool flag = false;


        try
        {
            lock (MyTiny)
            {
                if (key == null)
                    throw new Exception("the key is null");



                foreach (string k in MyTiny.Keys)
                {
                    if (MyTiny[k].MyTiny.Item4 == 0) // if the file not encrypted
                    {
                        continue;
                    }

                    byte[] tryDecrypt;
                    try
                    {
                        tryDecrypt = dcryptOneHelper(key, MyTiny[k].MyTiny.Item3); // first decrypt and check if it is equal to the data in the before encrypttion
                    }
                    catch (Exception e)
                    {

                        return false;
                    }


                    flag = true;

                    int number = MyTiny[k].MyTiny.Item4 - 1;

                    MyTiny[k].MyTiny = new Tuple<double, DateTime, byte[], int>(tryDecrypt.Length / 1024, MyTiny[k].MyTiny.Item2, tryDecrypt, number);


                }

                foreach (string k in MyTinyHidden.Keys)
                {
                    if (MyTinyHidden[k].MyTiny.Item4 == 0) // if the file not encrypted
                    {
                        continue;
                    }

                    byte[] tryDecrypt;
                    try
                    {
                        tryDecrypt = dcryptOneHelper(key, MyTinyHidden[k].MyTiny.Item3); // first decrypt and check if it is equal to the data in the before encrypttion
                    }
                    catch (Exception e)
                    {

                        return false;
                    }


                    flag = true;

                    int number = MyTinyHidden[k].MyTiny.Item4 - 1;

                    MyTinyHidden[k].MyTiny = new Tuple<double, DateTime, byte[], int>(tryDecrypt.Length / 1024, MyTinyHidden[k].MyTiny.Item2, tryDecrypt, number);


                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return false;
        }


        return flag;
    }



    // ***** NOT MANDATORY ***************
    // **** Extended features of TinyMemFS ************
    public bool saveToDisk(String fileName)
    {
        /*
         * Save the FS to a single file in disk
         * return false if operation failed for any reason
         * You should store the entire FS (metadata and files) from memory to a single file.
         * You can decide how to save the FS in a single file (format, etc.) 
         * Example:
         * SaveToDisk("MYTINYFS.DAT")
         */

        // I Will save the file in the order of the hash is build with "," between each 
        // and ; between each file properties save

        //fileName, Length, CreationTime,file data,number of encrypt done on the file ; nex values...
        try
        {
            lock (MyTiny)
            {
                string Path = Directory.GetCurrentDirectory() + "\\" + fileName + ".DAT";
                System.IO.File.WriteAllText(@Path, string.Empty); // first empty what was before so the content will be update to the date 

                ArrayList myFiles = new ArrayList();


                foreach (string k in MyTiny.Keys) // maybe try convert to byte and not string 
                {
                    MyFile myFile = new MyFile(k);

                    myFile.MyTiny = new Tuple<double, DateTime, byte[], int>(MyTiny[k].MyTiny.Item1, MyTiny[k].MyTiny.Item2, MyTiny[k].MyTiny.Item3, MyTiny[k].MyTiny.Item4);
                    myFiles.Add(myFile);

                }

                AppendAllBytes(@Path, ObjectToByteArray(myFiles));


                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }


        return true;
    }


    public static void AppendAllBytes(string path, byte[] bytes)
    {
        //argument-checking here.

        using (var stream = new FileStream(path, FileMode.Append))
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }


    public bool loadFromDisk(String fileName)
    {
        /*
         * Load a saved FS from a file  
         * return false if operation failed for any reason
         * You should clear all the files in the current TinyMemFS if exist, before loading the filenName
         * Example:
         * LoadFromDisk("MYTINYFS.DAT")
         */

        //load by the format
        //fileName,Length,CreationTime,file data,number of encrypt done on the file ; nex values...


        //first clean all the content from the currrent dict
        MyTiny = new Dictionary<string, MyFile>();

        try
        {
            lock (MyTiny)
            {
                // load the file according to the format

                string Path = Directory.GetCurrentDirectory() + "\\" + fileName + ".DAT";
                byte[] textByByte = System.IO.File.ReadAllBytes(@Path);


                ArrayList myFiles = (ArrayList)ByteArrayToObject(textByByte);

                foreach (MyFile mf in myFiles)
                {
                    MyTiny.Add(mf.name, mf);
                }


                return true;
            }
        }
        catch (Exception e)
        {

            return false;
        }

        return true;
    }

    public bool compressFile(String fileName)
    {
        /* Compress file fileName
         * return false if operation failed for any reason
         * You can use an compression/uncompression algorithm of your choice
         * Note that the file size might be changed due to this operation, update it accordingly
         * Example:
         * compressFile ("name1.pdf");
         */
        try
        {
            lock (MyTiny)
            {
                if (MyTiny[fileName].zip)
                {
                    throw new Exception("file already comress");

                }

                byte[] dataAfter = Zip(MyTiny[fileName].MyTiny.Item3);

                MyTiny[fileName].MyTiny = new Tuple<double, DateTime, byte[], int>(dataAfter.Length / 1024, MyTiny[fileName].MyTiny.Item2, dataAfter, MyTiny[fileName].MyTiny.Item4);
                MyTiny[fileName].zip = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return false;

        }


        return true;
    }



    public bool uncompressFile(String fileName)
    {
        /* uncompress file fileName
         * return false if operation failed for any reason
         * You can use an compression/uncompression algorithm of your choice
         * Note that the file size might be changed due to this operation, update it accordingly
         * Example:
         * uncompressFile ("name1.pdf");
         */



        try
        {
            lock (MyTiny)
            {
                if (MyTiny[fileName].zip)
                {
                    byte[] dataAfter = Unzip(MyTiny[fileName].MyTiny.Item3);

                    MyTiny[fileName].MyTiny = new Tuple<double, DateTime, byte[], int>(dataAfter.Length / 1024, MyTiny[fileName].MyTiny.Item2, dataAfter, MyTiny[fileName].MyTiny.Item4);
                    MyTiny[fileName].zip = false;
                }
                else
                {
                    throw new Exception("the file already unzipped");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;

        }

        return true;
    }





    public bool setHidden(String fileName, bool hidden)
    {
        /* set the hidden property of fileName
         * If file is hidden, it will not appear in the listFiles() results
         * return false if operation failed for any reason
         * Example:
         * setHidden ("name1.pdf", true);
         */

        try
        {
            lock (MyTiny)
            {
                if (hidden && !MyTiny.ContainsKey(fileName))
                {
                    return false;
                }

                if (hidden)
                {
                    MyFile temp = MyTiny[fileName];

                    MyTiny.Remove(fileName);

                    MyTinyHidden.Add(fileName, temp);

                    MyTinyHidden[fileName].hidden = true;

                }
                else // if hidden == false we will need to get the file out of hidden
                {
                    if (MyTinyHidden[fileName].hidden == false)
                    {
                        throw new Exception("the file has not been hidden");
                    }

                    MyFile temp = MyTinyHidden[fileName];

                    MyTinyHidden.Remove(fileName);

                    MyTiny.Add(fileName, temp);

                    MyTinyHidden[fileName].hidden = false;

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }

    public bool rename(String fileName, String newFileName) // check about the name
    {
        /* Rename filename to newFileName
         * Return false if operation failed for any reason (E.g., newFileName already exists)
         * Example:
         * rename ("name1.pdf", "name2.pdf");
         */

        if (!MyTiny.ContainsKey(fileName))
        {
            return false;
        }



        try
        {
            lock (MyTiny)
            {
                RenameKey(MyTiny, fileName, newFileName);
                MyTiny[newFileName].name = newFileName;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return false;
        }



        return true;
    }


    private void RenameKey<TKey, TValue>(IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
    {
        TValue value = dic[fromKey];
        dic.Remove(fromKey);
        dic[toKey] = value;
    }

    public bool copy(String fileName1, String fileName2)
    {
        /* Rename filename1 to a new filename2
         * Return false if operation failed for any reason (E.g., fileName1 doesn't exist or filename2 already exists)
         * Example:
          *rename("name1.pdf", "name2.pdf");*/
        try
        {
            lock (MyTiny)
            {
                if (!MyTiny.ContainsKey(fileName1) || MyTiny.ContainsKey(fileName2))
                {
                    throw new Exception();
                }

                MyFile myfile2 = new MyFile(fileName2);

                myfile2.MyTiny = new Tuple<double, DateTime, byte[], int>(MyTiny[fileName1].MyTiny.Item1, MyTiny[fileName1].MyTiny.Item2, MyTiny[fileName1].MyTiny.Item3, MyTiny[fileName1].MyTiny.Item4);

                MyTiny.Add(fileName2, myfile2);
            }

        }
        catch (Exception)
        {
            return false;
        }
        return true;


    }


    public void sortByName()
    {
        /* Sort the files in the FS by their names (alphabetical order)
         * This should affect the order the files appear in the listFiles 
         * if two names are equal you can sort them arbitrarily
         */
        try
        {
            lock (MyTiny)
            {
                Dictionary<String, MyFile> r = MyTiny;
                var l = r.OrderBy(x => x.Key);
                var dic = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                MyTiny = dic;
            }
        }
        catch (Exception)
        {
            return;
        }
        return;
    }

    public void sortByDate()
    {
        /* Sort the files in the FS by their date (new to old)
         * This should affect the order the files appear in the listFiles  
         * if two dates are equal you can sort them arbitrarily
         */
        try
        {
            lock (MyTiny)
            {
                Dictionary<String, MyFile> r = MyTiny;
                var l = r.OrderBy(x => x.Value.MyTiny.Item2);
                var dic = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                MyTiny = dic;
            }
        }

        catch (Exception)
        {
            return;
        }



        return;
    }

    public void sortBySize()
    {
        /* Sort the files in the FS by their sizes (large to small)
         * This should affect the order the files appear in the listFiles  
         * if two sizes are equal you can sort them arbitrarily
         */

        try
        {

            lock (MyTiny)
            {
                Dictionary<String, MyFile> r = MyTiny;
                var l = r.OrderBy(x => x.Value.MyTiny.Item1);
                var dic = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                MyTiny = dic;
            }
        }
        catch (Exception)
        {
            return;
        }



        return;
    }


    public bool compare(String fileName1, String fileName2)
    {
        /* compare fileName1 and fileName2
         * files considered equal if their content is equal 
         * Return false if the two files are not equal, or if operation failed for any reason (E.g., fileName1 or fileName2 not exist)
         * Example:
         * compare ("name1.pdf", "name2.pdf");
         */

        try
        {
            lock (MyTiny)
            {

                if (!MyTiny.ContainsKey(fileName1) || !MyTiny.ContainsKey(fileName2))
                    return false;

                if (ByteArrayCompare(MyTiny[fileName1].MyTiny.Item3, MyTiny[fileName2].MyTiny.Item3))
                    return true;
            }
        }
        catch (Exception)
        {
            return false;
        }


        return false;
    }


    private bool ByteArrayCompare(byte[] a1, byte[] a2)
    {
        if (a1.Length != a2.Length)
            return false;

        for (int i = 0; i < a1.Length; i++)
            if (a1[i] != a2[i])
                return false;

        return true;
    }





    public Int64 getSize()
    {
        /* return the size of all files in the FS (sum of all sizes)
         */

        Int64 sum = 0;

        try
        {


            foreach (string k in MyTiny.Keys)
            {
                sum += (Int64)MyTiny[k].MyTiny.Item1;
            }

            foreach (string k in MyTinyHidden.Keys)
            {
                sum += (Int64)MyTinyHidden[k].MyTiny.Item1;
            }

        }
        catch (Exception)
        {
            return sum;
        }

        return sum;
    }




    private byte[] encryptOneHelper(string password, byte[] text)
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                using (var transform = tdes.CreateEncryptor())
                {
                    /*byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text); // to change using the method i wrote convert*/
                    byte[] textBytes = text;
                    byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                    //return Convert.ToBase64String(bytes, 0, bytes.Length);
                    return bytes;
                }
            }
        }

    }
    private byte[] dcryptOneHelper(string password, byte[] text)
    {

        using (var md5 = new MD5CryptoServiceProvider())
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                using (var transform = tdes.CreateDecryptor())
                {
                    /*byte[] cipherBytes = Convert.FromBase64String(text);*/
                    byte[] cipherBytes = text;
                    byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    //return UTF8Encoding.UTF8.GetString(bytes);
                    return bytes;
                }
            }
        }

    }

    /*    private string BytesToString(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }*/

    public string BytesToString(byte[] bytes)
    {
        return UTF8Encoding.UTF8.GetString(bytes);
    }

    private byte[] StringToByte(string data)
    {
        return UTF8Encoding.UTF8.GetBytes(data);
    }


    // Convert an object to a byte array
    private byte[] ObjectToByteArray(Object obj)
    {
        if (obj == null)
            return null;

        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, obj);

        return ms.ToArray();
    }

    // Convert a byte array to an Object
    private Object ByteArrayToObject(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        Object obj = (Object)binForm.Deserialize(memStream);

        return obj;
    }




    public static void CopyTo(Stream src, Stream dest)
    {
        byte[] bytes = new byte[4096];

        int cnt;

        while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
        {
            dest.Write(bytes, 0, cnt);
        }
    }

    public static byte[] Zip(byte[] data)
    {
        // var bytes = Encoding.UTF8.GetBytes(str);
        var bytes = data;

        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                //msi.CopyTo(gs);
                CopyTo(msi, gs);
            }

            return mso.ToArray();
        }
    }


    public static byte[] Unzip(byte[] bytes)
    {
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {
                //gs.CopyTo(mso);
                CopyTo(gs, mso);
            }

            //return Encoding.UTF8.GetString(mso.ToArray());
            return mso.ToArray();
        }
    }






}


[Serializable()]
class MyFile
{
    public string name;
    public bool zip;
    public bool hidden;


    public Tuple<double, DateTime, byte[], int> MyTiny;
    public MyFile(string name)
    {
        this.name = name;
        zip = false;
    }


}
