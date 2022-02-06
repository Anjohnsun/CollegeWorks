using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Town_Hall : MonoBehaviour
{
    private string[] stats;
    private const float TIME = 10;
    [SerializeField] private float timeToCreate;
    [SerializeField] private bool inProgress = false;
    [SerializeField] private int REQUIRED_WHEAT = 5;
    [SerializeField] private int inQueue;

    void Start()
    {
        timeToCreate = TIME;
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
                Game_Controller.freeVillagers++;
                if (inQueue == 0)
                {
                    inProgress = false;
                }
                timeToCreate = TIME;
            }
        }
    }

    public void CreateVillager()
    {
        if (Game_Controller.wheat >= REQUIRED_WHEAT)
        {
            inQueue++;
            inProgress = true;
            Game_Controller.wheat -= REQUIRED_WHEAT;
        }
    }



}
