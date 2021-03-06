﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextBook_Biology
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        AddTextbookForm addTextbook;
        string path = Application.StartupPath;
        TextBookForm textBookForm;
        AutorizationForm autorizationForm;
        internal bool SingInOn = false;
        public MainForm()
        {
            InitializeComponent();
            try
            {
                FileStream file = new FileStream(path + "\\listTextBook.lst", FileMode.CreateNew, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(file, Encoding.Default);
                for (int i = 0; i < listTextbook.Items.Count; i++)
                {
                    streamWriter.WriteLine(listTextbook.Items[i].ToString());
                }
                streamWriter.Close();
            }
            catch (Exception)
            {

            }

        }
        void saveList()
        {
            FileStream file = new FileStream(path + "\\listTextBook.lst", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(file, Encoding.Default);
            for (int i = 0; i < listTextbook.Items.Count; i++)
            {
                streamWriter.WriteLine(listTextbook.Items[i].ToString());
            }
            streamWriter.Close();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (addTextbook == null)
            {
                addTextbook = new AddTextbookForm(this);
                addTextbook.Show();
            }
            else if (addTextbook.IsDisposed)
            {
                AddTextbookForm addTextbook = new AddTextbookForm(this);
                addTextbook.Show();
            }
        }

        private void removeBotton_Click(object sender, EventArgs e)
        {

            var item = this.listTextbook.SelectedItem;
            if (item != null)
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотете удалить " + item.Text + "? Все страницы учебника будут удалены!", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(path + "\\" + item);
                        directoryInfo.Delete(true);
                        listTextbook.Items.Remove(item);
                    }
                    catch (Exception)
                    {
                        DialogResult res2 = MessageBox.Show("Выбранный учебник " + item.Text + ", был удалён или перенесён. Удалить выделеную строку?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (res2 == DialogResult.OK)
                        {
                            listTextbook.Items.Remove(item);
                        }
                    }
                    saveList();
                }
            }
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            listTextbook.Items.Clear();
            StreamReader streamReader = new StreamReader(path + "\\listTextBook.lst", Encoding.Default);
            while (!streamReader.EndOfStream)
            {
                listTextbook.Items.Add(streamReader.ReadLine());
            }
            streamReader.Close();
        }

        private void goButton_Click(object sender, EventArgs e)
        {

            //Не рабтает администрирование с первого раза!
            var item = this.listTextbook.SelectedItem;
            string nameTextbook="";
            if (textBookForm == null && item != null)
            {
                nameTextbook = item.Text;
                textBookForm = new TextBookForm(nameTextbook,this);
                textBookForm.Text = this.listTextbook.SelectedItem.Text;
                FileStream reader = new FileStream(path + "\\" + nameTextbook + "\\tree.lst", FileMode.OpenOrCreate);
                textBookForm.radMenuItem10.Enabled = SingInOn;
                reader.Close();
                textBookForm.Show();
            }
            else if (item != null && textBookForm.IsDisposed)
            {
                nameTextbook = item.Text;
                textBookForm = new TextBookForm(nameTextbook, this);
                textBookForm.Text = this.listTextbook.SelectedItem.Text;
                textBookForm.Show();
                textBookForm.radMenuItem10.Enabled = SingInOn;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Выберете один учебние из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

            if (autorizationForm == null)
            {
                autorizationForm = new AutorizationForm(this);
                autorizationForm.Show();
            }
            else if (autorizationForm.IsDisposed)
            {
                AutorizationForm autorizationForm = new AutorizationForm(this);
                autorizationForm.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            removeBotton.Enabled = false;
            SingInOn = false;
            exitButton.Visible = false;
            autorizationForm.sigInON = false;
        }
    }
}
