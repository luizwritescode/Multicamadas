using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Multicamadas.BLL;
using Multicamadas.MODEL;

namespace Multicamadas
{
    public partial class AddProjectForm : Form
    {
        public AddProjectForm()
        {
            InitializeComponent();
            DataGridView dgv = ((Form1)Application.OpenForms["Form1"]).GetDataGridView();

            dgv.Refresh();
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            bool tem_erro = false;
            DateTime DataInicio = new DateTime();
            DateTime DataFim = new DateTime();

            if (textBox1.Text == "")
            {
                tem_erro = true;
                MessageBox.Show("O campo Nome é obrigatório!");
            }
            else if (textBox2.Text == "")
            {
                tem_erro = true;
                MessageBox.Show("O campo Gerente é obrigatório!");
            }
            else if (!DateTime.TryParse(textBox3.Text, out DataInicio))
            {
                tem_erro = true;
                MessageBox.Show("O campo Data Início está errado!");
            } else if (!DateTime.TryParse(textBox4.Text, out DataFim))
            {
                tem_erro = true;
                MessageBox.Show("O campo Data Fim está errado!");
            } else if (textBox6.Text == "") 
            {
                tem_erro = true;
                MessageBox.Show("O campo Status é obrigatório!");
            }

            if (tem_erro)
            {
                return;
            }

            else
            {
                
        

                Projetos projeto = new Projetos();
                projeto.NomeProjeto = textBox1.Text;
                projeto.NomeGerente = textBox2.Text;
                projeto.DataInicio = DateTime.Parse(textBox3.Text);
                projeto.DataFim = DateTime.Parse(textBox4.Text);
                projeto.Resumo = textBox5.Text;
                projeto.Status = textBox6.Text;

                //salvar projeto no banco de dados

                GestaoProjetos.Add(projeto);

                MessageBox.Show("Projeto adicionado com sucesso!");

                DataGridView dgv = ((Form1)Application.OpenForms["Form1"]).GetDataGridView();


                dgv.DataSource = null;
                dgv.DataSource = GestaoProjetos.GetAll();

                
                this.Close();
            
            }

        }
    }
}
