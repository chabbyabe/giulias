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
using System.IO;
using System.Drawing.Imaging;

namespace giulias_inventory_system
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        // 04-17-18 3:00 pm Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        frmClientConfiguration cc = new frmClientConfiguration();   //Calls the client configuration form to add or update costumers
        frmHome home = new frmHome();
        frmPasswordChecker pass_checker;

        string name;
        int user_id;
        int user_priviledge;
        string gender;
        string hash = "foxle@rn";

        int userID;
        int priviledgeID;
        int active;

        bool add_or_update = true;

        int active_inactive = 1;
        string search_this;
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            // initializing the forms when loaded
            // added by Abegail Isidro
            // April 17, 2018


            /* clear_all_values();
             dTable = new DataTable(); //initializing datatable
             sc.OpenConnection(); // accessing the OpenConnection method from the Connection class
             get_users_details(dTable);
             dgvResults.DataSource = dTable; // assigning values to the datagridview
             dTable.Dispose();
             */

            if (radActive.Checked == true)
            {
                txtSetActiveInactive.Text = "SET USER AS INACTIVE";
                // ClearAllValues();
                dTable = new DataTable();
                if (radActive.Checked == true)
                {
                    active_inactive = 1;
                }
                else
                {
                    active_inactive = 0;
                }
                get_active_users(dTable, active_inactive);
                dgvResults.DataSource = dTable;
                lblResult.Text = dgvResults.RowCount.ToString() + "   match(es) Found.";
                dTable.Dispose();
                //     Hide_DGV(); // calling Hide_DGV function
            }

            dgvResults.Columns["userID"].Visible = false;
            dgvResults.Columns["middle_initial"].Visible = false;
            dgvResults.Columns["photo"].Visible = false;
            dgvResults.Columns["userpriviledgeID"].Visible = false;
            dgvResults.Columns["gender"].Visible = false;
            dgvResults.Columns["dob"].Visible = false;
            dgvResults.Columns["username"].Visible = false;
            dgvResults.Columns["password"].Visible = false;
            dgvResults.Columns["date_started"].Visible = false;
            dgvResults.Columns["date_dismissed"].Visible = false;
            dgvResults.Columns["active"].Visible = false;
            dgvResults.Columns["userpriviledgeID"].Visible = false;
            dgvResults.Columns["description"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear_values();
        }
        private void get_users_details(DataTable dt)
        {
            // added by Abegail Isidro
            // April 17, 2018
            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("Select * From users");
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
        }


        public void add_update_user_details(DataTable dt)
        {
            // added by Abegail Isidro
            // April 17, 2018


            string first_name = txtFname.Text;
            string last_name = txtLast.Text;
            string middle_initial = txtMid.Text;
            string birth_date = dtpBirthday.Value.ToString("yyyy,MM,dd");   
            if (radFemale.Checked ==true){
                string gender = radFemale.Text;
            }
            else {
                string gender = radMale.Text;
            }
            string position = this.cmbPosition.Items[this.cmbPosition.SelectedIndex].ToString(); ;
            string date_started = txtStarted.Text;
            string date_dismissed = txtDismissed.Text;
            string usernmae = txtUsername.Text;
            string password = txtPassword.Text;
            string position_description = txtDesc.Text;

            /*
            try
            {

                sc.OpenConnection();
                if (first_name.Equals("") || last_name.Equals(""))
                {
                    MessageBox.Show("Please enter the name of the product.");
                }
                else
                {

                   if (btnAdd.Text == "ADD USER")
                   {
                       
                       sc.command = sc.SQLCommand("INSERT INTO `users`(`userID`, first_name, middle_initial,last_name,photo,userpriviledgeID,gender,dob,username,password,date_started,date_dismissed,active) "
                       + "VALUES(," + first_name+ "', '" + middle_initial+ "','" + last_name+ "','" + sss+ "',0, "+ price+",1)");
                       sc.command.ExecuteNonQuery();
                       sc.CloseConnection();
                       MessageBox.Show("Your record has been successfully saved.");
                   }
                   else if (btnUpdate.Text == "UPDATE USER")
                   {
                       sc.command = sc.SQLCommand("Update competition "
                         + "Set Name = '" + name + "', "
                         + "Description = '" + desc + "', "
                         + "DateFrom = '" + dFrom + "', "
                         + "DateTo = '" + dTo + "'"
                         + "Where ID = " + get_user_id + "");
                       sc.command.ExecuteNonQuery();
                       MessageBox.Show(name + desc + dFrom + dTo);
                       sc.CloseConnection();
                       MessageBox.Show("Your record has been successfully updated.");

                   }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
                       */

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Clicking the Upload Button
            // added by Abegail Isidro
            // April 17, 2018

            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                pbClientImage.ImageLocation = ofdPic.FileName;

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            home.getUsername(name, user_id, user_priviledge);
            home.Show();
        }

        private void clear_values()
        {
            // Function for Clearing All Values
            // added by Abegail Isidro
            // April 17, 2018


            txtFname.Text = "";
            txtLast.Text = "";
            txtMid.Text = "";
            txtDesc.Text = "";
            txtSearch.Text = "";
            txtUsername.Text = "";
            txtSearch.Focus();
        }

        private void get_active_users(DataTable dt, int active_inactive)
        {
            /**
                04-29-18 12:26 am Added by Abe Isidro 

                User active inactive details.
            */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT u.*,up.name,up.description FROM users as u INNER JOIN userprivileges as up ON u.userpriviledgeID = up.userprivilegeID WHERE u.active = @activeinactive ORDER BY u.userID DESC");
                sc.command.Parameters.Add("@activeinactive", MySqlDbType.Int32).Value = active_inactive;
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
                sc.command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

                sc.CloseConnection();
            }
        }
        public void get_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
        }
    }
}
