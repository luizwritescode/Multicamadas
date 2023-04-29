using Multicamadas.BLL;
using Multicamadas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multicamadas
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Gerenciamento de Projetos";
        }
        
        public DataGridView GetDataGridView()
        {
            return this.dataGridView1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Projetos' table. You can move, or remove it, as needed.
            this.projetosTableAdapter.Fill(this.databaseDataSet.Projetos);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        

        private void button1_Click(object sender, EventArgs e)
        {
            // open a new form for adding a new project
            AddProjectForm form2 = new AddProjectForm();
            form2.Show();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GestaoProjetos.GetAll();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // get a reference to selected row in datagridview

            DataGridViewRow row = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            // get the id of the selected project

            int id = Convert.ToInt32(row.Cells[0].Value);

            Projetos projeto = GestaoProjetos.GetById(id);

            GestaoProjetos.Delete(projeto);


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GestaoProjetos.GetAll();
         
            MessageBox.Show("Projeto excluido com sucesso!");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
