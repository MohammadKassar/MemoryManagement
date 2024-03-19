using System;
using System.ComponentModel.Design;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        // Question 1:
        // The stack is a memory allocation system with a LIFO structure. the stack itself is responsible for how code is stored.
        // When a piece of code is about to be executed, the last piece is called, after which it is removed from the stack so that the next piece can be executed.
        // The heap is tree structure.
        // any order. once a piece of code has been executed, it remains on the heap so it can be executed again and again. If no external
        // code deletes the segment, it remains until the "Dirty collector" deletes it or the program exits.

        // Question 2:
        // Value types are types from System.ValueType. These are stored directly in variables. They can end up both on the stack or the heap.
        // Reference types are types that inherit from System.Object. These can be any object and they are always stored in
        // the heap and variables refer to them.

        // Question 3:
        // The first one works with integers ie value types. y copies x, while x remains as it is.
        // The other works with objects ie reference types. When y is set to x, only the reference is copied. Both y and x refer
        // to the same object. When y changes its value to 4, the original value is overwritten. 

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
            when the count of elements exceeds the capacity of the underlying array.
            Med hur mycket ökar kapaciteten?
            doubles each time it needs to be increased
            Varför ökar inte listans kapacitet i samma takt som element läggs till?
            because doubling the capacity each time allows for efficient memory usage and reduces the frequency of resizing operations.
            Minskar kapaciteten när element tas bort ur listan?
            no the capacity remains unchanged unless explicitly modified.
            När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            if memory usage needs to be tightly controlled or if performance optimizations are necessary

             * 
            */

            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("enter ' + ' followed by name to add OR ' - ' followed by name to remove item from the lsit press 0 to Exit ");
                string input = Console.ReadLine();
                if (input == "0") break;
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"added {value} to the list. {theList.Count}, {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value} from the list. {theList.Count}, {theList.Capacity}");
                        break;
                    default:
                        Console.WriteLine($"use only + or -");
                        break;
                }
            }
            //
            //
            //

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> queue = new Queue<string>();
            Console.WriteLine("ica open and the qashier queue is empty");
            while (true)
            {
                Console.WriteLine("enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit ");
                string input = Console.ReadLine();

                if (input == "0") break;

                char nav = input[0];
                string value = input.Substring(1).Trim();
                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        Console.WriteLine($"enqueue {value} to the queue ");
                        break;
                    case '-':
                        if (queue.Count > 0)
                        {
                            string dequeue = queue.Dequeue();
                            Console.WriteLine($" dequeues {dequeue} from the queue ");
                        }
                        else
                        {
                            Console.WriteLine("queue is empty");
                        }
                        break;
                    default:
                        Console.WriteLine("please use only ' + ' or ' - '");
                        break;
                }
                /*
                 * enqueue Kalle to the queue
                enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit
            +greta
                enqueue greta to the queue
                enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit
            -
        dequeues Kalle from the queue
                enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit
            +Stina
                enqueue Stina to the queue
                enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit
            -
        dequeues greta from the queue
                enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit
            +olle
                enqueue olle to the queue
                enter ' + ' to enqueue or ' - ' to dequeue person from the queue enter ' 0 ' to exit              +olle
                */

            }

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<string> stack = new Stack<string>();
            while (true)
            {
                Console.WriteLine("enter ' + ' to push or ' _ ' to pop item from thje stack or press 0 to exit");
                string input = Console.ReadLine();
                if (input == "0") break;

                char nav = input[0];
                string value = input.Substring(1).Trim();

                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        Console.WriteLine($" push {value} to the stack ");
                        break;
                    case '-':
                        if (stack.Count > 0)
                        {
                            string poppedItem = stack.Pop();
                            Console.WriteLine($"popped {poppedItem}from the stack");
                        }
                        else
                        {
                            Console.WriteLine($"stack is empty");
                        }
                        break;
                    default:
                        Console.WriteLine($" please use only ' + ' or ' - '");
                        break;
                }
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            while (true)
            {
                Console.WriteLine("cheack if it is well formad or not or 0 to exit");
                string input = Console.ReadLine();

                if (input == "0") break;

                if (IsWellFormed(input))
                {
                    Console.WriteLine("the string is in right formad ");
                }
                else
                {
                    Console.WriteLine("the string is not well formad");
                }
            }

        }
        static bool IsWellFormed(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == ']')
                {
                    stack.Push(c);
                }

                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}

        
