    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Customer{
        public int CustomerID{get; set;}
        public string CustomerName{get; set;}
        public int Age{get; set;}

        public Customer(int cId, string cName, int age){
            CustomerID = cId;
            CustomerName = cName;
            Age = age;
        }


        public void DisplayDetails(){
            Console.WriteLine($"Customer ID: {CustomerID}, Customer Name: {CustomerName}, Age: {Age}");

        }
    }

    public class CustomerManager{

        public Dictionary<int,Customer> Customers = new Dictionary<int, Customer>();


    //***** Most Important(Add Method) in COD for MileStone 
        public void AddCustomer(Customer obj){
            if(Customers.ContainsKey(obj.CustomerID)){
                Console.WriteLine($"Customer with ID {obj.CustomerID} already exists.");
                return;
            }
            Customers.Add(obj.CustomerID,obj);
            Console.WriteLine("Customer Added Successfully.");
        }

        public void ShowCustomers(){

            if(Customers.Count == 0){
                Console.WriteLine("List is Empty.");
                return;
            }

            Console.WriteLine("All Customers Detail:");
            foreach(Customer c in Customers.Values){
                c.DisplayDetails();
            }
        }

        public void ShowById(int id){
            foreach(Customer c in Customers.Values){
                if(c.CustomerID == id){
                c.DisplayDetails();
                return;
                }
            }
            Console.WriteLine("Customer ID Not Found.");
        }

        public void DeleteCustomer(int id){
            foreach(Customer c in Customers.Values){
                if(c.CustomerID == id){
                Customers.Remove(id);
                Console.WriteLine("Customer Deleted.");
                return;
                }
            }
            Console.WriteLine("Customer ID Not Found.");

        }

        public void UpdateCustomer(int id, Customer objj){
            foreach(Customer c in Customers.Values){
                if(c.CustomerID == id){
                c.CustomerName = objj.CustomerName;
                c.Age = objj.Age;
                Console.WriteLine("Customer Updated.");
                return;
                }
            }
            Console.WriteLine("Customer ID Not Found.");
        }
    }

    public class Program{
        public static void Main(String[] args){

            CustomerManager m = new CustomerManager();
            

            while(true){

            
                
            Console.WriteLine("Customer Detail:");
            Console.WriteLine("1.....Add Customer");
            Console.WriteLine("2.....Show Customers");
            Console.WriteLine("3.....By ID Customer");
            Console.WriteLine("4.....Delete Customer");
            Console.WriteLine("5.....Update Customer");
            Console.WriteLine("6.....Exit");

            int opt = int.Parse(Console.ReadLine());

                switch(opt){
                case 1:
                Console.WriteLine("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Customer nc = new Customer(id, name, age);
                m.AddCustomer(nc);
                break;

                case 2:
                m.ShowCustomers();
                break;

                case 3:
                Console.WriteLine("Enter ID to show:");
                int idd = int.Parse(Console.ReadLine());
                m.ShowById(idd);
                break;

                case 4:
                Console.WriteLine("Enter ID to Delete:");
                int id3 = int.Parse(Console.ReadLine());
                m.DeleteCustomer(id3);
                break;

                case 5:
                Console.WriteLine("Enter ID: ");
                int id1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name: ");
                string name1 = Console.ReadLine();

                Console.WriteLine("Enter Age: ");
                int age1 = int.Parse(Console.ReadLine());

                Customer nc1 = new Customer(id1, name1, age1);
                m.UpdateCustomer(id1,nc1);
                break;

                case 6:
                Console.WriteLine("Exiting the program....");
                return;
                break;

                default:
                break;
            }


            } 
        }
    }
