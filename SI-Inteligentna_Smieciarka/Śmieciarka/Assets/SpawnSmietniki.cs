using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class SpawnSmietniki : MonoBehaviour {

    public GameObject Smietniki1;
    public GameObject Smietniki2;
    public GameObject Smietniki3;
    static int[] plansza1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,
                        0, -1, 0, -2, -1, 0, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0 ,
                        0, -1, 0, -2, -1, -1, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };
    static int[] plansza2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,
                        0, -1, 0, -2, -1, 0, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0 ,
                        0, -1, 0, -2, -1, -1, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };
    static int[] plansza3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,
                        0, -1, 0, -2, -1, 0, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0 ,
                        0, -1, 0, -2, -1, -1, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };
    static int[] plansza4 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,
                        0, -1, 0, -2, -1, 0, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0 ,
                        0, -1, 0, -2, -1, -1, -2, 0, -1, 0, -2, -1, -1, -2, 0 ,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };


    // Use this for initialization
    void Start () {
        // Spawn food every 4 seconds, starting in 3
        Spawn();
    }

    // Spawn
    void Spawn()
    {
        int[] plansza = AlgorythmGenetic();
        //int[,] plansza = Generuj(plansza1);
        int z = 0;
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 15; j++)
            {
                if (plansza[z] == 1)
                {
                    // Instantiate the food at (x, y)
                    Instantiate(Smietniki1,
                                new Vector2(j-7, i),
                                Quaternion.identity); // default rotation
                }
                if (plansza[z] == 2)
                {
                    // Instantiate the food at (x, y)
                    Instantiate(Smietniki2,
                                new Vector2(j-7,i),
                                Quaternion.identity); // default rotation
                }
                if (plansza[z] == 3)
                {
                    // Instantiate the food at (x, y)
                    Instantiate(Smietniki3,
                                new Vector2(j-7, i),
                                Quaternion.identity); // default rotation
                }
                z++;
            }
    }


    //generowanie plansz
    int[] Generuj(int[] plansza)
    {
        // x position between left & right border
        int bit = Random.Range(0,
                                  75);

        while (plansza[bit] != 0)
        {
            bit = Random.Range(0,
                                  75);
        }

        plansza[bit] = 1;

        bit = Random.Range(0,
                                  75);

        while (plansza[bit] != 0)
        {
            bit = Random.Range(0,
                                  75);
        }

        plansza[bit] = 2;

        // x position between left & right border
        bit = Random.Range(0,
                                  75);

        while (plansza[bit] != 0)
        {
            bit = Random.Range(0,
                                  75);
        }

        plansza[bit] = 3;

        return plansza;
    }
    
    int Kara(int wynik)
    {
        return wynik - 1;
    }

    //Czy śmietnik jest przy parku
    int Filtr1(int[] osobnik)
    {
        int wynik = 0;
        //drzewo[1,3] 18
        if (osobnik[17] == 1 || osobnik[17] == 2 || osobnik[17] == 3)
            wynik++;
        if (osobnik[33] == 1 || osobnik[33] == 2 || osobnik[33] == 3) //+dzrewo[3,3] 48
            wynik=wynik+2;
        if (osobnik[3] == 1 || osobnik[3] == 2 || osobnik[3] == 3)
            wynik++;

        //drzewo[1,6] 21
        if (osobnik[20] == 1 || osobnik[20] == 2 || osobnik[20] == 3)
            wynik++;
        if (osobnik[36] == 1 || osobnik[36] == 2 || osobnik[36] == 3) //+dzrewo[3,6] 51
            wynik = wynik + 2;
        if (osobnik[22] == 1 || osobnik[22] == 2 || osobnik[22] == 3)
            wynik++;
        if (osobnik[6] == 1 || osobnik[6] == 2 || osobnik[6] == 3)
            wynik++;

        //drzewo[1,10] 25
        if (osobnik[24] == 1 || osobnik[24] == 2 || osobnik[24] == 3)
            wynik++;
        if (osobnik[40] == 1 || osobnik[40] == 2 || osobnik[40] == 3) //+dzrewo[3,10] 55
            wynik = wynik + 2;
        if (osobnik[10] == 1 || osobnik[10] == 2 || osobnik[10] == 3)
            wynik++;

        //drzewo[1,13] 28
        if (osobnik[29] == 1 || osobnik[29] == 2 || osobnik[29] == 3)
            wynik++;
        if (osobnik[13] == 1 || osobnik[13] == 2 || osobnik[13] == 3)
            wynik++;

        //drzewo[3,3] 48
        if (osobnik[47] == 1 || osobnik[47] == 2 || osobnik[47] == 3)
            wynik++;
        if (osobnik[63] == 1 || osobnik[63] == 2 || osobnik[63] == 3)
            wynik++;

        //drzewo[3,6] 51
        if (osobnik[66] == 1 || osobnik[66] == 2 || osobnik[66] == 3)
            wynik++;
        if (osobnik[52] == 1 || osobnik[52] == 2 || osobnik[52] == 3)
            wynik++;

        //drzewo[3,10] 55
        if (osobnik[54] == 1 || osobnik[54] == 2 || osobnik[54] == 3)
            wynik++;
        if (osobnik[70] == 1 || osobnik[70] == 2 || osobnik[70] == 3)
            wynik++;

        //drzewo[3,13] 58
        if (osobnik[73] == 1 || osobnik[73] == 2 || osobnik[73] == 3)
            wynik++;
        if (osobnik[59] == 1 || osobnik[59] == 2 || osobnik[59] == 3)
            wynik++;

        return wynik;
    }

    //Czy smietniki tego samego rodzaju nie są obok siebie
    int Filtr2(int[] osobnik, int smietnik )
    {
        int wynik = 0;

        for (int i = 0; i < 75; i++)
        {
            if (osobnik[i] == smietnik)
            {
                //spr top
                int top = i + 15;
                while (top <= i + 30 && top < 75 && osobnik[top] != -1 && osobnik[top] != -2)
                {
                    if (osobnik[top] == osobnik[i])
                        wynik = Kara(wynik);
                    top = top + 15;
                }

                //spr bot
                int bot = i - 15;
                while (bot >= i - 30 && bot > -1 && osobnik[bot] != -1 && osobnik[bot] != -2)
                {
                    if (osobnik[bot] == osobnik[i])
                        wynik = Kara(wynik);
                    bot = bot - 15;
                }

                //spr left
                int left = i - 1;
                while (left >= i - 2 && left % 15 != 14 && left > -1 && osobnik[left] != -1 && osobnik[left] != -2)
                {
                    if (osobnik[left] == osobnik[i])
                        wynik = Kara(wynik);
                    left--;
                }

                //spr right
                int right = i + 1;
                while (right <= i + 2 && right % 15 != 0 && right < 75 && osobnik[right] != -1 && osobnik[right] != -2)
                {
                    if (osobnik[right] == osobnik[i])
                        wynik = Kara(wynik);
                    right++;
                }

            }
        }

        return wynik;
    }
    
    //Czy smietniki rozne sa obok siebie
    int Filtr3(int[] osobnik)
    {
        int wynik = 0;

        for (int i = 0; i < 75; i++)
        {
            if (osobnik[i] == 1 || osobnik[i] == 2 || osobnik[i] == 3)
            {
                //spr top
                int top = i + 15;
                if (top < 75)
                    if (osobnik[top] != osobnik[i] && osobnik[top] != -1 && osobnik[top] != -2 && osobnik[top] != 0)
                        wynik++;

                //spr bot
                int bot = i - 15;
                if (bot > -1)
                    if (osobnik[bot] != osobnik[i] && osobnik[bot] != -1 && osobnik[bot] != -2 && osobnik[bot] != 0)
                        wynik++;

                //spr left
                int left = i - 1;
                if (left > -1 && left % 15 != 14)
                    if (osobnik[left] != osobnik[i] && osobnik[left] != -1 && osobnik[left] != -2 && osobnik[left] != 0)
                        wynik++;

                //spr right
                int right = i + 1;
                if (right < 75 && right % 15 != 0)
                    if (osobnik[right] != osobnik[i] && osobnik[right] != -1 && osobnik[right] != -2 && osobnik[right] != 0)
                        wynik++;

            }
        }

            return wynik;
    }

    //liczba smietnikow i ich rodzajow oraz miejsca wolnego
    int Filtr4(int[] osobnik)
    {
        int wynik = 0;
        int liczba_plastik = 0;
        int liczba_papier = 0;
        int liczba_aluminium = 0;
        int wolne_miejsce = 53;
        int ilosc_smietnikow = 9;
        int ilosc_rodzaju = 3;

        for (int i = 0; i < 75; i++)
        {
            if (osobnik[i] == 1)
                liczba_plastik++;
            if (osobnik[i] == 2)
                liczba_papier++;
            if (osobnik[i] == 3)
                liczba_aluminium++;
        }

        wolne_miejsce = 53 - liczba_aluminium - liczba_papier - liczba_plastik;

        if (liczba_plastik <= ilosc_rodzaju)
            wynik = wynik + liczba_plastik;

        if (liczba_papier <= ilosc_rodzaju)
            wynik = wynik + liczba_papier;

        if (liczba_aluminium <= ilosc_rodzaju)
            wynik = wynik + liczba_aluminium;

        if(wolne_miejsce>40 && wolne_miejsce<50)
            wynik = wynik + wolne_miejsce;

        if (wolne_miejsce <= 40)
            wynik = wynik - (53 - wolne_miejsce);

        if (liczba_plastik + liczba_papier + liczba_aluminium <= ilosc_smietnikow)
            wynik = wynik + liczba_plastik + liczba_papier + liczba_aluminium;

        return wynik;
    }
    
    //Czy są ustawione x śmietników obok siebie;
    int Filtr5(int[] osobnik)
    {
        int wynik = 0;
        int licznik = 0;

        for (int i = 0; i < 5; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (osobnik[i] == 1 || osobnik[i] == 2 || osobnik[i] == 3)
                    {
                        //spr top
                        int top = i + 15;
                        while (top <= i + 4*15 && top < 75 && osobnik[top] != -1 && osobnik[top] != -2 && osobnik[top] != 0)
                        {
                            licznik++;
                            top++;
                        }

                        //spr bot
                        int bot = i - 15;
                        while (bot >= i - 4*15 && bot > -1 && osobnik[bot] != -1 && osobnik[bot] != -2 && osobnik[bot] != 0)
                        {
                            licznik++;
                            bot--;
                        }

                        //spr left
                        int left = i - 1;
                        while (left >= i - 4 && left > -1  && left%15 != 14 && osobnik[left] != -1 && osobnik[left] != -2 && osobnik[left] != 0)
                        {
                            licznik++;
                            left--;
                        }

                        //spr right
                        int right = i + 1;
                        while (right <= i + 4 && right < 75  && right%15 != 0 && osobnik[right] != -1 && osobnik[right] != -2 && osobnik[right] != 0)
                        {
                            licznik++;
                            right++;
                        }

                        if (licznik == 1)
                        { //spr top_right
                            int top_right = i + 16;                      
                            while (top_right <= i + 4*16 && top_right < 75 && top_right%15 != 0 && osobnik[top_right] != -1 && osobnik[top_right] != -2 && osobnik[top_right] != 0)
                            {
                                licznik++;
                                top_right = top_right + 16;
                            }

                            //spr top_left
                            int top_left = i + 14;
                            while (top_left <= i + 4*14 && top_left < 75 && top_left%15 != 14 && osobnik[top_left] != -1 && osobnik[top_left] != -2 && osobnik[top_left] != 0)
                            {
                                licznik++;
                                top_left = top_left + 14;
                            }

                            //spr bot_right
                            int bot_right = i - 14;
                            while (bot_right >= i - 4*14 && bot_right > -1 && bot_right%15 != 0 && osobnik[bot_right] != -1 && osobnik[bot_right] != -2 && osobnik[bot_right] != 0)
                            {
                                licznik++;
                                bot_right = bot_right - 14;
                            }

                            //spr bot_left
                            int bot_left = i - 16;
                            while (bot_left >= i - 4*16 && bot_left > -1 && bot_left%15 != 14  && osobnik[bot_left] != -1 && osobnik[bot_left] != -2 && osobnik[bot_left] != 0)
                            {
                                licznik++;
                                bot_left = bot_left - 16;
                            }
                        }

                        if (licznik == 0)
                            wynik++;

                        if (licznik == 1)
                            wynik = wynik + 2;

                        if (licznik == 2)
                            wynik = wynik + 3;

                        licznik = 0;
                    }
                }
        
        return wynik;
    }

    Plansze Skrzyzowanie(int[] osobnik1, int[] osobnik2)
    {
        int podzial = Random.Range(0, 75);
        int szansa_mutacji1 = Random.Range(1, 21);
        int szansa_mutacji2 = Random.Range(1, 21);
        int[] tabela1 = new int[75] ;
        int[] tabela2 = new int[75];

        for (int i=0; i<podzial; i++)
        {
             tabela1[i] = osobnik1[i];
             tabela2[i] = osobnik2[i];
        }

        for (int i = podzial; i < 75; i++)
        {
            tabela2[i] = osobnik1[i];
            tabela1[i] = osobnik2[i];
        }

        if (szansa_mutacji1 == 20)
            tabela1 = Mutacja(tabela1);
        if (szansa_mutacji2 == 20)
            tabela2 = Mutacja(tabela2);
        Plansze geny = new Plansze(tabela1, tabela2);
        return geny;
    }

    int[] Mutacja(int[] osobnik)
    {

        int smietnik = Random.Range(1,
                                  7);
        int mutacja = Random.Range(0,
                                         75);
        if (smietnik==1)
        {

            while (osobnik[mutacja] == -1 || osobnik[mutacja] == -2)
            {
                mutacja = Random.Range(0,
                                          75);
            }

            osobnik[mutacja] = 1;
        }

        if (smietnik == 2)
        {

            while (osobnik[mutacja] == -1 || osobnik[mutacja] == -2)
            {
                mutacja = Random.Range(0,
                                          75);
            }

            osobnik[mutacja] = 2;
        }

        if (smietnik == 3)
        {
            while (osobnik[mutacja] == -1 || osobnik[mutacja] == -2)
            {
                mutacja = Random.Range(0,
                                          75);
            }

            osobnik[mutacja] = 3;
        }
        //degradacja
        if (smietnik > 3)
        {
            while (osobnik[mutacja] == -1 || osobnik[mutacja] == -2)
            {
                mutacja = Random.Range(0,
                                          75);
            }

            osobnik[mutacja] = 0;
        }

        return osobnik;
    }

    int[] AlgorythmGenetic()
    {
        // This is the name of the file holding the data. You can use any file extension you like.
        string fileName = "C:\\Users\\X\\Desktop\\SZTUCZNA\\SI-Inteligentna_Smieciarka\\dataOsobniki.cjc";

        // Use a BinaryFormatter or SoapFormatter.
        IFormatter formatter = new BinaryFormatter();

        int[] osobnik = plansza1;
        //generacja genów
        Plansze osobniki = new Plansze();
        if (File.Exists(fileName))
        {
            Plansze a = Plansze.DeserializeItem(fileName, formatter); // Deserialize the instance.
            osobniki.plansza1 = a.plansza1;
            osobniki.plansza2 = a.plansza2;
            osobniki.plansza3 = a.plansza3;
            osobniki.plansza4 = a.plansza4;
        }
        else
        {
            //generacja genów
            osobniki.plansza1 = Generuj(Generuj(Generuj(plansza1)));
            
            osobniki.plansza2 = Generuj(Generuj(Generuj(plansza2)));
            
            osobniki.plansza3 = Generuj(Generuj(Generuj(Generuj(plansza3))));
            
            osobniki.plansza4 = Generuj(Generuj(plansza4));
           
        }

        //ocena genów
        int ocena1 = Filtr1(osobniki.plansza1) + Filtr2(osobniki.plansza1, 1) + Filtr2(osobniki.plansza1, 2) +  Filtr2(osobniki.plansza1, 3) + Filtr4(osobniki.plansza1);
        int ocena2 = Filtr1(osobniki.plansza2) + Filtr2(osobniki.plansza2, 1) + Filtr2(osobniki.plansza2, 2) + Filtr2(osobniki.plansza2, 3) + Filtr4(osobniki.plansza2);
        int ocena3 = Filtr1(osobniki.plansza3) + Filtr2(osobniki.plansza3, 1) + Filtr2(osobniki.plansza3, 2) + Filtr2(osobniki.plansza3, 3) + Filtr4(osobniki.plansza3);
        int ocena4 = Filtr1(osobniki.plansza4) + Filtr2(osobniki.plansza4, 1) + Filtr2(osobniki.plansza4, 2) + Filtr2(osobniki.plansza4, 3) + Filtr4(osobniki.plansza4);
        string wiadomosc = "start:\n" + Filtr1(osobniki.plansza1) + " " + Filtr2(osobniki.plansza1, 1) + " " + Filtr2(osobniki.plansza1, 2) + " " + Filtr2(osobniki.plansza1, 3) + " " + Filtr3(osobniki.plansza1) + " " + Filtr4(osobniki.plansza1) + " " + Filtr5(osobniki.plansza1) + "\n" +
            Filtr1(osobniki.plansza2) + " " + Filtr2(osobniki.plansza2, 1) + " " + Filtr2(osobniki.plansza2, 2) + " " + Filtr2(osobniki.plansza2, 3) + " " + Filtr3(osobniki.plansza2) + " " + Filtr4(osobniki.plansza2) + " " + Filtr5(osobniki.plansza2) + "\n" +
            Filtr1(osobniki.plansza3) + " " + Filtr2(osobniki.plansza3, 1) + " " + Filtr2(osobniki.plansza3, 2) + " " + Filtr2(osobniki.plansza3, 3) + " " + Filtr3(osobniki.plansza3) + " " + Filtr4(osobniki.plansza3) + " " + Filtr5(osobniki.plansza3) + "\n" +
            Filtr1(osobniki.plansza4) + " " + Filtr2(osobniki.plansza4, 1) + " " + Filtr2(osobniki.plansza4, 2) + " " + Filtr2(osobniki.plansza4, 3) + " " + Filtr3(osobniki.plansza4) + " " + Filtr4(osobniki.plansza4) + " " + Filtr5(osobniki.plansza4) + "\n";
        int[] tabela_ocen = { ocena1, ocena2, ocena3, ocena4 };

        for (int i = 0; i < 4; i++)
            if (tabela_ocen[i] < 1)
                tabela_ocen[i] = 1;

        int ilosc_skrzyzowan = 0;
        int suma_ocen;
        int[] szansa = new int[3];
        wiadomosc = wiadomosc + "Tabela ocen: " + tabela_ocen[0] + " " + tabela_ocen[1] + " " + tabela_ocen[2] + " " + tabela_ocen[3] + "\n";

        while (ilosc_skrzyzowan<20)
        {
            suma_ocen = tabela_ocen[0] + tabela_ocen[1] + tabela_ocen[2] + tabela_ocen[3];
            wiadomosc = wiadomosc + "Suma ocen: " + suma_ocen + "\n";
            for (int i = 0; i < 3; i++)
                if (suma_ocen != 0)
                    szansa[i] = (tabela_ocen[i] * 100) / suma_ocen;
                else
                    szansa[i] = 0;

            int wybrany_osobnik11 = Random.Range(1, 101);
            wiadomosc = wiadomosc + "Wylosowany numer: " + wybrany_osobnik11 + "\nszanse wylosowania: " + szansa[0] + " " + szansa[1] + " " + szansa[2] +  "\nWylosowane osobniki: ";
            if (wybrany_osobnik11<=szansa[0])
            {
                int wybrany_osobnik12 = Random.Range(szansa[0] + 1, 101);
                if(wybrany_osobnik12<=szansa[0]+szansa[1])
                {
                    int mutacja1 = Random.Range(1,21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza3 = Mutacja(osobniki.plansza1);
                    else
                        osobniki.plansza3 = osobniki.plansza1;
                    if(mutacja2==20)
                        osobniki.plansza4 = Mutacja(osobniki.plansza2);
                    else
                        osobniki.plansza4 = osobniki.plansza2;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza1, osobniki.plansza2);
                    osobniki.plansza1 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza2 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "12\n";
                }
                if (wybrany_osobnik12 > szansa[0]+szansa[1] && wybrany_osobnik12 <= szansa[0] + szansa[1]+szansa[2])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza2 = Mutacja(osobniki.plansza1);
                    else
                        osobniki.plansza2 = osobniki.plansza1;
                    if (mutacja2==20)
                        osobniki.plansza4 = Mutacja(osobniki.plansza3);
                    else
                        osobniki.plansza4 = osobniki.plansza3;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza1, osobniki.plansza3);
                    osobniki.plansza1 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza3 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "13\n";
                }
                if (wybrany_osobnik12 > szansa[0] + szansa[1] + szansa[2])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza2 = Mutacja(osobniki.plansza1);
                    else
                        osobniki.plansza2 = osobniki.plansza1;
                    if(mutacja2==20)
                        osobniki.plansza3 = Mutacja(osobniki.plansza4);
                    else
                        osobniki.plansza3 = osobniki.plansza4;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza1, osobniki.plansza4);
                    osobniki.plansza1 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza4 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "14\n";
                }
            }

            if (wybrany_osobnik11 > szansa[0] && wybrany_osobnik11 <= szansa[0]+szansa[1])
            {
                int wybrany_osobnik13 = Random.Range(1, 101);
                while(wybrany_osobnik13 > szansa[0] && wybrany_osobnik13 <= szansa[0] + szansa[1])
                    wybrany_osobnik13 = Random.Range(1, 101);

                if (wybrany_osobnik13 <= szansa[0])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza3 = Mutacja(osobniki.plansza2);
                    else
                        osobniki.plansza3 = osobniki.plansza2;
                    if(mutacja2==20)
                        osobniki.plansza4 = Mutacja(osobniki.plansza1);
                    else
                        osobniki.plansza4 = osobniki.plansza1;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza2, osobniki.plansza1);
                    osobniki.plansza1 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza2 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "21\n";
                }
                if (wybrany_osobnik13 > szansa[0] + szansa[1] && wybrany_osobnik13 <= szansa[0] + szansa[1] + szansa[2])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza1 = Mutacja(osobniki.plansza2);
                    else
                        osobniki.plansza1 = osobniki.plansza2;
                    if(mutacja2==20)
                        osobniki.plansza4 = Mutacja(osobniki.plansza3);
                    else
                        osobniki.plansza4 = osobniki.plansza3;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza2, osobniki.plansza3);
                    osobniki.plansza3 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza2 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "23\n";
                }
                if (wybrany_osobnik13 > szansa[0] + szansa[1] + szansa[2])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza1 = Mutacja(osobniki.plansza2);
                    else
                        osobniki.plansza1 = osobniki.plansza2;
                    if(mutacja2==20)
                        osobniki.plansza3 = Mutacja(osobniki.plansza4);
                    else
                        osobniki.plansza3 = osobniki.plansza4;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza2, osobniki.plansza4);
                    osobniki.plansza4 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza2 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "24\n";
                }
            }

            if (wybrany_osobnik11 > szansa[0] + szansa[1] && wybrany_osobnik11 <= szansa[0] + szansa[1] + szansa[2])
            {
                int wybrany_osobnik14 = Random.Range(1, 101);
                while (wybrany_osobnik14 > szansa[0] + szansa[1] && wybrany_osobnik14 <= szansa[0] + szansa[1] + szansa[2])
                    wybrany_osobnik14 = Random.Range(1, 101);

                if (wybrany_osobnik14 <= szansa[0])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza2 = Mutacja(osobniki.plansza3);
                    else
                        osobniki.plansza2 = osobniki.plansza3;
                    if(mutacja2==20)
                        osobniki.plansza4 = Mutacja(osobniki.plansza1);
                    else
                        osobniki.plansza4 = osobniki.plansza1;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza3, osobniki.plansza1);
                    osobniki.plansza1 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza3 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "31\n";
                }
                if (wybrany_osobnik14 > szansa[0] && wybrany_osobnik14 <= szansa[0] + szansa[1])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza1 = Mutacja(osobniki.plansza3);
                    else
                        osobniki.plansza1 = osobniki.plansza3;
                    if(mutacja2==20)
                        osobniki.plansza4 = Mutacja(osobniki.plansza2);
                    else
                        osobniki.plansza4 = osobniki.plansza2;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza3, osobniki.plansza2);
                    osobniki.plansza2 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza3 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "32\n";
                }
                if (wybrany_osobnik14 > szansa[0] + szansa[1] + szansa[2])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza1 = Mutacja(osobniki.plansza3);
                    else
                        osobniki.plansza1 = osobniki.plansza3;
                    if(mutacja2==20)
                        osobniki.plansza2 = Mutacja(osobniki.plansza4);
                    else
                        osobniki.plansza2 = osobniki.plansza4;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza3, osobniki.plansza4);
                    osobniki.plansza4 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza3 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "34\n";
                }
            }

            if (wybrany_osobnik11 > szansa[0] + szansa[1] + szansa[2])
            {
                int wybrany_osobnik15 = Random.Range(1, szansa[0] + szansa[1] + szansa[2] + 1);

                if (wybrany_osobnik15 <= szansa[0])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza2 = Mutacja(osobniki.plansza4);
                    else
                        osobniki.plansza2 = osobniki.plansza4;
                    if(mutacja2==20)
                        osobniki.plansza3 = Mutacja(osobniki.plansza1);
                    else
                        osobniki.plansza3 = osobniki.plansza1;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza4, osobniki.plansza1);
                    osobniki.plansza1 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza4 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "41\n";
                }
                if (wybrany_osobnik15 > szansa[0] && wybrany_osobnik15 <= szansa[0] + szansa[1])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza1 = Mutacja(osobniki.plansza4);
                    else
                        osobniki.plansza1 = osobniki.plansza4;
                    if(mutacja2==20)
                        osobniki.plansza3 = Mutacja(osobniki.plansza2);
                    else
                        osobniki.plansza3 = osobniki.plansza2;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza4, osobniki.plansza2);
                    osobniki.plansza2 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza4 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "42\n";
                }
                if (wybrany_osobnik15 > szansa[0] + szansa[1] && wybrany_osobnik15 <= szansa[0] + szansa[1] + szansa[2])
                {
                    int mutacja1 = Random.Range(1, 21);
                    int mutacja2 = Random.Range(1, 21);
                    if(mutacja1==20)
                        osobniki.plansza1 = Mutacja(osobniki.plansza4);
                    else
                        osobniki.plansza1 = osobniki.plansza4;
                    if(mutacja2==20)
                        osobniki.plansza2 = Mutacja(osobniki.plansza3);
                    else
                        osobniki.plansza2 = osobniki.plansza3;
                    Plansze wynik_skrzyrzowania = Skrzyzowanie(osobniki.plansza4, osobniki.plansza3);
                    osobniki.plansza3 = wynik_skrzyrzowania.plansza1;
                    osobniki.plansza4 = wynik_skrzyrzowania.plansza2;
                    wiadomosc = wiadomosc + "43\n";
                }
            }

            tabela_ocen[0] = Filtr1(osobniki.plansza1) + Filtr2(osobniki.plansza1, 1) + Filtr2(osobniki.plansza1, 2) + Filtr2(osobniki.plansza1, 3) + Filtr4(osobniki.plansza1);
            tabela_ocen[1] = Filtr1(osobniki.plansza2) + Filtr2(osobniki.plansza2, 1) + Filtr2(osobniki.plansza2, 2) + Filtr2(osobniki.plansza2, 3) + Filtr4(osobniki.plansza2);
            tabela_ocen[2] = Filtr1(osobniki.plansza3) + Filtr2(osobniki.plansza3, 1) + Filtr2(osobniki.plansza3, 2) + Filtr2(osobniki.plansza3, 3) + Filtr4(osobniki.plansza3);
            tabela_ocen[3] = Filtr1(osobniki.plansza4) + Filtr2(osobniki.plansza4, 1) + Filtr2(osobniki.plansza4, 2) + Filtr2(osobniki.plansza4, 3) + Filtr4(osobniki.plansza4);

            for (int i = 0; i < 4; i++)
                if (tabela_ocen[i] < 1)
                    tabela_ocen[i] = 1;
            ilosc_skrzyzowan++;
        }

        wiadomosc = wiadomosc + "\n" + Filtr1(osobniki.plansza1) + " " + Filtr2(osobniki.plansza1, 1) + " " + Filtr2(osobniki.plansza1, 2) + " " + Filtr2(osobniki.plansza1, 3) + " " + Filtr3(osobniki.plansza1) + " " + Filtr4(osobniki.plansza1) + " " + Filtr5(osobniki.plansza1) + "\n" +
            Filtr1(osobniki.plansza2) + " " + Filtr2(osobniki.plansza2, 1) + " " + Filtr2(osobniki.plansza2, 2) + " " + Filtr2(osobniki.plansza2, 3) + " " + Filtr3(osobniki.plansza2) + " " + Filtr4(osobniki.plansza2) + " " + Filtr5(osobniki.plansza2) + "\n" +
            Filtr1(osobniki.plansza3) + " " + Filtr2(osobniki.plansza3, 1) + " " + Filtr2(osobniki.plansza3, 2) + " " + Filtr2(osobniki.plansza3, 3) + " " + Filtr3(osobniki.plansza3) + " " + Filtr4(osobniki.plansza3) + " " + Filtr5(osobniki.plansza3) + "\n" +
            Filtr1(osobniki.plansza4) + " " + Filtr2(osobniki.plansza4, 1) + " " + Filtr2(osobniki.plansza4, 2) + " " + Filtr2(osobniki.plansza4, 3) + " " + Filtr3(osobniki.plansza4) + " " + Filtr4(osobniki.plansza4) + " " + Filtr5(osobniki.plansza4) + "\n";

        Plansze.SerializeItem(fileName, formatter, osobniki); // Serialize an instance of the class.

        int max = ocena1;
        int numer = 0;

        for (int i = 1; i < 4; i++)
            if (max < tabela_ocen[i])
            {
                max = tabela_ocen[i];
                numer = i;
            }


        if (numer == 0)
        {
            osobnik = osobniki.plansza1;

        }

        if (numer == 1)
        {
            osobnik = osobniki.plansza2;

        }

        if (numer == 2)
        {
            osobnik = osobniki.plansza3;
        }

        if (numer == 3)
        {
            osobnik = osobniki.plansza4;
        }
        wiadomosc = wiadomosc + "Wybrany osobnik: " + numer;
        string[] wiadomoscie = { wiadomosc };
        System.IO.File.WriteAllLines("C:\\Users\\X\\Desktop\\SZTUCZNA\\SI-Inteligentna_Smieciarka\\wiadomosc.txt", wiadomoscie);
        return osobnik;
    }
}
