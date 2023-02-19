using System.Windows.Forms;

namespace CuttingMachineGUI
{
    partial class MainPanel
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.MenuOptionsPanel = new System.Windows.Forms.Panel();
            this.SettingsBtn = new FontAwesome.Sharp.IconButton();
            this.DesignMakerBtn = new FontAwesome.Sharp.IconButton();
            this.DesignLoaderBtn = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ModelsBtn = new FontAwesome.Sharp.IconButton();
            this.ManualModeBtn = new FontAwesome.Sharp.IconButton();
            this.ESBtn = new FontAwesome.Sharp.IconButton();
            this.HomeBtn = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.MainPanelBtn = new FontAwesome.Sharp.IconButton();
            this.CurrentPanelLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.windowBtnsPanel = new System.Windows.Forms.Panel();
            this.MinimizeWdBtn = new FontAwesome.Sharp.IconButton();
            this.MaximizeWdBtn = new FontAwesome.Sharp.IconButton();
            this.CloseWindowBtn = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.BasePanel = new System.Windows.Forms.Panel();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.ChangueUserBtn = new System.Windows.Forms.Button();
            this.ChangePassBtn = new System.Windows.Forms.Button();
            this.UserBtn = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.MenuOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserIconPictureBox)).BeginInit();
            this.windowBtnsPanel.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.MenuOptionsPanel);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(214, 655);
            this.panelMenu.TabIndex = 0;
            // 
            // MenuOptionsPanel
            // 
            this.MenuOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MenuOptionsPanel.AutoScroll = true;
            this.MenuOptionsPanel.Controls.Add(this.SettingsBtn);
            this.MenuOptionsPanel.Controls.Add(this.DesignMakerBtn);
            this.MenuOptionsPanel.Controls.Add(this.DesignLoaderBtn);
            this.MenuOptionsPanel.Controls.Add(this.pictureBox1);
            this.MenuOptionsPanel.Controls.Add(this.ModelsBtn);
            this.MenuOptionsPanel.Controls.Add(this.ManualModeBtn);
            this.MenuOptionsPanel.Controls.Add(this.ESBtn);
            this.MenuOptionsPanel.Controls.Add(this.HomeBtn);
            this.MenuOptionsPanel.Location = new System.Drawing.Point(12, 106);
            this.MenuOptionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuOptionsPanel.Name = "MenuOptionsPanel";
            this.MenuOptionsPanel.Size = new System.Drawing.Size(200, 546);
            this.MenuOptionsPanel.TabIndex = 1;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsBtn.FlatAppearance.BorderSize = 0;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SettingsBtn.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.SettingsBtn.IconColor = System.Drawing.Color.White;
            this.SettingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsBtn.Location = new System.Drawing.Point(0, 360);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(200, 60);
            this.SettingsBtn.TabIndex = 16;
            this.SettingsBtn.Text = "Ajustes";
            this.SettingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // DesignMakerBtn
            // 
            this.DesignMakerBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DesignMakerBtn.FlatAppearance.BorderSize = 0;
            this.DesignMakerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DesignMakerBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesignMakerBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DesignMakerBtn.IconChar = FontAwesome.Sharp.IconChar.PencilRuler;
            this.DesignMakerBtn.IconColor = System.Drawing.Color.White;
            this.DesignMakerBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DesignMakerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignMakerBtn.Location = new System.Drawing.Point(0, 300);
            this.DesignMakerBtn.Name = "DesignMakerBtn";
            this.DesignMakerBtn.Size = new System.Drawing.Size(200, 60);
            this.DesignMakerBtn.TabIndex = 15;
            this.DesignMakerBtn.Text = "Diseñador";
            this.DesignMakerBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignMakerBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DesignMakerBtn.UseVisualStyleBackColor = true;
            this.DesignMakerBtn.Click += new System.EventHandler(this.DesignMakerBtn_Click);
            // 
            // DesignLoaderBtn
            // 
            this.DesignLoaderBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DesignLoaderBtn.FlatAppearance.BorderSize = 0;
            this.DesignLoaderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DesignLoaderBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesignLoaderBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DesignLoaderBtn.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.DesignLoaderBtn.IconColor = System.Drawing.Color.White;
            this.DesignLoaderBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DesignLoaderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignLoaderBtn.Location = new System.Drawing.Point(0, 240);
            this.DesignLoaderBtn.Name = "DesignLoaderBtn";
            this.DesignLoaderBtn.Size = new System.Drawing.Size(200, 60);
            this.DesignLoaderBtn.TabIndex = 13;
            this.DesignLoaderBtn.Text = "Cargar diseño";
            this.DesignLoaderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignLoaderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DesignLoaderBtn.UseVisualStyleBackColor = true;
            this.DesignLoaderBtn.Click += new System.EventHandler(this.DesignLoaderBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::CuttingMachineGUI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 452);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ModelsBtn
            // 
            this.ModelsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModelsBtn.FlatAppearance.BorderSize = 0;
            this.ModelsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModelsBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ModelsBtn.IconChar = FontAwesome.Sharp.IconChar.ToiletPaper;
            this.ModelsBtn.IconColor = System.Drawing.Color.White;
            this.ModelsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ModelsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModelsBtn.Location = new System.Drawing.Point(0, 180);
            this.ModelsBtn.Name = "ModelsBtn";
            this.ModelsBtn.Size = new System.Drawing.Size(200, 60);
            this.ModelsBtn.TabIndex = 9;
            this.ModelsBtn.Text = "Modelos";
            this.ModelsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModelsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ModelsBtn.UseVisualStyleBackColor = true;
            this.ModelsBtn.Click += new System.EventHandler(this.ModelsBtn_Click);
            // 
            // ManualModeBtn
            // 
            this.ManualModeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ManualModeBtn.FlatAppearance.BorderSize = 0;
            this.ManualModeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManualModeBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualModeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ManualModeBtn.IconChar = FontAwesome.Sharp.IconChar.HandPaper;
            this.ManualModeBtn.IconColor = System.Drawing.Color.White;
            this.ManualModeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ManualModeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ManualModeBtn.Location = new System.Drawing.Point(0, 120);
            this.ManualModeBtn.Name = "ManualModeBtn";
            this.ManualModeBtn.Size = new System.Drawing.Size(200, 60);
            this.ManualModeBtn.TabIndex = 7;
            this.ManualModeBtn.Text = "Control Manual";
            this.ManualModeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ManualModeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ManualModeBtn.UseVisualStyleBackColor = true;
            this.ManualModeBtn.Click += new System.EventHandler(this.ManualModeBtn_Click);
            // 
            // ESBtn
            // 
            this.ESBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ESBtn.FlatAppearance.BorderSize = 0;
            this.ESBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ESBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ESBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ESBtn.IconChar = FontAwesome.Sharp.IconChar.TrafficLight;
            this.ESBtn.IconColor = System.Drawing.Color.White;
            this.ESBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ESBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ESBtn.Location = new System.Drawing.Point(0, 60);
            this.ESBtn.Name = "ESBtn";
            this.ESBtn.Size = new System.Drawing.Size(200, 60);
            this.ESBtn.TabIndex = 6;
            this.ESBtn.Text = "E/S";
            this.ESBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ESBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ESBtn.UseVisualStyleBackColor = true;
            this.ESBtn.Click += new System.EventHandler(this.ESBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeBtn.FlatAppearance.BorderSize = 0;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HomeBtn.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.HomeBtn.IconColor = System.Drawing.Color.White;
            this.HomeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.HomeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeBtn.Location = new System.Drawing.Point(0, 0);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(200, 60);
            this.HomeBtn.TabIndex = 5;
            this.HomeBtn.Text = "Inicio";
            this.HomeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.MainPanelBtn);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(214, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // MainPanelBtn
            // 
            this.MainPanelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanelBtn.FlatAppearance.BorderSize = 0;
            this.MainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainPanelBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MainPanelBtn.IconChar = FontAwesome.Sharp.IconChar.Fan;
            this.MainPanelBtn.IconColor = System.Drawing.Color.Gray;
            this.MainPanelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MainPanelBtn.Location = new System.Drawing.Point(0, 0);
            this.MainPanelBtn.Name = "MainPanelBtn";
            this.MainPanelBtn.Size = new System.Drawing.Size(214, 100);
            this.MainPanelBtn.TabIndex = 6;
            this.MainPanelBtn.Text = "Estacion de corte";
            this.MainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MainPanelBtn.UseVisualStyleBackColor = true;
            this.MainPanelBtn.Click += new System.EventHandler(this.MainPanelBtn_Click);
            // 
            // CurrentPanelLbl
            // 
            this.CurrentPanelLbl.AutoSize = true;
            this.CurrentPanelLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPanelLbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.CurrentPanelLbl.Location = new System.Drawing.Point(18, 35);
            this.CurrentPanelLbl.Name = "CurrentPanelLbl";
            this.CurrentPanelLbl.Size = new System.Drawing.Size(90, 32);
            this.CurrentPanelLbl.TabIndex = 1;
            this.CurrentPanelLbl.Text = "Inicio";
            this.CurrentPanelLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CurrentPanelLbl_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(775, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 80);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UserIconPictureBox);
            this.panel2.Controls.Add(this.windowBtnsPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(-3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 80);
            this.panel2.TabIndex = 8;
            // 
            // UserIconPictureBox
            // 
            this.UserIconPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.UserIconPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserIconPictureBox.ForeColor = System.Drawing.Color.Indigo;
            this.UserIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.CircleUser;
            this.UserIconPictureBox.IconColor = System.Drawing.Color.Indigo;
            this.UserIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.UserIconPictureBox.IconSize = 51;
            this.UserIconPictureBox.Location = new System.Drawing.Point(0, 29);
            this.UserIconPictureBox.Name = "UserIconPictureBox";
            this.UserIconPictureBox.Size = new System.Drawing.Size(60, 51);
            this.UserIconPictureBox.TabIndex = 41;
            this.UserIconPictureBox.TabStop = false;
            // 
            // windowBtnsPanel
            // 
            this.windowBtnsPanel.Controls.Add(this.MinimizeWdBtn);
            this.windowBtnsPanel.Controls.Add(this.MaximizeWdBtn);
            this.windowBtnsPanel.Controls.Add(this.CloseWindowBtn);
            this.windowBtnsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBtnsPanel.Location = new System.Drawing.Point(0, 0);
            this.windowBtnsPanel.Name = "windowBtnsPanel";
            this.windowBtnsPanel.Size = new System.Drawing.Size(176, 29);
            this.windowBtnsPanel.TabIndex = 0;
            this.windowBtnsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowBtnsPanel_MouseDown);
            // 
            // MinimizeWdBtn
            // 
            this.MinimizeWdBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeWdBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeWdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeWdBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeWdBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MinimizeWdBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.MinimizeWdBtn.IconColor = System.Drawing.Color.White;
            this.MinimizeWdBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MinimizeWdBtn.IconSize = 18;
            this.MinimizeWdBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeWdBtn.Location = new System.Drawing.Point(49, 0);
            this.MinimizeWdBtn.Name = "MinimizeWdBtn";
            this.MinimizeWdBtn.Size = new System.Drawing.Size(47, 29);
            this.MinimizeWdBtn.TabIndex = 9;
            this.MinimizeWdBtn.Text = "\r\n";
            this.MinimizeWdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeWdBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MinimizeWdBtn.UseVisualStyleBackColor = true;
            this.MinimizeWdBtn.Click += new System.EventHandler(this.MinimizeWdBtn_Click);
            // 
            // MaximizeWdBtn
            // 
            this.MaximizeWdBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaximizeWdBtn.FlatAppearance.BorderSize = 0;
            this.MaximizeWdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeWdBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeWdBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MaximizeWdBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.MaximizeWdBtn.IconColor = System.Drawing.Color.White;
            this.MaximizeWdBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MaximizeWdBtn.IconSize = 20;
            this.MaximizeWdBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MaximizeWdBtn.Location = new System.Drawing.Point(96, 0);
            this.MaximizeWdBtn.Name = "MaximizeWdBtn";
            this.MaximizeWdBtn.Size = new System.Drawing.Size(39, 29);
            this.MaximizeWdBtn.TabIndex = 8;
            this.MaximizeWdBtn.Text = "\r\n";
            this.MaximizeWdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MaximizeWdBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MaximizeWdBtn.UseVisualStyleBackColor = true;
            this.MaximizeWdBtn.Click += new System.EventHandler(this.MaximizeWdBtn_Click);
            // 
            // CloseWindowBtn
            // 
            this.CloseWindowBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseWindowBtn.FlatAppearance.BorderSize = 0;
            this.CloseWindowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseWindowBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseWindowBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CloseWindowBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.CloseWindowBtn.IconColor = System.Drawing.Color.White;
            this.CloseWindowBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CloseWindowBtn.IconSize = 20;
            this.CloseWindowBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseWindowBtn.Location = new System.Drawing.Point(135, 0);
            this.CloseWindowBtn.Name = "CloseWindowBtn";
            this.CloseWindowBtn.Rotation = 90D;
            this.CloseWindowBtn.Size = new System.Drawing.Size(41, 29);
            this.CloseWindowBtn.TabIndex = 7;
            this.CloseWindowBtn.Text = "\r\n";
            this.CloseWindowBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseWindowBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CloseWindowBtn.UseVisualStyleBackColor = true;
            this.CloseWindowBtn.Click += new System.EventHandler(this.CloseWindowBtn_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.panel1);
            this.panelTitleBar.Controls.Add(this.CurrentPanelLbl);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(214, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(948, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // BasePanel
            // 
            this.BasePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(64)))));
            this.BasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasePanel.Location = new System.Drawing.Point(214, 80);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(948, 575);
            this.BasePanel.TabIndex = 2;
            // 
            // UserPanel
            // 
            this.UserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.UserPanel.Controls.Add(this.ChangueUserBtn);
            this.UserPanel.Controls.Add(this.ChangePassBtn);
            this.UserPanel.Controls.Add(this.UserBtn);
            this.UserPanel.Location = new System.Drawing.Point(1035, 29);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(124, 51);
            this.UserPanel.TabIndex = 43;
            // 
            // ChangueUserBtn
            // 
            this.ChangueUserBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(54)))));
            this.ChangueUserBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangueUserBtn.FlatAppearance.BorderSize = 0;
            this.ChangueUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangueUserBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangueUserBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.ChangueUserBtn.Location = new System.Drawing.Point(0, 110);
            this.ChangueUserBtn.Name = "ChangueUserBtn";
            this.ChangueUserBtn.Size = new System.Drawing.Size(124, 59);
            this.ChangueUserBtn.TabIndex = 18;
            this.ChangueUserBtn.Text = "Cambiar de usuario";
            this.ChangueUserBtn.UseVisualStyleBackColor = false;
            // 
            // ChangePassBtn
            // 
            this.ChangePassBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(54)))));
            this.ChangePassBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangePassBtn.FlatAppearance.BorderSize = 0;
            this.ChangePassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangePassBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.ChangePassBtn.Location = new System.Drawing.Point(0, 51);
            this.ChangePassBtn.Name = "ChangePassBtn";
            this.ChangePassBtn.Size = new System.Drawing.Size(124, 59);
            this.ChangePassBtn.TabIndex = 17;
            this.ChangePassBtn.Text = "Cambiar Contraseña";
            this.ChangePassBtn.UseVisualStyleBackColor = false;
            // 
            // UserBtn
            // 
            this.UserBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserBtn.FlatAppearance.BorderSize = 0;
            this.UserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserBtn.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            this.UserBtn.IconColor = System.Drawing.Color.White;
            this.UserBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.UserBtn.IconSize = 32;
            this.UserBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserBtn.Location = new System.Drawing.Point(0, 0);
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Size = new System.Drawing.Size(124, 51);
            this.UserBtn.TabIndex = 15;
            this.UserBtn.Text = "Operador";
            this.UserBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UserBtn.UseVisualStyleBackColor = true;
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1162, 655);
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.BasePanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainPanel";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPanel_KeyDown);

            this.panelMenu.ResumeLayout(false);
            this.MenuOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserIconPictureBox)).EndInit();
            this.windowBtnsPanel.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.UserPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel MenuOptionsPanel;
        private FontAwesome.Sharp.IconButton ManualModeBtn;
        private FontAwesome.Sharp.IconButton ESBtn;
        private FontAwesome.Sharp.IconButton HomeBtn;
        private FontAwesome.Sharp.IconButton ModelsBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton MainPanelBtn;
        private System.Windows.Forms.Label CurrentPanelLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconPictureBox UserIconPictureBox;
        private System.Windows.Forms.Panel windowBtnsPanel;
        private FontAwesome.Sharp.IconButton MinimizeWdBtn;
        private FontAwesome.Sharp.IconButton MaximizeWdBtn;
        private FontAwesome.Sharp.IconButton CloseWindowBtn;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel BasePanel;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Button ChangueUserBtn;
        private System.Windows.Forms.Button ChangePassBtn;
        private FontAwesome.Sharp.IconButton UserBtn;
        private FontAwesome.Sharp.IconButton DesignLoaderBtn;
        private FontAwesome.Sharp.IconButton SettingsBtn;
        private FontAwesome.Sharp.IconButton DesignMakerBtn;
    }
}

