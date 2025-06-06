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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Users : Form
    {
        private readonly checkUser user_;
        private SqlConnection sqlConnection = null;

        int selectedRow;
        public Users(checkUser _user)
        {
            user_ = _user;
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Id","ID");
            dataGridView1.Columns.Add("login", "Логин");
            dataGridView1.Columns.Add("password", "Пароль");
            dataGridView1.Columns.Add("DO", "ДО");
            dataGridView1.Columns.Add("is_admin", "Статус");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ClearFields()
        {
            textBox_id.Text = "";
            textBox_login.Text = "";
            textBox_password.Text = "";
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetValue(3), record.GetBoolean(4), RowState.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Users";

            SqlCommand command = new SqlCommand(queryString, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                ReadSingleRow(dgw, reader);

            reader.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString);
            sqlConnection.Open();

            tlsUserStatus.Text = $"{user_.Login}: {user_.Status}";

            CreateColumns();
            RefreshDataGrid(dataGridView1);

            var queryOffice = $"select id, Name from DO";
            SqlDataAdapter commandOffice = new SqlDataAdapter(queryOffice, sqlConnection);
            DataTable office = new DataTable();
            commandOffice.Fill(office);
            comboBox_DO.DataSource = office;
            comboBox_DO.ValueMember = "id";
            comboBox_DO.DisplayMember = "Name";

            textBox_login.MaxLength = 20;
            textBox_password.MaxLength = 8;
        }

        private void button_search_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            var login = textBox_login.Text;
            var password = textBox_password.Text;
            var DO = comboBox_DO.Text;
            var rights = Convert.ToBoolean(comboBox_right.Text);
           
            var addQuery = $"insert into Users (login, password, DO, is_admin) values ('{login}','{password}',N'{DO}','{rights}')";

            var command = new SqlCommand(addQuery, sqlConnection);
            command.ExecuteNonQuery();

            MessageBox.Show("Новый пользователь успешно создан!");
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Users where concat (id, login, DO) like N'%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, sqlConnection);

            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
                ReadSingleRow(dgw, read);

            read.Close();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if(dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var login = textBox_login.Text;
            var password = textBox_password.Text;
            var DO = comboBox_DO.Text;
            var rights = Convert.ToBoolean(comboBox_right.Text);

            if(dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, login, password, DO, rights);
                dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }
        }

        private void Opdate()
        {
            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if(rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Users where id = {id}";

                    var command = new SqlCommand(deleteQuery, sqlConnection);
                    command.ExecuteNonQuery();
                }

                if(rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var login = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var password = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var DO = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var rights = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Users set login = '{login}', password = '{password}', DO = N'{DO}', is_admin = '{rights}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, sqlConnection);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_login.Text = row.Cells[1].Value.ToString();
                textBox_password.Text = row.Cells[2].Value.ToString();
                comboBox_DO.Text = row.Cells[3].Value.ToString();
                comboBox_right.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Opdate();
            MessageBox.Show("Изменения сохранены!");
        }

        private void button_redact_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
