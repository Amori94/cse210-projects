using System;

namespace Learning04
{
    class Program
    {
        static void Main(string[] args)
        {
            Assignment student1 = new Assignment("Mara", "Math");
            MathAssignment student2 = new MathAssignment("Mario", "Math", "2", "These");
            WritingAssignment student3 = new WritingAssignment("Maria", "Writing", "Great Expectations");

            Console.WriteLine(student1.GetSummary());
            Console.WriteLine("");
            Console.WriteLine(student2.GetSummary());
            Console.WriteLine(student2.GetHomeworkList());
            Console.WriteLine("");
            Console.WriteLine(student3.GetSummary());
            Console.WriteLine(student3.GetWritingInfo());
        }
    }
}