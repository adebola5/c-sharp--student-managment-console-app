namespace StudentListSystemClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //create a list of students
            List<Student> list = new List<Student>();

            //ask user if they want to continue or not
            string userInput;
            Console.WriteLine("Do you want to add a student? (y/n):: ");
             userInput = Console.ReadLine();

            //use a while loop to say as long as y is not clicked end the program
            while (userInput.ToLower() == "y")
            {
               Console.WriteLine("Enter the student name: ");
               string name = Console.ReadLine();

                //when getting an int learn to tty to parse first so it does not crash
               Console.WriteLine("Enter the student's age: ");
                int age;
                bool isValid = int.TryParse(Console.ReadLine(), out age);

                if (!isValid)
                {
                    Console.WriteLine("Invalid age. Try again.");
                    continue;
                }
                //create a new student with the info , then add it to the list
                Student student = new Student();
                student.Name = name;
                student.Age = age;
                list.Add(student);

                //tell the user that the student has been added
                Console.WriteLine("Student added!");

                Console.WriteLine();
                Console.WriteLine("Do you want to add another student? (y/n): ");
                userInput = Console.ReadLine();
            }

            Console.WriteLine();

            //search function 
            Console.WriteLine("Enter name to search:");
            string nameSearch = Console.ReadLine();
            bool isFound = false;

            for (int i=0; i< list.Count; i++ )
            {
                if (list[i].Name.Equals(nameSearch, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {list[i].Name}, Age: {list[i].Age}");
                    isFound = true; 
                    //if 2 students have the same name it will only display the first one , so if you want it to display both remove the break element
                   // break;
                }
               //when you program it to output after every iteration, it will be a proble mecause it will produce multiple output so just use a boolean and break
            }

            if (!isFound)
            {
                Console.WriteLine("The student is not in the list");
            }

            Console.WriteLine();
            Console.WriteLine("The following is the list of students in the list");
            //loop through the program 
            for (int i=0; i < list.Count; i++)
            {
                Console.WriteLine($"Name: {list[i].Name}, Age: {list[i].Age}");
               
            }
        }
    }

    class Student
    {
        //This is encapsulation with validation
        private string name;
        private int age;

        //modify the program so that if incorrect data values are added, a newstudent is not added

        public string Name { 
            get{
                return name;
            }
            set { //you cant test with age yet because it is empty so use value because its the value given to us
                if  (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("invalid name! you will be given a default name");
                    name = "Unknown";//set the name to a default variable unknown
                }
            } }
        public int Age {
            get{
                return age; 
            }
            set {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Incorrect age! you cannot be younger than 0");
                    age = 0;
                }
            }
        }
    }
}
