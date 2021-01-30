using System;
using GradeBook.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException("Students are less than 5");

            // good ol copy pasting here
            var limit = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[limit - 1] <= averageGrade) return 'A';
            else if (grades[(limit * 2) - 1] <= averageGrade) return 'B';
            else if (grades[(limit * 3) - 1] <= averageGrade) return 'C';
            else if (grades[(limit * 4) - 1] <= averageGrade) return 'D';
            else return 'F';
        }
    }
}
