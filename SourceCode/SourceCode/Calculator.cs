using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    class Calculator
    {
        protected List<List<int>> UM;
        protected List<List<int>> AF;
        protected List<List<int>> AA;
        protected List<List<int>> CA;        
        public Calculator()
        {
            UM = new List<List<int>>();
            AF = new List<List<int>>();
            AA = new List<List<int>>();
            CA = new List<List<int>>();
        }

        internal void GetData(DataGridView data, string name)
        {
            List<List<int>> matrix = new List<List<int>>();
            for (int row = 0; row < data.RowCount; row++)
            {
                List<int> row_matrix = new List<int>();
                for (int col = 0; col < data.ColumnCount; col++)
                    row_matrix.Add(int.Parse(data.Rows[row].Cells[col].Value.ToString()));
                matrix.Add(row_matrix);
            }
            if (name == "UM")
                this.UM = matrix;
            if (name == "AF")
                this.AF = matrix;
        }

        internal void Calculate()
        {
            if (CheckDataValidity())
            {
                Create_AA_CA();
                CalculateAA();
                CalculateCA();
            }
        }



        #region Calculation
        private void CalculateAA()
        {
            int checkpoint = 0;
            for (int i = 0; i < AA.Count; i++)
            {
                for (int j = checkpoint; j < AA[0].Count; j++)
                {
                    int val = FindUsage(i, j);
                    AA[i][j] = val;
                    AA[j][i] = val;
                }
                checkpoint++;
            }
        }

        private int FindUsage(int first_A, int second_A)
        {
            int res = 0;
            for (int i = 0; i < UM.Count; i++)
            {
                if (UM[i][first_A] == 1 && UM[i][second_A] == 1)
                {
                    res += GetSumQueriesAccess(i);
                }
            }
            return res;
        }

        private int GetSumQueriesAccess(int row)
        {
            int res = 0;
            for (int i = 0; i < AF[0].Count; i++)
                res += AF[row][i];
            return res;
        }

        private void CalculateCA()
        {

        }
        #endregion



        #region Utilities
        private void Create_AA_CA()
        {
            //Create sample AA, CA for later use
            List<List<int>> matrix = new List<List<int>>();
            for (int row = 0; row < UM.Count; row++)
            {
                List<int> row_matrix = new List<int>();
                for (int col = 0; col < UM[row].Count; col++)
                    row_matrix.Add(0);
                matrix.Add(row_matrix);
            }
            AA = matrix;
            CA = matrix;
        }

        internal DataGridView ExportAAMatrix()
        {
            DataGridView newMatrix = new DataGridView();
            newMatrix.RowCount = AA.Count;
            newMatrix.ColumnCount = AA[0].Count;
            for (int row = 0; row < newMatrix.RowCount; row++)
            {
                List<int> row_matrix = new List<int>();
                for (int col = 0; col < newMatrix.ColumnCount; col++)
                    newMatrix.Rows[row].Cells[col].Value = AA[row][col];
            }
            return newMatrix;
        }
    
        private bool CheckDataValidity()
        {
            if (this.UM.Count < 0
                || this.AF.Count < 0
                || this.AA.Count < 0
                || this.CA.Count < 0)
                return false;
            return true;
        }
        #endregion
    }
}
