namespace parks
{
    partial class MainForm
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
            this.loadButton = new System.Windows.Forms.Button();
            this.customizeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editButton = new System.Windows.Forms.Button();
            this.notesButton = new System.Windows.Forms.Button();
            this.QueryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.loadButton.Location = new System.Drawing.Point(439, 290);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(112, 25);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load Data";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // customizeButton
            // 
            this.customizeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.customizeButton.Location = new System.Drawing.Point(439, 338);
            this.customizeButton.Name = "customizeButton";
            this.customizeButton.Size = new System.Drawing.Size(112, 25);
            this.customizeButton.TabIndex = 4;
            this.customizeButton.Text = "Customize";
            this.customizeButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::parks.Properties.Resources.matrix;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(22, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 290);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.notesButton);
            this.panel1.Controls.Add(this.QueryButton);
            this.panel1.Location = new System.Drawing.Point(414, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 186);
            this.panel1.TabIndex = 5;
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.editButton.Location = new System.Drawing.Point(25, 75);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(112, 33);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit Data";
            this.editButton.UseVisualStyleBackColor = false;
            // 
            // notesButton
            // 
            this.notesButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.notesButton.Location = new System.Drawing.Point(25, 133);
            this.notesButton.Name = "notesButton";
            this.notesButton.Size = new System.Drawing.Size(112, 33);
            this.notesButton.TabIndex = 2;
            this.notesButton.Text = "Add Notes";
            this.notesButton.UseVisualStyleBackColor = false;
            // 
            // QueryButton
            // 
            this.QueryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.QueryButton.Location = new System.Drawing.Point(25, 17);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(112, 33);
            this.QueryButton.TabIndex = 1;
            this.QueryButton.Text = "Charts and Graphs";
            this.QueryButton.UseVisualStyleBackColor = false;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(411, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataBase Queries";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(648, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customizeButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loadButton);
            this.Name = "MainForm";
            this.Text = "Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button customizeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button notesButton;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.Label label1;
    }
}