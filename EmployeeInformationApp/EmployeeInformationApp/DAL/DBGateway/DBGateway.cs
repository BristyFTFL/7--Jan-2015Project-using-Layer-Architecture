using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.DAL.DBGateway
{
    class DBGateway
    {
        private string connectionString = @"Data Source=BRISTY-PC\SQLEXPRESS;Database=EmployeeInformationDB;Integrated Security=true";
        private SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;
        public DBGateway()
        {
            aSqlConnection = new SqlConnection(connectionString);
        }

        public void Save(Designation aDesignation)
        {
            string query = "INSERT INTO T_Designation VALUES ('" + aDesignation.DesCode + "','" + aDesignation.DesTitle + "')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }
        public void Save(Employee aEmployee)
        {
            string query = "INSERT INTO T_Employee VALUES ('" + aEmployee.Name + "','" + aEmployee.Email + "','" + aEmployee.Address + "','" + aEmployee.DesId + "')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }
        public Employee ShowEmployee(Employee aEmployee)
        {
            string query = "SELECT * FROM T_Employee WHERE Emp_Id = '" + aEmployee.EmpId + "'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();

            while (aDataReader.Read())
            {
                aEmployee = new Employee();
                aEmployee.EmpId = Convert.ToInt32(aDataReader["Emp_Id"]);
                aEmployee.Name = aDataReader["Name"].ToString();
                aEmployee.Email = aDataReader["Email"].ToString();
                aEmployee.Address = aDataReader["Address"].ToString();
                aEmployee.DesId = (int) aDataReader["Des_Id"];

            }
            aDataReader.Close();
            aSqlConnection.Close();
            return aEmployee;
            
        }

        public string UpdateEmployee(Employee aEmployee)
        {
            aSqlConnection.Open();
            string query = "UPDATE T_Employee SET Name = '" + aEmployee.Name + "',Email = '" + aEmployee.Email + "',Address = '" + aEmployee.Address + "',Des_Id ='" + aEmployee.DesId + "' WHERE Emp_Id = '" + aEmployee.EmpId + "'";
            
            //string query = "UPDATE T_Employee SET Name = '" + aEmployee.Name + "',Email = '" + aEmployee.Email + "',Address = '" + aEmployee.Address + "',Des_Id ='" + aEmployee.DesId + "' WHERE Emp_Id = '" + aEmployee.EmpId + "'";
            SqlCommand command = new SqlCommand(query, aSqlConnection);

            command.ExecuteNonQuery();
          
            aSqlConnection.Close();
            return "Updated";
        }
        public Designation Find(string code)
        {
            string query = "SELECT * FROM T_Designation WHERE Des_Code = '" + code + "'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Designation aDesignation;

            if (aDataReader.HasRows)
            {
                aDesignation = new Designation();
                aDataReader.Read();
                aDesignation.DesId = Convert.ToInt32(aDataReader["Des_Id"]);
                aDesignation.DesCode = aDataReader["Des_Code"].ToString();
                aDesignation.DesTitle = aDataReader["Des_Title"].ToString();
                aDataReader.Close();
                aSqlConnection.Close();
                return aDesignation;
            }
            else
            {
                aSqlConnection.Close();
                return null;
            }
        }

        public List<Employee> Search(string name)
        {
            string query;
            List<Employee> employees = new List<Employee>();
            if (!String.IsNullOrEmpty(name))
            {
                query = "SELECT * FROM T_Employee WHERE Name = '" + name + "'";
            }
            else
            {
                query = "SELECT * FROM T_Employee";
            }

            
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            while (aDataReader.Read())
            {
                Employee aEmployee = new Employee();
                aEmployee.EmpId = Convert.ToInt32(aDataReader["Emp_Id"]);
                aEmployee.Name = aDataReader["Name"].ToString();
                aEmployee.Email = aDataReader["Email"].ToString();
                aEmployee.Address = aDataReader["Address"].ToString();
                aEmployee.DesId = (int)aDataReader["Des_Id"];
                employees.Add(aEmployee);
            }
            aDataReader.Close();
            aSqlConnection.Close();
            return employees;
        }
        public Employee GetUniqEmail(string email)
        {
            string query = "SELECT * FROM T_Employee WHERE Email = '" + email + "'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Employee aEmployee;

            if (aDataReader.HasRows)
            {
                aEmployee = new Employee();
                aDataReader.Read();
                aEmployee.EmpId = Convert.ToInt32(aDataReader["Emp_Id"]);
                aEmployee.Name = aDataReader["Name"].ToString();
                aEmployee.Email = aDataReader["Email"].ToString();
                aEmployee.Address = aDataReader["Address"].ToString();
                aDataReader.Close();
                aSqlConnection.Close();
                return aEmployee;
            }
            else
            {
                aSqlConnection.Close();
                return null;
            }
        }
        public List<Designation> FindList()
        {
            string query = "SELECT * FROM T_Designation";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            List<Designation> designations = new List<Designation>();

            while(aDataReader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.DesId = Convert.ToInt32(aDataReader["Des_Id"]);
                aDesignation.DesCode = aDataReader["Des_Code"].ToString();
                aDesignation.DesTitle = aDataReader["Des_Title"].ToString();
                designations.Add(aDesignation);
            }
            aDataReader.Close();
            aSqlConnection.Close();
            return designations;
        }
    }
}
