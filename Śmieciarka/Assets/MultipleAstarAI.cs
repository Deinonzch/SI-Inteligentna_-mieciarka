﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using System;
using Assets.TrashGenerator.Generator;
using Assets.RefuseBins.SelectorForBins;
using Assets.RefuseBins;
using Assets.RefuseBins.Bins;
using Assets.TrashGenerator.AllTrashs;
using Assets.TrashGenerator.AllTrashs.KindOfTrash;
using Assets.GarbageTruck;
using Assets.DecisionTree;

public class MultipleAstarAI : MonoBehaviour {

     public GameObject[] targets;
     public Vector3[] vectorTargets;

     //Variables used to generate trash and to sort it through garbage track and finally dispaly it to user.
     
     public Text _contentOfRefuseBin;
     public Text _contentOfGarbageTruck;
     public TrashGenerator _trashGenerator;
     public BinOfAluminium _binOfAluminium;
     public BinOfGlass _binOfGlass;
     public BinOfPaper _binOfPaper;
     public Trashs[] _contentOfBin;
     public GarbageTruck _garbageTruck;
     public DecisionTree _decisionTree;
     public int _currentAmountOfAluminium;
     public int _currentAmountOfGlass;
     public int _currentAmountOfPaper;
     //

     private Seeker seeker;
     private bool pathComplete;
     //The calculated path
     public Path path;
     // Use this for initialization
     //The waypoint we are currently moving towards
     private int currentWaypoint = 0;
     //The AI's speed per second
     public float speed = 1;

     //The max distance from the AI to a waypoint for it to continue to the next waypoint
     public float nextWaypointDistance = 3;

     bool gora = false;
     bool prawo = false;
     bool lewo = false;
     bool dol = false;

     float lastx = 0;
     float lasty = 0;
     //1 gora, 2, prawo, 3, dol, 4 lewo
     int przod = 1;
     void Start() {
          targets = GameObject.FindGameObjectsWithTag("Smietniki");
          int ilosc = targets.Length;
          vectorTargets = new Vector3[ilosc + 1];
          seeker = GetComponent<Seeker>();
          int i = 1;
          vectorTargets[0] = seeker.transform.position;
          foreach (var e in targets) {
               vectorTargets[i] = e.transform.position;
               i++;
          }

          //WaypointPath d = new WaypointPath(vectorTargets, OnPathComplete);
          //d.StartPath();
          //Start a new path to the targetPosition, return the result to the OnPathComplete function
          for (i = 0; i < ilosc; i++)
               seeker.StartPath(vectorTargets[0], vectorTargets[1], OnPathComplete);


     }

     void OnPathComplete(Path p) {
          Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
          if (!p.error) {

               path = p;
               //Reset the waypoint counter
               currentWaypoint = 0;
               pathComplete = true;
          }
     }

     // Update is called once per frame
     void OnPathComplete(WaypointPath p) {
          if (p.HasError()) {
               Debug.LogError("Noes, could not find the path!");
               return;
          } else {
               List<Vector3> vp = p.vectorPath;
               for (int i = 0; i < vp.Count - 1; i++) Debug.DrawLine(vp[i], vp[i + 1], Color.red, 20);
          }
     }

     public void FixedUpdate() {
          if (path == null) {
               //We have no path to move after yet
               return;
          }

          if (currentWaypoint >= path.vectorPath.Count && pathComplete == true) {
               Debug.Log("End Of Path Reached");
               Start();
               pathComplete = false;
               return;
          }

          //Direction to the next waypoint
          Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
          Vector3 roznica = dir;
          dir *= speed * Time.fixedDeltaTime;

          if (Math.Round(lastx, 0) != Math.Round(roznica.x, 0)) {
               if (Math.Round(roznica.x, 0) == 1) {
                    prawo = true;
               } else {
                    prawo = false;
               }
               if (Math.Round(roznica.x, 0) == -1) {
                    lewo = true;
               } else {
                    lewo = false;
               }
          }


          if (Math.Round(lasty, 0) != Math.Round(roznica.y, 0)) {
               if (Math.Round(roznica.y, 0) == 1) {
                    gora = true;
               } else {
                    gora = false;
               }
               if (Math.Round(roznica.y, 0) == -1) {
                    dol = true;
               } else {
                    dol = false;
               }
          }

          lastx = roznica.x;
          lasty = roznica.y;

          if (prawo == true && gora == false && lewo == false && dol == false && przod == 1) {
               transform.Rotate(new Vector3(0, 0, -90), Space.World);
               przod = 2;
          }

          if (prawo == true && gora == false && lewo == false && dol == false && przod == 2) {
               transform.Rotate(new Vector3(0, 0, 0), Space.World);
          }

          if (prawo == true && gora == false && lewo == false && dol == false && przod == 3) {
               transform.Rotate(new Vector3(0, 0, 90), Space.World);
               przod = 2;
          }

          if (prawo == true && gora == false && lewo == false && dol == false && przod == 4) {
               transform.Rotate(new Vector3(0, 0, 180), Space.World);
               przod = 2;
          }

          if (gora == true && prawo == false && lewo == false && dol == false && przod == 1) {
               transform.Rotate(new Vector3(0, 0, 0), Space.World);
          }

          if (gora == true && prawo == false && lewo == false && dol == false && przod == 2) {
               transform.Rotate(new Vector3(0, 0, 90), Space.World);
               przod = 1;
          }

          if (gora == true && prawo == false && lewo == false && dol == false && przod == 3) {
               transform.Rotate(new Vector3(0, 0, 180), Space.World);
               przod = 1;
          }

          if (gora == true && prawo == false && lewo == false && dol == false && przod == 4) {
               transform.Rotate(new Vector3(0, 0, -90), Space.World);
               przod = 1;
          }

          if (gora == false && prawo == false && lewo == false && dol == true && przod == 1) {
               transform.Rotate(new Vector3(0, 0, 180), Space.World);
               przod = 3;
          }

          if (gora == false && prawo == false && lewo == false && dol == true && przod == 2) {
               transform.Rotate(new Vector3(0, 0, -90), Space.World);
               przod = 3;
          }

          if (gora == false && prawo == false && lewo == false && dol == true && przod == 3) {
               transform.Rotate(new Vector3(0, 0, 0), Space.World);
          }

          if (gora == false && prawo == false && lewo == false && dol == true && przod == 4) {
               transform.Rotate(new Vector3(0, 0, 90), Space.World);
               przod = 3;
          }

          if (gora == false && prawo == false && lewo == true && dol == false && przod == 1) {
               transform.Rotate(new Vector3(0, 0, 90), Space.World);
               przod = 4;
          }

          if (gora == false && prawo == false && lewo == true && dol == false && przod == 2) {
               transform.Rotate(new Vector3(0, 0, 180), Space.World);
               przod = 4;
          }

          if (gora == false && prawo == false && lewo == true && dol == false && przod == 3) {
               transform.Rotate(new Vector3(0, 0, -90), Space.World);
               przod = 4;
          }

          if (gora == false && prawo == false && lewo == true && dol == false && przod == 4) {
               transform.Rotate(new Vector3(0, 0, 0), Space.World);
          }

          prawo = false;
          gora = false;
          dol = false;
          lewo = false;

          transform.Translate(dir, Space.World);
          //Check if we are close enough to the next waypoint
          //If we are, proceed to follow the next waypoint
          if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
               currentWaypoint++;
               return;
          }
     }
     public void OnDisable() {
          seeker.pathCallback -= OnPathComplete;
     }
     //Mehtod used to display content of bins and garbage truck.
     public void DisplayContentBin(RefuseBins bin) {

          _contentOfRefuseBin.text = ("Zawartość kosza: " + "\n" +
               bin.ContentOfBin[0].TypeOfTrash + "\n" +
               bin.ContentOfBin[1].TypeOfTrash + "\n" +
               bin.ContentOfBin[2].TypeOfTrash + "\n" +
               bin.ContentOfBin[3].TypeOfTrash + "\n" +
               bin.ContentOfBin[4].TypeOfTrash + "\n");

     }

     public void DisplayConentOfGarbageTruck(GarbageTruck garbageTruck) {
          _currentAmountOfAluminium = _currentAmountOfAluminium + garbageTruck.CurrentStateStorageForAluminium();
          _currentAmountOfGlass = _currentAmountOfGlass + garbageTruck.CurrentStateStorageForGlass();
          _currentAmountOfPaper = _currentAmountOfPaper + garbageTruck.CurrentStateStorageForPaper();

          _contentOfGarbageTruck.text = ("Zawartość śmieciarki: " + "\n" +
               "Aluminium: " + _currentAmountOfAluminium + "\n" + 
               "Szklo: " + _currentAmountOfGlass + "\n" + 
               "Papier: " + _currentAmountOfPaper);
     }

     //Event which react on colision between specific bin and garbage truck.
     void OnTriggerEnter2D(Collider2D coll) {

          _trashGenerator = new TrashGenerator();
          _garbageTruck = new GarbageTruck();
          _decisionTree = new DecisionTree();

          if (coll.name.StartsWith("SmietnikAluminium")){
               _binOfAluminium = new BinOfAluminium();

               while (_binOfAluminium.AmountOfEmptySpaceOfBin()) {
                    _binOfAluminium.AddTrashToBin(_trashGenerator.GetResult());
               }

               for(int index = 0; index < _binOfAluminium.ContentOfBin.Length; index++) {
                    if(_decisionTree.CheckWeight(_binOfAluminium.ContentOfBin[index]) == "NextTest") {
                         if(_decisionTree.CheckAbilityOfCrushing(_binOfAluminium.ContentOfBin[index]) == "NextTest") {
                              if (_decisionTree.CheckAbsorptionOfHeat(_binOfAluminium.ContentOfBin[index]) == "Paper")
                                   _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfAluminium.ContentOfBin[index]);
                              else if (_decisionTree.CheckAbsorptionOfHeat(_binOfAluminium.ContentOfBin[index]) == "Glass")
                                   _garbageTruck.AddTrashToGarbageTruck("Glass", _binOfAluminium.ContentOfBin[index]);
                              else
                                   _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfAluminium.ContentOfBin[index]);

                         }
                         else if(_decisionTree.CheckAbilityOfCrushing(_binOfAluminium.ContentOfBin[index]) == "Paper") {
                              _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfAluminium.ContentOfBin[index]);
                         } else {
                              _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfAluminium.ContentOfBin[index]);
                         }

                    }
                    else if(_decisionTree.CheckWeight(_binOfAluminium.ContentOfBin[index]) == "Paper"){
                         _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfAluminium.ContentOfBin[index]);
                    } else {
                         _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfAluminium.ContentOfBin[index]);
                    }

               }

               DisplayConentOfGarbageTruck(_garbageTruck);
               DisplayContentBin(_binOfAluminium);
               Destroy(coll.gameObject);
          }

          if (coll.name.StartsWith("SmietnikPapier")) {
               _binOfPaper = new BinOfPaper();

               while (_binOfPaper.AmountOfEmptySpaceOfBin()) {
                   _binOfPaper.AddTrashToBin(_trashGenerator.GetResult());
               }
               for (int index = 0; index < _binOfPaper.ContentOfBin.Length; index++) {
                    if (_decisionTree.CheckWeight(_binOfPaper.ContentOfBin[index]) == "NextTest") {
                         if (_decisionTree.CheckAbilityOfCrushing(_binOfPaper.ContentOfBin[index]) == "NextTest") {
                              if (_decisionTree.CheckAbsorptionOfHeat(_binOfPaper.ContentOfBin[index]) == "Paper")
                                   _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfPaper.ContentOfBin[index]);
                              else if (_decisionTree.CheckAbsorptionOfHeat(_binOfPaper.ContentOfBin[index]) == "Glass")
                                   _garbageTruck.AddTrashToGarbageTruck("Glass", _binOfPaper.ContentOfBin[index]);
                              else
                                   _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfPaper.ContentOfBin[index]);

                         } else if (_decisionTree.CheckAbilityOfCrushing(_binOfPaper.ContentOfBin[index]) == "Paper") {
                              _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfPaper.ContentOfBin[index]);
                         } else {
                              _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfPaper.ContentOfBin[index]);
                         }

                    } else if (_decisionTree.CheckWeight(_binOfPaper.ContentOfBin[index]) == "Paper") {
                         _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfPaper.ContentOfBin[index]);
                    } else {
                         _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfPaper.ContentOfBin[index]);
                    }

               }

               DisplayConentOfGarbageTruck(_garbageTruck);
               DisplayContentBin(_binOfPaper);
               Destroy(coll.gameObject);
          }

          if ( coll.name.StartsWith("SmietnikPlastik")) {
               _binOfGlass = new BinOfGlass();

               while (_binOfGlass.AmountOfEmptySpaceOfBin()) {
                    _binOfGlass.AddTrashToBin(_trashGenerator.GetResult());
               }

               for (int index = 0; index < _binOfGlass.ContentOfBin.Length; index++) {
                    if (_decisionTree.CheckWeight(_binOfGlass.ContentOfBin[index]) == "NextTest") {
                         if (_decisionTree.CheckAbilityOfCrushing(_binOfGlass.ContentOfBin[index]) == "NextTest") {
                              if (_decisionTree.CheckAbsorptionOfHeat(_binOfGlass.ContentOfBin[index]) == "Paper")
                                   _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfGlass.ContentOfBin[index]);
                              else if (_decisionTree.CheckAbsorptionOfHeat(_binOfGlass.ContentOfBin[index]) == "Glass")
                                   _garbageTruck.AddTrashToGarbageTruck("Glass", _binOfGlass.ContentOfBin[index]);
                              else
                                   _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfGlass.ContentOfBin[index]);

                         } else if (_decisionTree.CheckAbilityOfCrushing(_binOfGlass.ContentOfBin[index]) == "Paper") {
                              _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfGlass.ContentOfBin[index]);
                         } else {
                              _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfGlass.ContentOfBin[index]);
                         }

                    } else if (_decisionTree.CheckWeight(_binOfGlass.ContentOfBin[index]) == "Paper") {
                         _garbageTruck.AddTrashToGarbageTruck("Paper", _binOfGlass.ContentOfBin[index]);
                    } else {
                         _garbageTruck.AddTrashToGarbageTruck("Aluminium", _binOfGlass.ContentOfBin[index]);
                    }

               }

               DisplayConentOfGarbageTruck(_garbageTruck);
               DisplayContentBin(_binOfGlass);
               Destroy(coll.gameObject);
          }
     }
}

