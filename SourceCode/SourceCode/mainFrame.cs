using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class mainFrame : Form
    {
        public mainFrame()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreateUM_Click(object sender, EventArgs e)
        {
            if(checkInputRowCol(textRowUM,textColUM))
            {
                DrawMatrix(dataUM, int.Parse(textRowUM.Text), int.Parse(textColUM.Text));
            }
        }

        private void btnCreateAFM_Click(object sender, EventArgs e)
        {
            if(checkInputRowCol(textRowAFM, textColAFM))
            {
                DrawMatrix(dataAFM, int.Parse(textRowAFM.Text), int.Parse(textColAFM.Text));
            }
        }

        private void DrawMatrix(DataGridView dataView, int row, int col)
        {
            dataView.RowCount = row;
            dataView.ColumnCount = col;
        }

        private bool checkInputRowCol(TextBox textRow, TextBox textCol)
        {
            if (textRow.Text != "" && textCol.Text != "")
            {
                int temp1, temp2;
                if (int.TryParse(textRow.Text, out temp1) && int.TryParse(textCol.Text, out temp2))
                    return true;
            }
            return false;
        }
    }
}
