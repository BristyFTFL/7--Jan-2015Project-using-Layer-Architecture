using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformationApp.UI;

namespace EmployeeInformationApp
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeInformationEntryUI aUI = new EmployeeInformationEntryUI();
            aUI.Show();
        }

        private void addDesignationButton_Click(object sender, EventArgs e)
        {
            AddDesignationUI aUI = new AddDesignationUI();
            aUI.Show();
        }

        private void findEditButton_Click(object sender, EventArgs e)
        {
            SearchModifyEmployeeUI aUI = new SearchModifyEmployeeUI();
            aUI.Show();
        }
    }
}
