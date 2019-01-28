using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cpts321HW {
    namespace MyBST {

        struct BSTnode<T>
        {
            internal private BSTnode() { value = null; goLeft = goRight = null; }
            internal private BSTnode(T newValue) { value = newValue; }

            internal private T value;
            internal private BSTnode<T> goLeft;
            internal private BSTnode<T> goRight;
           
        }


        class BST<T>
        {
            public BST()
            {
                head = null;
                
                nodeCount = 0;
            }

            public BST(T value)
            {
                head = null;
                Add(value);
                nodeCount = 1;
            }



            /// <summary>
            /// checks if the 
            /// </summary>
            /// <param name="value"></param>
            public void Add(T value)
            {
                if(head != null)
                {
                    Add(value, head);
                }
                else
                {
                    head = new BSTnode<T>(value);
                }
            }



            /// <summary>
            /// private add that will traverse the tree till it finds an open space to put the data
            /// </summary>
            /// <param name="value">a value of T</param>
            /// <param name="currentHead">The current subtree being looked at</param>
            private void Add(T value, BSTnode currentHead)
            {
                if (currentHead == null)
                {
                    if (value < currentHead.value)
                    {
                        Add(value, currentHead.goLeft);
                    }
                    else
                    {
                        Add(value, currentHead.goRight);
                    }

                }
                else
                {
                    currentHead = new BSTnode<T>(value);
                }

            }


            public void printInOrder()
            {
                printInOrder(head);
            }

            private void printInOrder(BSTnode<T> currentHead)
            {
                printInOrder(currentHead.goLeft);
                if (currentHead != null)
                    Console.WriteLine(currentHead.value);
                printInOrder(currentHead.goRight);
            }

            private BSTnode<T> head; 
            private int nodeCount;

        }

    }
}