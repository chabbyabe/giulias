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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region "Forms and Connections"
        // 04-19-18 9:08 pm Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        frmClientConfiguration cc = new frmClientConfiguration();   //Calls the client configuration form to add or update costumers
        frmHome home = new frmHome();

        #endregion

        int id;
        int user_privilege;
        string hash = "foxle@rn";
        string date_today = DateTime.Now.ToString("yyyy-MM-dd");
        private void btnlogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = encrypt_value(txtPassword.Text);
            //MessageBox.Show(decyrpt_value(txtPassword.Text));
            try
            {

                sc.OpenConnection();

                if (username.Equals("") || password.Equals(""))
                {
                    MessageBox.Show("Please enter username or password.");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                }
                else
                {

                    sc.command = new MySqlCommand("SELECT * FROM users WHERE  `Username`= @Username and `Password`= @Password", sc.DBConnection);
                    sc.command.Parameters.Add("@Username", MySqlDbType.String).Value = username;
                    sc.command.Parameters.Add("@Password", MySqlDbType.String).Value = password;

                    sc.sqlReader = sc.command.ExecuteReader();
                    sc.command.Parameters.Clear();
                    if (sc.sqlReader.HasRows)
                    {
                        while (sc.sqlReader.Read())
                        {

                            id = Convert.ToInt32(sc.sqlReader["userID"].ToString());
                            user_privilege = Convert.ToInt32(sc.sqlReader["userpriviledgeID"].ToString());
                            txtUsername.BackColor = Color.White;
                            txtPassword.BackColor = Color.White;
                            MessageBox.Show("You successfully logged in!");
                            this.Hide();
                            home.getUsername(txtUsername.Text, id, user_privilege);
                            home.Show();
                            break;
                        }
                        sc.sqlReader.Close();
                        insert_into_history();
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
        private string getUsername(string getUsername)
        {
            getUsername = txtUsername.Text;
            return getUsername;
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
        public string decyrpt_value(string password)        // for decryption added by abegail isidro 04-25-2018
        {
            byte[] data = Convert.FromBase64String(password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    password = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return password;
        }

        private void insert_into_history()                  //shows history about user logged in
        {
            string note = txtUsername.Text + "logged in";
            try
            {

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, userID, note) VALUES (@date_modified, @user_id, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = id; // change if naa na userid
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
