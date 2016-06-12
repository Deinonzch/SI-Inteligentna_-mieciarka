using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.AllTrashs.Interfaces;

namespace Assets.TrashGenerator.AllTrashs.KindOfTrash {
     class RestOfTrash: Trashs {

          override public int Weight { set; get; }
          override public int AbilityOfCrushing { set; get; }
          override public int AbsorptionOfHeat { set; get; }
          override public string TypeOfTrash { get; set; }
          override public int SizeOfTrash { get; set; }

     }

}
