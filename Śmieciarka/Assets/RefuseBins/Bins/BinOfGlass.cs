using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.RefuseBins.Interfaces;
using Assets.TrashGenerator.AllTrashs;

namespace Assets.RefuseBins.Bins {
     public class BinOfGlass : RefuseBins, IPropertiesOfBin {

          private TrashGenerator.Generator.TrashGenerator _trashGenerator;
          private Trashs[] _capacityOfBin;
          private int _emptySizeOfBin = 0;


          public BinOfGlass() {
               _capacityOfBin = new Trashs[5];
          }

          override public Trashs[] ContentOfBin {
               get { return this._capacityOfBin; }
          }

          override public void AddTrashToBin(Trashs trash) {
               for (int i = 0; i < _capacityOfBin.Length; i++) {
                    if (_capacityOfBin[i] == null) {
                         _capacityOfBin[i] = trash;
                         break;
                    }
               }
          }

          override public bool AmountOfEmptySpaceOfBin() {
               _emptySizeOfBin = 0;
               for (int i = 0; i < _capacityOfBin.Length; i++) {
                    if (_capacityOfBin[i] == null)
                         _emptySizeOfBin++;
               }
               if (_emptySizeOfBin > 0)
                    return true;
               else
                    return false;
          }

          //To test it's ok :)
          override public string CreateResultOfContent() {
               return _emptySizeOfBin.ToString();
          }
     }
}
