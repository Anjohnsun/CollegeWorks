using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Town_Hall : MonoBehaviour
{
    private const float TIME = 3;
    [SerializeField] private float timeToCreate;
    [SerializeField] private bool inProgress = false;
    [SerializeField] private int REQUIRED_WHEAT = 5;
    [SerializeField] private int inQueue;
    [SerializeField] private Bootstrap bootstrap;
    private Game_Controller _game_Controller;

    void Start()
    {
        timeToCreate = TIME;
        _game_Controller = bootstrap._game_Controller;
    }

    private void Update()
    {
        if (inProgress)
        {
            if (timeToCreate > 0)
            {
                timeToCreate -= Time.deltaTime;
            }
            else
            {
                inQueue--;
                _game_Controller.FreeVillagers++;
                if (inQueue == 0)
                {
                    inProgress = false;
                }
                timeToCreate = TIME;
                bootstrap.UpdateData();
            }
        }
    }

    public void CreateVillager()
    {
        if (_game_Controller.Wheat >= REQUIRED_WHEAT)
        {
            inQueue++;
            _game_Controller.Wheat -= REQUIRED_WHEAT;
            bootstrap.UpdateData();

            inProgress = true;
        }
    }

}
