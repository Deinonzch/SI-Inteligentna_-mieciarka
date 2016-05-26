using UnityEngine;
using System.Collections;

public class SpawnSmietniki : MonoBehaviour {

    public GameObject Smietniki1;
    public GameObject Smietniki2;
    public GameObject Smietniki3;
    int[,] plansza1 = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, -1, 0, -2, -1, 0, -2, 0, -1, 0, -2, -1, -1, -2, 0 },
                       { 0, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0 },
                       { 0, -1, 0, -2, -1, -1, -2, 0, -1, 0, -2, -1, -1, -2, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
    int ilosc_smietnikow = 9;
    int ilosc_rodzaju = 3;
    // Use this for initialization
    void Start () {
        // Spawn food every 4 seconds, starting in 3
        Spawn();
    }

    // Spawn
    void Spawn()
    {
        int[,] plansza = AlgorythmGenetic();
        //int[,] plansza = Generuj(plansza1);

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 15; j++)
            {
                if (plansza[i, j] == 1)
                {
                    // Instantiate the food at (x, y)
                    Instantiate(Smietniki1,
                                new Vector2(j-7, i),
                                Quaternion.identity); // default rotation
                }
                if (plansza[i, j] == 2)
                {
                    // Instantiate the food at (x, y)
                    Instantiate(Smietniki2,
                                new Vector2(j-7,i),
                                Quaternion.identity); // default rotation
                }
                if (plansza[i, j] == 3)
                {
                    // Instantiate the food at (x, y)
                    Instantiate(Smietniki3,
                                new Vector2(j-7, i),
                                Quaternion.identity); // default rotation
                }
            }
    }


    //generowanie plansz
    int[,] Generuj(int[,] plansza)
    {
        // x position between left & right border
        int x1 = (int)Random.Range(0,
                                  15);

        // y position between top & bottom border
        int y1 = (int)Random.Range(0,
                                  5);

        while (plansza[y1, x1] != 0)
        {
            // x position between left & right border
            x1 = (int)Random.Range(0,
                                     15);

            // y position between top & bottom border
            y1 = (int)Random.Range(0,
                                      5);
        }

        plansza[y1, x1] = 1;

        // x position between left & right border
        int x2 = (int)Random.Range(0,
                                  15);

        // y position between top & bottom border
        int y2 = (int)Random.Range(0,
                                  5);

        while (plansza[y2, x2] != 0)
        {
            // x position between left & right border
            x2 = (int)Random.Range(0,
                                     15);

            // y position between top & bottom border
            y2 = (int)Random.Range(0,
                                      5);
        }

        plansza[y2, x2] = 2;

        // x position between left & right border
        int x3 = (int)Random.Range(0,
                                  15);

        // y position between top & bottom border
        int y3 = (int)Random.Range(0,
                                  5);

        while (plansza[y3, x3] != 0)
        {
            // x position between left & right border
            x3 = (int)Random.Range(0,
                                     15);

            // y position between top & bottom border
            y3 = (int)Random.Range(0,
                                      5);
        }

        plansza[y3, x3] = 3;

        return plansza;
    }
    
    int Kara(int wynik)
    {
        return wynik - 3;
    }

    //Czy śmietnik jest przy parku
    int Filtr1(int[,] gen)
    {
        int wynik = 0;
        //drzewo[1,3]
        if (gen[1, 2] == 1 || gen[1, 2] == 2 || gen[1, 2] == 3)
            wynik++;
        if (gen[2, 3] == 1 || gen[2, 3] == 2 || gen[2, 3] == 3) //+dzrewo[3,3]
            wynik=wynik+2;
        if (gen[0, 3] == 1 || gen[0, 3] == 2 || gen[0, 3] == 3)
            wynik++;

        //drzewo[1,6]
        if (gen[1, 5] == 1 || gen[1, 5] == 2 || gen[1, 5] == 3)
            wynik++;
        if (gen[2, 6] == 1 || gen[2, 6] == 2 || gen[2, 6] == 3) //+dzrewo[3,6]
            wynik = wynik + 2;
        if (gen[1, 7] == 1 || gen[1, 7] == 2 || gen[1, 7] == 3)
            wynik++;
        if (gen[0, 6] == 1 || gen[0, 6] == 2 || gen[0, 6] == 3)
            wynik++;

        //drzewo[1,10]
        if (gen[1, 9] == 1 || gen[1, 9] == 2 || gen[1, 9] == 3)
            wynik++;
        if (gen[2, 10] == 1 || gen[2, 10] == 2 || gen[2, 10] == 3) //+dzrewo[3,10]
            wynik = wynik + 2;
        if (gen[0, 10] == 1 || gen[0, 10] == 2 || gen[0, 10] == 3)
            wynik++;

        //drzewo[1,13]
        if (gen[1, 14] == 1 || gen[1, 14] == 2 || gen[1, 14] == 3)
            wynik++;
        if (gen[0, 13] == 1 || gen[0, 13] == 2 || gen[0, 13] == 3)
            wynik++;

        //drzewo[3,3]
        if (gen[3, 2] == 1 || gen[3, 2] == 2 || gen[3, 2] == 3)
            wynik++;
        if (gen[4, 3] == 1 || gen[4, 3] == 2 || gen[4, 3] == 3)
            wynik++;

        //drzewo[3,3]
        if (gen[3, 2] == 1 || gen[3, 2] == 2 || gen[3, 2] == 3)
            wynik++;
        if (gen[4, 3] == 1 || gen[4, 3] == 2 || gen[4, 3] == 3)
            wynik++;

        //drzewo[3,6]
        if (gen[4, 6] == 1 || gen[4, 6] == 2 || gen[4, 6] == 3)
            wynik++;
        if (gen[3, 7] == 1 || gen[3, 7] == 2 || gen[3, 7] == 3)
            wynik++;

        //drzewo[3,10]
        if (gen[3, 9] == 1 || gen[3, 9] == 2 || gen[3, 9] == 3)
            wynik++;
        if (gen[4, 10] == 1 || gen[4, 10] == 2 || gen[4, 10] == 3)
            wynik++;

        //drzewo[3,13]
        if (gen[4, 13] == 1 || gen[4, 13] == 2 || gen[4, 13] == 3)
            wynik++;
        if (gen[3, 14] == 1 || gen[3, 14] == 2 || gen[3, 14] == 3)
            wynik++;

        return wynik;
    }

    //Czy smietniki tego samego rodzaju nie są obok siebie
    int Filtr2(int[,] gen, int smietnik )
    {
        int wynik = 0;

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 15; j++)
            {
                if (gen[i, j] == smietnik)
                {
                    //spr top
                    int top = i + 1;
                    while (top <= i + 2 && top < 5 && gen[top, j] != -1 && gen[top, j] != -2)
                    {
                        if (gen[top, j] == gen[i, j])
                            wynik = Kara(wynik);
                        top++;
                    }

                    //spr bot
                    int bot = i - 1;
                    while (bot >= i - 2 && bot > -1 && gen[bot, j] != -1 && gen[bot, j] != -2)
                    {
                        if (gen[bot, j] == gen[i, j])
                            wynik = Kara(wynik);
                        bot--;
                    }

                    //spr left
                    int left = j - 1;
                    while (left >= j - 2 && left > -1 && gen[i, left] != -1 && gen[i, left] != -2)
                    {
                        if (gen[i, left] == gen[i, j])
                            wynik = Kara(wynik);
                        left--;
                    }

                    //spr right
                    int right = j + 1;
                    while (right <= j + 2 && right < 15 && gen[i, right] != -1 && gen[i, right] != -2)
                    {
                        if (gen[i, right] == gen[i, j])
                            wynik = Kara(wynik);
                        right++;
                    }

                }
            }

        return wynik;
    }
    
    //Czy smietniki rozne sa obok siebie
    int Filtr3(int[,] gen)
    {
        int wynik = 0;

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 15; j++)
            {
                if (gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3)
                {
                    //spr top
                    int top = i + 1;
                    if(top < 5)
                        if (gen[top, j] != gen[i, j] && gen[top, j] != -1 && gen[top, j] != -2 && gen[top, j] != 0)
                            wynik++;

                    //spr bot
                    int bot = i - 1;
                    if (bot > -1)
                        if (gen[bot, j] != gen[i, j] && gen[bot, j] != -1 && gen[bot, j] != -2 && gen[bot,j]!=0)
                            wynik++;

                    //spr left
                    int left = j - 1;
                    if(left > -1)
                        if (gen[i, left] != gen[i, j]  && gen[i, left] != -1 && gen[i, left] != -2 && gen[i, left] != 0)
                            wynik++;

                    //spr right
                    int right = j + 1;
                    if(right < 15)
                        if (gen[i, right] != gen[i, j] && gen[i, right] != -1 && gen[i, right] != -2 && gen[i, right] != 0)
                            wynik++;

                }
            }

        return wynik;
    }

    //liczba smietnikow i ich rodzajow
    int Filtr4(int[,] gen)
    {
        int wynik = 0;
        int liczba_plastik = 0;
        int liczba_papier = 0;
        int liczba_aluminium = 0;

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 15; j++)
            {
                if (gen[i, j] == 1)
                    liczba_plastik++;
                if (gen[i, j] == 1)
                    liczba_papier++;
                if (gen[i, j] == 1)
                    liczba_aluminium++;
            }

        if (liczba_plastik < ilosc_rodzaju)
            wynik = wynik + ilosc_rodzaju - liczba_plastik;
        else
            wynik = wynik - ilosc_rodzaju + liczba_plastik;

        if (liczba_papier < ilosc_rodzaju)
            wynik = wynik + ilosc_rodzaju - liczba_papier;
        else
            wynik = wynik - ilosc_rodzaju + liczba_papier;

        if (liczba_aluminium < ilosc_rodzaju)
            wynik = wynik + ilosc_rodzaju - liczba_aluminium;
        else
            wynik = wynik - ilosc_rodzaju + liczba_aluminium;

        if (liczba_plastik + liczba_papier + liczba_aluminium < ilosc_smietnikow)
            wynik = wynik + ilosc_smietnikow - (liczba_plastik + liczba_papier + liczba_aluminium);
        else
            wynik = wynik - ilosc_smietnikow + liczba_plastik + liczba_papier + liczba_aluminium;

        return wynik;
    }
    
    //Czy są ustawione x śmietników obok siebie;
    int Filtr5(int[,] gen)
    {
        int wynik = 0;
        int wynikZnalezionegoRzedu = 0;
        int licznik = 0;
        for(int i = 0; i<5; i++)
            for(int j = 0; j<15; j++)
            {
                if ((gen[i, j] == 1 || gen[i, j] == 2 || gen[i,j]==3) && licznik <4)
                    {
                            wynikZnalezionegoRzedu++;
                            licznik++;
                     }

                if ((gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3) && licznik == 4)
                {
                    wynikZnalezionegoRzedu = -1;
                    licznik++;
                }

                if ((gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3) && licznik > 4)
                {
                    wynikZnalezionegoRzedu--;
                    licznik++;
                }
                if ((gen[i, j] == -1 || gen[i,j]==-2 || gen[i,j]==0))
                {
                    licznik = 0;
                    wynik = wynik + wynikZnalezionegoRzedu;
                    wynikZnalezionegoRzedu = 0;
                }                        
            }
        licznik = 0;
        wynik = wynik + wynikZnalezionegoRzedu;
        wynikZnalezionegoRzedu = 0;
        for (int j = 0; j < 15; j++)
            for (int i = 0; i < 5; i++)
            {
                if ((gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3) && licznik < 4)
                {
                    wynikZnalezionegoRzedu++;
                    licznik++;
                }

                if ((gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3) && licznik == 4)
                {
                    wynikZnalezionegoRzedu = -1;
                    licznik++;
                }

                if ((gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3) && licznik > 4)
                {
                    wynikZnalezionegoRzedu--;
                    licznik++;
                }
                if ((gen[i, j] == -1 || gen[i, j] == -2 || gen[i, j] == 0))
                {
                    licznik = 0;
                    wynik = wynik + wynikZnalezionegoRzedu;
                    wynikZnalezionegoRzedu = 0;
                }
            }

        wynik = wynik + wynikZnalezionegoRzedu;

        return wynik;
    }

    //ocena 1/4 do poprawy ilosc w 2 cwirtach kolo 6
    int Ocena(int[,] gen, int y, int x)
    {
        int liczba = 0;
        //1 ćwiartka
        if (y == 0 && x == 0)
            for (int i = y; i < 2; i++)
                for (int j = x; j < 8; j++)
                    if (gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3)
                        liczba++;

        //2 cwiartka
        if (y == 0 && x == 8)
            for (int i = y; i < 2; i++)
                for (int j = x; j < 15; j++)
                    if (gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3)
                        liczba++;

        //3 cwiartka
        if (y == 2 && x == 0)
            for (int i = y; i < 5; i++)
                for (int j = x; j < 8; j++)
                    if (gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3)
                        liczba++;

        //4 cwiartka
        if (y == 2 && x == 8)
            for (int i = y; i < 5; i++)
                for (int j = x; j < 15; j++)
                    if (gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3)
                        liczba++;

        return liczba;
    }
    
    //ile smietnikow na planszy
    int Liczebnosc(int[,] gen)
    {
        int liczebnosc = 0;
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 15; j++)
                if (gen[i, j] == 1 || gen[i, j] == 2 || gen[i, j] == 3)
                    liczebnosc++;

        return liczebnosc;
    }

    void Skrzyzowanie(int[,]genX, int[,]genY)
    {
        int x = (int)Random.Range(0,15);
        int y = (int)Random.Range(0, 5);
        int szansa_mutacji = (int)Random.Range(1, 21);
        int[,] plansza = genX;
        int[,] plansza2 = genY;

        for(int i=0; i<x; i++)
            for(int j=0; j<y; j++)
            {
                genX[i, j] = plansza[i, j];
                genY[i, j] = plansza2[i, j];
            }

        for (int i = x; i < 5; i++)
            for (int j = y; j < 15; j++)
            {
                genX[i, j] = plansza2[i, j];
                genY[i, j] = plansza[i, j];
            }
        
        if(szansa_mutacji==20)
        {
            int pierwszyLubDrugi = (int)Random.Range(1, 4);
            if (pierwszyLubDrugi == 1)
                Mutacja(genX);
            if (pierwszyLubDrugi == 2)
                Mutacja(genX);
            if (pierwszyLubDrugi == 3)
            {
                Mutacja(genX);
                Mutacja(genY);
            }
        }

    }

    int[,] Mutacja(int[,]gen)
    {

        int smietnik = (int)Random.Range(1,
                                  7);
        if(smietnik==1)
        {
            // x position between left & right border
            int x1 = (int)Random.Range(0,
                                      15);

            // y position between top & bottom border
            int y1 = (int)Random.Range(0,
                                      5);

            while (gen[y1, x1] != 0)
            {
                // x position between left & right border
                x1 = (int)Random.Range(0,
                                         15);

                // y position between top & bottom border
                y1 = (int)Random.Range(0,
                                          5);
            }

            gen[y1, x1] = 1;
        }

        if (smietnik == 2)
        {
            // x position between left & right border
            int x1 = (int)Random.Range(0,
                                      15);

            // y position between top & bottom border
            int y1 = (int)Random.Range(0,
                                      5);

            while (gen[y1, x1] != 0)
            {
                // x position between left & right border
                x1 = (int)Random.Range(0,
                                         15);

                // y position between top & bottom border
                y1 = (int)Random.Range(0,
                                          5);
            }

            gen[y1, x1] = 2;
        }

        if (smietnik == 3)
        {
            // x position between left & right border
            int x1 = (int)Random.Range(0,
                                      15);

            // y position between top & bottom border
            int y1 = (int)Random.Range(0,
                                      5);

            while (gen[y1, x1] != 0)
            {
                // x position between left & right border
                x1 = (int)Random.Range(0,
                                         15);

                // y position between top & bottom border
                y1 = (int)Random.Range(0,
                                          5);
            }

            gen[y1, x1] = 3;
        }
        //degradacja
        if (smietnik == 4)
        {
            // x position between left & right border
            int x1 = (int)Random.Range(0,
                                      15);

            // y position between top & bottom border
            int y1 = (int)Random.Range(0,
                                      5);

            while (gen[y1, x1] != 1)
            {
                // x position between left & right border
                x1 = (int)Random.Range(0,
                                         15);

                // y position between top & bottom border
                y1 = (int)Random.Range(0,
                                          5);
            }

            gen[y1, x1] = 0;
        }

        if (smietnik == 5)
        {
            // x position between left & right border
            int x1 = (int)Random.Range(0,
                                      15);

            // y position between top & bottom border
            int y1 = (int)Random.Range(0,
                                      5);

            while (gen[y1, x1] != 2)
            {
                // x position between left & right border
                x1 = (int)Random.Range(0,
                                         15);

                // y position between top & bottom border
                y1 = (int)Random.Range(0,
                                          5);
            }

            gen[y1, x1] = 0;
        }

        if (smietnik == 6)
        {
            // x position between left & right border
            int x1 = (int)Random.Range(0,
                                      15);

            // y position between top & bottom border
            int y1 = (int)Random.Range(0,
                                      5);

            while (gen[y1, x1] != 3)
            {
                // x position between left & right border
                x1 = (int)Random.Range(0,
                                         15);

                // y position between top & bottom border
                y1 = (int)Random.Range(0,
                                          5);
            }

            gen[y1, x1] = 0;
        }

        return Generuj(gen);
    }

    int[,] AlgorythmGenetic()
    {
        int[,] osobnik = plansza1;
        int ocena=8;
        //generacja genów
        int[,] gen1 = Generuj(plansza1);
        int[,] gen2 = Generuj(plansza1);
        int[,] gen3 = Generuj(plansza1);
        int[,] gen4 = Generuj(plansza1);

        //ocena genów
        int ocena1 = Filtr1(gen1) + Filtr2(gen1, 1) + Filtr2(gen1, 2) + Filtr2(gen1, 3) + Filtr3(gen1) + Filtr4(gen1) + Filtr5(gen1);
        int ocena2 = Filtr1(gen2) + Filtr2(gen2, 1) + Filtr2(gen2, 2) + Filtr2(gen2, 3) + Filtr3(gen2) + Filtr4(gen2) + Filtr5(gen2);
        int ocena3 = Filtr1(gen3) + Filtr2(gen3, 1) + Filtr2(gen3, 2) + Filtr2(gen3, 3) + Filtr3(gen3) + Filtr4(gen3) + Filtr5(gen3);
        int ocena4 = Filtr1(gen4) + Filtr2(gen4, 1) + Filtr2(gen4, 2) + Filtr2(gen4, 3) + Filtr3(gen4) + Filtr4(gen4) + Filtr5(gen4);

        int[] tabela_ocen = { ocena1, ocena2, ocena3, ocena4 };
        int ilosc_skrzyzowan = 0;
        int max;
        int numer;
        int suma_ocen;
        int[] szansa = new int[3];
        int wybrany_osobnik1;
        int wybrany_osobnik2;
        while (ilosc_skrzyzowan<10 && ocena1< ocena && ocena2 < ocena && ocena3 < ocena && ocena4 < ocena)
        {
            
            max = ocena1;
            numer = 0;
            suma_ocen = ocena1 + ocena2 + ocena3 + ocena4;
            for(int i=0; i<3; i++)
                szansa[i] = tabela_ocen[i] / suma_ocen;

            wybrany_osobnik1 = (int)Random.Range(1, 101);

            if(wybrany_osobnik1<=szansa[0])
            {
                wybrany_osobnik2 = (int)Random.Range(szansa[0] + 1, 101);
                if(wybrany_osobnik2<=szansa[0]+szansa[1])
                {
                    gen3 = gen1;
                    gen4 = Mutacja(gen1);
                    Skrzyzowanie(gen1,gen2);
                }
                if (wybrany_osobnik2 > szansa[0]+szansa[1] && wybrany_osobnik2 <= szansa[0] + szansa[1]+szansa[2])
                {
                    gen2 = gen1;
                    gen4 = Mutacja(gen1);
                    Skrzyzowanie(gen1, gen3);
                }
                if (wybrany_osobnik2 > szansa[0] + szansa[1] + szansa[2])
                {
                    gen2 = gen1;
                    gen3 = Mutacja(gen1);
                    Skrzyzowanie(gen1, gen4);
                }
            }

            if (wybrany_osobnik1 > szansa[0] && wybrany_osobnik1 <= szansa[0]+szansa[1])
            {
                wybrany_osobnik2 = (int)Random.Range(1, 101);
                while(wybrany_osobnik2 > szansa[0] && wybrany_osobnik2 <= szansa[0] + szansa[1])
                    wybrany_osobnik2 = (int)Random.Range(1, 101);

                if (wybrany_osobnik2 <= szansa[0])
                {
                    gen3 = gen2;
                    gen4 = Mutacja(gen2);
                    Skrzyzowanie(gen2, gen1);
                }
                if (wybrany_osobnik2 > szansa[0] + szansa[1] && wybrany_osobnik2 <= szansa[0] + szansa[1] + szansa[2])
                {
                    gen1 = gen2;
                    gen4 = Mutacja(gen2);
                    Skrzyzowanie(gen2, gen3);
                }
                if (wybrany_osobnik2 > szansa[0] + szansa[1] + szansa[2])
                {
                    gen1 = gen2;
                    gen3 = Mutacja(gen2);
                    Skrzyzowanie(gen2, gen4);
                }
            }

            if (wybrany_osobnik1 > szansa[0] + szansa[1] && wybrany_osobnik1 <= szansa[0] + szansa[1] + szansa[2])
            {
                wybrany_osobnik2 = (int)Random.Range(1, 101);
                while (wybrany_osobnik1 > szansa[0] + szansa[1] && wybrany_osobnik1 <= szansa[0] + szansa[1] + szansa[2])
                    wybrany_osobnik2 = (int)Random.Range(1, 101);

                if (wybrany_osobnik2 <= szansa[0])
                {
                    gen2 = gen3;
                    gen4 = Mutacja(gen3);
                    Skrzyzowanie(gen3, gen1);
                }
                if (wybrany_osobnik2 > szansa[0] && wybrany_osobnik2 <= szansa[0] + szansa[1])
                {
                    gen1 = gen3;
                    gen4 = Mutacja(gen3);
                    Skrzyzowanie(gen3, gen2);
                }
                if (wybrany_osobnik2 > szansa[0] + szansa[1] + szansa[2])
                {
                    gen1 = gen3;
                    gen2 = Mutacja(gen3);
                    Skrzyzowanie(gen3, gen4);
                }
            }

            if (wybrany_osobnik1 > szansa[0] + szansa[1] + szansa[2])
            {
                wybrany_osobnik2 = (int)Random.Range(1, szansa[0] + szansa[1] + szansa[2]) + 1;

                if (wybrany_osobnik2 <= szansa[0])
                {
                    gen2 = gen4;
                    gen3 = Mutacja(gen4);
                    Skrzyzowanie(gen4, gen1);
                }
                if (wybrany_osobnik2 > szansa[0] && wybrany_osobnik2 <= szansa[0] + szansa[1])
                {
                    gen1 = gen4;
                    gen3 = Mutacja(gen4);
                    Skrzyzowanie(gen4, gen2);
                }
                if (wybrany_osobnik2 > szansa[0] + szansa[1] && wybrany_osobnik2 <= szansa[0] + szansa[1] + szansa[2])
                {
                    gen1 = gen4;
                    gen2 = Mutacja(gen4);
                    Skrzyzowanie(gen4, gen3);
                }
            }

            ocena1 = Filtr1(gen1) + Filtr2(gen1, 1) + Filtr2(gen1, 2) + Filtr2(gen1, 3) + Filtr3(gen1) + Filtr4(gen1) + Filtr5(gen1);
            ocena2 = Filtr1(gen2) + Filtr2(gen2, 1) + Filtr2(gen2, 2) + Filtr2(gen2, 3) + Filtr3(gen2) + Filtr4(gen2) + Filtr5(gen2);
            ocena3 = Filtr1(gen3) + Filtr2(gen3, 1) + Filtr2(gen3, 2) + Filtr2(gen3, 3) + Filtr3(gen3) + Filtr4(gen3) + Filtr5(gen3);
            ocena4 = Filtr1(gen4) + Filtr2(gen4, 1) + Filtr2(gen4, 2) + Filtr2(gen4, 3) + Filtr3(gen4) + Filtr4(gen4) + Filtr5(gen4);

            tabela_ocen[0] = ocena1;
            tabela_ocen[1] = ocena2;
            tabela_ocen[2] = ocena3;
            tabela_ocen[3] = ocena4;

            ilosc_skrzyzowan++;
        }

        
        max= ocena1;
        numer = 0;

        for (int i = 1; i < 4; i++)
            if (max < tabela_ocen[i])
            {
                max = tabela_ocen[i];
                numer = i;
            }


        if (numer == 0)
        {
            osobnik = gen1;

        }

        if (numer == 1)
        {
            osobnik = gen2;

        }

        if (numer == 2)
        {
            osobnik = gen3;
        }

        if (numer == 3)
        {
            osobnik = gen4;
        }

        return osobnik;
    }
}
