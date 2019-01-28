using System;
using System.Collections.Generic;
using System.Text;

namespace cs321HWBSTTests
{
    internal class BST
    {
        private BSTnode head;
        private int levelCount;

        public BST()
        {
            this.levelCount = 0;
        }

        public BST(List<int> list)
        {
            this.levelCount = 0;
            this.head = null;
            foreach (int x in list)
            {
                this.Add(x);
            }
        }

        public BST(int value)
        {
            this.levelCount = 0;
            this.head = null;
            this.Add(value);
        }

        /// <summary>
        /// Allows the user to pass in a string of integers which are then read and added
        /// </summary>
        /// <param name="userInput">The string of integers to be added</param>
        public void Add(string userInput)
        {
            int temp = 0;
            string[] numbers = userInput.Split(' ');
            if (userInput != string.Empty)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (int.TryParse(numbers[i], out temp))
                    {
                        this.Add(int.Parse(numbers[i]));
                    }
                }
            }
        }

        /// <summary>
        /// public add checks if the insertion is simple
        /// if simple if simply puts it in
        /// </summary>
        /// <param name="value">The value to be placed in the tree</param>
        public void Add(int value)
        {
            int level = 1;
            if (this.head != null)
            {
                this.Add(value, ref this.head, level);
            }
            else
            {
                this.head = new BSTnode(value);
                this.levelCount++;
            }
        }

        /// <summary>
        /// Calculates the current number of nodes in the tree
        /// finds the current height level of the tree
        /// Calculates the minimum possible height for a tree with such a number of nodes
        /// </summary>
        public void Statistics()
        {
            int nodeCount = 0;
            nodeCount = this.countNodes();
            int minimumLevels;

            Console.WriteLine("The number of nodes is " + nodeCount);
            Console.WriteLine("The number of levels is " + this.levelCount);

            minimumLevels = minLevel();

            Console.WriteLine("A tree with " + nodeCount + " nodes would have a minimum level of " + minimumLevels);
        }

        public int minLevel()
        {
            int nodeCount = this.countNodes();
            if (nodeCount > 1)
            {
                return (int)Math.Ceiling(Math.Sqrt(nodeCount + 1));
            }
            else if (nodeCount == 1)
            {
                return 1;
            }
            else
            {
               return 0;
            }
        }

        public int countNodes()
        {
            return CountNodes(this.head);
        }
        /// <summary>
        /// checks to see if an item exists in the tree
        /// </summary>
        /// <param name="value">The value to be searched for</param>
        /// <returns>A boolean based on if it found the element or not</returns>
        public bool Find(int value)
        {
            return this.Find(value, this.head);
        }

        /// <summary>
        /// first checks if the tree has any elements, if not it gives an error, else it goes to print the tree
        /// </summary>
        public void PrintInOrder()
        {
            if (this.head != null)
            {
                this.PrintInOrder(this.head);
            }
            else
            {
                Console.WriteLine("ERROR: No tree exists to print in order");
            }
        }

        /// <summary>
        /// private add that will traverse the tree till it finds an open space to put the data
        /// </summary>
        /// <param name="value">a value of T</param>
        /// <param name="currentHead">The current subtree being looked at</param>
        /// <param name = "currentLevel">A value to test if the tree grows in height</param>
        private void Add(int value, ref BSTnode currentHead, int currentLevel)
        {
            if (!this.Find(value))
            {
                if (currentHead != null)
                {
                    if (value < currentHead.Value)
                    {
                        currentLevel++;
                        this.Add(value, ref currentHead.Left, currentLevel);
                    }
                    else
                    {
                        currentLevel++;
                        this.Add(value, ref currentHead.Right, currentLevel);
                    }
                }
                else
                {
                    if (currentLevel > this.levelCount)
                    {
                        this.levelCount = currentLevel;
                    }

                    currentHead = new BSTnode(value);
                }
            }
        }

        private void PrintInOrder(BSTnode currentHead)
        {
            if (currentHead != null)
            {
                this.PrintInOrder(currentHead.Left);
                if (currentHead != null)
                {
                    Console.WriteLine(currentHead.Value);
                }

                this.PrintInOrder(currentHead.Right);
            }
        }

        /// <summary>
        /// Will search to see if an item exists in the tree
        /// </summary>
        /// <param name="value">The value to be found</param>
        /// <param name="currentHead">The current subtree being searched</param>
        /// <returns>returns false if it encounters a null object before finding the item.
        /// returns true if it encounters an object containing the same value</returns>
        private bool Find(int value, BSTnode currentHead)
        {
            if (currentHead != null)
            {
                if (value != currentHead.Value)
                {
                    if (value < currentHead.Value)
                    {
                        return this.Find(value, currentHead.Left);
                    }
                    else
                    {
                        return this.Find(value, currentHead.Right);
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private int CountNodes(BSTnode currentHead)
        {
            int count = 0;
            if (currentHead != null)
            {
                count++;
                return count + this.CountNodes(currentHead.Left) + this.CountNodes(currentHead.Right);
            }
            else
            {
                return count;
            }
        }
    }
}
