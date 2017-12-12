using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogTemplates;

namespace SourceCode
{
    class Calculator
    {
        public string calculatorLogs;
        public Calculator()
        {
            calculatorLogs = string.Empty;
        }

        #region Calculation
        #region Calculate AA
        internal void CalculateAA(DataGridView dataUM, DataGridView dataAF, DataGridView dataAA)
        {
            calculatorLogs = string.Empty;
            dataAA.RowCount = dataUM.ColumnCount;
            dataAA.ColumnCount = dataUM.ColumnCount;
            int checkpoint = 0; //used to by pass duplicate cases. For example: calculating A[1][0] and A[0][1]
            for (int i = 0; i < dataAA.RowCount; i++)
            {
                for (int j = checkpoint; j < dataAA.Rows[i].Cells.Count; j++)
                {
                    AddLogs(String.Format(LogTemplates.Constant.calculatingAAElements, (i+1).ToString(), (j+1).ToString()), false);
                    int val = FindUsageOfAAonUM(dataUM, dataAF, i, j);
                    dataAA.Rows[i].Cells[j].Value = val;
                    dataAA.Rows[j].Cells[i].Value = val;
                    AddLogs(val.ToString(), true);
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
                int sum = 0;
                if (int.Parse(dataUM.Rows[i].Cells[first_A].Value.ToString()) == 1 
                    && int.Parse(dataUM.Rows[i].Cells[second_A].Value.ToString()) == 1)
                {
                    sum = GetSumQueriesAccess(dataAF,i);
                    res += sum;
                }
                //Logs
                if (i != dataUM.RowCount - 1)
                    AddLogs(sum.ToString() + "+");
                else
                    AddLogs(sum.ToString());
                if (i == dataUM.RowCount - 1)
                    AddLogs("=");
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
        internal List<int> CalculateCA(DataGridView dataCA)
        {
            calculatorLogs = string.Empty;
            DataGridViewRow ZeroRow = new DataGridViewRow();//This is A0 
            for (int i = 0; i < dataCA.RowCount; i++)       //Add zero cells to A0
            {
                ZeroRow.Cells.Add(new DataGridViewTextBoxCell { Value = 0 });
            }
            List<int> orderList = new List<int>();  //List of row order <=> column order
            //___Place column 1 and 2 of AA in CA
            AddLogs(LogTemplates.Constant.putA1A2inCA,true);
            orderList.Add(0);
            orderList.Add(1);
            for (int rowAA = 2; rowAA < dataCA.ColumnCount; rowAA++) //Since AA is symmetric matrix, row <=> col. 
            {
                AddLogs(String.Format(LogTemplates.Constant.considerColumn, (rowAA+1).ToString()),true);
                int highestCont = 0;    //Highest contribution
                int position = 0;       //Position of current row which have highest contribution
                for (int i = -1; i < orderList.Count; i++)
                {
                    int currentCont = 0;
                    if (i == -1)
                    {
                        // Case (0,Ai,A1)
                        AddLogs(String.Format(LogTemplates.Constant.contribution, "0", (rowAA + 1).ToString(), (orderList[0]+1).ToString()));
                        currentCont = CalculateCont(ZeroRow, dataCA.Rows[rowAA], dataCA.Rows[orderList[0]]);
                        AddLogs(currentCont.ToString(), true);
                    }
                    if (i == orderList.Count - 1)
                    {
                        // Case (An,Ai,0)
                        AddLogs(String.Format(LogTemplates.Constant.contribution, (orderList[i]+1).ToString(), (rowAA + 1).ToString(), "0"));
                        currentCont = CalculateCont(dataCA.Rows[orderList[i]], dataCA.Rows[rowAA], ZeroRow);
                        AddLogs(currentCont.ToString(), true);
                    }
                    if (i != orderList.Count - 1 && i != -1)
                    {
                        // Normal Case
                        AddLogs(String.Format(LogTemplates.Constant.contribution, (orderList[i]+1).ToString(), (rowAA + 1).ToString(), (orderList[i+1]+1).ToString()));
                        currentCont = CalculateCont(dataCA.Rows[orderList[i]], dataCA.Rows[rowAA], dataCA.Rows[orderList[i + 1]]);
                        AddLogs(currentCont.ToString(), true);
                    }
                    // if current contribution is higher, change value of highest contribution and position 
                    if (highestCont < currentCont)
                    {
                        highestCont = currentCont;
                        position = i;
                    }
                }
                orderList.Insert(position+1, rowAA);    //Add position of crrent highest contribution to list
                AddLogs(String.Format(LogTemplates.Constant.informNewOrder, GenerateStringSetOfQueries(orderList,"A"), true));
                AddLogs(" ", true);
            }
            DataGridView CA = RearrangeAAUsingListOrder(orderList,dataCA);
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
            calculatorLogs = string.Empty;
            int pointX = 0;
            long maxZ = 0;
            int EndPoint = dataCA.RowCount; // The final possible point on diagonal line of CA matrix. 
                                            // Since each point on diagonal line is present as CA[i][i], saving one value i is enough.
            List<int> TQ = new List<int>();
            List<int> BQ = new List<int>();
            List<int> OQ = new List<int>();
            for (int crrPoint = 1; crrPoint < EndPoint; crrPoint++)
            {
                AddLogs(String.Format(LogTemplates.Constant.choosePointX, (crrPoint).ToString()), true);
                TQ.Clear();
                BQ.Clear();
                OQ.Clear();
                // Get queries for TQ & BQ. Leftovers will be put in OQ
                for (int queryIndex = 0; queryIndex < cloneUM.RowCount; queryIndex++)
                {
                    int crrTASumQueryUsage = GetSumUsageOfQueryOnAttributes(cloneUM, queryIndex, 0, crrPoint);
                    int crrBASumQueryUsage = GetSumUsageOfQueryOnAttributes(cloneUM, queryIndex, crrPoint, EndPoint);
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
                //Logs
                AddLogs("\tTQ = {" + GenerateStringSetOfQueries(TQ, "q") + "}",true);
                AddLogs("\tBQ = {" + GenerateStringSetOfQueries(BQ, "q") + "}", true);
                AddLogs("\tOQ = {" + GenerateStringSetOfQueries(OQ, "q") + "}", true);
                // Calculate current Z
                long crrZ = CalculateZ(TQ, BQ, OQ, dataAF);
                if (maxZ < crrZ)
                {
                    maxZ = crrZ;
                    pointX = crrPoint;
                }
            }
            AddLogs("",true);
            AddLogs(String.Format(LogTemplates.Constant.informPointX, pointX), true);
            return pointX;
        }

        private long CalculateZ(List<int> TQ, List<int> BQ, List<int> OQ, DataGridView dataAF)
        {
            long Z = 0;
            long CTQ = GetSumOfAccessFrequenciesOnSite(dataAF, TQ);
            long CBQ = GetSumOfAccessFrequenciesOnSite(dataAF, BQ);
            long COQ = GetSumOfAccessFrequenciesOnSite(dataAF, OQ);
            AddLogs("\tCTQ = " + CTQ.ToString(),true);
            AddLogs("\tCBQ = " + CBQ.ToString(),true);
            AddLogs("\tCOQ = " + COQ.ToString(),true);
            // Apply formula to calculate Z
            Z = CTQ * CBQ - COQ * COQ;
            AddLogs("\tz = " + Z.ToString(), true);
            return Z;
        }

        private long GetSumOfAccessFrequenciesOnSite(DataGridView dataAF, List<int> queries)
        {
            int sum = 0;
            for (int i = 0; i < queries.Count; i++)
                sum += GetSumQueriesAccess(dataAF, queries[i]);
            return sum;
        }

        private int GetSumUsageOfQueryOnAttributes(DataGridView cloneUM, int queryIndex, int start, int end)
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



        #region Utilities
        private void AddLogs(string line, bool EOL = false)
        {
            calculatorLogs += line;
            if (EOL == true)
                calculatorLogs += Environment.NewLine;
        }

        private string GenerateStringSetOfQueries(List<int> listQueries, string symbol = "")
        {
            string res = String.Empty;
            for (int i = 0; i < listQueries.Count; i++)
            {
                res += symbol + (listQueries[i] + 1).ToString() + " ";
                if (i < listQueries.Count - 1)
                    res += ",";
            }
            return res;
        }
        #endregion
    }
}
