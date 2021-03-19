using ConsoleAppProject.App03;
using System.Collections.Generic;

namespace WebApps.Models.App03
{
    /// <summary>
    /// This model keeps data for grade profiles in percentages
    /// </summary>
    public class GradeProfile
    {
        private List<Grades> _studentGrades;

        public GradeProfile()
        {
        }

        public GradeProfile(List<Grades> studentsGrades)
        {
            this._studentGrades = studentsGrades;

            SetProfiles();
        }

        public double FirstClass { get; private set; }
        public double UpperSecondClass { get; private set; }
        public double LowerSecondClass { get; private set; }
        public double ThirdClass { get; private set; }
        public double Fail { get; private set; }

        public string Message { get; set; }
        
        private void SetProfiles() 
        {
            foreach (var grade in this._studentGrades)
            {
                if (grade == Grades.F)
                    this.Fail++;

                else if (grade == Grades.D)
                    this.ThirdClass++;
                
                else if (grade == Grades.C)
                    this.LowerSecondClass++;
                
                else if (grade == Grades.B)
                    this.UpperSecondClass++;
                
                else if (grade == Grades.A)
                    this.FirstClass++;
            }

            this.FirstClass = this.FirstClass * (100 / this._studentGrades.Count);
            this.UpperSecondClass = this.UpperSecondClass * (100 / this._studentGrades.Count);
            this.LowerSecondClass = this.LowerSecondClass * (100 / this._studentGrades.Count);
            this.ThirdClass = this.ThirdClass * (100 / this._studentGrades.Count);
            this.Fail = this.Fail * (100 / this._studentGrades.Count);
        }
    }
}
