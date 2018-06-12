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
            txtDescription.Text = "";
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search_this = txtSearch.Text.ToString();

            clear_all_values();
            dTable = new DataTable();
            if (radActive.Checked == true)
            {
                active_inactive = 1;
            }
            else
            {
                active_inactive = 0;
            }

            search_items(dTable, active_inactive, search_this);
            dgvResults.DataSource = dTable;
            lblResult.Text = dgvResults.RowCount.ToString() + "   match(es) Found.";
            dTable.Dispose();
            // Hide_DGV(); // calling Hide_DGV function
        }

        private void radActive_CheckedChanged(object sender, EventArgs e)
        {
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

        }

        private void radInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (radInactive.Checked == true)
            {
                txtSetActiveInactive.Text = "SET USER AS ACTIVE";
                //  ClearAllValues();
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
            }
        }

        private void dgvResults_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /**
             04-28-18 12:05 pm Added by Abe Isidro 

             This method is triggered when the user clicks any cell in the results dgv
            */


            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvResults.Rows[e.RowIndex];
                int rowindex = dgvResults.CurrentCell.RowIndex;
                int columnindex = dgvResults.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    btnUpdate.Visible = true;
                    btnAdd.Visible = false;
                    btnChangePass.Visible = true;
                    txtPassword.Visible = false;
                    userID = Convert.ToInt32(dgvResults.Rows[rowindex].Cells[0].Value.ToString());
                    txtFname.Text = dgvResults.Rows[rowindex].Cells[1].Value.ToString();
                    txtMid.Text = dgvResults.Rows[rowindex].Cells[2].Value.ToString();
                    txtLast.Text = dgvResults.Rows[rowindex].Cells[3].Value.ToString();
                    priviledgeID = Convert.ToInt32(dgvResults.Rows[rowindex].Cells[5].Value.ToString());

                    if (dgvResults.Rows[rowindex].Cells[6].Value.ToString() == "Female")
                    {
                        radFemale.Checked = true;
                        radMale.Checked = false;
                    }
                    else
                    {
                        radFemale.Checked = false;
                        radMale.Checked = true;
                    }

                    dtpBirthday.Text = dgvResults.Rows[rowindex].Cells[7].Value.ToString();

                    txtUsername.Text = dgvResults.Rows[rowindex].Cells[8].Value.ToString();

                    string started = dgvResults.Rows[rowindex].Cells[10].Value.ToString();
                    DateTime dt1 = Convert.ToDateTime(started);
                    dtpStarted.Text = dt1.ToString("yyyy/MM/dd");

                    string dismissed = dgvResults.Rows[rowindex].Cells[11].Value.ToString();
                    DateTime dt2 = Convert.ToDateTime(dismissed);
                    txtDismissed.Text = dt2.ToString("yyyy/MM/dd");

                    active = Convert.ToInt32(dgvResults.Rows[rowindex].Cells[12].Value.ToString());
                    cmbPosition.Text = dgvResults.Rows[rowindex].Cells[1].Value.ToString();
                    MessageBox.Show(cmbPosition.Text);
                    txtDescription.Text = dgvResults.Rows[rowindex].Cells[1].Value.ToString();
                    MessageBox.Show(txtDescription.Text);


                }
                catch (Exception)
                {
                }
                // assigning the values to the respective placements
                // picture
                try
                {
                    if (row.Cells["photo"].Value != System.DBNull.Value) // if there is a picture available
                    {
                        var data = (Byte[])(row.Cells["photo"].Value);
                        var stream = new MemoryStream(data);
                        pbClientImage.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_clients;
                    }
                }
                catch (Exception)
                {
                    pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_clients;
                }
            }
        }




        private void convertPictureBox(bool checker_add_or_update)          //get the picture box and queries happen here
        {
            string first_name = txtFname.Text;
            string middle_init = txtMid.Text;
            string last_name = txtLast.Text;
            string bod = dtpBirthday.Text;
            string[] split = bod.Split('/');
            string formatted_date = split[2] + '-' + split[1] + '-' + split[0];
            string gender;
            if (radFemale.Checked == true)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string position = cmbPosition.Text;
            string description = txtDescription.Text;

            string dStarted = dtpStarted.Text;
            string[] split_started = dStarted.Split('/');
            string formatted_started = split_started[2] + '-' + split_started[1] + '-' + split_started[0];

            string date_dismissed = txtDismissed.Text;

            MessageBox.Show(formatted_date.ToString(), formatted_started.ToString());
            //kuhaon ang picture gikan sa picturebox
            Image img = pbClientImage.Image;
            // byte na array
            byte[] arr;
            //memory stream
            var ms = new MemoryStream();



            //check ang file tapos i convert ang Image to memory stream

            if (ImageFormat.Jpeg.Equals(img.RawFormat))
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ImageFormat.Png.Equals(img.RawFormat))
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ImageFormat.Gif.Equals(img.RawFormat))
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }

            //himoun og array ang memory stream
            arr = ms.ToArray();

            //check lang ni if default ang picture
            bool Default = Check_IF_Default(arr);


            if (Default == true)
            {

                byte[] Def = { 0 };
                arr = Def;


            }
            //1048576

            //check if more than 5mb. If more than then di pwede
            if (arr.Length < 65536)
            {

                try
                {
                    sc.OpenConnection();
                    // modification of the error messages that will show

                    if (name.Equals(""))
                    {
                        MessageBox.Show("Please enter the name of the user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (add_or_update == true)
                        {
                            // query to save to database
                            sc.command = sc.SQLCommand("INSERT INTO  users (first_name,middle_initial,last_name,photo,userpriviledgeID,gender,dob,username,password,date_started,active) VALUES(@Firstname,@Middlename,@Lastname,@Picture,@PriviledgeID,@Gender,@DOB,@Username,@Password,@Started,1)");
                            sc.command.Parameters.Add("@Firstname", MySqlDbType.String).Value = first_name;
                            sc.command.Parameters.Add("@Middlename", MySqlDbType.String).Value = middle_init;
                            sc.command.Parameters.Add("@Lastname", MySqlDbType.String).Value = last_name;
                            sc.command.Parameters.Add("@Picture", MySqlDbType.Blob).Value = arr;
                            sc.command.Parameters.Add("@PriviledgeID", MySqlDbType.Int32).Value = priviledgeID;
                            sc.command.Parameters.Add("@Gender", MySqlDbType.String).Value = gender;
                            sc.command.Parameters.Add("@DOB", MySqlDbType.String).Value = formatted_date;
                            sc.command.Parameters.Add("@Username", MySqlDbType.String).Value = username;
                            sc.command.Parameters.Add("@Password", MySqlDbType.String).Value = password;
                            sc.command.Parameters.Add("@Started", MySqlDbType.String).Value = formatted_started;
                            sc.command.ExecuteNonQuery();
                            sc.CloseConnection();
                            sc.command.Parameters.Clear();
                            MessageBox.Show("You have successfully saved a profile.");

                            //     insert_into_history(add_or_update);
                            clear_all_values();
                        }
                        else if (add_or_update == false)
                        {
                            // query to save to database
                            sc.command = sc.SQLCommand("UPDATE users SET first_name = @Firstname, middle_initial =@Middlename,last_name =@Lastname, photo = @Picture, userpriviledgeID = @PriviledgeID, gender = @Gender, dob = @DOB, username = @Username, password =@Password, date_started = @Started WHERE userID = @UserID");
                            sc.command.Parameters.Add("@UserID", MySqlDbType.Int32).Value = userID;
                            sc.command.Parameters.Add("@Firstname", MySqlDbType.String).Value = first_name;
                            sc.command.Parameters.Add("@Middlename", MySqlDbType.String).Value = middle_init;
                            sc.command.Parameters.Add("@Lastname", MySqlDbType.String).Value = last_name;
                            sc.command.Parameters.Add("@Picture", MySqlDbType.Blob).Value = arr;
                            sc.command.Parameters.Add("@PriviledgeID", MySqlDbType.Int32).Value = priviledgeID;
                            sc.command.Parameters.Add("@Gender", MySqlDbType.String).Value = gender;
                            sc.command.Parameters.Add("@DOB", MySqlDbType.String).Value = formatted_date;
                            sc.command.Parameters.Add("@Username", MySqlDbType.String).Value = username;
                            sc.command.Parameters.Add("@Password", MySqlDbType.String).Value = password;
                            sc.command.Parameters.Add("@Started", MySqlDbType.String).Value = formatted_started;
                            sc.command.ExecuteNonQuery();
                            sc.CloseConnection();
                            sc.command.Parameters.Clear();

                            MessageBox.Show("You have successfully updated your profile.");
                            //      insert_into_history(add_or_update);
                            clear_all_values();
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
            }
            else
            {
                MessageBox.Show("Oopss. The size of the image reached the maximum value. Please upload 65kb or lesser than files.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Check_IF_Default(byte[] Image)
        {
            Image Default_Image = giulias_inventory_system.Properties.Resources.original_clients;
            byte[] arr;

            var ms = new MemoryStream();

            if (ImageFormat.Jpeg.Equals(Default_Image.RawFormat))
            {
                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ImageFormat.Png.Equals(Default_Image.RawFormat))
            {

                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ImageFormat.Gif.Equals(Default_Image.RawFormat))
            {

                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }
            arr = ms.ToArray();

            Boolean Same = true;

            //check every single bit.
            int a = 0;
            try
            {

                while (a < Image.Length)
                {
                    if (arr[a] != Image[a])
                    {

                        Same = false;
                        break;
                    }
                    a += 1;
                }
            }
            catch (Exception)
            {
                Same = false;
            }
            return Same;
        }
        public string encrypt_value(string password)         //added by abegail isidro 04-25-2018 to encrypt password
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    password = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return password;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            add_or_update = false;
            btnChangePass.Visible = false;
            txtPassword.Visible = true;
            convertPictureBox(add_or_update);
        }

        private void frmUsers_Activated(object sender, EventArgs e)
        {
            /*   dTable = new DataTable(); //initializing datatable
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
                dTable.Dispose();
                lblResult.Text = dgvResults.RowCount.ToString() + "   match(es) Found.";
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

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            sc.sqlReader.Close();
            get_user_position_description();
        }
        private void get_user_position_description()                // get the position of the user
        {
            try
            {
                sc.OpenConnection();
                if (cmbPosition.SelectedIndex == 0)
                {
                    sc.command = new MySqlCommand("SELECT * FROM userprivileges WHERE userprivilegeID =1", sc.DBConnection);
                    priviledgeID = 1;
                }
                else if (cmbPosition.SelectedIndex == 1)
                {
                    sc.command = new MySqlCommand("SELECT * FROM userprivileges WHERE userprivilegeID =2", sc.DBConnection);
                    priviledgeID = 2;
                }
                else if (cmbPosition.SelectedIndex == 2)
                {
                    sc.command = new MySqlCommand("SELECT * FROM userprivileges WHERE userprivilegeID =3", sc.DBConnection);
                    priviledgeID = 3;
                }
                sc.sqlReader = sc.command.ExecuteReader();
                if (sc.sqlReader.HasRows)
                {
                    while (sc.sqlReader.Read())
                    {
                        txtDescription.Text = sc.sqlReader["description"].ToString();
                        break;
                    }
                    sc.sqlReader.Close();
                }
                else
                {
                    MessageBox.Show("no selected");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                sc.CloseConnection();
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            pass_checker = new frmPasswordChecker();
            pass_checker.users_get_user_details(name, user_id, user_priviledge, 2);
            pass_checker.Show();
        }

        private void txtSetActiveInactive_Click(object sender, EventArgs e)
        {
            /**
   04-28-18 7:38 pm Added by Abe Isidro 

      Set Active Inactive
  */

            if (user_id > 0)
            {
                int active_checker = 0;

                if (txtSetActiveInactive.Text == "SET USER AS ACTIVE")
                {
                    active_checker = 1;
                    MessageBox.Show("You set user to ACTIVE.");
                }
                else if (txtSetActiveInactive.Text == "SET USER AS INACTIVE")
                {
                    active_checker = 0;
                    MessageBox.Show("You set user to INACTIVE.");
                }

                try
                {
                    sc.OpenConnection();
                    sc.command = sc.SQLCommand("UPDATE users SET active = @active_inactive WHERE userID= @id");
                    sc.command.Parameters.Add("@id", MySqlDbType.Int32).Value = userID;
                    sc.command.Parameters.Add("@active_inactive", MySqlDbType.Int32).Value = active_checker;
                    sc.command.ExecuteNonQuery();
                    sc.CloseConnection();
                    sc.command.Parameters.Clear();
                    // insert_into_history_active_inactive(active_checker);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sc.CloseConnection();

                }
                //   ClearAllValues();
            }
            else
            {
                MessageBox.Show("Please Select a User first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

               private void search_active_users(DataTable dt, bool checker)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                Gets all of the products of the user
                parameters: datatable, id for the client id and activeinactive
            */
            int checkers = 0;

            if (checker == true)
            {
                checkers = 1;
            }

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT * FROM users WHERE userID = @UserID AND active = @active_inactive");
                sc.command.Parameters.Add("@UserID", MySqlDbType.Int32).Value = userID;
                sc.command.Parameters.Add("@active_inactive", MySqlDbType.Int32).Value = checkers;
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
        }
        private void search_items(DataTable dt, int active_inactive, string search)
        {
            /**
               04-19-18 11:26 am Added by Kwen Isidro 

               Search Clients and Products
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT u.*,up.name,up.description FROM users as u INNER JOIN userprivileges as up ON u.userpriviledgeID = up.userprivilegeID WHERE u.active = @activeinactive AND (u.first_name LIKE '%" + search + "%' OR u.last_name LIKE '%" + search + "%')");
                sc.command.Parameters.Add("@activeinactive", MySqlDbType.Int32).Value = active_inactive;
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
                sc.command.Parameters.Clear();
            }
        }

        private void get_product_details(DataTable dt, int active_inactive)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                Client and Product details.
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

        private void clear_all_values()         //clears all values in the textboxes
        {
            txtFname.Focus();
            txtFname.Text = "";
            txtMid.Text = "";
            txtLast.Text = "";
            dtpBirthday.Value = DateTime.Now;
            txtUsername.Text = "";
            txtDismissed.Text = "";
            radFemale.Checked = false;
            radMale.Checked = false;
            //  cmbPosition.SelectedIndex=0;
            txtSearch.Text = "";
        }
    }
}
