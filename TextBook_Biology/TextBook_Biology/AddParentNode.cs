using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Telerik.WinControls.UI;

namespace TextBook_Biology
{
    public partial class AddParentNode : Telerik.WinControls.UI.RadForm
    {
        TextBookForm bookForm;
        bool flag;
        public AddParentNode(TextBookForm bookForm, bool flag)
        {
            InitializeComponent();
            this.bookForm = bookForm;
            this.flag = flag;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            radTextBox2.Text = openFileDialog1.FileName;
        }

        private void radTextBox2_Validated(object sender, EventArgs e)
        {

        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (radTextBox1.Text != "" && radTextBox2.Text != "")
            {
                radButton1.Enabled = true;
            }
            else
            {
                radButton1.Enabled = false;
            }
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (radTextBox1.Text != "" && radTextBox2.Text != "")
            {
                radButton1.Enabled = true;
            }
            else
            {
                radButton1.Enabled = false;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //var selectNode = treeView.SelectedNode;
            //if (selectNode != null)
            //{
            //    treeView.SelectedNode.Nodes.Add("Новый");
            //}
            //else
            //{
            //}
            if (flag)
            {
                bookForm.treeView.Nodes.Add(radTextBox1.Text);
                FileInfo file = new FileInfo(radTextBox2.Text);
                if (file.Exists)
                {
                    file.CopyTo(Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + radTextBox1.Text + ".html");
                }
                FileStream writer = new FileStream(Application.StartupPath + "\\" + bookForm.nameTextbook + "\\tree.lst", FileMode.Create, FileAccess.Write);
                bookForm.treeView.SaveXML(writer);
                writer.Close();
                this.Close();
            }
            else
            {
                var selectNode = bookForm.treeView.SelectedNode;
                if (selectNode != null)
                {
                    bookForm.treeView.SelectedNode.Nodes.Add(radTextBox1.Text);
                    FileInfo file = new FileInfo(radTextBox2.Text);
                    if (file.Exists)
                    {
                        file.CopyTo(Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + radTextBox1.Text + ".html");
                    }
                    FileStream writer = new FileStream(Application.StartupPath + "\\" + bookForm.nameTextbook + "\\tree.lst", FileMode.Create, FileAccess.Write);
                    bookForm.treeView.SaveXML(writer);
                    writer.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не выбран родительский элемент, добавление дочернего невозможно! Пожалуйста выберете родительский узел!");
                    this.Close();
                }
                
            }
            
        }
    }
}
