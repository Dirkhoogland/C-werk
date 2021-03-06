using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Dirks's new Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The Lowest grade is {stats.Low}");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or q to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}

