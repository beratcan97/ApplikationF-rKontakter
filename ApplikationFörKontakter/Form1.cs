using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using MigrationsDemo;

namespace ApplikationFörKontakter
{                                                                                                               
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            uppdatelist();

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void uppdatelist()
        {

            listBox1.Items.Clear();
            using (var context = new BlogContext())
            {
                foreach (var item in context.person)
                {
                    listBox1.Items.Add(item);
                }

            }
        }
        private void btnAvsluta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLäggtill_Click(object sender, EventArgs e)
        {
            var id = Guid.NewGuid();

            // insert
            using (var db = new BlogContext())
            {
                var customers = db.Set<person>();
                customers.Add(new person { namn = txtNamn.Text, gatuadress = txtGatuadress.Text, postnummer = txtPostnummer.Text, postort = txtPostort.Text, telefon = txtTelefon.Text, epost = txtEpost.Text, födelsedag = txtFödelsedatum.Text });

                db.SaveChanges();
            }

            uppdatelist();
        }

        private void btnTabort_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var valdaanvändaren = listBox1.SelectedItem;

                var toBeRemoved = listBox1.SelectedItem;

                using (var db = new BlogContext())
                {
                    db.Entry(toBeRemoved).State = EntityState.Deleted;

                    db.SaveChanges();
                }
                uppdatelist();
            }
            else
                MessageBox.Show("Välj en användare!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedItem = (person)listBox1.SelectedItem;

                txtNamn.Text = selectedItem.namn;
                txtGatuadress.Text = selectedItem.gatuadress;
                txtPostnummer.Text = selectedItem.postnummer;
                txtPostort.Text = selectedItem.postort;
                txtTelefon.Text = selectedItem.telefon;
                txtEpost.Text = selectedItem.epost;
                txtFödelsedatum.Text = selectedItem.födelsedag;
            }
        }

        private void btnSök_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (var db = new BlogContext())
                {

                    string search = textBox1.Text;
                    var hittadekontakter = from kontakter in db.person
                                           where (kontakter.namn.Contains(search))
                                           select kontakter;

                    listBox1.Items.Clear();

                    foreach (var contact in hittadekontakter)
                    {
                        listBox1.Items.Add(contact);
                    }
                }
            }
            else
            {
                MessageBox.Show("Skriv in det ord som ska sökas i text rutan");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //Tabort 
                var valdaanvändaren = listBox1.SelectedItem;
                var toBeRemoved = listBox1.SelectedItem;
                using (var db = new BlogContext())
                {
                    db.Entry(toBeRemoved).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                uppdatelist();

                //Spara den nya
                var id = Guid.NewGuid();
                using (var db = new BlogContext())
                {
                    var customers = db.Set<person>();
                    customers.Add(new person { namn = txtNamn.Text, gatuadress = txtGatuadress.Text, postnummer = txtPostnummer.Text, postort = txtPostort.Text, telefon = txtTelefon.Text, epost = txtEpost.Text, födelsedag = txtFödelsedatum.Text });
                    db.SaveChanges();
                }
                uppdatelist();
            }
            else
                MessageBox.Show("Välj en användare!");
        }
    }
}