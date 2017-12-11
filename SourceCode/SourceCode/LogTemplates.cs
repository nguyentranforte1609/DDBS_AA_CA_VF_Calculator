using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTemplates
{
    static class Constant
    {
        public const string calculatingAAElements = "A[{0}][{1}] = A[{1}][{0}] = ";
        public const string considerColumn = "Consider column A[{0}]";
        public const string contribution = "cont(A[{0}],A[{1}],A[{2}]) = ";
        public const string choosePointX = "Choose X at ({0},{0}): ";
    }
}