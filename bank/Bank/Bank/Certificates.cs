using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Bank
{
    public partial class Certificates : Form
    {
        private readonly checkUser user2;
        private SqlConnection sqlConnection = null;

        int selectedRow;
        public Certificates(checkUser _user)
        {
            user2 = _user;
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("INN", "ИНН");
            dataGridView1.Columns.Add("Region", "Область");
            dataGridView1.Columns.Add("Country", "Страна");
            dataGridView1.Columns.Add("Nnositel", "№ Носителя");
            dataGridView1.Columns.Add("Nsticker", "№ Наклейки");
            dataGridView1.Columns.Add("Nsertif", "Серийный номер сертификата");
            dataGridView1.Columns.Add("nach", "Дата начала действия");
            dataGridView1.Columns.Add("kon", "Дата окончания действия");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

private void ReadSingleRow(DataGridView dgw, IDataRecord record)
      {
           dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetDateTime(7), record.GetDateTime(8), RowState.ModifiedNew);

      }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Certificates";

            SqlCommand command = new SqlCommand(queryString, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                ReadSingleRow(dgw, reader);

            reader.Close();
        }

        private void ClearFields()
        {
            textBox_id.Text = "";
            textBox_INN.Text = "";
            textBox_Nnositel.Text = "";
            textBox_Nsertif.Text = "";
            textBox_Nsticker.Text = "";
            
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var INN = textBox_INN.Text;
            var Nnositel = textBox_Nnositel.Text;
            var Nsticker = textBox_Nsticker.Text;
            var Nsertif = textBox_Nsertif.Text;
            var Region = textBox_Region.Text;
            var Country = textBox_Country.Text;
            DateTime nach = DateTime.Parse(dtp_nach.Text);
            DateTime kon = DateTime.Parse(dtp_kon.Text);

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, INN, Region, Country, Nnositel, Nsticker, Nsertif, nach, kon);
                dataGridView1.Rows[selectedRowIndex].Cells[9].Value = RowState.Modified;
            }
        }

        private void Opdate()
        {
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[9].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Certificates where id = {id}";

                    var command = new SqlCommand(deleteQuery, sqlConnection);
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var INN = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Nnositel = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var Nsticker = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var Nsertif = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    DateTime nach = DateTime.Parse(dataGridView1.Rows[index].Cells[7].Value.ToString());
                    DateTime kon = DateTime.Parse(dataGridView1.Rows[index].Cells[8].Value.ToString());

                    var changeQuery = $"update Certificates set INN = '{INN}', Nnositel = '{Nnositel}', Nsticker = '{Nsticker}', Nsertif = '{Nsertif}',nach = '{nach.Month}/{nach.Day}/{nach.Year}', kon = '{kon.Month}/{kon.Day}/{kon.Year}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, sqlConnection);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Certificates where concat (INN, N_nositel, N_sticker, N_certif, nach, kon) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, sqlConnection);

            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
                ReadSingleRow(dgw, read);

            read.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Certificates_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString);
            sqlConnection.Open();

            tlsUserStatus.Text = $"{user2.Login}: {user2.Status}";

            CreateColumns();
            RefreshDataGrid(dataGridView1);

            //dtp_nach.MinDate = new DateTime(1985, 6, 20); dtp_kon.MinDate = new DateTime(1985, 6, 20);
            //dtp_nach.MaxDate = DateTime.Today; dtp_kon.MaxDate = DateTime.Today;
            dtp_nach.CustomFormat = "MM'.'dd'.'yyyy"; dtp_kon.CustomFormat = "MM'.'dd'.'yyyy";
            dtp_nach.Format = DateTimePickerFormat.Custom; dtp_kon.Format = DateTimePickerFormat.Custom;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_INN.Text = row.Cells[1].Value.ToString();
                textBox_Region.Text = row.Cells[2].Value.ToString();
                textBox_Country.Text = row.Cells[3].Value.ToString();
                textBox_Nnositel.Text = row.Cells[4].Value.ToString();
                textBox_Nsticker.Text = row.Cells[5].Value.ToString();
                textBox_Nsertif.Text = row.Cells[6].Value.ToString();
                dtp_nach.Text = row.Cells[7].Value.ToString();
                dtp_kon.Text = row.Cells[8].Value.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Opdate();
            MessageBox.Show("Изменения сохранены!");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void button_redact_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            var id = textBox_id.Text;
            var INN = textBox_INN.Text;
            var Region = textBox_Region.Text;
            var Country = textBox_Country.Text;
            var Nnositel = textBox_Nnositel.Text;
            var Nsticker = textBox_Nsticker.Text;
            var Nsertif = textBox_Nsertif.Text;
            DateTime nach = DateTime.Parse(dtp_nach.Text);
            DateTime kon = DateTime.Parse(dtp_kon.Text);

            var addQuery = $"insert into Certificates (id, INN, Region, Country, Nnositel, Nsticker, Nsertif, nach, kon) values ('{id}','{INN}', '{Region}' , '{Country}' , '{Nnositel}', '{Nsticker}', '{Nsertif}', '{nach.Month}/{nach.Day}/{nach.Year}', '{kon.Month}/{kon.Day}/{kon.Year}')";

            var command = new SqlCommand(addQuery, sqlConnection);
            command.ExecuteNonQuery();

            MessageBox.Show("Новый сертификат добавлен!");
        }

        private void dtp_nach_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIOFORM sio = new SIOFORM(user2);
            this.Hide();
            sio.ShowDialog();
            this.Show();
        }
    }
}
