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
        //Копирование папки со всеми вложениями
        void CopyDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
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
            if (flag)
            {
                bookForm.treeView.Nodes.Add(radTextBox1.Text);
                File.Copy(radTextBox2.Text, Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + radTextBox1.Text + ".html");

                    try
                    {
                        CopyDir(radTextBox2.Text.Substring(0, radTextBox2.Text.Length - 4) + "files", Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.Length - 4) + "files");
                    }
                    catch (Exception)
                    {

                    }
                    
                    FileStream fileClose = new FileStream(Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + radTextBox1.Text + ".html", FileMode.Open);
                    fileClose.Close();
                
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
                    File.Copy(radTextBox2.Text, Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + radTextBox1.Text + ".html");

                    try
                    {
                            CopyDir(radTextBox2.Text.Substring(0, radTextBox2.Text.Length - 4) + "files", Application.StartupPath + "\\" + bookForm.nameTextbook + "\\" + openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.Length - 4) + "files");
                        }
                        catch (Exception)
                        {

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

        private void AddParentNode_Shown(object sender, EventArgs e)
        {
            if (flag)
            {
                Text = "Добвить родительский узел";
                label1.Text = "Имя родительского узла:";
            }
            else
            {
                Text = "Добвить вложенный узел";
                label1.Text = "Имя вложенного узла:";
            }
        }
    }
}
