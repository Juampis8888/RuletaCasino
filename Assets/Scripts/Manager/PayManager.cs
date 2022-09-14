using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayManager : MonoBehaviour
{
    private BalanceManager BalanceManager;

    private BetManager BetManager;

    private TimeManager TimeManager;

    private GameManager GameManager;

    private void Awake()
    {
        BalanceManager = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<BalanceManager>();
        BetManager = GameObject.FindGameObjectWithTag("BetManager").GetComponent<BetManager>();
        TimeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void Win(string betTaken)
    {
        TimeManager.TimeText.text = "Pagando";
        int Multi = 0;
        int TotalBet = 0;
        BetManager.Bets.ForEach(bet =>
        {
            if(bet.BetText == betTaken)
            {
                Multi = bet.ValueBet;
            }
        });
        BetManager.BetAdapters.ForEach(betAdapter =>
        {
            if (betAdapter.Bet == betTaken)
            {
                TotalBet = betAdapter.TotalBet;
            }
        });
        BalanceManager.UpdateBalance(Multi* TotalBet);
        GameManager.CallReset();
    }
}
