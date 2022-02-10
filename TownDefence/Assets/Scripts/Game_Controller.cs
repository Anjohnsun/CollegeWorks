using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    //private static Game_Controller _instance;

    //public static Game_Controller Container() =>
    //_instance ? new Game_Controller()

    public Game_Controller(int freeVillagers, int guards, int wheat, int iron)
    {
        FreeVillagers = freeVillagers;
        Guards = guards;
        Wheat = wheat;
        Iron = iron;
    }
    public int FreeVillagers, Guards, Wheat, Iron;

}
