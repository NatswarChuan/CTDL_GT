using System;
using System.Collections.Generic;
using System.Text;

namespace CTDL_GT
{
    class Node
    {
        public BienLai Value;
        public Node Next;

        public Node(BienLai value)
        {
            this.Value = value;
        }
    }
}
