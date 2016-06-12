using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.AllTrashs.KindOfTrash;
using Assets.TrashGenerator.AllTrashs.Interfaces;

namespace Assets.TrashGenerator.Generator {

     //In bottom file you have comment with info about scale of attributes of Trashs
     public class TrashGenerator : Trashs{

          private int _resultGenerator;

          private Random _attributeGenerator;
          private Random _trashGenerator;
          private Trashs _successedTrash;


          public TrashGenerator() {
               this._trashGenerator = new Random();
               this._attributeGenerator = new Random();
          }

          override public int Weight { set; get; }
          override public int AbilityOfCrushing { set; get; }
          override public int AbsorptionOfHeat { set; get; }
          override public string TypeOfTrash { get; set; }
          override public int SizeOfTrash { get; set; }

          public Trashs GetResult() {

               this._resultGenerator = _trashGenerator.Next(1, 4);

               switch (_resultGenerator) {
                    case 1:
                         Weight = _attributeGenerator.Next(4,9);
                         AbilityOfCrushing = _attributeGenerator.Next(4, 9);
                         AbsorptionOfHeat = _attributeGenerator.Next(6, 10);
                         SizeOfTrash = _attributeGenerator.Next(3, 7);
                         TypeOfTrash = "Aluminium";
                         _successedTrash = new Aluminium(Weight, AbilityOfCrushing, AbsorptionOfHeat, TypeOfTrash);
                         break;

                    case 2:
                         Weight = _attributeGenerator.Next(2, 5);
                         AbilityOfCrushing = _attributeGenerator.Next(3, 6);
                         AbsorptionOfHeat = _attributeGenerator.Next(4, 7);
                         SizeOfTrash = _attributeGenerator.Next(1, 4);
                         TypeOfTrash = "Szklo";
                         _successedTrash = new Glass(Weight, AbilityOfCrushing, AbsorptionOfHeat, TypeOfTrash);
                         break;

                    case 3:
                         Weight = _attributeGenerator.Next(4, 9);
                         AbilityOfCrushing = _attributeGenerator.Next(4, 9);
                         AbsorptionOfHeat = _attributeGenerator.Next(7, 10);
                         SizeOfTrash = _attributeGenerator.Next(1, 3);
                         TypeOfTrash = "Papier";
                         _successedTrash = new Paper(Weight, AbilityOfCrushing, AbsorptionOfHeat, TypeOfTrash);     
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
