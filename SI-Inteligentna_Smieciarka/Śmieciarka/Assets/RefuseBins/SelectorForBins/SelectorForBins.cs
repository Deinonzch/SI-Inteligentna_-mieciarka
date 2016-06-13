using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.RefuseBins.Bins;

namespace Assets.RefuseBins.SelectorForBins {
     public class SelectorForBins {
          private RefuseBins _selectedBin;
          
          public SelectorForBins() {

          }

          public RefuseBins SelectBin(string selectedBin) {
               switch (selectedBin) {
                    case "Aluminium":
                         _selectedBin = new BinOfAluminium();
                         break;

                    case "Paper":
                         _selectedBin = new BinOfPaper();
                         break;
                    case "Glass":
                         _selectedBin = new BinOfGlass();
                         break;
               }

               return _selectedBin;
          }
     }
}
