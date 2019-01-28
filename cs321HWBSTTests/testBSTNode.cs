using System;
using System.Collections.Generic;
using System.Text;

namespace cs321HWBSTTests
{
    internal class BSTnode
    {
        private int value;
        private BSTnode goLeft;
        private BSTnode goRight;

        internal BSTnode(int newValue)
        {
            this.value = newValue;
            this.goLeft = this.goRight = null;
        }

        internal BSTnode()
        {
            this.goLeft = this.goRight = null;
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ref BSTnode Left
        {
            get { return ref this.goLeft; }
        }

        public ref BSTnode Right
        {
            get { return ref this.goRight; }
        }
    }
}
