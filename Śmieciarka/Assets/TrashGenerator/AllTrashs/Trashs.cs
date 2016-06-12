using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.TrashGenerator.AllTrashs {
     public abstract class Trashs {


          abstract public int Weight { set; get; }
          abstract public int AbilityOfCrushing { set; get; }
          abstract public int AbsorptionOfHeat { set; get; }
          abstract public string TypeOfTrash { get; set; }
          abstract public int SizeOfTrash { get; set; }
     }
}
