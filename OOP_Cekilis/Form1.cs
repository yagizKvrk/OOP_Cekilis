using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Cekilis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Kisi> Kisiler = new List<Kisi>();
        private void Form1_Load(object sender, EventArgs e)
        {
            KisiVarMi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kisi k = new Kisi();
            k.Ad = textBox1.Text;
            k.Soyad = textBox2.Text;
            k.TcNo = textBox3.Text;
            k.TelNo = maskedTextBox1.Text;
            k.Id = Guid.NewGuid();
            Kisiler.Add(k);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Kisiler;
            dataGridView1.Columns[4].Visible = false;
        }

        //Kullanıcının bilgilerinin girildiği ve silinebilidği(tuş ile // delete) bir çekiliş arayüzü oluşturunuz.
        //her kişi eşsiz olsun(unique)
        //dataGridView kullanın kişileri listelemek için (kolaylık)
        //En son projemi kapatıp tekrar açtığımda halihazırda kayıtlı olan isimler tekrar yüklensin. Eğer değişiklik yaparsam değiştirilmiş hali ile gelsin(Form load da nesneleri oluşturmayacağız ve yüklemeyeceğiz)
        private void KisiVarMi()
        {
            if (dataGridView1.DataSource == null)
                btnCekilisYap.Enabled = false;
            else
                btnCekilisYap.Enabled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            KisiVarMi();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
            {
                Kisi silinecekKisi = (Kisi)dataGridView1.SelectedRows[0].DataBoundItem;
                Kisiler.Remove(silinecekKisi);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Kisiler;
            }
        }

        private void btnCekilisYap_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int Talihli = rnd.Next(0, Kisiler.Count);
            lblKazanan.Text = Kisiler[Talihli].Ad + " " + Kisiler[Talihli].Soyad + " " + Kisiler[Talihli].TcNo;
            lblKazanan.BorderStyle = BorderStyle.FixedSingle;
            lblKazanan.BackColor = SystemColors.Info;
            this.BackColor = Color.Turquoise;
        }
    }
}
