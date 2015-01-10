using System;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.UI
{
    public partial class AddDesignationUI : Form
    {
        public AddDesignationUI()
        {
            InitializeComponent();
        }

        private string connectionString = @"Data Source = WINDOWS8\SQLEXPRESS;Database = EmployeeInformationDB ; Integrated Security = true;";
        private void saveButton_Click(object sender, EventArgs e)
        {
            Designation aDesignation = new Designation();
            Manager aDesignationManager = new Manager();
            aDesignation.DesCode = codeTextBox.Text;
            aDesignation.DesTitle = titleTextBox.Text;
            string msg = aDesignationManager.Save(aDesignation);
            MessageBox.Show(msg);
        }
    }
}
