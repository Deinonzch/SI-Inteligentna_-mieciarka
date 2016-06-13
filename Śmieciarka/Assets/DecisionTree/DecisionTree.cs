using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.TrashGenerator.AllTrashs.KindOfTrash;
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.Generator;

namespace Assets.DecisionTree {
     public class DecisionTree {

          public DecisionTree() {

          }

          public string CheckWeight(Trashs trash) {

               if (trash.Weight < 2) {
                    return "Paper";
               } else if ((trash.Weight >= 2) && (trash.Weight <= 4)) {
                    return "NextTest";
               } else
                    return "Aluminium";
          }

          public string CheckAbilityOfCrushing(Trashs trash) {

               if (trash.AbilityOfCrushing < 3) {
                    return "Paper";
               } else if ((trash.AbilityOfCrushing >= 3) && (trash.AbilityOfCrushing <= 5)) {
                    return "NextTest";
               } else
                    return "Aluminium";
          }

          public string CheckAbsorptionOfHeat(Trashs trash) {

               if (trash.AbsorptionOfHeat <= 3) {
                    return "Paper";
               } else if ((trash.AbsorptionOfHeat >= 4) && (trash.AbsorptionOfHeat <= 6)) {
                    return "Glass";
               } else
                    return "Aluminium";
          }
     }
}
