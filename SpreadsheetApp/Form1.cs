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

namespace SpreadsheetApp
{

    public partial class Form1 : Form
    {
        private static int users = 5;
        private SpreadSheet sheet = new SpreadSheet(20,10,users);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            restartDataGrid();
        }

        private void Save_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }
            if (SaveTextBox.Text != "" )
            {
                if (!Int32.TryParse(SaveTextBox.Text.Substring(0, 1), out int result))
                {
                    sheet.save(SaveTextBox.Text);
                    MessageBox.Show("the Sheet has saved in file name " + SaveTextBox.Text + ".csv" + " on the directory");
                }
                else
                {
                    MessageBox.Show("Name of String not good!");
                }
            }
            else
            {
                MessageBox.Show("Name of String not good!");

            }

        }



        private void loadBtn_Click(object sender, EventArgs e)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            string fileName = LoadTextBox.Text;
            string absolutePath = @CurrentDirectory + "\\" + fileName + ".csv";

            if (LoadTextBox.Text != "")
            {
                if (!Int32.TryParse(LoadTextBox.Text.Substring(0, 1), out int result) || File.Exists(absolutePath))
                {
                    sheet.load(LoadTextBox.Text);
                    restartDataGrid();
                }
                else
                {
                    MessageBox.Show("File Not Exists!");
                }
            }
            else
            {
                MessageBox.Show("File Not Exists!");
            }

            

        }

        private void restartDataGrid()
        {
            DataTable dt = new DataTable();

            string[] rowToAdd = null;


            //dt.Columns. = sheet.getCols();
            for (int j = 0; j < sheet.getCols(); j++)
            {

                dt.Columns.Add("");
            }
            for (int i = 0; i < sheet.getRows(); i++)
            {
                rowToAdd = new string[sheet.getCols()];
                for (int j = 0; j < sheet.getCols(); j++)
                {
                    rowToAdd[j] = SpreadSheet.spreadsheet[i][j];
                }
                //listView1.Items.Add(Records[i],Records[i+1],Records[i+2]);
                dt.Rows.Add(rowToAdd);
            }
            dataGrid.DataSource = dt;
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void findAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            try
            {
                Tuple<int, int>[] result = null;

                if (findAllcomboBox.SelectedItem != null && findAllcomboBox.SelectedItem.ToString() == "true")
                    result = sheet.findAll(findAlltextBox.Text.ToString(), true);
                else
                    result = sheet.findAll(findAlltextBox.Text.ToString(), false);

                if (result.Length > 0 && result[0].Item1 != -1)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        dataGrid.Rows[result[i].Item1].Cells[result[i].Item2].Style.BackColor = Color.Yellow;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    dataGrid.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void SetAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j]=dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            if (setAllcomboBox.SelectedItem != null && setAllcomboBox.SelectedItem.ToString() == "true")
                sheet.setAll(setAllText.Text.ToString(), setAlltextBox2.Text.ToString(), true);
            else
                sheet.setAll(setAllText.Text.ToString(), setAlltextBox2.Text.ToString(), false);

            restartDataGrid();

        }

        private void ExchangeRow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j]=dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }
            if (exchangeTextBox.Text == "" || exchangeTextBox2.Text == "" || Int32.Parse(exchangeTextBox.Text) - 1 < 0 || Int32.Parse(exchangeTextBox2.Text.ToString()) - 1 < 0 ||
                Int32.Parse(exchangeTextBox.Text) - 1 > dataGrid.RowCount - 1 || Int32.Parse(exchangeTextBox2.Text.ToString()) - 1 > dataGrid.RowCount - 1)
            {
                MessageBox.Show("Index out of range!");

            }
            else
            {
                sheet.exchangeRows(Int32.Parse(exchangeTextBox.Text) - 1, Int32.Parse(exchangeTextBox2.Text) - 1);
                restartDataGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)//exchange cols
        {

            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            if (col1textBox2.Text == "" || col2textBox1.Text == "" || Int32.Parse(col1textBox2.Text) - 1 < 0 || Int32.Parse(col2textBox1.Text.ToString()) - 1 < 0 ||
                Int32.Parse(col1textBox2.Text) - 1 > dataGrid.ColumnCount-1 || Int32.Parse(col2textBox1.Text) - 1 > dataGrid.ColumnCount-1)
            {
                MessageBox.Show("Index out of range!");

            }
            else
            {
                sheet.exchangeCols(Int32.Parse(col1textBox2.Text) - 1, Int32.Parse(col2textBox1.Text.ToString()) - 1);
                restartDataGrid();
            }
        }

        private void AddRow_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }
            if (AddRowtextBox3.Text == "" || Int32.Parse(AddRowtextBox3.Text) - 1 < 0 || Int32.Parse(AddRowtextBox3.Text) - 1 > dataGrid.RowCount)
            {
                MessageBox.Show("Index out of range!");

            }
            else
            {
                sheet.addRow(Int32.Parse(AddRowtextBox3.Text) - 1);
                restartDataGrid();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    SpreadSheet.spreadsheet[i][j] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }
            if (AddColtextBox1.Text == "" || Int32.Parse(AddColtextBox1.Text) - 1 < 0 || Int32.Parse(AddColtextBox1.Text) - 1 > dataGrid.ColumnCount)
            {
                MessageBox.Show("Index out of range!");

            }
            else
            {
                sheet.addCol(Int32.Parse(AddColtextBox1.Text) - 1);
                restartDataGrid();
            }
        }
    }



}
