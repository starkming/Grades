﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0;
            foreach(float grade in grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(stats.HighestGrade, grade);
                stats.LowestGrade = Math.Min(stats.LowestGrade, grade);
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if(_name != value)
                    {
                        NameChanged(_name, value);
                    }
                    _name = value;
                }
            }
        }
        public NameChangedDelegate NameChanged;
        private List<float> grades;
        private string _name;
    }
}
