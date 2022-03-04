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
    public partial class FrmSiparisOlustur : Form
    {
        public FrmSiparisOlustur()
        {
            InitializeComponent();
        }
        public static List<Siparis> Siparisler = new List<Siparis>();
        public static List<Siparis> MevcutSiparisler = new List<Siparis>();


        public static List<Menu> Menuler = new List<Menu>()
        {
                new Menu {MenuAdi="BigMac",MenuFiyati=15.75m},
                new Menu {MenuAdi="McChicken",MenuFiyati=12.75m},
                new Menu {MenuAdi="DoubleMcChicken",MenuFiyati=11.75m},
                new Menu {MenuAdi="McRoyal",MenuFiyati=14.75m},
                new Menu {MenuAdi="DoubleCheeseBurger",MenuFiyati=19.75m}
        };
        public static void AddMenu(Menu menu)
        {
            Menuler.Add(menu);
        }

        public static List<EkstraMalzemeler> ekstramalzemelerList = new List<EkstraMalzemeler>()
        {
                new EkstraMalzemeler{EkstraMalzemelerAdi="Ranch",EkstraMalzelerFiyati=1},
                new EkstraMalzemeler{EkstraMalzemelerAdi="Ketçap",EkstraMalzelerFiyati=1},
                new EkstraMalzemeler{EkstraMalzemelerAdi="Mayonez",EkstraMalzelerFiyati=1},
                new EkstraMalzemeler{EkstraMalzemelerAdi="BBQ",EkstraMalzelerFiyati=1},
                new EkstraMalzemeler{EkstraMalzemelerAdi="Hardal",EkstraMalzelerFiyati=1}

        };
        public static void AddEkstra(EkstraMalzemeler ekstra)
        {
            ekstramalzemelerList.Add(ekstra);
        } 
       

        private void FrmSiparisOlustur_Load(object sender, EventArgs e)
        {

            foreach (Menu item in Menuler)
            {
                cmbMenuListe.Items.Add(item);
            };

            foreach (EkstraMalzemeler ekstraMalzemeler in ekstramalzemelerList)
            {
                flwMalzemeler.Controls.Add(new CheckBox() { Text = ekstraMalzemeler.EkstraMalzemelerAdi, Tag = ekstraMalzemeler });
            };

            cmbMenuListe.SelectedIndex = 0;
           
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Siparis siparisyeni = new Siparis();
                siparisyeni.SecilenMenu = (Menu)(cmbMenuListe.SelectedItem);
                if (rdbKucuk.Checked)
                {
                    siparisyeni.SecilenMenuBoyutu = Boyut.Kucuk;
                }
                else if (rdbOrta.Checked)
                {
                    siparisyeni.SecilenMenuBoyutu = Boyut.Orta;
                }
                else if (rdbBuyuk.Checked)
                {
                    siparisyeni.SecilenMenuBoyutu = Boyut.Büyük;
                };
                siparisyeni.SecilenMenuAdedi = Convert.ToInt32(nmrAdet.Value);
                siparisyeni.SecilenEkstraMalzemeler = new List<EkstraMalzemeler>();
                
                foreach (CheckBox item in flwMalzemeler.Controls)
                {
                    if (item.Checked) 
                    {
                        siparisyeni.SecilenEkstraMalzemeler.Add((EkstraMalzemeler)(item.Tag));
                    }
                        
                }
                siparisyeni.TutarHesapla();               
                Siparisler.Add(siparisyeni);
                MevcutSiparisler.Add(siparisyeni);
                lstSiparis.Items.Add(siparisyeni);
                ToplamTutarHesapla();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private decimal ToplamTutarHesapla()
        {
            decimal toplamTutar = 0;
            for (int i=0; i<lstSiparis.Items.Count;i++)
            {
                Siparis gelen = (Siparis)lstSiparis.Items[i];
                toplamTutar += gelen.SiparisTutari;   
            }
            lblTL.Text = toplamTutar.ToString("C2");
            return toplamTutar;

        }

    }
}
