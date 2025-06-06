using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Bank
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString);

            sqlConnection.Open();

            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            textBox1.MaxLength = 20;
            textBox2.MaxLength = 8;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id, login, password, is_admin from Users where login = '{loginUser}' and password = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring,sqlConnection);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1) 
            {
                var user = new checkUser(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3]));

                Menu menu = new Menu(user);
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
            else 
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введённых данных!");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
