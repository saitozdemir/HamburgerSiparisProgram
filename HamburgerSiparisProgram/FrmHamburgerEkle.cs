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
    public partial class FrmHamburgerEkle : Form
    {
        public FrmHamburgerEkle()
        {
            InitializeComponent();
        }

        
        private void FrmHamburgerEkle_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEkle_MouseClick(object sender, MouseEventArgs e)
        {
            Menu menu1 = new Menu();
            menu1.MenuAdi = txtMenuAd.Text;
            menu1.MenuFiyati = Convert.ToDecimal(txtMenuFiyat.Text);
            FrmSiparisOlustur.AddMenu(menu1);
            MessageBox.Show("Ürün Başarıyla eklendi");



        }
    }
}
