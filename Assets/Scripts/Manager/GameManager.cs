using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Bet> NumSelect;

    public BetManager BetManager;

    public BalanceManager BalanceManager;

    public TimeManager TimeManager;

    public RouletteManager RouletteManager;

    public bool IsBet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int index)
    {
        if (BetManager.GetBet() > 0 & BalanceManager.GetBalance() >= BetManager.GetBet())
        {
            Image image = NumSelect[index].GameObjectBet.GetComponent<Image>();
            Button button = NumSelect[index].GameObjectBet.GetComponent<Button>();
            BalanceManager.UpdateBalance(-BetManager.GetBet());
            BetManager.AddContentAdapter(NumSelect[index], BetManager.GetBet());
            BetManager.ResetBet();
            image.color = Color.green;
            button.interactable = false;
            
        }
    }

    private void ResetButtonsBet()
    {
        NumSelect.ForEach(num =>
        {
            Image image = num.GameObjectBet.GetComponent<Image>();
            Button button = num.GameObjectBet.GetComponent<Button>();
            image.color = Color.white;
            button.interactable = true;
        });
    }

    private void ResetAll()
    {
        ResetButtonsBet();
        TimeManager.ResetTime();
        BetManager.ResetBet();
        BetManager.ResetBets();
        RouletteManager.ResetRoulette();
    }

    public void CallReset()
    {
        Invoke("ResetAll", 2f);
    }
}
