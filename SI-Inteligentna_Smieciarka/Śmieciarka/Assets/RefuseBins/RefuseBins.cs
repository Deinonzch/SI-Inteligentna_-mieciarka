using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.RefuseBins.Bins;
using Assets.TrashGenerator.AllTrashs;

namespace Assets.RefuseBins {
     public abstract class RefuseBins {


          abstract public Trashs[] ContentOfBin { get; }
          abstract public void AddTrashToBin(Trashs trash);
          abstract public bool AmountOfEmptySpaceOfBin();
          abstract public string CreateResultOfContent();

     }
}
