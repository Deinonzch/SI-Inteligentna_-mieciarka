using UnityEngine;
using System.Collections;

public class SpawnSmietniki : MonoBehaviour {

    public GameObject Smietniki1;
    public GameObject Smietniki2;
    public GameObject Smietniki3;
    bool[,] plansza = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                        { false, true, false, true, true, false, true, false, true, false, true, true, true, true, false },
                        { false, true, false, false, false, false, false, false, true, false, false, false, false, true, false },
                        { false, true, false, true, true, true, true, false, true, false, true, true, true, true, false },
                        { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false } };
    
    // Use this for initialization
    void Start () {
        // Spawn food every 4 seconds, starting in 3
        Generuj();
    }

    // Spawn one piece of food
    void Spawn()
    {
        // x position between left & right border
        int x1 = (int)Random.Range(-7,
                                  8);

        // y position between top & bottom border
        int y1 = (int)Random.Range(0,
                                  5);

       while (plansza[y1,x1+7]==true)
        {
            // x position between left & right border
            x1 = (int)Random.Range(-7,
                                     7);

            // y position between top & bottom border
            y1 = (int)Random.Range(0,
                                      4);
        }

        plansza[y1, x1 + 7] = true;
        
        // x position between left & right border
        int x2 = (int)Random.Range(-7,
                                  8);

        // y position between top & bottom border
        int y2 = (int)Random.Range(0,
                                  5);

        while (plansza[y2, x2 + 7] == true)
        {
            // x position between left & right border
            x2 = (int)Random.Range(-7,
                                     7);

            // y position between top & bottom border
            y2 = (int)Random.Range(0,
                                      4);
        }

        plansza[y2, x2 + 7] = true;

        // x position between left & right border
        int x3 = (int)Random.Range(-7,
                                  8);

        // y position between top & bottom border
        int y3 = (int)Random.Range(0,
                                  5);

        while (plansza[y3, x3 + 7] == true)
        {
            // x position between left & right border
            x3 = (int)Random.Range(-7,
                                     7);

            // y position between top & bottom border
            y3 = (int)Random.Range(0,
                                      4);
        }

        plansza[y3, x3 + 7] = true;

        // Instantiate the food at (x, y)
        Instantiate(Smietniki1,
                    new Vector2(x1, y1),
                    Quaternion.identity); // default rotation
        Instantiate(Smietniki2,
                    new Vector2(x2, y2),
                    Quaternion.identity); // default rotation
        Instantiate(Smietniki3,
                    new Vector2(x3, y3),
                    Quaternion.identity); // default rotation
    }

    void Generuj()
    {
        for (int i = 0; i < 3; i++)
            Spawn();
    }
}
