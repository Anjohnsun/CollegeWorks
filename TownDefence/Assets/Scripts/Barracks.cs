using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    private float TIME = 5;
    [SerializeField] private float timeToCreate;
    [SerializeField] private bool inProgress = false;
    [SerializeField] private int guardsCount = 0;
    [SerializeField] private int inQueue = 0;
    [SerializeField] private int requiredIron = 10;
    [SerializeField] private Bootstrap bootstrap;
    private Game_Controller _game_Controller;

    void Start()
    {
        timeToCreate = TIME;
        _game_Controller = bootstrap._game_Controller;
    }

    void Update()
    {
        if (inProgress)
        {
            timeToCreate -= Time.deltaTime;
            if (timeToCreate <= 0)
            {
                timeToCreate = TIME;
                guardsCount++;
                _game_Controller.Guards++;
                inQueue--;
                bootstrap.UpdateData();
                if (inQueue == 0)
                {
                    inProgress = false;
                }
            }
        }
    }

    public void createGuard()
    {
        if (_game_Controller.FreeVillagers > 0 && _game_Controller.Iron >= requiredIron)
        {
            _game_Controller.FreeVillagers--;
            _game_Controller.Iron -= requiredIron;
            inQueue++;
            bootstrap.UpdateData();
            inProgress = true; //стоит ли убрать с рассчётом на сравнение по onField>0?
        }
    }
}
