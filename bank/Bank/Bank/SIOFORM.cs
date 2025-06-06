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
    
    public partial class SIOFORM : Form

    {

        private readonly checkUser user_;
        DataBase dataBase = new DataBase();
        int selectedRow;
        //private SqlConnection sqlConnection = null;

        public SIOFORM(checkUser _user)
        {
            user_ = _user;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("INN", "ИНН");
            dataGridView1.Columns.Add("NameOrg", "Название организации");
            dataGridView1.Columns.Add("FIO", "ФИО");
            dataGridView1.Columns.Add("Podrazdelenie", "Подразделение организации");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("DO", "ДО");
            /* dataGridView1.Columns["id"].DisplayIndex = 2;
             dataGridView1.Columns["Nomer_DO"].DisplayIndex = 1;
             dataGridView1.Columns["Naimenovanie_DO"].DisplayIndex = 0;*/
            dataGridView1.Columns.Add("IsNew", String.Empty);

        }

        private void ClearFields()
        {
            textBox1id.Text = "";
            textBox1inn.Text = "";
            textBox1nameorg.Text = "";
            textBox1fio.Text = "";
            textBox1podrezd.Text = "";
            textBox1email.Text = "";
            //comboBox1do.Text = "";

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            object idObj = null;
            object innObj = null;
            string nameOrg = string.Empty;
            string fio = string.Empty;
            string podrazdelenie = string.Empty;
            string email = string.Empty;
            string doField = string.Empty;

            // Обработка id
            if (!record.IsDBNull(0))
                idObj = record.GetValue(0);

            // Обработка INN
            if (!record.IsDBNull(1))
                innObj = record.GetValue(1);

            // Остальные строки
            if (!record.IsDBNull(2))
                nameOrg = record.GetString(2);
            if (!record.IsDBNull(3))
                fio = record.GetString(3);
            if (!record.IsDBNull(4))
                podrazdelenie = record.GetString(4);
            if (!record.IsDBNull(5))
                email = record.GetString(5);
            if (!record.IsDBNull(6))
                doField = record.GetString(6);

            // Преобразование id и inn в long
            long id = 0;
            long inn = 0;

            if (idObj != null)
                id = Convert.ToInt64(idObj);

            if (innObj != null)
                inn = Convert.ToInt64(innObj);

            dgw.Rows.Add(id, inn, nameOrg, fio, podrazdelenie, email, doField, RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select* from SIO";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void SIOFORM_Load(object sender, EventArgs e)
        {
            tlsUserStatus.Text = $"{user_.Login}: {user_.Status}";
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            //sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            //sqlConnection.Open();

            var queryOffice = $"select Id, Name from DO";
            SqlDataAdapter commandOffice = new SqlDataAdapter(queryOffice, dataBase.getConnection());
            DataTable office = new DataTable();
            commandOffice.Fill(office);
            comboBox1do.DataSource = office;
            comboBox1do.ValueMember = "Id";
            comboBox1do.DisplayMember = "Name";

        }

              
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1id.Text = row.Cells[0].Value.ToString();
                textBox1inn.Text = row.Cells[1].Value.ToString();
                textBox1nameorg.Text = row.Cells[2].Value.ToString();
                textBox1fio.Text = row.Cells[3].Value.ToString();
                textBox1podrezd.Text = row.Cells[4].Value.ToString();
                textBox1email.Text = row.Cells[5].Value.ToString();
                comboBox1do.Text = row.Cells[6].Value.ToString();

            }
        }

        private void button1obnov_Click(object sender, EventArgs e)
        {

            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void button1dobav_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [SIO] (INN,NameOrg,FIO,Podrazdelenie,Email,DO) VALUES (@INN,@NameOrg,@FIO,@Podrazdelenie,@Email,@DO)",
                dataBase.getConnection());

            command.Parameters.AddWithValue("INN", textBox1inn.Text);
            command.Parameters.AddWithValue("NameOrg", textBox1nameorg.Text);
            command.Parameters.AddWithValue("FIO", textBox1fio.Text);
            command.Parameters.AddWithValue("Podrazdelenie", textBox1podrezd.Text);
            command.Parameters.AddWithValue("Email", textBox1email.Text);
            command.Parameters.AddWithValue("DO", comboBox1do.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Данные успешно добавлены!");
        }

        private void comboBox1do_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1do.ValueMember = "Id";
            comboBox1do.DisplayMember = "Name";
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from SIO where concat (id,INN,NameOrg,FIO,Podrazdelenie,Email,DO) like N'%" + textBox1poisk.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();
        }

        private void deleteRow()
        {

            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[7].Value = RowState.Deleted;
        }


        private void Opdate()
        {
            dataBase.openConnection();

            
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[7].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);

                    var deleteQuery = $"delete from SIO where id={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var INN = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var NameOrg = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var FIO = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var Podrazdelenie = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var Email = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var DO = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    
                                        
                    var changeQuery = $"update SIO set INN='{INN}',NameOrg=N'{NameOrg}',FIO=N'{FIO}',Podrazdelenie=N'{Podrazdelenie}',Email='{Email}',DO=N'{DO}' where id='{id}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

            }

            dataBase.closeConnection();
        }


        private void textBox1poisk_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button2delet_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void button3soxr_Click(object sender, EventArgs e)
        {
            Opdate();
            MessageBox.Show("Изменения сохранены!");
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox1id.Text;
            var INN = textBox1inn.Text;
            var NameOrg = textBox1nameorg.Text;
            var FIO = textBox1fio.Text;
            var Podrazdelenie = textBox1podrezd.Text;
            var Email = textBox1email.Text;
            var DO = comboBox1do.Text;


            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != String.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id,INN, NameOrg, FIO, Podrazdelenie, Email, DO);
                dataGridView1.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
            }


        }


        private void button1izmen_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void button1perexsertif_Click(object sender, EventArgs e)
        {
            Certificates cert = new Certificates(user_);
            this.Hide();
            cert.ShowDialog();
            this.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
