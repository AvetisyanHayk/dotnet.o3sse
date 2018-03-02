using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.o3sse
{
    class Program
    {
        private static List<string> GetFruit()
        {
            return new List<string> { "apple", "pear", "banana", "strawberry", "lemon" };
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { Firstname="Freddy", Secondname="Fish", Age=20 },
                new Student { Firstname="Bill", Secondname="Jones", Age=25 },
                new Student { Firstname="Kitty", Secondname="Cat", Age=18 },
                new Student { Firstname="Suwy", Secondname="Wan", Age=15 },
            };
        }

        delegate string CreateMessage1(string word);
        delegate string CreateMessage2(Student student, int max);

        static void Main(string[] args)
        {
            Console.WriteLine("[OEFENING 1]");
            Oefening1();
            Console.WriteLine("\n[OEFENING 2]");
            Oefening2();
            Console.WriteLine("\n[OEFENING 3]");
            Oefening3();
            Console.WriteLine("\n[OEFENING 4]");
            Oefening4();
            Console.WriteLine("\n[OEFENING 5]");
            Oefening5();
            Console.WriteLine();
        }

        private static void Oefening1()
        {
            CreateMessage1 cm = delegate (string word)
            {
                return word.ToUpper();
            };

            GetFruit().ForEach(word => Console.WriteLine(cm.Invoke(word)));
        }

        private static void Oefening2()
        {
            CreateMessage1 cm = delegate (string word)
            {
                return $"{word} telt {word.Length} tekens";
            };
            GetFruit().ForEach(word => Console.WriteLine(cm.Invoke(word)));
        }

        private static void Oefening3()
        {
            string prev = "";
            CreateMessage1 cm = delegate (string current)
            {
                if (prev == "")
                {
                    prev = current;
                    return "";
                }
                bool currentLarger = prev.Length > current.Length;
                string result = $"{prev} contains more characters than {current}: {currentLarger}";
                prev = current;
                return result;
            };
            GetFruit().ForEach(word =>
            {
                string message = cm.Invoke(word);
                if (!string.IsNullOrEmpty(message)) Console.WriteLine(message);
            });
        }

        private static void Oefening4()
        {
            CreateMessage1 cm = delegate (string word)
            {
                char[] charArr = word.ToCharArray();
                Array.Sort(charArr);
                return $"Characters of {word} alphabetically : \"{String.Join("", charArr)}\"";
            };
            GetFruit().ForEach(word => Console.WriteLine(cm.Invoke(word)));
        }

        private static void Oefening5()
        {
            CreateMessage2 cm = delegate (Student student, int max)
            {
                string not = "";
                if (student.Age < max) not = "not ";
                return $"{student} is {not}old enough";
            };
            GetStudents().ForEach(student => Console.WriteLine(cm.Invoke(student, 21)));
        }
    }
}
