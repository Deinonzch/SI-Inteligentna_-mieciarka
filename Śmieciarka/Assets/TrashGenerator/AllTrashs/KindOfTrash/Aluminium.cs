using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs.Interfaces;

namespace Assets.TrashGenerator.AllTrashs.KindOfTrash {

     public class Aluminium : Trashs {

          private int _weight;
          private int _abilityOfCrushing;
          private int _absorptionOfHeat;
          private string _typeOfTrash;

          public Aluminium() {

          }
          public Aluminium(int weight = 0, int abilityOfCrushing = 0, int absorptionOfHeat = 0, string typeOfTrash = "") {

               this._weight = weight;
               this._abilityOfCrushing = abilityOfCrushing;
               this._absorptionOfHeat = absorptionOfHeat;
               this._typeOfTrash = typeOfTrash;
          }

          override public int Weight {
               get { return this._weight; }
               set { this._weight = value; }
          }
          override public int AbilityOfCrushing {
               get { return this._abilityOfCrushing; }
               set { this._abilityOfCrushing = value; }
          }
          override public int AbsorptionOfHeat {
               get { return this._absorptionOfHeat; }
               set { this._absorptionOfHeat = value; }
          }
          override public string TypeOfTrash {
               get { return _typeOfTrash; }
               set { this._typeOfTrash = value;} }
          override public int SizeOfTrash { get; set; }

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
