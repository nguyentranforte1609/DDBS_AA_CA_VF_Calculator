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
        #region Initialization
        public mainFrame()
        {
            InitializeComponent();
             myCal = new Calculator();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        #region Main Functions
        private void buttonCreateMatrix_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                DrawMatrix(dataUM, int.Parse(textQueries.Text), int.Parse(textAttributes.Text));
                NameRowAndColumn(dataUM, 'q', 'A');
                DrawMatrix(dataAF, int.Parse(textQueries.Text), int.Parse(textSites.Text));
                NameRowAndColumn(dataAF, 'q', 'S');

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataUM.Rows.Clear();
            dataUM.Columns.Clear();
            dataAF.Rows.Clear();
            dataAF.Columns.Clear();
            dataAA.Rows.Clear();
            dataAA.Columns.Clear();
            dataCA.Rows.Clear();
            dataCA.Columns.Clear();
            textLogs.Text = String.Empty;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            myCal.GetData(dataUM, "UM");
            myCal.GetData(dataAF, "AF");
            myCal.Calculate();
            DataGridView AA = myCal.ExportAAMatrix();
            DataGridView CA = myCal.ExportCAMatrix();
            DisplayMatrix(dataAA, AA);
            DisplayMatrix(dataCA, CA);

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

        private void NameRowAndColumn(DataGridView data, char rol, char col)
        {
            for (int i = 0; i < data.ColumnCount; i++)
                data.Columns[i].HeaderText = col + (i + 1).ToString();
            for (int i = 0; i < data.RowCount; i++)
                data.Rows[i].HeaderCell.Value = rol + (i + 1).ToString();
        }

        private void DisplayMatrix(DataGridView data, DataGridView source)
        {
            DrawMatrix(data, source.RowCount, source.ColumnCount);
            for (int i = 0; i < data.RowCount; i++)
                for (int j = 0; j < data.Rows[i].Cells.Count; j++)
                    data.Rows[i].Cells[j].Value = source.Rows[i].Cells[j].Value;
            NameRowAndColumn(data, 'A', 'A');
        }
    }
    #endregion
        
}
