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
    public partial class Form1 : Form
    {
        private DatabaseEntities entities = new DatabaseEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDepartement();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Departement departement = new Departement();

            departement.Name = txtName.Text.ToString();

            entities.Departements.Add(departement);
            entities.SaveChanges();

            ShowDepartement();

            txtName.Text = "";
        }

        public void ShowDepartement()
        {
            dataGridView1.DataSource = entities.Departements.Select(a => new { a.Id, a.Name, Names = a.Name.Length.ToString() }).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.RowIndex();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            Departement departement = entities.Departements.Find(Id);

            departement.Name = txtName.Text;

            entities.Departements.Append(departement);

            ShowDepartement();
            txtName.Text = "";
            txtId.Text = "";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            Departement departement = entities.Departements.Find(Id);

            txtName.Text = departement.Name;
        }
    }
}
