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
                Create_AA();
                CalculateAA();
                CalculateCA();
            }
        }



        #region Calculation
        private void CalculateAA()
        {
            int checkpoint = 0; //used to by pass duplicate cases. For example: calculating A[1][0] and A[0][1]
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
            List<int> A0 = new List<int>();
            List<int> order = new List<int>();
            int highestCont = 0;
            for (int i = 0; i < AA.Count; i++)
                A0.Add(0);

            CA.Add(AA[0]);          //obviously
            CA.Add(AA[1]);
            int checkpointCol = 2;  //used as a counter to present how many column that we have placed in CA
            for(int rowAA = 2; rowAA < AA.Count; rowAA++) //Since AA is symmetric matrix, row <=> col
            {
                for(int rowCA = 0; rowCA < checkpointCol; rowCA++)
                {
                    if (rowCA == 0)
                    {
                        int cont = CalContribution(A0, CA[rowCA], AA[rowAA], highestCont);
                        highestCont = cont;
                        order.Clear();
                        order.Add(0);
                        order.Add(rowCA);
                        order.Add(rowAA);
                    }
                    else if (rowCA == checkpointCol-1)
                    {
                        int cont = CalContribution(CA[rowCA], AA[rowAA], A0, highestCont);
                        if (cont > highestCont)
                        {
                            highestCont = cont;
                            order.Clear();
                            order.Add(rowCA);
                            order.Add(rowAA);
                            order.Add(0);
                        }
                    }
                    else
                    {
                        int cont = CalContribution(CA[rowCA], AA[rowAA], CA[rowCA+1], highestCont);
                        if (cont > highestCont)
                        {
                            highestCont = cont;
                            order.Clear();
                            order.Add(rowCA);
                            order.Add(rowAA);
                            order.Add(rowCA+1);
                        }
                    }
                }
                if (order[0] == 0)
                    CA.Insert(0, AA[rowAA]);
                else if (order[2] == 0)
                    CA.Add(AA[rowAA]);
                else
                    CA.Insert(order[0]+1, AA[rowAA]);
                highestCont = 0;
                order.Clear();
                checkpointCol++;
            }
        }

        private int CalContribution(List<int> left, List<int> mid, List<int> right, int highestCont)
        {
            return 2 * bond(left, mid) + 2 * bond(mid, right) - 2 * bond(left, right);
        }

        private int bond(List<int> col1, List<int> col2)
        {
            int res = 0;
            for (int i = 0; i < col1.Count; i++)
                res += col1[i] * col2[i];
            return res;
        }
        #endregion



        #region Utilities
        private void Create_AA()
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
                    newMatrix.Rows[row].Cells[col].Value = AA[col][row];
            }
            return newMatrix;
        }

        internal DataGridView ExportCAMatrix()
        {
            DataGridView newMatrix = new DataGridView();
            newMatrix.RowCount = CA.Count;
            newMatrix.ColumnCount = CA[0].Count;
            for (int row = 0; row < newMatrix.RowCount; row++)
            {
                List<int> row_matrix = new List<int>();
                for (int col = 0; col < newMatrix.ColumnCount; col++)
                    newMatrix.Rows[row].Cells[col].Value = CA[col][row];
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
