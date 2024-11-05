
using System;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        var todo = new List<string>();
        bool bodyLoop = false;
        while (!bodyLoop)
        {
            Console.WriteLine();
            Console.WriteLine("Hello!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all todos");
            Console.WriteLine("[A]dd a Todo");
            Console.WriteLine("[D]elete Todo's");
            Console.WriteLine("[E]xit");
            Console.WriteLine();
            var userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "S":
                    SeeTodos();
                    break;
                case "A":
                    AddTodo();
                    break;
                case "D":
                    DeleteTodo();
                    break;
                case "E":
                    bodyLoop = true;
                    break;
            }

            void AddTodo()
            {
                bool isTrue = false;
                while (!isTrue)
                {
                    Console.WriteLine("Add a Description!");
                    var description = Console.ReadLine();
                    if (description == "")
                    {
                        Console.WriteLine("Description cannot be empty!");
                    }
                    else if (todo.Contains(description))
                    {
                        Console.WriteLine("Description must be unique");
                    }
                    else
                    {
                        isTrue = true;
                        todo.Add(description);
                        Console.WriteLine("Todo Added Successfully");
                    }
                }
            }

            void SeeTodos()
            {
                if (todo.Count == 0)
                {
                    Console.WriteLine("You have not added any Todos!");
                }
                else
                {
                    int i = 1;
                    foreach (var todos in todo)
                    {
                        Console.WriteLine($"{i}. {todos}");
                        i++;
                        //for (int i=0; i < todo.Count; i++)
                        //{
                        //    Console.WriteLine($"{i + 1}. {todo}");
                        //}
                    }
                }
            }

            void DeleteTodo()
            {
                
                bool loop = false;
                while (!loop)
                {
                    Console.WriteLine("Select the index of Todo to be deleted");
                    SeeTodos();
                    Console.WriteLine();
                    var input = Console.ReadLine();
                    var deleteIndex = int.Parse(input);


                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Selected index cannot be empty.");
                        continue;
                    }
                    else if (!int.TryParse(input, out deleteIndex))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number!.");
                        continue;
                    }
                    else if (deleteIndex < 1 || deleteIndex > todo.Count)
                    {
                        Console.WriteLine("Invalid Index. Please Enter an index within the range of list.");
                        continue;
                    }
                    else
                    {
                        int realDelete = deleteIndex - 1;
                        todo.RemoveAt(realDelete);
                        
                        //Console.WriteLine("Todo Removed: " + remove );
                        SeeTodos();
                        loop = true;
                    }
                    //else
                    //{
                    //    if (deleteIndex != todo.Count)
                    //    {
                    //        Console.WriteLine("Invalid Index. Please Enter an index within the range of list.");
                    //    }
                    //    else
                    //    {
                    //        todo.RemoveAt(deleteIndex - 1);
                    //        SeeTodos();
                    //        loop = true;
                    //    }

                    //}

                }
            }
        }
    }
}