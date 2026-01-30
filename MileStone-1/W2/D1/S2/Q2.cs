using System;

public class Program
{
    public static void Main(string[] args)
    {
        LinkedList<string> ls = new LinkedList<string>();
        bool running = true;

        while(true){

            Console.WriteLine("LinkedList Operations:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student by Name");
            Console.WriteLine("5. Clear List");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice (1-6) : ");

            switch(Console.ReadLine()){

                case "1":
                 AddStudent(ls);
                 break;

                case "2":
                 DisplayStudents(ls);
                 break;

                case "3":
                 UpdateStudent(ls);
                 break;

                case "4":
                 DeleteStudentByName(ls);
                 break;

                case "5":
                 ClearList(ls);
                 break;

                case "6":
                 running = false;
                 break;

                default:
                 Console.WriteLine("Invalid option. Please try again.");
                 break;
            }
        }
    }

    public static void AddStudent(LinkedList<string> list){
        Console.WriteLine("Enter student name to add: ");
        string name = Console.ReadLine();
        list.AddLast(name);
        Console.WriteLine($"{name} added to the list.");
    }

    public static void DisplayStudents(LinkedList<string> list){
        if(list.Count == 0){
            Console.WriteLine("No students in the list.");
            return;
        }
        Console.WriteLine("Students in the list:");
        foreach(var student in list){
            Console.WriteLine(student);
        }
    }

    public static void UpdateStudent(LinkedList<string> list){
        Console.WriteLine("Enter the current student name to update: ");
        string oldName = Console.ReadLine();

        var node = list.Find(oldName);

        if(node == null){
            Console.WriteLine($"{oldName} not found in the list.");
            return ;
        }
        Console.WriteLine("Enter the new student name: ");
        string newName = Console.ReadLine();
        node.Value = newName;

        Console.WriteLine($"{oldName} updated to {newName}");
    }

    public static void DeleteStudentByName(LinkedList<string> list){
        Console.WriteLine("Enter student name to delete: ");
        string name = Console.ReadLine();

        var node = list.Find(name);
        if(node == null){
            Console.WriteLine($"{name} not found in the list.");
            return;
        }
        list.Remove(node);
        Console.WriteLine($"{name} removed from the list.");
    }

    public static void ClearList(LinkedList<string> list){
        list.Clear();
        Console.WriteLine("The list has been cleared.");
    }
}
