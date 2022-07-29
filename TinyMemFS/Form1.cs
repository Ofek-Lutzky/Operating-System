using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyMemFS
{
    public partial class TinyMemFSWindow : Form
    {
        TinyMemFSClass tiny = new TinyMemFSClass();

        public static bool gridInit = false;

        public TinyMemFSWindow()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();

            string[] rowToAdd = null;


            //dt.Columns. = sheet.getCols();
            for (int j = 0; j < 5; j++)
            {

                dt.Columns.Add("");
            }

            foreach (string keyName in tiny.MyTiny.Keys)
            {

                rowToAdd = new string[5] {tiny.MyTiny[keyName].name,
                tiny.MyTiny[keyName].MyTiny.Item1.ToString() + "KB" ,tiny.MyTiny[keyName].MyTiny.Item2.ToString(),
                    tiny.BytesToString(tiny.MyTiny[keyName].MyTiny.Item3) ,tiny.MyTiny[keyName].MyTiny.Item4.ToString()};
                dt.Rows.Add(rowToAdd);
            }

            dataGrid.DataSource = dt;
            dataGrid.Columns[0].HeaderText = "File name";
            //dataGrid.Columns[1].HeaderText = "Is hidden";
            dataGrid.Columns[1].HeaderText = "Size";
            dataGrid.Columns[2].HeaderText = "Create date";
            dataGrid.Columns[3].HeaderText = "Data";
            dataGrid.Columns[4].HeaderText = "Num of encrypts";
            dataGrid.Refresh();

            gridInit = true;

        }

        private void TinyMemFSWindow_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Tuple<string, string> chosenFile = openDialog();
            if (chosenFile.Item1 == "" || chosenFile.Item2 == "")
                return;

            tiny.add(chosenFile.Item1, chosenFile.Item2);

            //tiny.add(addText1.Text, addText2.Text);
            LoadGrid();
        }

      

        private void removeBtn_Click(object sender, EventArgs e)
        {
            tiny.remove(SelectedRowName());
            LoadGrid();
        }

        private void Save_Click(object sender, EventArgs e)
        {

            try {
                if (saveText2.Text == "")
                    throw new Exception();

                tiny.save(SelectedRowName(), saveText2.Text);
                LoadGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Path incorrect");
            }
            
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            tiny.encrypt(encText1.Text);
            LoadGrid();
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tiny.decrypt(decText1.Text);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Password was Incorrect try again!");
            }
            LoadGrid();
        }

        private void SaveToDiskBtn_Click(object sender, EventArgs e)
        {
            tiny.saveToDisk(saveDisktext.Text);
        }

        private void LoadFromDiskBtn_Click(object sender, EventArgs e)
        {
            tiny.loadFromDisk(loadDisktext.Text);
            LoadGrid();

        }



        private string SelectedRowName()
        {
            string str = null;

            try
            {
                if (!gridInit)
                {
                    throw new Exception();
                }

                str = dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("didn't chose file");
            }

            return str;

        }

        private Tuple<string, string> openDialog()
        {
            string fileName = "";
            string filePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                //MessageBox.Show(openFileDialog.FileName);
                fileName = openFileDialog.SafeFileName;

                filePath = openFileDialog.FileName;
            }

            return new Tuple<string, string>(fileName, filePath);
        }

        private void compressBTn_Click(object sender, EventArgs e)
        {
            tiny.compressFile(SelectedRowName());
            LoadGrid();
        }

        private void uncompressBtn_Click(object sender, EventArgs e)
        {
            tiny.uncompressFile(SelectedRowName());
            LoadGrid();
        }

        private void setHiddenBtn_Click(object sender, EventArgs e)
        {
            if(hiddenCombo.Text == "True")
            {
                alreadyHiddenCombo.Items.Add(SelectedRowName());
                tiny.setHidden(SelectedRowName(), true);
                

            }
            else
            {
                tiny.setHidden(alreadyHiddenCombo.Text, false);
                alreadyHiddenCombo.Items.Remove(alreadyHiddenCombo.Text);
            }

            LoadGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tiny.rename(SelectedRowName(),renameT.Text);
            LoadGrid();
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            bool answer = tiny.compare(SelectedRowName(), compareT.Text);

            if (answer)
            {
                MessageBox.Show("the files data are the same!");
            }
            else
            {
                MessageBox.Show("Different files!");

            }


            LoadGrid();
        }



        private void Sort_Click(object sender, EventArgs e)
        {

            if (sortCombo.Text == "Name")
            {
                tiny.sortByName();

            }
            else if(sortCombo.Text == "Date")
            {
                tiny.sortByDate();
            }
            else
            {
                tiny.sortBySize();
            }

            LoadGrid();

        }

        private void getSizeBtn_Click(object sender, EventArgs e)
        {
            long size = tiny.getSize();
            MessageBox.Show(size.ToString());
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            tiny.copy(SelectedRowName(), copyText.Text);
            LoadGrid();
        }
    }
}
