using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.AllTrash.Interfaces;

namespace Assets.TrashGenerator.AllTrashs.KindOfTrash {
     class Glass : Trashs, IPropertiesOfTrash {
          private int _weight;
          private int _abilityOfCrushing;
          private int _absorptionOfHeat;

          public Glass() {

          }
          public Glass(int weight = 0, int abilityOfCrushing = 0, int absorptionOfHeat = 0) {

               this._weight = weight;
               this._abilityOfCrushing = abilityOfCrushing;
               this._absorptionOfHeat = absorptionOfHeat;
          }

          public int Weight { set; get; }
          public int AbilityOfCrushing { set; get; }
          public int AbsorptionOfHeat { set; get; }


     }
}
