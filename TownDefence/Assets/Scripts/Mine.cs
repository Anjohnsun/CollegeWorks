using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    private float TIME = 7;
    [SerializeField] private float timeToCreate;
    [SerializeField] private bool inProgress = false;
    [SerializeField] private int inMine = 0;
    [SerializeField] private int ironForVillager = 1;
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
            if (timeToCreate <= 0)
            {
                timeToCreate = TIME;
                _game_Controller.Iron += inMine * ironForVillager;
                bootstrap.UpdateData();
            }
        }
    }

    public void sendInMine()
    {
        if (_game_Controller.FreeVillagers > 0)
        {
            _game_Controller.FreeVillagers--;
            inMine++;
            bootstrap.UpdateData();
            inProgress = true; //аналогично onField
            textArea.text = inMine.ToString();
        }
    }
}
