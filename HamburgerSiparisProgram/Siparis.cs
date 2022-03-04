using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerSiparisProgram
{
    public class Siparis
    {
        public Boyut SecilenMenuBoyutu { get; set; }
        public Menu SecilenMenu { get; set; }
        public List<EkstraMalzemeler> SecilenEkstraMalzemeler { get; set; }
        public int SecilenMenuAdedi { get; set; }
        public decimal SiparisTutari { get; set; }
        public void TutarHesapla()
        {
            SiparisTutari = 0;
            SiparisTutari+=SecilenMenu.MenuFiyati;
            foreach (EkstraMalzemeler ekstraMalzeme in SecilenEkstraMalzemeler)
            {
                SiparisTutari +=ekstraMalzeme.EkstraMalzelerFiyati;
            }
            switch (SecilenMenuBoyutu)
            {
                case Boyut.Kucuk: 
                    SiparisTutari+=SiparisTutari*0.1m;
                    break;
                case Boyut.Orta:
                    SiparisTutari += SiparisTutari * 0.2m;
                    break;
                case Boyut.Büyük:
                    SiparisTutari += SiparisTutari * 0.3m;
                    break;
            }

            SiparisTutari *= SecilenMenuAdedi;
        }
        public string EkstramalzemeYaz()
        {
            if (SecilenEkstraMalzemeler.Count>= 1)
            {
                string EkstraMalzemeler = null;
                foreach (EkstraMalzemeler ekstramalazme in SecilenEkstraMalzemeler)
                    EkstraMalzemeler += ekstramalazme.EkstraMalzemelerAdi + ",";

                EkstraMalzemeler = EkstraMalzemeler.Trim(',');
                return string.Format(EkstraMalzemeler);
            }

            return "";
                       

        }

        public override string ToString()
        {

            return string.Format("{0} Menu,x{1} Adet,{2} Boy,[{3}],Toplam:{4}", SecilenMenu.MenuAdi, SecilenMenuAdedi,SecilenMenuBoyutu, EkstramalzemeYaz(), SiparisTutari.ToString("C2"));

        }
    }
}
