using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem
{
    public class LeaveClass
    {


        //  public List<Data> allData = new List<Data>();
        public static void SickLeaveUI()
        {

            var data = new StringBuilder();

            string idEmployee, nameEmployee, daysLeave;

            Console.WriteLine("*** Sick Leave ***");

            Console.Write("\nEmployee ID number: ");
            idEmployee = Console.ReadLine();

            Data.CreateEmployeeList();

            if (idEmployee.Length == 0) { Console.WriteLine("Returning to Leave Application"); Console.ReadKey(); Console.Clear(); SubMenu.LeaveReqUI(); }
            if (Data.ValidateID(idEmployee))
            {

                Console.Write("\nName: ");
                nameEmployee = Console.ReadLine();

                Console.Write("\nDays of Leave: ");
                daysLeave = Console.ReadLine();

                Console.WriteLine();

                Data.CreateSickList();

                Data test = new Data(idEmployee, nameEmployee, daysLeave);

                data.AppendLine("Employee ID number\t\tName\t\t\tDays of Leave\t\t\t Type of Leave");
                data.AppendLine($"{test.EmployeeID}\t\t\t\t{test.Name}\t\t\t{test.Days}\t\t\t\t Sick Leave");
                Console.WriteLine(data.ToString());

                try
                {


                    List<string> lines = File.ReadAllLines(Data.data_path_s).ToList();

                    var employeeIDname = test.EmployeeID.ToString();
                    var name = test.Name.ToString();
                    var days = test.Days.ToString();



                    if (lines.Count == 0)
                    {

                        string text = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", "Employee ID", "Name", "Days of Leave", "Type of Leave");

                        string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Sick Leave");

                        lines.Add(text);

                        File.WriteAllLines(Data.data_path_s, lines);

                        lines.Add(text2);

                        File.WriteAllLines(Data.data_path_s, lines);

                    }
                    else
                    {

                        string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Sick Leave");

                        lines.Add(text2);

                        File.WriteAllLines(Data.data_path_s, lines);

                    }

                    Console.WriteLine("\n*** Leave Request recorded. ***");

                    Console.WriteLine("Press ANY key to return to Menu.");
                    Console.ReadKey();

                    Console.Clear();

                    Menu.ShowUI();

                }
                catch (Exception e)
                {
                    string temp = e.Message;
                    Console.WriteLine(temp);

                }

            }
            else
            {
                Console.WriteLine("Invalid Employee ID");
                Console.ReadKey();
                Console.Clear();
                LeaveClass.SickLeaveUI();
            }
        }


        /*  public static void Test() {

          var data = new StringBuilder();

            data.AppendLine("Employee ID number\t\tName\t\tDays of Leave\t Type of Leave");
           
            foreach (var item in allData)
            {
                data.AppendLine($"{item.EmployeeID}\t{item.Name}\t{item.Days}\t Sick Leave");         
            }

            return data.ToString();
          


    }*/
        public static void VacationLeaveUI()
        {

            var data = new StringBuilder();

            string idEmployee, nameEmployee, daysLeave;

            Console.WriteLine("*** Vacation Leave ***");

            Console.Write("\nEmployee ID number: ");
            idEmployee = Console.ReadLine();

            Data.CreateEmployeeList();

            if (idEmployee.Length == 0) { Console.WriteLine("Returning to Leave Application"); Console.ReadKey(); Console.Clear(); SubMenu.LeaveReqUI(); }
            if (Data.ValidateID(idEmployee))
            {
   
                Console.Write("\nName: ");
                nameEmployee = Console.ReadLine();

                Console.Write("\nDays of Leave: ");
                daysLeave = Console.ReadLine();

                Console.WriteLine();

                Data.CreateVacationList();

                Data test = new Data(idEmployee, nameEmployee, daysLeave);

                data.AppendLine("Employee ID number\t\tName\t\t\tDays of Leave\t\t\t Type of Leave");
                data.AppendLine($"{test.EmployeeID}\t\t\t\t{test.Name}\t\t\t{test.Days}\t\t\t\t Vacation Leave");
                Console.WriteLine(data.ToString());

                try
                {


                    List<string> lines = File.ReadAllLines(Data.data_path_l).ToList();

                    var employeeIDname = test.EmployeeID.ToString();
                    var name = test.Name.ToString();
                    var days = test.Days.ToString();

                    if (lines.Count == 0)
                    {

                        string text = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", "Employee ID", "Name", "Days of Leave", "Type of Leave");

                        string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Vacation Leave");

                        lines.Add(text);

                        File.WriteAllLines(Data.data_path_l, lines);

                        lines.Add(text2);

                        File.WriteAllLines(Data.data_path_l, lines);

                    }
                    else
                    {

                        string text2 = string.Format("|{0,-30}|{1,-30}|{2,-15}|{3,-30}", employeeIDname, name, days, "Vacation Leave");

                        lines.Add(text2);

                        File.WriteAllLines(Data.data_path_l, lines);

                    }

                    Console.WriteLine("\n*** Leave Request recorded. ***");

                    Console.WriteLine("Press ANY key to return to Menu.");
                    Console.ReadKey();

                    Console.Clear();

                    Menu.ShowUI();


                }
                catch (Exception ee)
                {
                    string temp = ee.Message;

                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID");
                Console.ReadKey();
                Console.Clear();
                LeaveClass.VacationLeaveUI();

            }
        }
    }
}
