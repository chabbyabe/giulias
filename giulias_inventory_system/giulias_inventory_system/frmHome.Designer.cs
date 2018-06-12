namespace giulias_inventory_system
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnlogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbsProfile = new System.Windows.Forms.PictureBox();
            this.pbsHistory = new System.Windows.Forms.PictureBox();
            this.pbsUsers = new System.Windows.Forms.PictureBox();
            this.pbsReports = new System.Windows.Forms.PictureBox();
            this.pbsTransaction = new System.Windows.Forms.PictureBox();
            this.pbsClients = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbsProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.LimeGreen;
            this.btnlogout.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Location = new System.Drawing.Point(141, 271);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(101, 40);
            this.btnlogout.TabIndex = 4;
            this.btnlogout.Text = "logout";
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepPink;
            this.panel1.Controls.Add(this.pbsProfile);
            this.panel1.Controls.Add(this.pbsHistory);
            this.panel1.Controls.Add(this.pbsUsers);
            this.panel1.Controls.Add(this.pbsReports);
            this.panel1.Controls.Add(this.pbsTransaction);
            this.panel1.Controls.Add(this.pbsClients);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(283, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 488);
            this.panel1.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Brush Script MT", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(106, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 46);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome";
            // 
            // pbsProfile
            // 
            this.pbsProfile.AccessibleName = "pbsProfile";
            this.pbsProfile.Image = global::giulias_inventory_system.Properties.Resources.original_profile;
            this.pbsProfile.Location = new System.Drawing.Point(317, 83);
            this.pbsProfile.Name = "pbsProfile";
            this.pbsProfile.Size = new System.Drawing.Size(125, 150);
            this.pbsProfile.TabIndex = 11;
            this.pbsProfile.TabStop = false;
            this.pbsProfile.Click += new System.EventHandler(this.pbsProfile_Click);
            this.pbsProfile.MouseLeave += new System.EventHandler(this.pbsProfile_MouseLeave);
            this.pbsProfile.MouseHover += new System.EventHandler(this.pbsProfile_MouseHover);
            // 
            // pbsHistory
            // 
            this.pbsHistory.Image = global::giulias_inventory_system.Properties.Resources.original_history;
            this.pbsHistory.Location = new System.Drawing.Point(174, 257);
            this.pbsHistory.Name = "pbsHistory";
            this.pbsHistory.Size = new System.Drawing.Size(125, 150);
            this.pbsHistory.TabIndex = 10;
            this.pbsHistory.TabStop = false;
            this.pbsHistory.Click += new System.EventHandler(this.pbsHistory_Click);
            this.pbsHistory.MouseLeave += new System.EventHandler(this.pbsHistory_MouseLeave);
            this.pbsHistory.MouseHover += new System.EventHandler(this.pbsHistory_MouseHover);
            // 
            // pbsUsers
            // 
            this.pbsUsers.AccessibleName = "pbsUsers";
            this.pbsUsers.Image = global::giulias_inventory_system.Properties.Resources.original_users;
            this.pbsUsers.Location = new System.Drawing.Point(317, 257);
            this.pbsUsers.Name = "pbsUsers";
            this.pbsUsers.Size = new System.Drawing.Size(125, 150);
            this.pbsUsers.TabIndex = 9;
            this.pbsUsers.TabStop = false;
            this.pbsUsers.Click += new System.EventHandler(this.pbsUsers_Click);
            this.pbsUsers.MouseLeave += new System.EventHandler(this.pbsUsers_MouseLeave);
            this.pbsUsers.MouseHover += new System.EventHandler(this.pbsUsers_MouseHover);
            // 
            // pbsReports
            // 
            this.pbsReports.Image = global::giulias_inventory_system.Properties.Resources.original_reports;
            this.pbsReports.Location = new System.Drawing.Point(26, 257);
            this.pbsReports.Name = "pbsReports";
            this.pbsReports.Size = new System.Drawing.Size(125, 150);
            this.pbsReports.TabIndex = 8;
            this.pbsReports.TabStop = false;
            this.pbsReports.Click += new System.EventHandler(this.pbsReports_Click);
            this.pbsReports.MouseLeave += new System.EventHandler(this.pbsReports_MouseLeave);
            this.pbsReports.MouseHover += new System.EventHandler(this.pbsReports_MouseHover);
            // 
            // pbsTransaction
            // 
            this.pbsTransaction.Image = global::giulias_inventory_system.Properties.Resources.original_transaction;
            this.pbsTransaction.Location = new System.Drawing.Point(174, 83);
            this.pbsTransaction.Name = "pbsTransaction";
            this.pbsTransaction.Size = new System.Drawing.Size(125, 150);
            this.pbsTransaction.TabIndex = 7;
            this.pbsTransaction.TabStop = false;
            this.pbsTransaction.Click += new System.EventHandler(this.pbsTransaction_Click);
            this.pbsTransaction.MouseLeave += new System.EventHandler(this.pbsTransaction_MouseLeave);
            this.pbsTransaction.MouseHover += new System.EventHandler(this.pbsTransaction_MouseHover);
            // 
            // pbsClients
            // 
            this.pbsClients.Image = global::giulias_inventory_system.Properties.Resources.original_clients;
            this.pbsClients.Location = new System.Drawing.Point(26, 83);
            this.pbsClients.Name = "pbsClients";
            this.pbsClients.Size = new System.Drawing.Size(125, 150);
            this.pbsClients.TabIndex = 6;
            this.pbsClients.TabStop = false;
            this.pbsClients.Click += new System.EventHandler(this.pbsClients_Click);
            this.pbsClients.MouseLeave += new System.EventHandler(this.pbsClients_MouseLeave);
            this.pbsClients.MouseHover += new System.EventHandler(this.pbsClients_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::giulias_inventory_system.Properties.Resources.giulia;
            this.pictureBox1.Location = new System.Drawing.Point(-23, -120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 565);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giulia Inventory System v.1.0.0";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbsProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbsClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbsTransaction;
        private System.Windows.Forms.PictureBox pbsClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbsHistory;
        private System.Windows.Forms.PictureBox pbsUsers;
        private System.Windows.Forms.PictureBox pbsReports;
        private System.Windows.Forms.PictureBox pbsProfile;
        public System.Windows.Forms.Label lblName;
    }
}