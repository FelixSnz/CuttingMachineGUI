namespace CuttingMachineGUI.Popups
{
    partial class CanvasSettings
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.MarginTxtBox = new System.Windows.Forms.TextBox();
            this.SeparationTxtBox = new System.Windows.Forms.TextBox();
            this.SurfaceWidthTxtBox = new System.Windows.Forms.TextBox();
            this.SurfaceHeightTxtBox = new System.Windows.Forms.TextBox();
            this.ClothHeightTxtBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SaveDesign = new FontAwesome.Sharp.IconButton();
            this.CancelBtn = new FontAwesome.Sharp.IconButton();
            this.InchesCheckBox = new System.Windows.Forms.CheckBox();
            this.MillimetersCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WindowTitleLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBtn = new FontAwesome.Sharp.IconButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MarginTxtBox);
            this.panel2.Controls.Add(this.SeparationTxtBox);
            this.panel2.Controls.Add(this.SurfaceWidthTxtBox);
            this.panel2.Controls.Add(this.SurfaceHeightTxtBox);
            this.panel2.Controls.Add(this.ClothHeightTxtBox);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(803, 540);
            this.panel2.TabIndex = 1;
            // 
            // MarginTxtBox
            // 
            this.MarginTxtBox.Location = new System.Drawing.Point(135, 8);
            this.MarginTxtBox.MaxLength = 8;
            this.MarginTxtBox.Name = "MarginTxtBox";
            this.MarginTxtBox.Size = new System.Drawing.Size(100, 22);
            this.MarginTxtBox.TabIndex = 6;
            this.MarginTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleFilter);
            // 
            // SeparationTxtBox
            // 
            this.SeparationTxtBox.Location = new System.Drawing.Point(185, 141);
            this.SeparationTxtBox.MaxLength = 8;
            this.SeparationTxtBox.Name = "SeparationTxtBox";
            this.SeparationTxtBox.Size = new System.Drawing.Size(100, 22);
            this.SeparationTxtBox.TabIndex = 5;
            this.SeparationTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleFilter);
            // 
            // SurfaceWidthTxtBox
            // 
            this.SurfaceWidthTxtBox.Location = new System.Drawing.Point(240, 388);
            this.SurfaceWidthTxtBox.MaxLength = 8;
            this.SurfaceWidthTxtBox.Name = "SurfaceWidthTxtBox";
            this.SurfaceWidthTxtBox.Size = new System.Drawing.Size(100, 22);
            this.SurfaceWidthTxtBox.TabIndex = 4;
            this.SurfaceWidthTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleFilter);
            // 
            // SurfaceHeightTxtBox
            // 
            this.SurfaceHeightTxtBox.Location = new System.Drawing.Point(494, 238);
            this.SurfaceHeightTxtBox.MaxLength = 8;
            this.SurfaceHeightTxtBox.Name = "SurfaceHeightTxtBox";
            this.SurfaceHeightTxtBox.Size = new System.Drawing.Size(100, 22);
            this.SurfaceHeightTxtBox.TabIndex = 3;
            this.SurfaceHeightTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleFilter);
            // 
            // ClothHeightTxtBox
            // 
            this.ClothHeightTxtBox.Location = new System.Drawing.Point(575, 73);
            this.ClothHeightTxtBox.MaxLength = 8;
            this.ClothHeightTxtBox.Name = "ClothHeightTxtBox";
            this.ClothHeightTxtBox.Size = new System.Drawing.Size(100, 22);
            this.ClothHeightTxtBox.TabIndex = 2;
            this.ClothHeightTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DoubleFilter);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SaveDesign);
            this.panel3.Controls.Add(this.CancelBtn);
            this.panel3.Controls.Add(this.InchesCheckBox);
            this.panel3.Controls.Add(this.MillimetersCheckBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 452);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(793, 83);
            this.panel3.TabIndex = 1;
            // 
            // SaveDesign
            // 
            this.SaveDesign.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveDesign.FlatAppearance.BorderSize = 0;
            this.SaveDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDesign.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDesign.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveDesign.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.SaveDesign.IconColor = System.Drawing.Color.White;
            this.SaveDesign.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SaveDesign.Location = new System.Drawing.Point(651, 10);
            this.SaveDesign.Name = "SaveDesign";
            this.SaveDesign.Size = new System.Drawing.Size(66, 63);
            this.SaveDesign.TabIndex = 20;
            this.SaveDesign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveDesign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveDesign.UseVisualStyleBackColor = true;
            this.SaveDesign.Click += new System.EventHandler(this.SaveDesign_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.CancelBtn.IconColor = System.Drawing.Color.White;
            this.CancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CancelBtn.IconSize = 38;
            this.CancelBtn.Location = new System.Drawing.Point(717, 10);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(66, 63);
            this.CancelBtn.TabIndex = 19;
            this.CancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // InchesCheckBox
            // 
            this.InchesCheckBox.AutoSize = true;
            this.InchesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InchesCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.InchesCheckBox.Location = new System.Drawing.Point(83, 43);
            this.InchesCheckBox.Name = "InchesCheckBox";
            this.InchesCheckBox.Size = new System.Drawing.Size(107, 26);
            this.InchesCheckBox.TabIndex = 1;
            this.InchesCheckBox.Text = "Pulgadas";
            this.InchesCheckBox.UseVisualStyleBackColor = true;
            this.InchesCheckBox.CheckedChanged += new System.EventHandler(this.InchesCheckBox_CheckedChanged);
            // 
            // MillimetersCheckBox
            // 
            this.MillimetersCheckBox.AutoSize = true;
            this.MillimetersCheckBox.Checked = true;
            this.MillimetersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MillimetersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MillimetersCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.MillimetersCheckBox.Location = new System.Drawing.Point(83, 11);
            this.MillimetersCheckBox.Name = "MillimetersCheckBox";
            this.MillimetersCheckBox.Size = new System.Drawing.Size(112, 26);
            this.MillimetersCheckBox.TabIndex = 0;
            this.MillimetersCheckBox.Text = "Milimetros";
            this.MillimetersCheckBox.UseVisualStyleBackColor = true;
            this.MillimetersCheckBox.CheckedChanged += new System.EventHandler(this.MillimetersCheckBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CuttingMachineGUI.Properties.Resources.CanvasSettings;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(793, 451);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WindowTitleLbl
            // 
            this.WindowTitleLbl.AutoSize = true;
            this.WindowTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowTitleLbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.WindowTitleLbl.Location = new System.Drawing.Point(35, 3);
            this.WindowTitleLbl.Name = "WindowTitleLbl";
            this.WindowTitleLbl.Size = new System.Drawing.Size(298, 29);
            this.WindowTitleLbl.TabIndex = 0;
            this.WindowTitleLbl.Text = "Configuracion de diseño";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.WindowTitleLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 37);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CloseBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.CloseBtn.IconColor = System.Drawing.Color.White;
            this.CloseBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CloseBtn.IconSize = 30;
            this.CloseBtn.Location = new System.Drawing.Point(737, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Rotation = 90D;
            this.CloseBtn.Size = new System.Drawing.Size(66, 37);
            this.CloseBtn.TabIndex = 20;
            this.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // CanvasSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(803, 577);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CanvasSettings";
            this.Text = "CanvasSettings";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox MarginTxtBox;
        private System.Windows.Forms.TextBox SeparationTxtBox;
        private System.Windows.Forms.TextBox SurfaceWidthTxtBox;
        private System.Windows.Forms.TextBox SurfaceHeightTxtBox;
        private System.Windows.Forms.TextBox ClothHeightTxtBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox InchesCheckBox;
        private System.Windows.Forms.CheckBox MillimetersCheckBox;
        private FontAwesome.Sharp.IconButton SaveDesign;
        private FontAwesome.Sharp.IconButton CancelBtn;
        private System.Windows.Forms.Label WindowTitleLbl;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton CloseBtn;
    }
}