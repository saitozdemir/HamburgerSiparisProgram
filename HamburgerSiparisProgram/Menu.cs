﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerSiparisProgram
{
    public class Menu
    {
        public string MenuAdi { get; set; }
        public decimal MenuFiyati { get; set; }
        public override string ToString()
        {
            return MenuAdi + " " + "Menu" + " " + MenuFiyati.ToString("C2");
        }


    }
}
