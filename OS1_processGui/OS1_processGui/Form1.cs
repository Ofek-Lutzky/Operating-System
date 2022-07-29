using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace OS1_processGui
{
    public partial class FormW : Form
    {
        public FormW()
        {
            InitializeComponent();       
        }

  
        private void Form1_Load(object sender, EventArgs e)
        {
            //refresh the grid process
            gridRestart(); 

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void seachName_Click(object sender, EventArgs e)
        {
            //just for fun there is three types of search or according to the combo box or with combo empty

            string text = textSearchName.Text.ToString();

            if (comboBox1.Text == "ID")
            {

                (dataGrid.DataSource as DataTable).DefaultView.RowFilter = String.Format("ID like '%" + text + "%'");
            }

            else if (comboBox1.Text == "Process")
            {
                
                (dataGrid.DataSource as DataTable).DefaultView.RowFilter = String.Format("Process like '%" + text + "%'");
            }

            else
            {   
                if (Int32.TryParse(text,out int result))
                {
                    (dataGrid.DataSource as DataTable).DefaultView.RowFilter = String.Format("ID like '%" + text + "%'");
                }
                else
                {
                    (dataGrid.DataSource as DataTable).DefaultView.RowFilter = String.Format("Process like '%" + text + "%'");
                }
                
            }
            
        }


        private void textSearchName_TextChanged(object sender, EventArgs e)
        {
            
        }

  

        private void killButton_Click(object sender, EventArgs e)
        {
            


            if (dataGrid.SelectedCells.Count > 0)
            {
                //the next few lines are get to the row index were the user is clicking and get the value of the ID of the process in the row
                int selectedRowIndex = dataGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGrid.Rows[selectedRowIndex];
                string cellValue = Convert.ToString(selectedRow.Cells["Process"].Value);
               // MessageBox.Show(cellValue);  // TEST

                //the lines kill the process first get the process then remove it from the computer

                Process[] cellsWithName = Process.GetProcessesByName(cellValue);

                foreach (Process cell in cellsWithName)
                {
                    cell.Kill();
                }

                //refresh the grid process
                gridRestart();
                    
            }

        }
        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //func to get a list of all the process of the local computer
        private Process[] GetAllProcess()
        {
            Process[] allProcess = Process.GetProcesses();
            return allProcess;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gridRestart()
        {
            Process[] allProcess = GetAllProcess();
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Process", typeof(string));

            foreach (Process process in allProcess)
            {
                dt.Rows.Add(process.Id, process.ProcessName.ToString());
            }

            dataGrid.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
