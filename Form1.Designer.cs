namespace Golf2019
{
    partial class Form1
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
            this.btn1 = new System.Windows.Forms.Button();
            this.LvGolf = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Firstname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Surname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DOB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Street = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Suburb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Available = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Handicap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(61, 49);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(163, 87);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Load Data";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // LvGolf
            // 
            this.LvGolf.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Firstname,
            this.Surname,
            this.Gender,
            this.DOB,
            this.Street,
            this.Suburb,
            this.City,
            this.Available,
            this.Handicap});
            this.LvGolf.Location = new System.Drawing.Point(276, 49);
            this.LvGolf.Name = "LvGolf";
            this.LvGolf.Size = new System.Drawing.Size(712, 389);
            this.LvGolf.TabIndex = 1;
            this.LvGolf.UseCompatibleStateImageBehavior = false;
            this.LvGolf.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // Firstname
            // 
            this.Firstname.Text = "Firstname";
            // 
            // Surname
            // 
            this.Surname.Text = "Surname";
            // 
            // Gender
            // 
            this.Gender.Text = "Gender";
            // 
            // DOB
            // 
            this.DOB.Text = "DOB";
            // 
            // Street
            // 
            this.Street.Text = "Street";
            // 
            // Suburb
            // 
            this.Suburb.Text = "Suburb";
            // 
            // City
            // 
            this.City.Text = "City";
            // 
            // Available
            // 
            this.Available.Text = "Available";
            // 
            // Handicap
            // 
            this.Handicap.Text = "Handicap";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 450);
            this.Controls.Add(this.LvGolf);
            this.Controls.Add(this.btn1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.ListView LvGolf;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Firstname;
        private System.Windows.Forms.ColumnHeader Surname;
        private System.Windows.Forms.ColumnHeader Gender;
        private System.Windows.Forms.ColumnHeader DOB;
        private System.Windows.Forms.ColumnHeader Street;
        private System.Windows.Forms.ColumnHeader Suburb;
        private System.Windows.Forms.ColumnHeader City;
        private System.Windows.Forms.ColumnHeader Available;
        private System.Windows.Forms.ColumnHeader Handicap;
    }
}

