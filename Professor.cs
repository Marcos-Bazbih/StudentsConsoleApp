using System;

namespace StudentsConsoleApp
{
    class Professor
    {
        public string professorName;
        public string studentName;
        public int studentId;
        public int [] grades;
        public Professor() { }
        public Professor(string _professorName, string _studentName, int _studentId, int[] _grades)
        {
            this.professorName = _professorName;
            this.studentName = _studentName;
            this.studentId = _studentId;
            this.grades = _grades;
        }
    }
}
