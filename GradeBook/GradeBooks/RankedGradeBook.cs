using System;
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
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Students are less than 5");
            }
            var grade = 'F';

            if (averageGrade >= 80) return grade = 'A';
            if (averageGrade >= 60 && averageGrade < 80) return grade = 'B';
            if (averageGrade >= 40 && averageGrade < 60) return grade = 'C';
            if (averageGrade >= 0 && averageGrade < 40) return grade = 'D';

            return grade;
        }
    }
}
