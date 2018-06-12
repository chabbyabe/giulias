using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //needed import to connect to the mysql database
using System.Security.Cryptography; //need for encryption and decryption

namespace giulias_inventory_system
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }
        // 04-17-18 11:49 am Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable

        frmClients clients;
        frmHistory history;
        frmProfile profile;
        frmTransaction transactions;
        frmUsers users;
        frmReposrts reports;
        int user_id;
        int user_priviledge;

        string date_today = DateTime.Now.ToString("yyyy-MM-dd");

        #region "Mouse Hover and Leave"
        private void pbsClients_MouseHover(object sender, EventArgs e)
        {
            pbsClients.Image = Properties.Resources.selected_clients;
        }

        private void pbsClients_MouseLeave(object sender, EventArgs e)
        {
            pbsClients.Image = Properties.Resources.original_clients;
        }

        private void pbsTransaction_MouseHover(object sender, EventArgs e)
        {
            pbsTransaction.Image = Properties.Resources.selected_transaction;
        }

        private void pbsTransaction_MouseLeave(object sender, EventArgs e)
        {
            pbsTransaction.Image = Properties.Resources.original_transaction;
        }

        private void pbsProfile_MouseHover(object sender, EventArgs e)
        {
            pbsProfile.Image = Properties.Resources.selected_profile;
        }

        private void pbsProfile_MouseLeave(object sender, EventArgs e)
        {
            pbsProfile.Image = Properties.Resources.original_profile;
        }

        private void pbsReports_MouseHover(object sender, EventArgs e)
        {
            pbsReports.Image = Properties.Resources.selected_reports;
        }

        private void pbsReports_MouseLeave(object sender, EventArgs e)
        {
            pbsReports.Image = Properties.Resources.original_reports;
        }

        private void pbsHistory_MouseHover(object sender, EventArgs e)
        {
            pbsHistory.Image = Properties.Resources.selected_history;
        }

        private void pbsHistory_MouseLeave(object sender, EventArgs e)
        {
            pbsHistory.Image = Properties.Resources.original_history;
        }

        private void pbsUsers_MouseHover(object sender, EventArgs e)
        {
            pbsUsers.Image = Properties.Resources.selected_users;
        }

        private void pbsUsers_MouseLeave(object sender, EventArgs e)
        {
            pbsUsers.Image = Properties.Resources.original_users;
        }
#endregion
        #region "Main form Clicks"
        private void pbsClients_Click(object sender, EventArgs e)
        {
            this.Hide();
            clients = new frmClients();
            clients.get_details(lblName.Text, user_id, user_priviledge);
            MessageBox.Show(lblName.Text.ToString() + "---" +user_id.ToString() + "---"+user_priviledge.ToString());
            clients.ShowDialog();

        }

        private void pbsTransaction_Click(object sender, EventArgs e)
        {
            this.Hide();
            transactions = new frmTransaction();
            transactions.get_details(lblName.Text, user_id, user_priviledge);
            transactions.ShowDialog();
        }

        private void pbsProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            profile = new frmProfile();
            profile.get_current_details(lblName.Text, user_id, user_priviledge);
            profile.ShowDialog();
        }

        private void pbsReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            reports = new frmReposrts();
            reports.get_details(lblName.Text, user_id, user_priviledge);
            reports.ShowDialog();
        }

        private void pbsHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            history = new frmHistory();
            history.get_details(lblName.Text, user_id, user_priviledge);
            history.ShowDialog();
        }

        private void pbsUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            users = new frmUsers();
            users.get_details(lblName.Text, user_id, user_priviledge);
            users.ShowDialog();
        }
        #endregion

        private void frmHome_Load(object sender, EventArgs e)
        {

        }
        public void getUsername(string user, int id, int priviledge)
        {
            lblName.Text = user;
            user_id = id;
            user_priviledge = priviledge;
        }

        private void insert_into_history()                  //shows history about user logged in
        {
            string note = lblName.Text + "logged out";
            try
            {

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, userID, note) VALUES (@date_modified, @user_id, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id; // change if naa na userid
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = note;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
                //  MessageBox.Show("Sucessfully logged in!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            insert_into_history();
            MessageBox.Show("Thank you for logging out.");
            this.Close();
        }
    }
}
