using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.AllTrashs.Interfaces;

namespace Assets.TrashGenerator.AllTrashs.KindOfTrash {
     class RestOfTrash: Trashs, IPropertiesOfTrash {

          public int Weight { set; get; }
          public int AbilityOfCrushing { set; get; }
          public int AbsorptionOfHeat { set; get; }
     }
}
