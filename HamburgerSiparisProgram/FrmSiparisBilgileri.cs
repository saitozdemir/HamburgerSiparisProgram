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
    public partial class FrmSiparisBilgileri : Form
    {
        public FrmSiparisBilgileri()
        {
            InitializeComponent();
        }

        private void FrmSiparisBilgileri_Load(object sender, EventArgs e)
        {
            Decimal Ciro = 0;
            decimal EkstraMalzemeGeliri = 0;
            int SatisAdedi = 0;
            foreach (Siparis item in FrmSiparisOlustur.Siparisler)
            {               
                Ciro += item.SiparisTutari;  
                
                foreach(EkstraMalzemeler ekstra in item.SecilenEkstraMalzemeler)
                {
                    EkstraMalzemeGeliri += ekstra.EkstraMalzelerFiyati;
                }
                SatisAdedi += item.SecilenMenuAdedi;
                lstTumSiparisler.Items.Add(item);
            }  
            
            lblCiro.Text =Ciro.ToString("C2");
            lblSiparsSayısı.Text=Convert.ToString(FrmSiparisOlustur.Siparisler.Count);
            lblEkstraMalzemeGeliri.Text =(EkstraMalzemeGeliri.ToString("C2"));
            lblSatılanUrunAdedi.Text = Convert.ToString(SatisAdedi);
        }

      
    }
}
