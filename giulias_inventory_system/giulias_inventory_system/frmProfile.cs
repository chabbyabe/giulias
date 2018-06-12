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
    public partial class frmProfile : Form
    {
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

        int priviledgeID;
        public frmProfile()
        {
            InitializeComponent();
        }
   
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            home.getUsername(name,user_id,user_priviledge);         //to send data from one place to another
            home.Show();
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

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            pass_checker = new frmPasswordChecker();
            pass_checker.profile_get_user_details(name, user_id, user_priviledge, 1);
            pass_checker.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            convertPictureBox();
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

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void convertPictureBox()
        {
            string first_name = txtFname.Text;
            string middle_init = txtMid.Text;
            string last_name = txtLastName.Text;

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
            string password = encrypt_value(txtPassword.Text);
            string position = cmbPosition.Text;
            string description = txtDescription.Text;

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
                //  string name = txtClient.Text;
                //   string desc = txtClientDescription.Text;

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


                        // query to save to database
                        sc.command = sc.SQLCommand("UPDATE users SET first_name = @Firstname, middle_initial =@Middlename,last_name =@Lastname, photo = @Picture, userpriviledgeID = @PriviledgeID, gender = @Gender, dob = @DOB, username = @Username WHERE userID = @UserID");
                        sc.command.Parameters.Add("@UserID", MySqlDbType.Int32).Value = user_id;
                        sc.command.Parameters.Add("@Firstname", MySqlDbType.String).Value = first_name;
                        sc.command.Parameters.Add("@Middlename", MySqlDbType.String).Value = middle_init;
                        sc.command.Parameters.Add("@Lastname", MySqlDbType.String).Value = last_name;
                        sc.command.Parameters.Add("@Picture", MySqlDbType.Blob).Value = arr;
                        sc.command.Parameters.Add("@PriviledgeID", MySqlDbType.Int32).Value = priviledgeID;
                        sc.command.Parameters.Add("@Gender", MySqlDbType.String).Value = gender;
                        sc.command.Parameters.Add("@DOB", MySqlDbType.String).Value = formatted_date;
                        sc.command.Parameters.Add("@Username", MySqlDbType.String).Value = username;
                        // sc.command.Parameters.Add("@Password", MySqlDbType.String).Value = password;
                        sc.command.ExecuteNonQuery();
                        sc.CloseConnection();
                        sc.command.Parameters.Clear();

                        MessageBox.Show("You have successfully updated your profile.", "INFORMATION", MessageBoxButtons.OK);
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

        private void get_newly_added_client()
        {
            try
            {
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("SELECT clientID from clients ORDER BY clientID DESC LIMIT 1");
                sc.sqlReader = sc.command.ExecuteReader();

                while (sc.sqlReader.Read())
                {
                    //   currently_added_client_id = Convert.ToInt32(read["clientID"]);
                }
                sc.CloseConnection();
                sc.command.Parameters.Clear();

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

        private void frmProfile_Activated(object sender, EventArgs e)
        {
            get_current_user_details();
        }

        private void get_current_user_details()             //get the details of the users from the database to their resepctive places
        {
            try
            {
                sc.OpenConnection();
                sc.command = new MySqlCommand("SELECT a.*,up.name, up.description FROM users as a INNER JOIN userprivileges as up ON a.userpriviledgeID = up.userprivilegeID WHERE a.userID =" + user_id + "", sc.DBConnection);
                sc.sqlReader = sc.command.ExecuteReader();
                if (sc.sqlReader.HasRows)
                {
                    while (sc.sqlReader.Read())
                    {
                        // pbClientImage.Image = sc.sqlReader["photo"].ToImage();
                        string date_started = sc.sqlReader["date_started"].ToString();
                        DateTime dt = Convert.ToDateTime(date_started);
                        lblDateStarted.Text = dt.ToString("yyyy/MM/dd");

                        txtFname.Text = sc.sqlReader["first_name"].ToString();
                        txtLastName.Text = sc.sqlReader["last_name"].ToString();
                        txtMid.Text = sc.sqlReader["middle_initial"].ToString();

                        var data = (Byte[])(sc.sqlReader["photo"]);
                        var stream = new MemoryStream(data);
                        pbClientImage.Image = Image.FromStream(stream);

                        string bod = sc.sqlReader["dob"].ToString();
                        DateTime dt1 = Convert.ToDateTime(bod);
                        dtpBirthday.Text = dt1.ToString("yyyy/MM/dd");


                        if (sc.sqlReader["gender"].ToString() == "Male")
                        {
                            radMale.Checked = true;
                        }
                        else
                        {
                            radFemale.Checked = true;
                        }
                        txtUsername.Text = sc.sqlReader["username"].ToString();
                        //  txtPassword.Text = sc.sqlReader["password"].ToString();
                        cmbPosition.Text = sc.sqlReader["name"].ToString();
                        break;
                    }
                    sc.sqlReader.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid username or password.");
                    txtUsername.BackColor = Color.LightGoldenrodYellow;
                    txtPassword.BackColor = Color.LightGoldenrodYellow;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();

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

        private void get_user_position_description()           //get current user description
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

        public void get_current_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
            MessageBox.Show(name + "--"+user_id +"--"+ user_priviledge);
        }
        private void frmProfile_Load(object sender, EventArgs e)
        {

        }

    }
}
