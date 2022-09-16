// See https://aka.ms/new-console-template for more information
using ADODotNet;

class program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        top:
        Console.WriteLine("Select Options to Perform:\n" +
            "1)Create Database\n" +
            "2)Create Table\n" +
            "3)Insert values to the database\n" +
            "4)Delete Values from the database\n" +
            "5)Update Values\n" +
            "6)Display Database\n" +
            "7)Extra Method to Show both Insert and Display Method\n");

        int option=Convert.ToInt32(Console.ReadLine());
        Customer cust=new Customer();
        CustomerModel model = new CustomerModel();

        switch (option)
        {
            case 1:
                Console.WriteLine("Created Database");
                Customer.CreateDataBase();
                break;

            case 2:
                Console.WriteLine("Table Created Successfully");
                Customer.CreateTable();
                break;

            case 3:
                Console.WriteLine("Inserting Values");
                Console.Write("Enter the CustomerName: > ");
                model.Customername = Console.ReadLine();
                Console.Write("Enter Address: > ");
                model.Address = Console.ReadLine();
                Console.Write("Enter Email: > ");
                model.email = Console.ReadLine();

                cust.insert(model);
                Console.WriteLine("Given Values Inserted Successfully ");
                break;

            case 4:
                Console.WriteLine("Deleting Values from the Database");
                Console.Write("Enter CustomerName which was present in database : > ");
                model.Customername= Console.ReadLine();
                Console.Write("Enter Address: > ");
                model.Address = Console.ReadLine() ;
                Console.Write("Enter Email: > ");
                model.email = Console.ReadLine();

                cust.delete(model);
                Console.WriteLine("Given values Deleted Successfully");
                break;

            case 5:
                Console.WriteLine("To Updating Database Please Enter :");
                Console.Write("Enter CustomerName: > ");
                model.Customername = Console.ReadLine();
                Console.Write("Enter Address: > ");
                model.Address = Console.ReadLine();
                Console.Write("Enter Email: > ");
                model.email = Console.ReadLine();

                cust.Update(model);
                Console.WriteLine("Update Successful");
                break;

            case 6:
                Console.WriteLine("Displaying Available Database\n");
                cust.Display();
                Console.WriteLine("Displayed");
                break;

            case 7:
                Console.WriteLine("Extra method of insert and display method");
                Console.WriteLine("Inserting Values");
                Console.Write("Enter the CustomerName: > ");
                model.Customername = Console.ReadLine();
                Console.Write("Enter Address: > ");
                model.Address = Console.ReadLine();
                Console.Write("Enter Email: > ");
                model.email = Console.ReadLine();

                cust.insertanddisplay(model);
                Console.WriteLine("Given Values Inserted Successfully ");
                break;


            default:
                Console.WriteLine("Please select correct option");
                break;
        }
        goto top;
    }
}
