using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.AllTrashs.KindOfTrash;
using Assets.TrashGenerator.AllTrashs.Interfaces;

namespace Assets.TrashGenerator.Generator {

     //In bottom file you have comment with info about scale of attributes of Trashs
     public class TrashGenerator : IPropertiesOfTrash{

          private int _resultGenerator;

          private Random _attributeGenerator;
          private Random _trashGenerator;
          private Trashs _successedTrash;


          public TrashGenerator() {
               this._trashGenerator = new Random();
               this._attributeGenerator = new Random();
          }

          public int Weight { set; get; }
          public int AbilityOfCrushing { set; get; }
          public int AbsorptionOfHeat { set; get; }


          public Trashs GetResult() {

               this._resultGenerator = _trashGenerator.Next(1, 4);

               switch (_resultGenerator) {
                    case 1:
                         Weight = _attributeGenerator.Next(4,8);
                         AbilityOfCrushing = _attributeGenerator.Next(4, 8);
                         AbsorptionOfHeat = _attributeGenerator.Next(6, 9);
                         _successedTrash = new Aluminium(Weight, AbilityOfCrushing, AbsorptionOfHeat);
                         break;

                    case 2:
                         Weight = _attributeGenerator.Next(2, 4);
                         AbilityOfCrushing = _attributeGenerator.Next(3, 5);
                         AbsorptionOfHeat = _attributeGenerator.Next(4, 6);
                         _successedTrash = new Glass(Weight, AbilityOfCrushing, AbsorptionOfHeat);
                         break;

                    case 3:
                         Weight = _attributeGenerator.Next(4, 8);
                         AbilityOfCrushing = _attributeGenerator.Next(4, 8);
                         AbsorptionOfHeat = _attributeGenerator.Next(7, 9);
                         _successedTrash = new Paper();     
                         break;

                    case 4:
                         this._successedTrash = new RestOfTrash();
                         break;
               }

               return _successedTrash;
          }

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
