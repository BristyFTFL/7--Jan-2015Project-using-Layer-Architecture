using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL.DAO;
using EmployeeInformationApp.DAL.DBGateway;

namespace EmployeeInformationApp.BLL
{
    class Manager
    {
        const int MIN_LENGTH_OF_CODE = 3;
        DBGateway aDbGateway = new DBGateway();
        public string Save(Designation aDesignation)
        {
            
            if (aDesignation.DesCode.Length >= MIN_LENGTH_OF_CODE)
            {
                Designation designationFound = aDbGateway.Find(aDesignation.DesCode);
                if (designationFound == null)
                {
                    aDbGateway.Save(aDesignation);
                    return "Saved";
                }
                else
                {
                    return "This Designation already exists";
                }
            }
            else
            {
                return "Code must be " + MIN_LENGTH_OF_CODE + " char long";
            }
        }
        bool IsValidEmail(string email)
        {
             try {
                      var addr = new System.Net.Mail.MailAddress(email);
                      return addr.Address == email;
                 }
           catch {
                      return false;
                 }
        }


        public String UpdateEmployee(Employee aEmployee)
        {
            if (IsValidEmail(aEmployee.Email))
            {
                aDbGateway.UpdateEmployee(aEmployee);
                return "Updated";
            }
            else
            {
                return "Please Use the correct format of Email !";
            }
        }
        public List<Designation> DesignationList()
        {
            return aDbGateway.FindList();
        }
        public string Save(Employee aEmployee)
        {
            Employee employeeFound = aDbGateway.GetUniqEmail(aEmployee.Email);
            if (!IsValidEmail(aEmployee.Email))
            {
                return "Please Use the correct format of Email !";
            }
            if (employeeFound == null)
            {
                aDbGateway.Save(aEmployee);
                return "Saved";
            }
            else
            {
                return "This Employee already exists";
            }
       
        }

        public Employee ShowEmployee(Employee aEmployee)
        {
            return aDbGateway.ShowEmployee(aEmployee);
        }
        public List<Employee> Search(Employee aEmployee)
        {
            return aDbGateway.Search(aEmployee.Name);
        }
    }
}
