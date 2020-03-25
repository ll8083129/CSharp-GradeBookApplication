﻿using System;
using System.Collections.Generic;
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
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minumum of 5 students to work.");
            }
            var treshold = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> grades = new List<double>();
            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort();
            if(grades[treshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(treshold * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(treshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(treshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
