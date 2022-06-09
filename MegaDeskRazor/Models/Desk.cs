using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class Desk
    {
        public int DeskId { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        [Display(Name = "Number Of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name="Desktop Material")]
        public int DesktopMaterialId { get; set; }
        
        public DesktopMaterial DesktopMaterial { get; set; }
        public DeskQuote DeskQuote { get; set; }
    }

}
