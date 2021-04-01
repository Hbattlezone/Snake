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
        public string newLine = "\n";
        char fruit = Convert.ToChar("■");
        public List<string> boxList = new List<string>();
        public int boxArea;
        public int middleOfBox;
        public List<int> validSpaces = new List<int>();
        public bool isFruit = false;
        readonly int height;
        readonly int width;

        //Constructor to create the Box's width and height.
        public Box(int height, int width)
        {
            boxArea = (height - 2) * (width - 2);

            this.height = height;
            this.width = width;

            for (int i = 0; i < height; i++)
            {
                boxList.Add(newLine);

                for (int j = 0; j < width; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        if (i > 0 && j < width -1)
                            if (i == height -1 && j != width -1)
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
            this.CalculateSpace();
        }

        //Loops over the boxList variable and prints to the screen.
        public void PrintBox()
        {
            foreach (string item in this.boxList)
                Console.Write(item);
        }

        //Converts the box string variable into a string list and puts it in boxList variable.
        public void ResetBox()
        {

        }

        //Debug -- Prints the box size to the Console screen.
        public void ShowBoxStats()
        {
            Console.Write("Gamewindow Size: {0} x {1} = {2}", height, width, (height * width));
            Console.WriteLine("\n" + boxArea);
        }

        //Iterates over the boxList and places a defined fruit in a valid area.
        //TODO -- Break down code into smaller functions, too much going on here.
        public void RandomFruit()
        {
            int num1 = random.Next(1000);
            int num2 = random.Next(1000);
            int fruitLocation;
            int iCount = 0;
            int iterationCount = 0;
            bool isFruit = false;

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
        public void PlaceSnake()
        {
            Player snake = new Player();
            snake.DSnake.Add("Snake", new Tuple<string, int, int>("s", 1, 0));
            snake.DSnake.Add("Tail", new Tuple<string, int, int>("o", 0, 0));

            middleOfBox = (int)Math.Ceiling(boxArea / 2.0);
            boxList.RemoveAt(middleOfBox);
            boxList.Insert(middleOfBox, snake.DSnake["Snake"].Item1);

            
        }

        //Calculates all the blank spaces inside the defined game window and puts them into a string list.
        public void CalculateSpace()
        {
            for (int i = 0; i < boxList.Count; i++)
            {
                if (boxList[i] == "\n")
                    {
                        
                    }
                if (boxList[i] == " ")
                {
                    validSpaces.Add(i);
                }
            }
        }

        //Debug -- Prints the validSpaces string list to the screen.
        public void PrintValidSpaces()
        {
            Console.WriteLine("\nThe valid empty spaces inside the box are: ");
            foreach (int element in validSpaces)
                Console.Write(element + ", ");
            Console.WriteLine("\nThe amount of spaces: " + validSpaces.Count());
            Console.WriteLine("\nThe middle of the list is value: " + validSpaces[middleOfBox]);
        }

        //REMOVE -- might not need to find newlines to remove from the string.
        public int FindNewlines()
        {
            int count = 0;
            foreach (string x in boxList.FindAll(x => x == "\n."))
            {
                count++;
            }
            return count;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {

        Box newBox = new Box(6, 6);



        bool isExit = false;

        //do
        //{
        //}
        //while (isExit == false);

        newBox.ShowBoxStats();
        newBox.RandomFruit();
        newBox.PlaceSnake();
        newBox.PrintBox();
        newBox.PrintValidSpaces();
        Console.ReadLine();
        //System.Threading.Thread.Sleep(3000);
        //Console.Clear();

    }
}


