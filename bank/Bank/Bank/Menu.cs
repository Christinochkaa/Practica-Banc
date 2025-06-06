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
    public partial class Menu : Form
    {
        private readonly checkUser _user;
        private SqlConnection sqlConnection = null;
        public Menu(checkUser user)
        {
            _user = user;
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void IsAdmin()
        {
            btnUsers.Enabled = _user.IsAdmin;
            btnDo.Enabled = _user.IsAdmin;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString);
            sqlConnection.Open();

            //tlsUserStatus.Text = $"{_user.Login}: {_user.Status}";
            IsAdmin();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users users = new Users(_user);
            this.Hide();
            users.ShowDialog();
            this.Show();
        }

        private void btnSert_Click(object sender, EventArgs e)
        {
            Certificates sert = new Certificates(_user);
            this.Hide();
            sert.ShowDialog();
            this.Show();
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            DopOffice dp = new DopOffice(_user);
            this.Hide();
            dp.ShowDialog();
            this.Show();
        }

        private void btnSio_Click(object sender, EventArgs e)
        {
            SIOFORM sio = new SIOFORM(_user);
            this.Hide();
            sio.ShowDialog();
            this.Show();
        }
    }
}
