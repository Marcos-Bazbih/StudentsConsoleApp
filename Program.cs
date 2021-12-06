using StudentsConsoleApp;


List<Professor> professorsList = new List<Professor>();
List<string> studentsStrings = new List<string>();



void StudentMenu()
{
    try
    {
        Console.WriteLine("to add a student enter - 1");
        Console.WriteLine("to see all students enter - 2");
        Console.WriteLine("to see first student enter - 3");
        int userSelect = int.Parse(Console.ReadLine());

        switch (userSelect)
        {
            case 1:
                AddProfessor();
                break;
            case 2:
                AddstudentToList();
                break;
            case 3:
                GetFirstStudent();
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
            writer.Write($"id:{counterId}, name:{student.studentName}, taz:{student.studentId}, grades:");

            foreach (int grade in student.grades)
            {
                writer.Write(" "+grade);
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
    }
}



void GetFirstStudent()
{
    Console.WriteLine("Enter prfessor name");
    string prfessorName = Console.ReadLine();

    FileStream firstStudentFs = new FileStream($@"C:\TEST\STUDENTS\{prfessorName}.txt", FileMode.Open);
    using (StreamReader Reader = new StreamReader(firstStudentFs))
    {
        string student = Reader.ReadLine();

        int nameStart = student.IndexOf("name:")+5;
        int nameEnd = student.IndexOf(", taz")-11;

        string fName = student.Substring(nameStart, nameEnd);
        Console.WriteLine(fName);

        int grade1Start = student.IndexOf("grades:") + 8;
        int grade1End = student.IndexOf(" ");

        string grade1 = student.Substring(grade1Start, grade1End-2);

        string grade2 = student.Substring(grade1End, grade1End);


        //string grade3 = student.Substring(student.IndexOf(grade2) + grade2.Length+1);

        Console.WriteLine(grade1);
        Console.WriteLine(grade2);
        //Console.WriteLine(grade3);
    }

}

