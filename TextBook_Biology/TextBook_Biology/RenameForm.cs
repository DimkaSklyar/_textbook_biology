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
    public partial class RenameForm : Telerik.WinControls.UI.RadForm
    {
        string nameNode;
        string path = Application.StartupPath;
        TextBookForm textBookForm;
        public RenameForm(TextBookForm textBookForm, string nameNode)
        {
            InitializeComponent();
            this.nameNode = nameNode;
            this.textBookForm = textBookForm;
        }

        private void RenameForm_Shown(object sender, EventArgs e)
        {
            radTextBox1.Text = nameNode;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radTextBox1.Text != "")
            {
                string old_file = path + "\\" + textBookForm.nameTextbook + "\\" + nameNode + ".html";
                string new_file = path + "\\" + textBookForm.nameTextbook + "\\" + radTextBox1.Text + ".html";
                File.Move(old_file, new_file);
                FileInfo file = new FileInfo(old_file);
                if (file.Exists)
                {
                    file.Delete();
                }
                textBookForm.treeView.SelectedNode.Text = radTextBox1.Text;
                FileStream writer = new FileStream(Application.StartupPath + "\\" + textBookForm.nameTextbook + "\\tree.lst", FileMode.Create, FileAccess.Write);
                textBookForm.treeView.SaveXML(writer);
                writer.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Некоректное имя узла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
