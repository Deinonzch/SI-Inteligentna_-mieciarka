using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs.KindOfTrash;
using Assets.TrashGenerator.AllTrashs;
using Assets.RefuseBins.Bins;
using Assets.RefuseBins;

namespace Assets.GarbageTruck {
     public class GarbageTruck {

          private Aluminium[] _storageForAluminium;
          private Glass[] _storageForGlass;
          private Paper[] _storageForPaper;

          private int _amountOfAluminiumTrash;
          private int _amountOfGlassTrash;
          private int _amountOfPaperTrash;
          
     
          public GarbageTruck() {

               this._amountOfAluminiumTrash = 0;
               this._amountOfGlassTrash = 0;
               this._amountOfPaperTrash = 0; 
                   
               this._storageForAluminium = new Aluminium[100];
               this._storageForGlass = new Glass[100];
               this._storageForPaper = new Paper[100];
          }

          public void AddTrashToGarbageTruck(string TypeOfTrash, Trashs trash) {
               if(TypeOfTrash == "Aluminium") {
                    for(int i = 0; i < _storageForAluminium.Length; i++) {
                         if(_storageForAluminium[i] == null) {
                              _storageForAluminium[i] = new Aluminium(trash.Weight, trash.AbilityOfCrushing, trash.AbsorptionOfHeat);
                              _amountOfAluminiumTrash++;
                              break;
                         }
                    }
               }
               else if (TypeOfTrash == "Glass") {
                    for (int i = 0; i < _storageForGlass.Length; i++) {
                         if (_storageForGlass[i] == null) {
                              _storageForGlass[i] = new Glass(trash.Weight, trash.AbilityOfCrushing, trash.AbsorptionOfHeat);
                              _amountOfGlassTrash++;
                              break;
                         }
                    }
               }
               else if (TypeOfTrash == "Paper") {
                    for (int i = 0; i < _storageForPaper.Length; i++) {
                         if (_storageForPaper[i] == null) {
                              _storageForPaper[i] = new Paper(trash.Weight, trash.AbilityOfCrushing, trash.AbsorptionOfHeat);
                              _amountOfPaperTrash++;
                              break;
                         }
                    }
               }
          }

          public int CurrentStateStorageForAluminium() {
               return _amountOfAluminiumTrash;
          }

          public int CurrentStateStorageForGlass() {
               return _amountOfGlassTrash;
          }

          public int CurrentStateStorageForPaper() {
               return _amountOfPaperTrash;
          }
     }
}
