using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem
{
    public class Admin
    {
        public static void ViewSickLeaveEmployee()
        {
            if (File.Exists(Data.data_path_s))
            {

                List<string> lines = File.ReadAllLines(Data.data_path_s).ToList();
                foreach (String line in lines)
                {

                    Console.WriteLine(line);

                }
                Console.ReadKey();
                SubMenu.AdminSelection();
            }
            else
            {
                Console.WriteLine("File Not Found");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }

        }
        public static void ViewVacationLeaveEmployee()
        {
            

            if (File.Exists(Data.data_path_l))
            {
                List<string> lines2 = File.ReadAllLines(Data.data_path_l).ToList();
                foreach (String line in lines2)
                {

                    Console.WriteLine(line);

                }
                Console.ReadKey();
                SubMenu.AdminSelection();
            }
            else
            {
                Console.WriteLine("File Not Found");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }
        }




        public static void ViewListEmployee()
        {

            if (!File.Exists(Data.data_path_e))
            {

                Console.WriteLine("List is Empty");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();

            }
            else
            {


                List<string> list = File.ReadAllLines(Data.data_path_e).ToList();


                foreach (String line in list)
                {

                    Console.WriteLine(line);

                }
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }
        }

        public static void AddList()
        {

            try
            {
                string idEmployee, nameEmployee;
                do
                {

               
                var data = new StringBuilder();

                Console.Clear();

                Console.Write("Employee ID:");
                idEmployee = Console.ReadLine();

                Console.Write("Name: ");
                nameEmployee = Console.ReadLine();
    
                Data input = new Data(idEmployee, nameEmployee, null);
    
                Data.CreateEmployeeList();




                List<string> lines = File.ReadAllLines(Data.data_path_e).ToList();

                var employeeIDname = input.EmployeeID.ToString();
                var name = input.Name.ToString();
                



                if (lines.Count == 0)
                {

                    string text = string.Format("|{0,-30}|{1,-30}", "Employee ID", "Name");

                    lines.Add(text);

                    File.WriteAllLines(Data.data_path_e, lines);

                }
                    if (Data.ValidateEmployeeID(idEmployee, name))
                    {

                        string text2 = string.Format("|{0,-30}|{1,-30}", employeeIDname, name);

                        lines.Add(text2);

                        File.WriteAllLines(Data.data_path_e, lines);

                    }
                    else { Console.WriteLine("Invalid Input"); }

                } while (idEmployee.Length != 0 && nameEmployee.Length !=0);

                Console.WriteLine("\n*** Employee ID recorded. ***");

                Console.WriteLine("Press ANY key to return to Menu.");
                Console.ReadKey();

                Console.Clear();

                SubMenu.AdminSelection();

            }
            catch (Exception e)
            {
                string temp = e.Message;
                Console.WriteLine(temp);

            }
        }



        public static void UpdateList()
        {
            if (!File.Exists(Data.data_path_e))
            {

                Console.WriteLine("List is Empty");
                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }
            else
            {
                List<string> list = File.ReadAllLines(Data.data_path_e).ToList();

                foreach (String line in list)
                {
                    Console.WriteLine(line);
                }

                Console.Write("\nReplace: ");
                string input = Console.ReadLine();

                Console.Write("\nTo: ");
                string newValue = Console.ReadLine();

                string text = File.ReadAllText(Data.data_path_e);
                text = text.Replace(input, newValue);
                File.WriteAllText(Data.data_path_e, text);

                Console.ReadKey();
                Console.Clear();
                SubMenu.AdminSelection();
            }
        }

        public static void DeleteList()
        {
            Console.WriteLine("*** Choose which File to Delete ***");
            var deleteSelection = new List<string> { "", "Enter 1 - Sick Leave List", "Enter 2 - Vacation Leave List", "Enter 3 - Employee List", "Enter 4 - Go back" };

            foreach (string item in deleteSelection)
            {
                Console.WriteLine(item);
            }
            var input = Console.ReadLine();

            switch (input) {

                case "1": Data.DeleteSickLeaveList();

                    break;

                case "2": Data.DeleteVacationLeaveList();
                    break;

                case "3": Data.DeleteEmployeeList();
                    break;

                case "4": SubMenu.AdminSelection();
                    break;

                default: Console.WriteLine("Invalid Input"); break; 
            
            
      
            }
        }

    }
}
    

