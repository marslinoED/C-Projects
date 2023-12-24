using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_C_sharp
{

    class Person // Parent
    {
        private int id = -1; // Private variable won't show up in the child
        private int private_data_in_parent = -1;
        protected string name; // Protected do
        protected int age;
        public int ID //u can just right {get; set;}
        {
            // or u can have conditions using
            set
            {
                if (value > 0) // condition to choose the data type
                {
                    this.id = value;
                }
                else
                {
                    Console.WriteLine("Enter positive value"); // message
                    ID = int.Parse(Console.ReadLine()); // re call the set
                }
            }
            get
            {
                return this.id;
            }
        } // Properites to enter private data without accessieng it

        public Person() // null struct 
        { }
        public Person(string name, int Age) // overload struct to enter data
        {
            this.name = name; //if the variable have same name u need to put this to access this class variable
            age = Age;

        }
        public Person(string name, int Age, int privatedata) // overload struct to enter the private data
        {
            this.name = name; //if the variable have same name u need to put this to access this class variable
            age = Age;
            private_data_in_parent = privatedata;

        }
        public virtual void display() // virtual method that can be access in the child method override
        {

            Console.WriteLine("The next print in the Parent : ");
            Console.WriteLine("Person Name : " + name + "    Person age : " + age);
            if (id != -1) // condition to be sure that id have data cause u can access it just in the parent 
            { Console.WriteLine("ID is : " + id); }
            if (private_data_in_parent != -1)
            { Console.WriteLine("private data = " + private_data_in_parent); }
        }
    }

    class Student : Person // child : parent
    {
        // data in parents will be in the child but not the opposite is wrong
        private string School_Name;
        private int Grade;
        public Student() // null struct
        {

        }
        public Student(string name, int age, string schoolname, int grade) : base(name, age) // u can access person variables data with : base(variable names, ...)
        {
            School_Name = schoolname;
            Grade = grade;
        }
        // now u can make override display method
        public override void display()
        {
            // u can just make ur new fuction using the override 
            // or u can enter more structers in the base method using base.MethodName();

            base.display();
            Console.WriteLine("The next print in the child : ");
            Console.WriteLine("School Name : " + School_Name + "   Grade : " + Grade);
        }
    }


    // Abstract class
    abstract class car
    {
        private string id;

        public car(string id)
        {
            this.id = id;
        }
        public abstract void change_id(string ID);
        public virtual void display() { Console.WriteLine("ID is : " + id); }
    }
    class new_car : car
    {
        static string id;
        string new_ID;

        public new_car(string new_id) : base(id)
        { this.new_ID = new_id; }
        public override void change_id(string id)
        {
            id = new_ID;
        }
        public override void display() { Console.WriteLine(new_ID); }
    }
    // interface cant have any decleraed variable 
    public interface Area // but it use Polymorphism without using override
    {
        void area(int x, int y);
    }
    class rectangle : Area
    {
        public void area(int x, int y)
        {
            Console.WriteLine("area = " + x * y);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("marslino", 25, 1234);
            p1.ID = 1; // access private variables in the parent
            p1.display();

            Console.WriteLine();

            Student s1 = new Student("marslino", 19, "SHA", 2);
            s1.ID = 15; // can access the private data because the public prop
                        // cant access s1.private_data_in_parent because its private
            s1.display();

            Console.WriteLine();

            Person p2 = new Student("new", 20, "sha", 3); // using Polymorphism to make new object of parent that point to the child
            p2.display();

            Console.WriteLine("\n_____________Interface_____________\n");

            Area area = new rectangle();
            area.area(3, 3);

            Console.WriteLine("\n_____________Exception Handling_____________\n");

            try // tis block is the block u think u gonna have an error
            {
                int i = 3, j = 0;
                Console.WriteLine((i / j)); // u cant divide by zero so error will happend
            }
            catch (Exception ex) // this is exception to print if there is an error
            {
                Console.WriteLine(ex.Message); // ex.message is the error type
            }
            finally // print to handle error even if there no errors
            {
                Console.WriteLine("there is an error"); // u can put any type of code block here
            }
            Console.WriteLine("The rest of the programme"); // the rest of the code goes there

        }
    }
}
