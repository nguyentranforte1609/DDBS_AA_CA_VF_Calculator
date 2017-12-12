using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTemplates
{
    static class Constant
    {
        public const string calculatingAAElements = "\tA[{0}][{1}] = A[{1}][{0}] = ";
        public const string considerColumn = "Find new position for column A[{0}]";
        public const string contribution = "\tcont( A[{0}], A[{1}], A[{2}]) = ";
        public const string choosePointX = "Choose X at ({0}, {0}): ";
        public const string putA1A2inCA = "Put A1 and A2 in CA.";
        public const string informNewOrder = "\t=> New Order: {0}";
        public const string informPointX = "=> Choose X ({0}, {0})";
    }
}