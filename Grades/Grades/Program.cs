using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();
            book.NameChanged = new NameChangedDelegate(OnNameChanged);
            book.NameChanged += OnNameChanged2; //compiler will accept this also

            book.Name = "Scott's Grade Book";
            book.Name="Scott is ";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine("AverageGrade " + stats.AverageGrade);
            Console.WriteLine("HighestGrade " + stats.HighestGrade);
            Console.WriteLine("LowestGrade " + stats.LowestGrade);


        }
        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing from {existingName} to {newName}");
        }
        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing from {existingName} to {newName}");
        }
    }
}
