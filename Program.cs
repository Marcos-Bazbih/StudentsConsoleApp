using StudentsConsoleApp;


List<Professor> professorsList = new List<Professor>();
List<string> studentsStrings = new List<string>();



void StudentMenu()
{
    try
    {
        Console.WriteLine("to add a student enter - 1");
        Console.WriteLine("to see all students enter - 2");
        int userSelect = int.Parse(Console.ReadLine());

        switch (userSelect)
        {
            case 1:
                AddProfessor();
                break;
            case 2:
                AddstudentToList();
                break;
            default:
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
StudentMenu();


void AddProfessor()
{
    Console.WriteLine("Enter your name");
    string professorName = Console.ReadLine();

    Console.WriteLine("Enter number of students");
    int numOfStudents = int.Parse(Console.ReadLine());


    for (int i = 0; i < numOfStudents; i++)
    {
        Professor currentStudent = new Professor();

        currentStudent.professorName = professorName;

        Console.WriteLine($"student number {i + 1} name");
        currentStudent.studentName = Console.ReadLine();

        Console.WriteLine($"student number {i + 1} id");
        currentStudent.studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("students grades");
        currentStudent.grades = new int[3];

        for (int j = 0; j < 3; j++)
        {
            Console.WriteLine($"student grade {j + 1}");
            currentStudent.grades[j] = int.Parse(Console.ReadLine());
        }

        professorsList.Add(currentStudent);
    }
    SaveProfessor();
}



void SaveProfessor()
{
    int counterId = 0;
    foreach (Professor student in professorsList)
    {
        FileStream professorFs = new FileStream($@"C:\TEST\STUDENTS\{student.professorName}.txt", FileMode.Append);
        using (StreamWriter writer = new StreamWriter(professorFs))
        {
            writer.WriteLine($"id:{counterId}, name:{student.studentName}, taz:{student.studentId}, grades: ");

            foreach (int grade in student.grades)
            {
                writer.Write(grade + " ,");
            }
            writer.WriteLine();
            counterId++;
        }
    }

}




void AddstudentToList()
{
    Console.WriteLine("Enter professor name");
    string fileName = Console.ReadLine();

    FileStream addToStudentsList = new FileStream($@"C:\TEST\STUDENTS\{fileName}.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(addToStudentsList))
    {
        for (int i = 0; i < reader.Peek(); i++)
        {
            studentsStrings.Add(reader.ReadLine());
        }
    }

    foreach (string item in studentsStrings)
    {
        Console.WriteLine(item);
        Console.WriteLine("*");
    }
}




//AddstudentToList("haim");
//AddstudentToList("marcos");





//void GetFirstStudent()
//{

//}












//foreach (string item in studentsStrings)
//{
//    Console.WriteLine(item);
//    Console.WriteLine("*");
//}










//for (int i = 0; i < professorsList.Count; i++)
//{
//    Console.WriteLine($"professor Name:{professorsList[i].professorName}");
//    Console.WriteLine($"student Name:{professorsList[i].studentName}");
//    Console.WriteLine($"student Id:{professorsList[i].studentId}");

//    for (int j = 0; j < professorsList[i].grades.Length; j++)
//    {
//        Console.WriteLine(professorsList[i].grades[j]);
//    }
//}