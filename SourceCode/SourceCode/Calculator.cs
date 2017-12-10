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
        public Calculator()
        {

        }

        #region Calculation
        #region Calculate AA
        internal void CalculateAA(DataGridView dataUM, DataGridView dataAF, DataGridView dataAA)
        {
            dataAA.RowCount = dataUM.ColumnCount;
            dataAA.ColumnCount = dataUM.ColumnCount;
            int checkpoint = 0; //used to by pass duplicate cases. For example: calculating A[1][0] and A[0][1]
            for (int i = 0; i < dataAA.RowCount; i++)
            {
                for (int j = checkpoint; j < dataAA.Rows[i].Cells.Count; j++)
                {
                    int val = FindUsageOfAAonUM(dataUM, dataAF, i, j);
                    dataAA.Rows[i].Cells[j].Value = val;
                    dataAA.Rows[j].Cells[i].Value = val;
                }
                checkpoint++;
            }
        }

        private int FindUsageOfAAonUM(DataGridView dataUM, DataGridView dataAF, int first_A, int second_A)
        {
            //___If two attributes have access by queries, get the sum of that query access frequencies.
            int res = 0;
            for (int i = 0; i < dataUM.RowCount; i++)
            {
                if (int.Parse(dataUM.Rows[i].Cells[first_A].Value.ToString()) == 1 
                    && int.Parse(dataUM.Rows[i].Cells[second_A].Value.ToString()) == 1)
                {
                    res += GetSumQueriesAccess(dataAF,i);
                }
            }
            return res;
        }

        private int GetSumQueriesAccess(DataGridView dataAF, int idxRow)
        {
            //___Calculate sum of access frequencies of a given query
            int res = 0;
            for (int i = 0; i < dataAF.ColumnCount; i++)
                res += int.Parse(dataAF.Rows[idxRow].Cells[i].Value.ToString());
            return res;
        }
        #endregion

        #region Calculate CA
        internal List<int> CalculateCA(DataGridView dataAA)
        {
            DataGridViewRow ZeroRow = new DataGridViewRow();//This is A0 
            for (int i = 0; i < dataAA.RowCount; i++)       //Add zero cells to A0
            {
                ZeroRow.Cells.Add(new DataGridViewTextBoxCell { Value = 0 });
            }
            List<int> orderList = new List<int>();  //List of row order <=> column order
            //___Place column 1 and 2 of AA in CA
            orderList.Add(0);
            orderList.Add(1);
            for (int rowAA = 2; rowAA < dataAA.ColumnCount; rowAA++) //Since AA is symmetric matrix, row <=> col. 
            {
                int highestCont = 0;    //Highest contribution
                int position = 0;       //Position of current row which have highest contribution
                for (int i = 0; i < orderList.Count; i++)
                {
                    if (i == 0)
                    {
                        // Case (0,Ai,A1)
                        highestCont = CalculateCont(ZeroRow, dataAA.Rows[rowAA], dataAA.Rows[orderList[i]]);
                        position = i;
                    }
                    if (i != 0)
                    {
                        int currentCont = 0;
                        if (i == orderList.Count - 1)
                        {
                            // Case (An,Ai,0)
                            currentCont = CalculateCont(dataAA.Rows[orderList[i]], dataAA.Rows[rowAA], ZeroRow);
                        }
                        if (i != orderList.Count - 1)
                        {
                            // Normal Case
                            currentCont = CalculateCont(dataAA.Rows[orderList[i]], dataAA.Rows[rowAA], dataAA.Rows[orderList[i + 1]]);
                        }
                        // if current contribution is higher, change value of highest contribution and position 
                        if (highestCont < currentCont)
                        {
                            highestCont = currentCont;
                            position = i;
                        }
                    }
                }
                orderList.Insert(position+1, rowAA);    //Add position of crrent highest contribution to list
            }
            DataGridView CA = RearrangeAAUsingListOrder(orderList,dataAA);
            return orderList;
        }

        private int CalculateCont(DataGridViewRow left, DataGridViewRow mid, DataGridViewRow right)
        {
            return 2 * CalculateBond(left, mid) + 2 * CalculateBond(mid, right) - 2 * CalculateBond(left, right);
        }

        private int CalculateBond(DataGridViewRow left, DataGridViewRow mid)
        {
            int result = 0;
            for (int i = 0; i < left.Cells.Count; i++)
                result += int.Parse(left.Cells[i].Value.ToString()) * int.Parse(mid.Cells[i].Value.ToString());
            return result;
        }

        private DataGridView RearrangeAAUsingListOrder(List<int> orderList, DataGridView dataAA)
        {
            //Rearrange columns
            for(int i = 0; i < dataAA.RowCount; i++)
                for(int j = 0; j < dataAA.ColumnCount; j++)
                {
                    if(dataAA.Rows[i].Cells[j].ColumnIndex < orderList[j])
                    {
                        object temp = dataAA.Rows[i].Cells[j].Value;
                        dataAA.Rows[i].Cells[j].Value = dataAA.Rows[i].Cells[orderList[j]].Value;
                        dataAA.Rows[i].Cells[orderList[j]].Value = temp;
                    }
                }
            //Rearrange rows
            for (int i = 0; i < dataAA.RowCount; i++)
                for (int j = 0; j < dataAA.ColumnCount; j++)
                {
                    if (dataAA.Rows[i].Cells[j].RowIndex < orderList[i])
                    {
                        object temp = dataAA.Rows[i].Cells[j].Value;
                        dataAA.Rows[i].Cells[j].Value = dataAA.Rows[orderList[i]].Cells[j].Value;
                        dataAA.Rows[orderList[i]].Cells[j].Value = temp;
                    }
                }
            return dataAA;
        }
        #endregion

        #region Calculate VF
        internal int CalculateVF(DataGridView cloneUM, DataGridView dataAF, DataGridView dataCA)
        {
            int pointX = 0;
            long maxZ = 0;
            int EndPoint = dataCA.RowCount;
            List<int> TQ = new List<int>();
            List<int> BQ = new List<int>();
            List<int> OQ = new List<int>();
            for (int crrPoint = 0; crrPoint < EndPoint; crrPoint++)
            {
                TQ.Clear();
                BQ.Clear();
                OQ.Clear();
                // Get queries for TQ & BQ. Leftovers will be put in OQ
                for (int queryIndex = 0; queryIndex < cloneUM.RowCount; queryIndex++)
                {
                    int crrTASumQueryUsage = GetSumUsageOfQuery(cloneUM, queryIndex, 0, crrPoint);
                    int crrBASumQueryUsage = GetSumUsageOfQuery(cloneUM, queryIndex, crrPoint, EndPoint);
                    if (crrTASumQueryUsage > 0)
                        TQ.Add(queryIndex);
                    if (crrBASumQueryUsage > 0)
                        BQ.Add(queryIndex);
                    //Put queries that didn't access any attributes in OQ
                    if (crrTASumQueryUsage == 0 && crrBASumQueryUsage == 0)
                        OQ.Add(queryIndex);
                }
                for (int i = 0; i < TQ.Count; i++)
                {   // Add any duplication in TQ & BQ to OQ
                    if (BQ.IndexOf(TQ[i]) != -1)
                        OQ.Add(TQ[i]);
                }
                for (int i = 0; i < OQ.Count; i++)
                {   // Remove duplications in TQ & BQ
                    if (TQ.IndexOf(OQ[i]) != -1 && BQ.IndexOf(OQ[i]) != -1)
                    {
                        TQ.RemoveAt(TQ.IndexOf(OQ[i]));
                        BQ.RemoveAt(BQ.IndexOf(OQ[i]));
                    }
                }
                // Calculate current Z
                long crrZ = CalculateZ(TQ, BQ, OQ, dataAF);
                if (maxZ < crrZ)
                {
                    maxZ = crrZ;
                    pointX = crrPoint;
                }
            }
            return pointX;
        }

        private long CalculateZ(List<int> TQ, List<int> BQ, List<int> OQ, DataGridView dataAF)
        {
            long Z = 0;
            long CTQ = GetSumAccessOfQueriesSet(dataAF, TQ);
            long CBQ = GetSumAccessOfQueriesSet(dataAF, BQ);
            long COQ = GetSumAccessOfQueriesSet(dataAF, OQ);
            // Apply formula to calculate Z
            Z = CTQ * CBQ - COQ * COQ;
            return Z;
        }

        private long GetSumAccessOfQueriesSet(DataGridView dataAF, List<int> queries)
        {
            int sum = 0;
            for (int i = 0; i < queries.Count; i++)
                sum += GetSumQueriesAccess(dataAF, queries[i]);
            return sum;
        }

        private int GetSumUsageOfQuery(DataGridView cloneUM, int queryIndex, int start, int end)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
                sum += int.Parse(cloneUM.Rows[queryIndex].Cells[i].Value.ToString());
            return sum;
        }

        internal DataGridView ReorderColsOfUM(DataGridView cloneUM, List<int> orderList)
        {
            //Rearrange columns
            for (int i = 0; i < cloneUM.RowCount; i++)
                for (int j = 0; j < cloneUM.ColumnCount; j++)
                {
                    if (cloneUM.Rows[i].Cells[j].ColumnIndex < orderList[j])
                    {
                        object temp = cloneUM.Rows[i].Cells[j].Value;
                        cloneUM.Rows[i].Cells[j].Value = cloneUM.Rows[i].Cells[orderList[j]].Value;
                        cloneUM.Rows[i].Cells[orderList[j]].Value = temp;
                    }
                }
            return cloneUM;
        }
        #endregion
        #endregion
    }
}
