namespace TextBook_Biology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.listTextbook = new Telerik.WinControls.UI.RadListControl();
            this.addButton = new Telerik.WinControls.UI.RadButton();
            this.removeBotton = new Telerik.WinControls.UI.RadButton();
            this.settingsButton = new Telerik.WinControls.UI.RadButton();
            this.goButton = new Telerik.WinControls.UI.RadButton();
            this.exitButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.listTextbook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBotton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // listTextbook
            // 
            this.listTextbook.Location = new System.Drawing.Point(12, 12);
            this.listTextbook.Name = "listTextbook";
            this.listTextbook.Size = new System.Drawing.Size(338, 295);
            this.listTextbook.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(356, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(126, 24);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.ThemeName = "VisualStudio2012Light";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeBotton
            // 
            this.removeBotton.Enabled = false;
            this.removeBotton.Location = new System.Drawing.Point(356, 53);
            this.removeBotton.Name = "removeBotton";
            this.removeBotton.Size = new System.Drawing.Size(126, 24);
            this.removeBotton.TabIndex = 1;
            this.removeBotton.Text = "Удалить";
            this.removeBotton.ThemeName = "VisualStudio2012Light";
            this.removeBotton.Click += new System.EventHandler(this.removeBotton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(356, 94);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(126, 24);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Администрирование";
            this.settingsButton.ThemeName = "VisualStudio2012Light";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(356, 283);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(126, 24);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Открыть";
            this.goButton.ThemeName = "VisualStudio2012Light";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(356, 134);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(126, 24);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Выход";
            this.exitButton.ThemeName = "VisualStudio2012Light";
            this.exitButton.Visible = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 319);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.removeBotton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listTextbook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор учебника | Программа Учебник";
            this.ThemeName = "VisualStudio2012Light";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.listTextbook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBotton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadButton settingsButton;
        private Telerik.WinControls.UI.RadButton goButton;
        internal Telerik.WinControls.UI.RadListControl listTextbook;
        internal Telerik.WinControls.UI.RadButton addButton;
        internal Telerik.WinControls.UI.RadButton removeBotton;
        internal Telerik.WinControls.UI.RadButton exitButton;
    }
}