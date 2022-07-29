using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ThreadedBinarySearchTree
{
    class Node
    {
        public int data;
        public Node left = null;
        public Node right = null;
        //Node father = null;
        public Node(int num)
        {
            data = num;
        }
    }
    
    class ThreadedBinarySearchTree
    {
        ReaderWriterLock rwl = new ReaderWriterLock();
        private static Mutex mutex = new Mutex();

        public Node root;

        //first try
        public void add(int num)
        {
            while (true)
            {
                try
                {
                    //Console.WriteLine(num);
                    rwl.AcquireWriterLock(1000);
                    addHelper(root, num);
                    rwl.ReleaseWriterLock();
                    break;
                }
                catch (Exception e)
                {
                   // Console.WriteLine(e.Message);
                }
            }


        }   //add num to the tree, if it already exists, do nothing


        public bool addHelper(Node node, int data)
        {
            if (node == null)
            {
                this.root = new Node(data);
                return true;
            }

            Node father = null;
            while (node != null)
            {
                father = node;
                if (data < node.data)
                    node = node.left;
                else if (data > node.data)
                    node = node.right;
                else
                    return false; // same data
            }

            if (data < father.data)
                father.left = new Node(data);
            else
                father.right = new Node(data);

            return true;
        }

        //first try
        public void remove(int num)
        {
            while (true)
            {
                try
                {
                    rwl.AcquireWriterLock(1000);
                    removeHelper(root, num);
                    rwl.ReleaseWriterLock();
                    break;
                }

                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }

        } // remove num from the tree, if it doesn't exists, do nothing


        private Node removeHelper(Node current, int key)
        {
            if (current == null) return current;

            if (key < current.data) 
                current.left = removeHelper(current.left, key);
            else if (key > current.data)
                current.right = removeHelper(current.right, key);
            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (current.left == null)
                    return current.right;
                else if (current.right == null)
                    return current.left;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                current.data = MinValue(current.right);

                // Delete the inorder successor  
                current.right = removeHelper(current.right, current.data);
            }

            return current;
        }

        private int MinValue(Node node)
        {
            int minv = node.data;

            while (node.left != null)
            {
                minv = node.left.data;
                node = node.left;
            }

            return minv;
        }

        //first try
        public bool search(int num)
        {
            bool result = false;
            while (true)
            {
                try
                {
                    rwl.AcquireReaderLock(1000);
                    result = searchHelper(root, num);
                    break;

                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
            rwl.ReleaseReaderLock();
            return result;
            


        } // search num in the tree and return true/false accordingly

        private bool searchHelper(Node current, int num)
        {

            while (current != null)
            {
                if (current.data == num)
                {
                    return true;
                }
                if (num < current.data)
                    current = current.left;
                else if (num > current.data)
                    current = current.right;
            }

            return false;
        }


        public void clear()
        {
            while (true)
            {
                try
                {
                    rwl.AcquireWriterLock(1000);
                    this.root = null;
                    break;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
            rwl.ReleaseWriterLock();
        }


        public void print()
        {
            while (true)
            {
                try
                {
                    rwl.AcquireReaderLock(1000);
                    mutex.WaitOne();

                    if (root != null)
                    {
                        List<string> treeRepresent = inorderHelper(this.root, new List<string>());


                        for (int i = 0; i < treeRepresent.Count; i++)
                        {
                            if (i == treeRepresent.Count - 1)
                            {
                                Console.WriteLine(treeRepresent[i] + ".");
                            }
                            else
                            {
                                Console.Write(treeRepresent[i] + ",");
                            }
                        }

                    }
                    mutex.ReleaseMutex();
                    break;
                }

                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }

            rwl.ReleaseReaderLock();
            
        }


        private List<string> inorderHelper(Node root, List<string> treeR)
        {
            if (root != null)
            {
                inorderHelper(root.left, treeR);
                //Console.Write(root.data + ",");
                treeR.Add(root.data.ToString());
                inorderHelper(root.right, treeR);
            }
            return treeR;

        }
    }
}
