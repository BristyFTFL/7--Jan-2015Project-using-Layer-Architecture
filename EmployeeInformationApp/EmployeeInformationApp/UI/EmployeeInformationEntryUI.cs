using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.UI
{
    public partial class EmployeeInformationEntryUI : Form
    {
        Manager aManager = new Manager();
        private Designation selectedDesignation;
        public EmployeeInformationEntryUI()
        {
            InitializeComponent();
            designationComboBox.DataSource = aManager.DesignationList();
            designationComboBox.DisplayMember = "DesTitle";
            designationComboBox.ValueMember = "DesId";
            updateButton.Visible = false;
        }

        public void ButtonVisible()
        {
            updateButton.Visible = true;
            saveButton.Visible = false;
        }
        public void ShowEmployee(ListViewItem selectedItem)
        {

            Employee selectedEmployee = (Employee)selectedItem.Tag;
            idLabel.Text = selectedEmployee.EmpId.ToString();
            nameTextBox.Text = selectedEmployee.Name;
            emailTextBox.Text = selectedEmployee.Email;
            addressTextBox.Text = selectedEmployee.Address;
            designationComboBox.SelectedValue = selectedEmployee.DesId;


        }
        private Employee aEmployee;
        private string msg;
        private void saveButton_Click(object sender, EventArgs e)
        {
            GetValue();

            msg = aManager.Save(aEmployee);
            MessageBox.Show(msg);
           
        }

        private void GetValue()
        {
            aEmployee = new Employee();

            aEmployee.Name = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.DesId = selectedDesignation.DesId;
        }


        private void designationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDesignation = (Designation)designationComboBox.SelectedItem;
          
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
    
            GetValue();
            aEmployee.EmpId = Convert.ToInt32(idLabel.Text);
            msg = aManager.UpdateEmployee(aEmployee);
            aManager.ShowEmployee(aEmployee);
            MessageBox.Show(msg);
            
        }
    }
}
