using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.UI
{
    public partial class SearchModifyEmployeeUI : Form
    {
        public SearchModifyEmployeeUI()
        {
            InitializeComponent();
        }
        Manager aManager = new Manager();

        void searchEmployee()
        {
            Employee aEmployee = new Employee();
            aEmployee.Name = employeeNameTextBox.Text;
            List<Employee> employees = aManager.Search(aEmployee);
            showListView.Items.Clear();
            foreach (Employee anEmployee in employees)
            {
                ListViewItem item = new ListViewItem(anEmployee.EmpId.ToString());
                item.SubItems.Add(anEmployee.Name);
                item.SubItems.Add(anEmployee.Email);

                item.Tag = anEmployee;

                showListView.Items.Add(item);
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
          searchEmployee();
        }

        private void showListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = showListView.SelectedItems[0];
            EmployeeInformationEntryUI aUI = new EmployeeInformationEntryUI();
            aUI.ShowEmployee(selectedItem);
            aUI.ButtonVisible();
            aUI.Show();

        }

        private void SearchModifyEmployeeUI_Load(object sender, EventArgs e)
        {
            searchEmployee();
        }

      
     
    }
}
