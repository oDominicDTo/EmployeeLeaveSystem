using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem
{
    public class SubMenu
    {

       public static int returnInput = 0;
        public static void LeaveReqUI()
        {
            try
            {
            do
            {
                Console.WriteLine("*** Leave Application ***");

                Console.WriteLine("\nYou have requested for leave. Enter all the details needed below:");

                Console.WriteLine("\nChoose your Leave Type:");

                var selectionUi = new List<string> { "", "Enter 1 - Sick Leave", "Enter 2 - Vacation Leave", "Enter 3 - Go back" };

                foreach (var item in selectionUi)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nInput Leave Type: ");

                int userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 1)
                {
                        Console.Clear();
                        LeaveClass.SickLeaveUI();

                }
                else if (userInput == 2)
                {
                        Console.Clear();
                        LeaveClass.VacationLeaveUI();

                    }
                else if (userInput == 3)
                {
                    Console.WriteLine($"You want to go back. Press Enter key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Menu.ShowUI();
                }
                else
                {

                    Console.WriteLine("Invalid Input. Press Enter key to return");
                    Console.ReadKey();
                    var change = SubMenu.returnInput = 1;


                }

            } while (returnInput == 1);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                SubMenu.LeaveReqUI();
            }
        }


        public static void AdminLogin()
        {
            try
            {
                do
                {
                    Console.WriteLine("\a \n *** Admin Login ***\n ");



                    Console.Write("Username: ");
                    var username = Console.ReadLine();


                    Console.Write("Password: ");
                    var password = Console.ReadLine();


                    var x = new Data(null, null, null);


                    if (username == x.UserName && password == x.PassWord)
                    {
                        Console.Clear();
                        SubMenu.AdminSelection();
                        
                    }
                    else
                    {

                        Console.WriteLine("Your username or password is incorrect!");
                        Console.ReadKey();
                        Console.Clear();
                        var change = SubMenu.returnInput = 1;


                    }

                } while (returnInput == 1);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminLogin();
            }
        }


        public static void AdminSelection() {

            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("*** Employee Data ***");

                    Console.WriteLine("\nSelect from MENU:\n");

                    var selectionUi = new List<string> { "Enter 0 - View Employee Leave List", "Enter 1 - View List of Employees", "Enter 2 - Add New Employee/s", "Enter 3 - Update list of Employee/s", "Enter 4 - Delete List", "Enter 5 - Go Back", "Enter 6 - Exit"};

                    foreach (var item in selectionUi)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write("\nUser Input: ");

                    int userInput = Convert.ToInt32(Console.ReadLine());

                    if (userInput == 0)
                        

                    {
                        Console.Clear();
                        Console.WriteLine("Enter 1 - Sick Leave List");
                        Console.WriteLine("Enter 2 - Vacation Leave List");

                        var input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                Console.Clear();
                                Admin.ViewSickLeaveEmployee();
                                break;
                            case "2":
                                Console.Clear();
                                Admin.ViewVacationLeaveEmployee();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid Input");
                                break;

                        }
                    }


                    else if (userInput == 1)
                    {
                        Console.Clear();
                        Admin.ViewListEmployee();

                    }
                    else if (userInput == 2)
                    {
                        Console.Clear();
                        Admin.AddList();


                    }
                    else if (userInput == 3)
                    {
                        Console.Clear();
                        Admin.UpdateList();


                    }
                    else if (userInput == 4)
                    {
               
                        Console.Clear();
                        Admin.DeleteList();

                    }
                    else if (userInput == 5)
                    {

                        Console.Clear();
                        Menu.ShowUI();

                    }
                    else if (userInput == 6)
                    {
                        Environment.Exit(0);

                    }
                    else
                    {

                        Console.WriteLine("Invalid Input. Press Enter key to return");
                        Console.ReadKey();
                        var change = SubMenu.returnInput = 1;


                    }

                } while (returnInput == 1);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter key to go back");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }
        }

    }
 }
    




