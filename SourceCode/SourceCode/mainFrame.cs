using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceCode;

namespace SourceCode
{
    public partial class mainFrame : Form
    {
        Calculator myCal;
        public String mainFrameLogs;
        #region Initialization
        public mainFrame()
        {
            InitializeComponent();
            myCal = new Calculator();
            mainFrameLogs = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Main Functions
        private void buttonCreateMatrix_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender,e);
            //___Create matrices: UM, AF, AA, CA using user's input values
            if (checkInput())
            {
                DrawMatrix(dataUM, int.Parse(textQueries.Text), int.Parse(textAttributes.Text));
                NameRowAndColumn(dataUM, 'q', 'A');
                DrawMatrix(dataAF, int.Parse(textQueries.Text), int.Parse(textSites.Text));
                NameRowAndColumn(dataAF, 'q', 'S');
                DrawMatrix(dataAA, int.Parse(textAttributes.Text), int.Parse(textAttributes.Text));
                NameRowAndColumn(dataAA, 'A', 'A');
                DrawMatrix(dataCA, int.Parse(textAttributes.Text), int.Parse(textAttributes.Text));
                NameRowAndColumn(dataCA, 'A', 'A');
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //___Clear all datagridviews
            dataUM.Rows.Clear();
            dataUM.Columns.Clear();
            dataAF.Rows.Clear();
            dataAF.Columns.Clear();
            dataAA.Rows.Clear();
            dataAA.Columns.Clear();
            dataCA.Rows.Clear();
            dataCA.Columns.Clear();
            mainFrameLogs = String.Empty;
            richTextLogs.Text = string.Empty;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            mainFrameLogs = string.Empty;
            //___Calculate AA matrix
            AddLogs("Calculating Attribute Affinity matrix: ");
            myCal.CalculateAA(dataUM, dataAF, dataAA);
            AddLogs(myCal.calculatorLogs);
            //___Calculate CA matrix and return list of column order
            //___Copy AA to CA
            AddLogs("Calculating Clustered Affinity matrix: ");
            for (int i = 0; i < dataAA.RowCount; i++)
            {
                for (int j = 0; j < dataAA.Rows[i].Cells.Count; j++)
                {
                    dataCA.Rows[i].Cells[j].Value = dataAA.Rows[i].Cells[j].Value;
                }
            }
            List<int> orderList = myCal.CalculateCA(dataCA);
            AddLogs(myCal.calculatorLogs);
            NameRowAndColumn(dataCA,'A','A', orderList);    // name CA columns
            //___Calculate VF matrix
                //___Make a copy of UM
            AddLogs("Calculating Vertical Fragmentations: ");
            DataGridView cloneUM = new DataGridView();
            cloneUM.ColumnCount = dataUM.ColumnCount;
            cloneUM.RowCount = dataUM.RowCount;
            for (int i = 0; i < dataUM.RowCount; i++)
            {
                for (int j = 0; j < dataUM.Rows[i].Cells.Count; j++)
                {
                    cloneUM.Rows[i].Cells[j].Value = dataUM.Rows[i].Cells[j].Value;
                }
            }
            cloneUM = myCal.ReorderColsOfUM(cloneUM, orderList);
            int pointX = myCal.CalculateVF(cloneUM, dataAF, dataCA);
            AddLogs(myCal.calculatorLogs);
            string TA = string.Empty;
            string BA = string.Empty;
            for(int i = 0; i < pointX; i++)
            {
                TA += dataCA.Columns[i].HeaderText;
                if (i != pointX - 1)
                    TA += ",";
            }
            for (int i = pointX; i < dataCA.ColumnCount; i++)
            {
                BA += dataCA.Columns[i].HeaderText;
                if (i != dataCA.ColumnCount - 1)
                    BA += ",";
            }
            richTextVF.Text = "{" + TA + "}";
            richTextVF.Text += Environment.NewLine;
            richTextVF.Text += Environment.NewLine;
            richTextVF.Text += "{" + BA + "}";
            //___Update views
            dataAA.Update();
            dataAA.Refresh();
            dataCA.Update();
            dataCA.Refresh();
            richTextLogs.Text = mainFrameLogs;
        }
        #endregion

        #region Utilities
        private void DrawMatrix(DataGridView dataView, int row, int col)
        {
            dataView.RowCount = row;
            dataView.ColumnCount = col;
        }

        private bool checkInput() 
        {
            //___Check user's input values. It's will be invalid if it's not able to convert to integer
            if (textAttributes.Text != "" && textQueries.Text != "" && textSites.Text != "")
            {
                int temp1, temp2, temp3;
                if (int.TryParse(textAttributes.Text, out temp1)
                    && int.TryParse(textQueries.Text, out temp2)
                    && int.TryParse(textSites.Text, out temp3))
                    return true;
            }
            return false;
        }

        private void NameRowAndColumn(DataGridView data, char rol, char col, List<int> orderList = null)
        {
            if (orderList == null)  // In case of UM, AF, AA matrix
            {
                for (int i = 0; i < data.ColumnCount; i++)  // Name columns
                    data.Columns[i].HeaderText = col + (i + 1).ToString();
                for (int i = 0; i < data.RowCount; i++)     //Name rows
                    data.Rows[i].HeaderCell.Value = rol + (i + 1).ToString();
            }
            if (orderList != null)  // In case of CA matrix
            {
                for (int i = 0; i < dataCA.ColumnCount; i++)    // Name column
                    dataCA.Columns[i].HeaderText = col + (orderList[i] + 1).ToString();
                for (int i = 0; i < dataCA.RowCount; i++)       //Name rows
                    dataCA.Rows[i].HeaderCell.Value = col + (orderList[i] + 1).ToString();
            }
        }

        private void AddLogs(string line)
        {
            mainFrameLogs += line;
            mainFrameLogs += Environment.NewLine;
        }
    }
    #endregion
        
}
