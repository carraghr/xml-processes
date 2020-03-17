using ABM_Developer_Test.question_1;
using ABM_Developer_Test.question_2;
using ABM_Developer_Test.Question_3;
using System;

namespace ABM_Developer_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            Console.WriteLine();
            EdifactQuestion test = new EdifactQuestion();
            test.RunSolution();

            Console.WriteLine();
            Console.WriteLine("Question 2");
            Console.WriteLine();

            XmlQuestion test2 = new XmlQuestion();
            test2.RunSolution();

            Console.WriteLine();
            Console.WriteLine("Question 3");
            Console.WriteLine();
            ValidateXML test3 = new ValidateXML();
            test3.Run();
        }
    }
}
