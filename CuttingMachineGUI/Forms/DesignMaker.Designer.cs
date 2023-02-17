namespace CuttingMachineGUI.Forms
{
    partial class DesignMaker
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearBtn = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SaveDesignBtn = new FontAwesome.Sharp.IconButton();
            this.DesignSettingsBtn = new FontAwesome.Sharp.IconButton();
            this.MatrixCutBtn = new FontAwesome.Sharp.IconButton();
            this.SingleCutBtn = new FontAwesome.Sharp.IconButton();
            this.BgPanel = new System.Windows.Forms.Panel();
            this.FabricPanel = new System.Windows.Forms.Panel();
            this.figureMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rotarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redimensionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.BgPanel.SuspendLayout();
            this.figureMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ClearBtn);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.SaveDesignBtn);
            this.panel1.Controls.Add(this.DesignSettingsBtn);
            this.panel1.Controls.Add(this.MatrixCutBtn);
            this.panel1.Controls.Add(this.SingleCutBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(237, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 27);
            this.label1.TabIndex = 22;
            this.label1.Text = "SinTitulo.json";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClearBtn.FlatAppearance.BorderSize = 0;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearBtn.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.ClearBtn.IconColor = System.Drawing.Color.White;
            this.ClearBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ClearBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearBtn.Location = new System.Drawing.Point(173, 0);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(58, 80);
            this.ClearBtn.TabIndex = 21;
            this.ClearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(115, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(58, 80);
            this.iconButton2.TabIndex = 20;
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.File;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(941, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(66, 80);
            this.iconButton1.TabIndex = 19;
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // SaveDesignBtn
            // 
            this.SaveDesignBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveDesignBtn.FlatAppearance.BorderSize = 0;
            this.SaveDesignBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDesignBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDesignBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveDesignBtn.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.SaveDesignBtn.IconColor = System.Drawing.Color.White;
            this.SaveDesignBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SaveDesignBtn.Location = new System.Drawing.Point(1007, 0);
            this.SaveDesignBtn.Name = "SaveDesignBtn";
            this.SaveDesignBtn.Size = new System.Drawing.Size(66, 80);
            this.SaveDesignBtn.TabIndex = 18;
            this.SaveDesignBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveDesignBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveDesignBtn.UseVisualStyleBackColor = true;
            // 
            // DesignSettingsBtn
            // 
            this.DesignSettingsBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DesignSettingsBtn.FlatAppearance.BorderSize = 0;
            this.DesignSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DesignSettingsBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesignSettingsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DesignSettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.DesignSettingsBtn.IconColor = System.Drawing.Color.White;
            this.DesignSettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DesignSettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignSettingsBtn.Location = new System.Drawing.Point(1073, 0);
            this.DesignSettingsBtn.Name = "DesignSettingsBtn";
            this.DesignSettingsBtn.Size = new System.Drawing.Size(58, 80);
            this.DesignSettingsBtn.TabIndex = 17;
            this.DesignSettingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignSettingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DesignSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // MatrixCutBtn
            // 
            this.MatrixCutBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.MatrixCutBtn.FlatAppearance.BorderSize = 0;
            this.MatrixCutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MatrixCutBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatrixCutBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MatrixCutBtn.IconChar = FontAwesome.Sharp.IconChar.Microsoft;
            this.MatrixCutBtn.IconColor = System.Drawing.Color.White;
            this.MatrixCutBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MatrixCutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MatrixCutBtn.Location = new System.Drawing.Point(57, 0);
            this.MatrixCutBtn.Name = "MatrixCutBtn";
            this.MatrixCutBtn.Size = new System.Drawing.Size(58, 80);
            this.MatrixCutBtn.TabIndex = 15;
            this.MatrixCutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MatrixCutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MatrixCutBtn.UseVisualStyleBackColor = true;
            // 
            // SingleCutBtn
            // 
            this.SingleCutBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.SingleCutBtn.FlatAppearance.BorderSize = 0;
            this.SingleCutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SingleCutBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleCutBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SingleCutBtn.IconChar = FontAwesome.Sharp.IconChar.SquareFull;
            this.SingleCutBtn.IconColor = System.Drawing.Color.White;
            this.SingleCutBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SingleCutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SingleCutBtn.Location = new System.Drawing.Point(0, 0);
            this.SingleCutBtn.Name = "SingleCutBtn";
            this.SingleCutBtn.Size = new System.Drawing.Size(57, 80);
            this.SingleCutBtn.TabIndex = 14;
            this.SingleCutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SingleCutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SingleCutBtn.UseVisualStyleBackColor = true;
            this.SingleCutBtn.Click += new System.EventHandler(this.SingleCutBtn_Click);
            // 
            // BgPanel
            // 
            this.BgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.BgPanel.Controls.Add(this.FabricPanel);
            this.BgPanel.Location = new System.Drawing.Point(12, 86);
            this.BgPanel.Name = "BgPanel";
            this.BgPanel.Size = new System.Drawing.Size(1107, 481);
            this.BgPanel.TabIndex = 1;
            this.BgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BgPanel_Paint);
            // 
            // FabricPanel
            // 
            this.FabricPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FabricPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.FabricPanel.Location = new System.Drawing.Point(3, 160);
            this.FabricPanel.Name = "FabricPanel";
            this.FabricPanel.Size = new System.Drawing.Size(724, 318);
            this.FabricPanel.TabIndex = 4;
            this.FabricPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FabricPanel_Paint);
            this.FabricPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FabricPanel_MouseClick);
            this.FabricPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FabricPanel_MouseDown);
            this.FabricPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FabricPanel_MouseMove);
            this.FabricPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FabricPanel_MouseUp);
            // 
            // figureMenuStrip
            // 
            this.figureMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.figureMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotarToolStripMenuItem,
            this.redimensionarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.figureMenuStrip.Name = "figureMenuStrip";
            this.figureMenuStrip.Size = new System.Drawing.Size(211, 104);
            // 
            // rotarToolStripMenuItem
            // 
            this.rotarToolStripMenuItem.Name = "rotarToolStripMenuItem";
            this.rotarToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.rotarToolStripMenuItem.Text = "rotar";
            this.rotarToolStripMenuItem.Click += new System.EventHandler(this.rotarToolStripMenuItem_Click);
            // 
            // redimensionarToolStripMenuItem
            // 
            this.redimensionarToolStripMenuItem.Name = "redimensionarToolStripMenuItem";
            this.redimensionarToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.redimensionarToolStripMenuItem.Text = "redimensionar";
            this.redimensionarToolStripMenuItem.Click += new System.EventHandler(this.redimensionarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.eliminarToolStripMenuItem.Text = "eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // DesignMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1131, 730);
            this.Controls.Add(this.BgPanel);
            this.Controls.Add(this.panel1);
            this.Name = "DesignMaker";
            this.Text = "Panel de Diseñador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.BgPanel.ResumeLayout(false);
            this.figureMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton DesignSettingsBtn;
        private FontAwesome.Sharp.IconButton MatrixCutBtn;
        private FontAwesome.Sharp.IconButton SingleCutBtn;
        private System.Windows.Forms.Panel BgPanel;
        private System.Windows.Forms.Panel FabricPanel;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton SaveDesignBtn;
        private FontAwesome.Sharp.IconButton ClearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip figureMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rotarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redimensionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}