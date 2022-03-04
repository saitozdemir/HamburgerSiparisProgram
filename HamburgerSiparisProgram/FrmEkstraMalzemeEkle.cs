using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamburgerSiparisProgram
{
    public partial class FrmEkstraMalzemeEkle : Form
    {
        public FrmEkstraMalzemeEkle()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EkstraMalzemeler ekstra1 = new EkstraMalzemeler();
            ekstra1.EkstraMalzemelerAdi = txtEkstraAd.Text;
            ekstra1.EkstraMalzelerFiyati = Convert.ToDecimal(txtEkstraFiyat.Text);
            FrmSiparisOlustur.AddEkstra(ekstra1);
            MessageBox.Show("Ürün Başarıyla eklendi");
        }
    }
}
