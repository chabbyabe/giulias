namespace giulias_inventory_system
{
    partial class frmClientConfiguration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActiveInactive = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pbClientImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtClientDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvClientType = new System.Windows.Forms.DataGridView();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitle.ForeColor = System.Drawing.Color.White;
            this.lblBookTitle.Location = new System.Drawing.Point(-11, 6);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(0, 23);
            this.lblBookTitle.TabIndex = 35;
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.BackColor = System.Drawing.Color.Crimson;
            this.btnUpdateClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateClient.ForeColor = System.Drawing.Color.White;
            this.btnUpdateClient.Location = new System.Drawing.Point(237, 282);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(176, 33);
            this.btnUpdateClient.TabIndex = 103;
            this.btnUpdateClient.Text = "UPDATE CLIENT";
            this.btnUpdateClient.UseVisualStyleBackColor = false;
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.Crimson;
            this.btnAddClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(237, 246);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(176, 33);
            this.btnAddClient.TabIndex = 102;
            this.btnAddClient.Text = "ADD CLIENT";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 98;
            this.label1.Text = "Client Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 97;
            this.label2.Text = "Client Name:";
            // 
            // btnActiveInactive
            // 
            this.btnActiveInactive.BackColor = System.Drawing.Color.Crimson;
            this.btnActiveInactive.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveInactive.ForeColor = System.Drawing.Color.White;
            this.btnActiveInactive.Location = new System.Drawing.Point(14, 271);
            this.btnActiveInactive.Name = "btnActiveInactive";
            this.btnActiveInactive.Size = new System.Drawing.Size(150, 33);
            this.btnActiveInactive.TabIndex = 102;
            this.btnActiveInactive.Text = "SET AS INACTIVE";
            this.btnActiveInactive.UseVisualStyleBackColor = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Crimson;
            this.btnUpload.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(14, 191);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(150, 33);
            this.btnUpload.TabIndex = 101;
            this.btnUpload.Text = "Upload Photo";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.ForeColor = System.Drawing.Color.DeepPink;
            this.txtClientName.Location = new System.Drawing.Point(16, 51);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(401, 27);
            this.txtClientName.TabIndex = 36;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.YellowGreen;
            this.label26.Location = new System.Drawing.Point(3, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 25);
            this.label26.TabIndex = 94;
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Crimson;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnActiveInactive);
            this.panel6.Controls.Add(this.btnUpload);
            this.panel6.Controls.Add(this.pbClientImage);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.lblBookTitle);
            this.panel6.Location = new System.Drawing.Point(2, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 318);
            this.panel6.TabIndex = 71;
            // 
            // pbClientImage
            // 
            this.pbClientImage.Image = global::giulias_inventory_system.Properties.Resources.original_profile;
            this.pbClientImage.Location = new System.Drawing.Point(14, 33);
            this.pbClientImage.Name = "pbClientImage";
            this.pbClientImage.Size = new System.Drawing.Size(150, 150);
            this.pbClientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClientImage.TabIndex = 70;
            this.pbClientImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightPink;
            this.panel1.Controls.Add(this.txtClientDescription);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvClientType);
            this.panel1.Controls.Add(this.btnUpdateClient);
            this.panel1.Controls.Add(this.btnAddClient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtClientName);
            this.panel1.Location = new System.Drawing.Point(184, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 321);
            this.panel1.TabIndex = 70;
            // 
            // txtClientDescription
            // 
            this.txtClientDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientDescription.ForeColor = System.Drawing.Color.DeepPink;
            this.txtClientDescription.Location = new System.Drawing.Point(223, 127);
            this.txtClientDescription.Name = "txtClientDescription";
            this.txtClientDescription.ReadOnly = true;
            this.txtClientDescription.Size = new System.Drawing.Size(190, 92);
            this.txtClientDescription.TabIndex = 106;
            this.txtClientDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(219, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 105;
            this.label3.Text = "Description:";
            // 
            // dgvClientType
            // 
            this.dgvClientType.AllowUserToAddRows = false;
            this.dgvClientType.AllowUserToDeleteRows = false;
            this.dgvClientType.AllowUserToResizeColumns = false;
            this.dgvClientType.AllowUserToResizeRows = false;
            this.dgvClientType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientType.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientType.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientType.GridColor = System.Drawing.Color.LightPink;
            this.dgvClientType.Location = new System.Drawing.Point(16, 128);
            this.dgvClientType.MultiSelect = false;
            this.dgvClientType.Name = "dgvClientType";
            this.dgvClientType.ReadOnly = true;
            this.dgvClientType.RowHeadersVisible = false;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Crimson;
            this.dgvClientType.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClientType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientType.Size = new System.Drawing.Size(187, 91);
            this.dgvClientType.TabIndex = 104;
            this.dgvClientType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientType_CellClick);
            this.dgvClientType.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientType_CellMouseClick);
            this.dgvClientType.SelectionChanged += new System.EventHandler(this.dgvClientType_SelectionChanged);
            // 
            // frmClientConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 318);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmClientConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.frmClientConfiguration_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActiveInactive;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pbClientImage;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvClientType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtClientDescription;
    }
}