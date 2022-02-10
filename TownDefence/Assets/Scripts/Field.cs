using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    private float TIME = 3;
    [SerializeField] private float timeToCreate;
    [SerializeField] private bool inProgress = false;
    [SerializeField] private int onField = 0;
    [SerializeField] private int wheatForVillager = 1;
    [SerializeField] private Image indicator; 
    [SerializeField] private TextMeshProUGUI textArea;
    [SerializeField] private Bootstrap bootstrap;
    private Game_Controller _game_Controller;
    

    void Start()
    {
        timeToCreate = TIME;
        _game_Controller = bootstrap._game_Controller;
        textArea.text = "0";
        indicator.fillAmount = 0;
    }

    void Update()
    {
        if (inProgress)
        {
            timeToCreate -= Time.deltaTime;
            indicator.fillAmount = (TIME - timeToCreate) / TIME;
            if(timeToCreate <= 0)
            {
                timeToCreate = TIME;
                _game_Controller.Wheat += onField * wheatForVillager;
                bootstrap.UpdateData();            
            }
        }
    }

    public void sendOnField()
    {
        if (_game_Controller.FreeVillagers > 0)
        {
            _game_Controller.FreeVillagers--;
            onField++;
            bootstrap.UpdateData();
            inProgress = true; //стоит ли убрать с рассчётом на сравнение по onField>0?
            textArea.text = onField.ToString();
        }
    }
}
