using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.Generator;
using Assets.TrashGenerator.AllTrashs;

namespace Assets.RefuseBins.Interfaces {
     public interface IPropertiesOfBin {
          Trashs [] ContentOfBin { get; }
          void AddTrashToBin(Trashs trash);
          bool AmountOfEmptySpaceOfBin();
     }
}
