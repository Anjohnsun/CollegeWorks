using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Church : MonoBehaviour
{
    [SerializeField] private int inChurch = 0;
    [SerializeField] private int TIME = 5;
    [SerializeField] private float timeToChange;
    [SerializeField] private float expForVlgr = 0.00000000000000001f;

    private float FINALTIME = 1.8f;
    private float timeChangeColor;
    private bool pressed = false;

    [SerializeField] private Image detector, redDetector, greenDetector;
    [SerializeField] private Bootstrap bootstrap;

    private Game_Controller _game_Controller;

    void Start()
    {
        _game_Controller = bootstrap._game_Controller;
        timeToChange = TIME;
        redDetector.fillAmount = 0;
        greenDetector.fillAmount = 0;
        timeChangeColor = FINALTIME;
    }

    void Update()
    {
        if (inChurch > 0)
        {
            timeToChange -= Time.deltaTime;
            if (timeToChange <= 0)
            {
                timeToChange = TIME;
                detector.fillAmount += expForVlgr*inChurch;
            }
        }

        if (pressed)
        {

        }
    }

    public void sendInChurch()
    {
        if (_game_Controller.FreeVillagers > 0)
        {
            inChurch++;
            _game_Controller.FreeVillagers--;
            bootstrap.UpdateData();
            //добавить изменение заполненности шкалы церкви
        }
    }



    public void onChurchButtinClick()
    {
        pressed = true;
      //  if (Random.value < detector.fillAmount)
        
    }


    private void rotateDetector()
    {
        redDetector.fillAmount = 1;
        greenDetector.fillAmount = 1;
    }
}
