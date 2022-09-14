using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    private int Balance = 100000;

    public TextMeshProUGUI BalanceText;

    private void Awake()
    {
        BalanceText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        BalanceText.text = Balance.ToString("C");
        
    }

    public int GetBalance()
    {
        return Balance;
    }

    public void SetBalance(int balance)
    {
        Balance = balance;
    }

    public void UpdateBalance(int balance)
    {
        SetBalance(GetBalance() + balance);
        BalanceText.text = GetBalance().ToString("C");
    }
}
