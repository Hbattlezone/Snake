using Snake;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Box
    {
        Random random = new Random();
        public string dot = ".";
        public string box = "";
        char fruit = Convert.ToChar("■");
        public List<string> boxList = new List<string>();
        public int boxArea;
        public int boxDimensions;
        public int middleOfBoxOdd;
        public int middleOfBoxEven;
        public int middleOfValidSpaces;
        public List<int> validSpaces = new List<int>();
        public bool isFruit = false;
        public int height;
        public int width;

        //Constructor to create the Box's width and height.
        public Box(int width, int height)
        {
            boxArea = (height - 2) * (width - 2);
            boxDimensions = height * width;

            middleOfBoxOdd = (int) Math.Ceiling(boxDimensions / 2.0);
            middleOfBoxEven = middleOfBoxOdd - width / 2;

            this.height = height;
            this.width = width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        if (j < width - 1)
                            if (i == height - 1 && j != width - 1)
                            {
                                boxList.Add(dot);
                            }
                            else
                            {
                                boxList.Add(" ");
                            }

                        if (j == width - 1)
                        {
                            boxList.Add(dot);
                        }
                    }
                    else
                    {
                        boxList.Add(dot);
                    }
                }
            }

            CalculateSpace();
        }

        //Loops over the boxList variable and prints to the screen.
        public void PrintBox()
        {
            int newLineCount = 0;
            for (int i = 0; i < boxList.Count; i++)
            {
                Console.Write(boxList[i]);
                newLineCount++;
                if (newLineCount == width)
                {
                    Console.WriteLine();
                    newLineCount = 0;
                }
            }
        }

        //Debug -- Prints the box size to the Console screen.
        public void ShowBoxStats()
        {
            Console.Write("\nGamewindow Size: {0} x {1} = {2}", width, height, (height * width));
            Console.WriteLine("\n\nThe valid empty spaces inside the box are: ");
            foreach (int element in validSpaces)
                Console.Write(element + ", ");
            Console.WriteLine("\n\nThe amount of spaces: " + validSpaces.Count());
            Console.WriteLine("\nThe middle of the list is value: " + validSpaces[middleOfValidSpaces]);
            Console.WriteLine("The middle of the box value is: " + middleOfBoxOdd);
            Console.WriteLine("The snake is at position: {0}");
        }

        //Iterates over the boxList and places a defined fruit in a valid area.
        //TODO -- Break down code into smaller functions, too much going on here.
        public void RandomFruit()
        {
            CalculateSpace();
            int num1 = random.Next(1000);
            int num2 = random.Next(1000);
            int fruitLocation;
            int iCount = 0;
            int iterationCount = 0;
            this.isFruit = false;

            if (boxList.Contains(fruit.ToString()))
            {

            }

            while (isFruit == false)
            {
                for (int i = 0; i < boxList.Count; i++)
                {
                    iCount++;
                    if (boxList[i] == " ")
                    {
                        if (num1 == num2)
                        {
                            fruitLocation = i;
                            boxList.RemoveAt(i);
                            boxList.Insert(i, fruit.ToString());
                            isFruit = true;
                            break;
                        }
                        else
                        {
                            num1 = random.Next(1000);
                            num2 = random.Next(1000);
                        }
                    }
                    else
                    {
                        num1 = random.Next(1000);
                        num2 = random.Next(1000);
                    }
                }

                iterationCount++;
            }

            Console.WriteLine("\nAmount of number generations: " + iCount);
            Console.WriteLine("Amount of iterations: " + iterationCount);

        }

        //TODO code to iterate over the boxList and place the snake in the center of the screen.
        public void PlaceSnake(Player InputSnake)
        {
            CalculateSpace();

            if (height % 2 == 0 && width % 2 == 0)
            {
                boxList.RemoveAt(middleOfBoxEven);
                boxList.Insert(middleOfBoxEven, "s");
            }
            else if (width % 2 != 0 && height % 2 == 0)
            {
                boxList.RemoveAt(middleOfBoxEven);
                boxList.Insert(middleOfBoxEven, "s");
            }
            else
            {
                boxList.RemoveAt(middleOfBoxOdd);
                boxList.Insert(middleOfBoxOdd, "s");
            }

        }

        //Calculates all the blank spaces inside the defined game window and puts them into a string list.
        public void CalculateSpace()
        {
            validSpaces.Clear();
            for (int i = 0; i < boxDimensions; i++)
            {
                if (boxList[i] == " " && validSpaces.Contains(i + 1) == false)
                {
                    validSpaces.Add(i + 1);
                }
            }

            middleOfValidSpaces = validSpaces.Count / 2;

        }

        //Debug -- Prints the validSpaces string list to the screen.
        public void PrintValidSpaces()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player snake = new Player();

            Random num = new Random();
            bool isExit = false;

            do
            {
                Box newBox = new Box(num.Next(40, 50), num.Next(10, 20));
                newBox.PlaceSnake(snake);
                newBox.RandomFruit();
                newBox.ShowBoxStats();
                newBox.PrintBox();
                newBox.PrintValidSpaces();
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
            } while (isExit == false);
        }
    }
}


