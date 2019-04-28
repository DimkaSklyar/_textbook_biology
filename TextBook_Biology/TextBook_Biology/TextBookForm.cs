using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TextBook_Biology
{
    public partial class TextBookForm : Telerik.WinControls.UI.RadForm
    {
        internal string nameTextbook;
        string path = Application.StartupPath;
        public TextBookForm(string nameTextbook)
        {
            InitializeComponent();
            menuItemAdd.Click += MenuItemAdd_Click;
            menuItemRemove.Click += MenuItemRemove_Click;
            menuItemSubAdd.Click += MenuItemSubAdd_Click;
            menuItemRename.Click += MenuItemRename_Click;
            this.nameTextbook = nameTextbook;
        }

        private void MenuItemRename_Click(object sender, EventArgs e)
        {
            var item = treeView.SelectedNode;
            if (item != null)
            {
                RenameForm renameForm = new RenameForm(this,item.Text);
                renameForm.Show();
            }
        }

        private void MenuItemSubAdd_Click(object sender, EventArgs e)
        {
            AddParentNode addParentNode = new AddParentNode(this, false); //false - дочерний эелемент
            addParentNode.Show();
        }

        private void MenuItemRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите удалить страницу учебника: " + treeView.SelectedNode.Text + "?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                FileInfo file = new FileInfo(Application.StartupPath + "\\" + nameTextbook + "\\" + treeView.SelectedNode.Text + ".html");
                if (file.Exists)
                {
                    file.Delete();
                }
                treeView.SelectedNode.Remove();
                FileStream writer = new FileStream(Application.StartupPath + "\\" + nameTextbook + "\\tree.lst", FileMode.Create, FileAccess.Write);
                treeView.SaveXML(writer);
                writer.Close();
                
            }
        }

        private void MenuItemAdd_Click(object sender, EventArgs e)
        {
            AddParentNode addParentNode = new AddParentNode(this, true);   //true - дочерний эелемент
            addParentNode.Show();
            
        }

        private void radTreeView1_ContextMenuOpening(object sender, Telerik.WinControls.UI.TreeViewContextMenuOpeningEventArgs e)
        {
            radContextMenu1.Show();
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                radContextMenu1.Show(treeView, p);
            }
        }

        private void TextBookForm_Shown(object sender, EventArgs e)
        {
            FileStream reader = new FileStream(path + "\\"+nameTextbook+"\\tree.lst", FileMode.Open, FileAccess.Read);
            try
            {
                treeView.LoadXML(reader);
            }
            catch (Exception)
            {
                MessageBox.Show("Структура учебника повреждена или не существует! Если происходит создание нового учебника проигнорируете это сообщение, иначе обратитесь к Сестемному Администратору", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                treeView.Nodes.Clear();
            }
            
            reader.Close();
            treeView.SelectedNode = treeView.Nodes[0];
        }

        private void treeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            Uri uri = new Uri(path + "\\" + nameTextbook + "\\" + e.Node.Text + ".html");
            webBrowser1.Url = uri;
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
