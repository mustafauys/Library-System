using KutuphaneSistemi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Kitap _kitap = new Kitap();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSil.Enabled = false;
            Yukle();
            
        }

        private void Yukle(string ara = "")
        {
            if (ara == "")
            {
                dtgList.DataSource = _kitap.Get();
            }
            else
            {
                dtgList.DataSource = _kitap.Get(ara);
            }
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Güncelle")
            {
                _kitap.Id = Convert.ToInt32(dtgList.CurrentRow.Cells[0].Value);
                _kitap.Ad = txtAd.Text;
                _kitap.Detay = txtDetay.Text;
                _kitap.Yazar = txtYazar.Text;
                _kitap.YayınEvi = txtYayin.Text;

                _kitap.Guncelle(_kitap);
                Yukle();
                MessageBox.Show("Kurs Güncellendi");
            }
            else
            {
                _kitap.Ad = txtAd.Text;
                _kitap.Detay = txtDetay.Text;
                _kitap.Yazar = txtYazar.Text;
                _kitap.YayınEvi = txtYayin.Text;

                _kitap.Kaydet(_kitap);
                Yukle();
                MessageBox.Show("Yeni Kitap Eklendi");
            }
        }

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgList.ClearSelection();
            btnKaydet.Text = "Güncelle";
            btnSil.Enabled = true;


            txtAd.Text = dtgList.CurrentRow.Cells[1].Value.ToString();
            txtDetay.Text = dtgList.CurrentRow.Cells[2].Value.ToString();
            txtYazar.Text = dtgList.CurrentRow.Cells[3].Value.ToString();
            txtYayin.Text = dtgList.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _kitap.Id = Convert.ToInt32(dtgList.CurrentRow.Cells[0].Value);
            _kitap.Sil(_kitap);
            Yukle();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnTemiz_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtAd.Text = txtDetay.Text = txtYazar.Text = txtYayin.Text = "";
            btnSil.Enabled = false;
            btnKaydet.Text = "Kaydet";
            dtgList.ClearSelection();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            Yukle(txtAra.Text);
        }
    }
}
