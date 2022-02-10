using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public Game_Controller _game_Controller;
    [SerializeField] private TextMeshProUGUI villagersText;
    [SerializeField] private TextMeshProUGUI guardsText;
    [SerializeField] private TextMeshProUGUI wheatText;
    [SerializeField] private TextMeshProUGUI ironText;

    void Awake()
    {
        _game_Controller = new Game_Controller(0, 0, 20, 0);
        UpdateData();
    }

    public void UpdateData()
    {
        villagersText.text = _game_Controller.FreeVillagers.ToString();
        guardsText.text = _game_Controller.Guards.ToString();
        wheatText.text = _game_Controller.Wheat.ToString();
        ironText.text = _game_Controller.Iron.ToString();
    }

}
