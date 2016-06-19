using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class SpawnWasteland : MonoBehaviour {

    public GameObject Wasteland;

    static int[] board1 =
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };
    static int[] board2 =
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };
    static int[] board3 =
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };
    static int[] board4 =
    {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
    };

    // Use this for initialization
    void Start () {
	
	}
    //filtr
    int WaterDistance(int[] specimen)
    {
        int wynik = 0;
        for(int i = 0; i <= 50;i++)
        {
            if (specimen[i] == 1)
            {
                wynik += i % 17;
            }
        }
        return wynik;
    }
    //filtr
    int CityDistance(int[] specimen)
    {
        int wynik = 0;
        for (int i = 0; i <= 50; i++)
        {
            if(specimen[i]==1)
            {
                if (i < 17)
                {
                    wynik += 5;
                } else if (i < 34)
                {
                    wynik += 10;
                } else
                {
                    wynik += 15;
                }
            }
        }
        return wynik;
    }

    int add10(int a)
    {
        return a + 10;
    }
    //filtr
    int WasteDistance(int[] specimen)
    {
        int wynik = 0;
        for (int i = 0; i <= 50; i++)
        {
            if(specimen[i]==1)
            {
                if(i > 0 && specimen[i-1]==1)
                {
                    add10(wynik);
                }
                if(i > 17 && specimen[i-17]==1)
                {
                    add10(wynik);
                }
                if (i < 50 && specimen[i + 1] == 1)
                {
                    add10(wynik);
                }
                if (i < 33 && specimen[i+17]==1)
                {
                    add10(wynik);
                }
            }
        }
        return wynik;
    }
    //filtr
    int EntranceProximity(int[] specimen)
    {
        int wynik = 0;
        for (int i = 0 ; i <= 50 ; i++ )
        {
            if(specimen[i]==1)
            {
                //"Wjazd" do miasta/osiedla
                if (i == 8 || i == 25 || i == 42)
                {
                    wynik -= 20;
                }
            }
        }
        return wynik;
    }
    //Generowanie planszy z +2 śmeitniskami
    int[] Generate(int[] board)
    {
        //Losowy wybór 2 miejsc
        for (int i = 0; i < 2; i++)
        {
            int place = Random.Range(0, 50);
            while (board[place] != 0)
            {
                place = Random.Range(0, 50);
            }
            board[place] = 1;
        }
        return board;
    }

    int[] GeneticAlgorythm()
    {
        string fName = "C:\\Users\\user\\Documents\\GitHub\\SI-Inteligentna_Smieciarka\\Śmieciarka\\dataWasteland.cjc";

        IFormatter formatter = new BinaryFormatter();

        int[] alpha = board1;

        Plansze generation = new Plansze();
        if (File.Exists(fName))
        {
            Plansze a = Plansze.DeserializeItem(fName, formatter);
            generation.plansza1 = a.plansza1;
            generation.plansza2 = a.plansza2;
            generation.plansza3 = a.plansza3;
            generation.plansza4 = a.plansza4;
        } else
        {
            //Plansze z 4 śmietniskami
            generation.plansza1 = Generate(Generate(board1));
            generation.plansza2 = Generate(Generate(board2));
            //Plansze z 2 śmietniskami
            generation.plansza3 = Generate(board3);
            generation.plansza4 = Generate(board4);
        }

        //Ocenianie osobników
        int mark1 = WaterDistance(generation.plansza1) + EntranceProximity(generation.plansza1) + CityDistance(generation.plansza1) + WasteDistance(generation.plansza1);
        int mark2 = WaterDistance(generation.plansza2) + EntranceProximity(generation.plansza2) + CityDistance(generation.plansza2) + WasteDistance(generation.plansza2);
        int mark3 = WaterDistance(generation.plansza3) + EntranceProximity(generation.plansza3) + CityDistance(generation.plansza3) + WasteDistance(generation.plansza3);
        int mark4 = WaterDistance(generation.plansza4) + EntranceProximity(generation.plansza4) + CityDistance(generation.plansza4) + WasteDistance(generation.plansza4);
        int[] marks = { mark1, mark2, mark3, mark4 };

        string info = "Początek:\n" + WaterDistance(generation.plansza1) + " " + EntranceProximity(generation.plansza1) + " " + CityDistance(generation.plansza1) + " " + WasteDistance(generation.plansza1) +"\n"
            + " " + WaterDistance(generation.plansza2) + " " + EntranceProximity(generation.plansza2) + " " + CityDistance(generation.plansza2) + " " + WasteDistance(generation.plansza2) +"\n"
            + " " + WaterDistance(generation.plansza3) + " " + EntranceProximity(generation.plansza3) + " " + CityDistance(generation.plansza3) + " " + WasteDistance(generation.plansza3) +"\n"
            + " " + WaterDistance(generation.plansza4) + " " + EntranceProximity(generation.plansza4) + " " + CityDistance(generation.plansza4) + " " + WasteDistance(generation.plansza4) +"\n";

        //542 teraz

        return alpha;
    }
}
