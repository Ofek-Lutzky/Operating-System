using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//I adsded
using System.Diagnostics;
//for the checking of the url
using System.Net;
using System.Threading;

namespace DDoSAttack
{
    public partial class FormWindow : Form
    {
        int numberOfBrowsers;
        string url;
        bool urlValid = false;
        //Process[] allStartedProcesses;
        LinkedList<Process> allStartedProcesses = new LinkedList<Process>();
       // LinkedList<int> allStartedID = new LinkedList<int>();

        public FormWindow()
        {
            InitializeComponent();
        }

        private void DDoSBtn_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(tBBrowsersNumber.Text, out int result))
            {
                MessageBox.Show("Didn't enter NUMBER!", "Error", MessageBoxButtons.OKCancel);
            }

            else if (tBUrl.Text.Length == 0)
            {
                MessageBox.Show("Didn't enter URL!", "Error", MessageBoxButtons.OKCancel);
            }

            

            else if (RemoteFileExists(tBUrl.Text))
            {
                this.numberOfBrowsers = result;
                this.url = tBUrl.Text;

                for (int i = 0; i < numberOfBrowsers; i++)
                {
                    Process p = Process.Start(url);
                    allStartedProcesses.AddLast(p);
                    Thread.Sleep(100);
                }

                this.urlValid = true;
            }

            else
            {
                MessageBox.Show("URL isn't valid", "Error", MessageBoxButtons.OKCancel);
            }



        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (urlValid)
            {
               
                foreach (Process proc in allStartedProcesses)
                {
                      if (!(proc == null))
                      { 
                          
                          if (!proc.HasExited) proc.Kill();
                          proc.WaitForExit();
                      }

                }

                this.urlValid = false;
            }

            else
            {
                MessageBox.Show("URL isn't valid Or already Close!", "Error", MessageBoxButtons.OKCancel);
            }
            
        }



        ///
        /// Checks the file exists or not.
        ///
        /// The URL of the remote file.
        /// True : If the file exits, False if file not exists
        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }


    }
}
