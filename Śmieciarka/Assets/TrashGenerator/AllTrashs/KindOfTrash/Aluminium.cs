using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs.Interfaces;

namespace Assets.TrashGenerator.AllTrashs.KindOfTrash {

     public class Aluminium : Trashs, IPropertiesOfTrash {

          private int _weight;
          private int _abilityOfCrushing;
          private int _absorptionOfHeat;

          public Aluminium() {

          }
          public Aluminium(int weight = 0, int abilityOfCrushing = 0, int absorptionOfHeat = 0) {

               this._weight = weight;
               this._abilityOfCrushing = abilityOfCrushing;
               this._absorptionOfHeat = absorptionOfHeat;
          }

          public int Weight { set; get; }
          public int AbilityOfCrushing { set; get; }
          public int AbsorptionOfHeat { set; get; }

          
     }
}

/*
     Interval attributes for Aluminium in scale [1-10]:
       *Weight [4-8]
       *Crushing [4-8]
       *Absorption [7-9]

     Interval attributes for Glass in scale [1-10]:
       *Weight [2-4]
       *Crushing [3-5]
       *Absorption [4-6]

     Interval attributes for Paper in scale [1-10]:
       *Weight [1-3]
       *Crushing [1-3]
       *Absorption [1-3]

     
*/
