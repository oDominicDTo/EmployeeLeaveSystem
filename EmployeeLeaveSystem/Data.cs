using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem
{
    public class Data
    {
        private string adminUserName = "admin";
        private string adminPass = "admin";
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }

        public string UserName { get; }
        public string PassWord { get;  }

        public static string data_path_s = @"C:\Users\DT\source\repos\EmployeeLeaveSystem\EmployeeLeaveSystem\SickLeave.txt";
        public static string data_path_l = @"C:\Users\DT\source\repos\EmployeeLeaveSystem\EmployeeLeaveSystem\VacationLeave.txt";
        public static string data_path_e = @"C:\Users\DT\source\repos\EmployeeLeaveSystem\EmployeeLeaveSystem\EmployeeList.txt";
        public Data(string id, string name, string days)
        {
            EmployeeID = id;
            Name = name;
            Days = days;
            this.UserName = adminUserName; 
            this.PassWord = adminPass;

       
    }
        public static bool ValidateEmployeeID(string EmployeeID, string Name) {

            return EmployeeID.Length !=0 && EmployeeID.EndsWith("PH") && Name.Length !=0;
        
        
        }

        public static bool ValidateID(string EmployeeID)
        {
            bool returnValid = false;

            List<string> lines = File.ReadAllLines(Data.data_path_e).ToList();
            foreach (string line in lines)
            {
                if (line.Contains(EmployeeID)) {
                
                returnValid = true;
                
                }else { returnValid = false; } 
            }
            return returnValid;
        }
        public static void CreateSickList() {

            if (!File.Exists(Data.data_path_s))
            {
                using (StreamWriter sw = File.CreateText(Data.data_path_s)) ;
            }
        }


        public static void CreateVacationList()
        {

            if (!File.Exists(Data.data_path_l))
            {
                using (StreamWriter sw = File.CreateText(Data.data_path_l)) ;
            }
        }

        public static void CreateEmployeeList() {

            if (!File.Exists(Data.data_path_e))
            {
                using (StreamWriter sw = File.CreateText(Data.data_path_e)) ;
            }

        }


    public static void DeleteSickLeaveList()
        {
            if (File.Exists(Data.data_path_s))
            {

                Console.WriteLine("Deleting File...");
                File.Delete(Data.data_path_s);
                Console.ReadKey();
                Console.Clear();
                Admin.DeleteList();
            }
            else
            {

                Console.WriteLine("File does not exist");
                Console.ReadKey();
                Console.Clear();
                Admin.DeleteList();
            }

        }

        public static void DeleteVacationLeaveList()
        {
            if (File.Exists(Data.data_path_l))
            {

                Console.WriteLine("Deleting File...");
                File.Delete(Data.data_path_l);
                Console.ReadKey();
                Console.Clear();
                Admin.DeleteList();
            }
            else
            {

                Console.WriteLine("File does not exist");
                Console.ReadKey();
                Console.Clear();
                Admin.DeleteList();
            }
        }
            public static void DeleteEmployeeList()
            {
                if (File.Exists(Data.data_path_e))
                {

                    Console.WriteLine("Deleting File...");
                    File.Delete(Data.data_path_e);
                    Console.ReadKey();
                    Console.Clear();
                    Admin.DeleteList();
                }
                else
                {

                    Console.WriteLine("File does not exist");
                    Console.ReadKey();
                    Console.Clear();
                    Admin.DeleteList();
            }
         }
    }
}
