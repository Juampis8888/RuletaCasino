using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private int Time;

    private int TimeCurrent;

    public TextMeshProUGUI TimeText;

    public RouletteManager RouletteManager;

    private void Awake()
    {
        TimeText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time = 10;
        TimeCurrent = Time;
        TimeText.text = TimeCurrent.ToString();
        InvokeRepeating("TimeUpdate", 1, 1);
    }

    public void TimeUpdate()
    {
        TimeCurrent--;
        TimeText.text = TimeCurrent.ToString();
        if (TimeCurrent == 0)
        {
            TimeText.text = "Fin de apuestas";
            CancelInvoke("TimeUpdate");
            RouletteManager.CallTime();
        }
    }

    public void ResetTime()
    {
        TimeCurrent = Time;
        TimeText.text = TimeCurrent.ToString();
        InvokeRepeating("TimeUpdate", 1, 1);
    }
}
