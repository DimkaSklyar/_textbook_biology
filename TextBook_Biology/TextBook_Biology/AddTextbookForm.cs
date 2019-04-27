using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace TextBook_Biology
{
    public partial class AddTextbookForm : Telerik.WinControls.UI.RadForm
    {
        MainForm mainForm;
        string path = Application.StartupPath;
        public AddTextbookForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        void addTextbook()
        {
            if (nameTextbookTextBox.Text != "")
            {
                mainForm.listTextbook.Items.Add(nameTextbookTextBox.Text);
                FileStream file = new FileStream(path + "\\listTextBook.lst", FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(file, Encoding.Default);
                for (int i = 0; i < mainForm.listTextbook.Items.Count; i++)
                {
                    streamWriter.WriteLine(mainForm.listTextbook.Items[i].ToString());
                }
                streamWriter.Close();
                Directory.CreateDirectory(path + "\\" + nameTextbookTextBox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите имя добавляемого учебника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            addTextbook();
        }

        private void nameTextbookTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                addTextbook();
            }
        }
    }
}
