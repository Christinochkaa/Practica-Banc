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
    
    public partial class DopOffice  : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        //private SqlConnection sqlConnection = null;
        private readonly checkUser user_;

        public DopOffice(checkUser _user)
        {
            user_ = _user;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Nomer_DO", "Номер ДО");
            dataGridView1.Columns.Add("Naimenovanie_DO", "Наименование ДО");
            //dataGridView1.Columns["id"].DisplayIndex = 2;           //вот часть, которая переворачивает мою таблицу
            //dataGridView1.Columns["Nomer_DO"].DisplayIndex = 1;
            //dataGridView1.Columns["Naimenovanie_DO"].DisplayIndex = 0;
            dataGridView1.Columns.Add("IsNew", String.Empty);

        }

        private void ClearFields()
        {
            textBox1id.Text = "";
            textBox2nomdo.Text = "" ;
            textBox3imado.Text = "" ;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            try
            {
                int id = record.IsDBNull(0) ? 0 : record.GetInt32(0);
                string number = record.IsDBNull(1) ? "" : record.GetString(1);
                string name = record.IsDBNull(2) ? "" : record.GetString(2);
                dgw.Rows.Add(id, number, name, RowState.ModifiedNew);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных: {ex.Message}");
            }
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select* from DO";
            SqlCommand command= new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            //sqlConnection=new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString);
            //sqlConnection.Open();
            tlsUserStatus.Text = $"{user_.Login}: {user_.Status}";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void button1obnov_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
            /*Update();*/
            /*Change();*/

        }

        private void button1dobav_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [DO] (No,Name) VALUES (@No,@Name)",
                dataBase.getConnection());

            command.Parameters.AddWithValue("No", textBox2nomdo.Text);
            command.Parameters.AddWithValue("Name", textBox3imado.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные успешно добавлены!");
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from DO where concat (Id,No,Name) like N'%" + textBox1poisk.Text + "%'";

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

            dataGridView1.Rows[index].Visible= false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[3].Value= RowState.Deleted;
        }

        private void Opdate()
        {
            dataBase.openConnection();

            for (int index=0; index<dataGridView1.Rows.Count; index++)
            {
                var rowState=(RowState)dataGridView1.Rows[index].Cells[3].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id=Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);

                    var deleteQuery = $"delete from DO where Id={id}";

                    var command = new SqlCommand(deleteQuery,dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var Nomer_DO = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Naimenovanie_DO = dataGridView1.Rows[index].Cells[2].Value.ToString();

                    var changeQuery =$"update DO set No=N'{Nomer_DO}',Name=N'{Naimenovanie_DO}' where id='{id}'";
                    var command = new SqlCommand(changeQuery,dataBase.getConnection());
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
            var selectedRowIndex=dataGridView1.CurrentCell.RowIndex;

            var id = textBox1id.Text;
            var Nomer_DO = textBox2nomdo.Text;
            var Naimenovanie_DO = textBox3imado.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != String.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id,Nomer_DO, Naimenovanie_DO);
                dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
            
        }


        private void button1izmen_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1id.Text = row.Cells[0].Value.ToString();
                textBox2nomdo.Text=row.Cells[1].Value.ToString();
                textBox3imado.Text=row.Cells[2].Value.ToString();


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
