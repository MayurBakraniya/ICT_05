using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class EmployeeSearch : Form
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public EmployeeSearch()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = databaseEntities.Employees.Select(Employee => new { Employee.Id, Employee.Name }).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = (from Employee in databaseEntities.Employees
                                        where Employee.Name.Contains(textBox1.Text)
                                        select new { Employee.Id, Employee.Name }).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = databaseEntities.Employees.Select(Employee => new { Employee.Id, Employee.Name }).ToList();
        }
    }
}
