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
    public partial class frmPasswordChecker : Form
    {
        string name;
        int user_id;
        int user_priviledge;
        string old_password;
        string hash = "foxle@rn";
        int checker;
        frmProfile profile = new frmProfile();
        frmUsers users = new frmUsers();

        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        public frmPasswordChecker()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string current = encrypt_value(txtCurrent.Text);
            string password = encrypt_value(txtPrevious.Text);
            //MessageBox.Show(decyrpt_value(txtPassword.Text));
            try
            {

                sc.OpenConnection();

                if (current.Equals("") || password.Equals(""))
                {
                    MessageBox.Show("Please enter your password.");
                    txtCurrent.Text = "";
                    txtPrevious.Text = "";
                    txtCurrent.Focus();
                }
                else
                {
                    sc.command = new MySqlCommand("SELECT * FROM users WHERE  `userID`= @UserID", sc.DBConnection);
                    sc.command.Parameters.Add("@UserID", MySqlDbType.Int32).Value = user_id;
                    sc.sqlReader = sc.command.ExecuteReader();

                    sc.command.Parameters.Clear();
                    if (sc.sqlReader.HasRows)
                    {
                        while (sc.sqlReader.Read())
                        {
                            old_password = sc.sqlReader["password"].ToString();
                            break;
                        }
                        sc.sqlReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("The password you have entered is incorrect.");
                        txtCurrent.Text = "";
                        txtPrevious.Text = "";
                        txtCurrent.Focus();
                    }
                }
                MessageBox.Show(old_password.ToString());
                MessageBox.Show(user_id.ToString());
                MessageBox.Show(password);
                if (old_password == password)
                {
                    sc.command = sc.SQLCommand("UPDATE users SET password = @Password WHERE userID = @UserID");
                    sc.command.Parameters.Add("@UserID", MySqlDbType.Int32).Value = user_id;
                    sc.command.Parameters.Add("@Password", MySqlDbType.String).Value = current;
                    sc.sqlReader = sc.command.ExecuteReader();
                    this.Close();
                    profile.get_current_details(name, user_id, user_priviledge);         //to send data from one place to another
                    MessageBox.Show("You successfully changed your password!");
                }
                else
                {
                    MessageBox.Show("The password you have entered is incorrect.");

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCurrent.Text = "";
            txtPrevious.Text = "";
            this.Close();
            if (checker == 1)
            {
                profile.get_current_details(name, user_id, user_priviledge);         //to send data from one place to another
                profile.Show();
            }
            else if (checker == 2)
            {
                users.get_details(name, user_id, user_priviledge);         //to send data from one place to another
                users.Show();
            }
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
        public void profile_get_user_details(string user, int id, int priviledge, int check)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
            checker = check;
        }

        public void users_get_user_details(string user, int id, int priviledge, int check)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
            checker = check;
        }

        public void get_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
        }
    }
}
