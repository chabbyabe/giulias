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
using System.Drawing.Imaging;
using System.IO;

namespace giulias_inventory_system
{
    public partial class frmClientConfiguration : Form
    {
        public frmClientConfiguration()
        {
            InitializeComponent();
        }
        #region "Forms and Connections"
        // 04-17-18 11:49 am Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        #endregion

        #region "variables"
        string type; //get the tpye of client
        int client_classification_id; // getting the client_classificationID

        // variables used for the get-set property
        string client_name;
        string client_type;
        string client_desc;
        byte[] client_pic;
        #endregion

        #region "GetSet Properties"
        public string ClientName { set { client_name = value; } }
        public string ClientType{ set { client_type = value; } }
        public string ClientDesc { set { client_desc = value; } }
        public byte[] ClientPicture { set { client_pic = value; } }
        #endregion


        #region "methods"

        private void get_client_type(DataTable dt)
        {

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("Select clientclassificationID,name,description  From clientclassifications");
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

        private void convertPictureBox()
        {

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
            if (arr.Length < 5242880)
            {
                string name = txtClientName.Text;
                string desc = txtClientDescription.Text;

                try
                {
                    sc.OpenConnection();
                    // modification of the error messages that will show
                    if (name.Equals("") || desc.Equals(""))
                    {
                        if (name.Equals(""))
                        {
                            MessageBox.Show("Please enter the name of the product.","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        else if (desc.Equals(""))
                        {
                            MessageBox.Show("Please select a client type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                    else
                    {
                        // check the current value of the client_classification_id
                        if (client_classification_id==0)
                        {
                            client_classification_id = 1;
                        }

                        // query to save to database
                           sc.command = sc.SQLCommand("INSERT INTO  clients (name,photo,clientclassificationID,active) VALUES('"+ name + "',@Picture," + client_classification_id +",1)");
                           sc.command.Parameters.Add("@Picture", MySqlDbType.Blob).Value = arr;
                           sc.command.ExecuteNonQuery();
                           sc.CloseConnection();
                           sc.command.Parameters.Clear();
                           MessageBox.Show("Your record has been successfully saved.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.Dispose();
                    }
                    /* 
                    else if (btnUpdate.Text == "UPDATE PRODUCT")
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
                     */
                    
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
                MessageBox.Show("Oopss. The size of the image reached the maximum value. Please upload 5mb or lesser than files.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


        #endregion

        #region "events"
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            convertPictureBox();
        }

        private void dgvClientType_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClientType.Rows[e.RowIndex];
                int rowindex = dgvClientType.CurrentCell.RowIndex;
                int columnindex = dgvClientType.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvclienttype;
                    client_classification_id = Convert.ToInt32(dgvClientType.Rows[rowindex].Cells[0].Value.ToString());
          
                }
                catch (Exception ex)
                {

                }

               

            }

            // getting the description of the client description type
            if (dgvClientType.Rows.Count > -1)
            {
                txtClientDescription.Text = dgvClientType.Rows[e.RowIndex].Cells[2].Value.ToString();
                type = dgvClientType.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void frmClientConfiguration_Load(object sender, EventArgs e)
        {
            btnUpdateClient.Enabled = false;
            dTable = new DataTable();
            get_client_type(dTable);
            dgvClientType.DataSource = dTable;
            dTable.Dispose();
            dgvClientType.Columns[0].Visible = false;
            dgvClientType.Columns[2].Visible = false;
            dgvClientType.ColumnHeadersVisible = false;
        }

        private void dgvClientType_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvClientType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif)|*.jpg; *.jpeg; *.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pbClientImage.Image = new Bitmap(open.FileName);
            }
        }
        #endregion






    }
}
