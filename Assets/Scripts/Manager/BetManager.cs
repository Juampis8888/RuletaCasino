using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetManager : MonoBehaviour
{
    private int Bet;

    public TextMeshProUGUI BetText;

    public BetAdapter BetAdapter;

    public RectTransform ContentBetAdapter;

    public List<Bet> Bets;

    public List<BetAdapter> BetAdapters;

    public int Position = 0;

    void Start()
    {
        Bet = 0;
        BetText.text = Bet.ToString("C");
    }

    public int GetBet()
    {
        return Bet;
    }

    public void SetBet(int bet)
    {
        Bet = bet;
    } 

    public void UpdateBet(int bet)
    {
        SetBet(GetBet()+bet);
        BetText.text = GetBet().ToString("C");
    }

    public void ResetBet()
    {
        SetBet(0);
        BetText.text = GetBet().ToString("C");
    }

    public void AddContentAdapter(Bet bet,int Totalbet)
    {
        var NumRectTransform = BetAdapter.GetComponent<RectTransform>();
        float templateWidth = NumRectTransform.rect.width;
        var item = Instantiate(BetAdapter);
        item.name = "Bet " + ContentBetAdapter.childCount + 1;
        item.NumBetText.text = "Numero Apostado: " + bet.BetText;
        item.Bet = bet.BetText;
        item.TotalBet = Totalbet;
        item.TotalBetText.text = "Total Apostado: " + Totalbet.ToString("c");
        item.Parent(ContentBetAdapter);
        var TopX = ((templateWidth * Position) + (10 * (Position + 1)));
        Debug.Log(TopX);
        item.Location(TopX);
        item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        var Width = ((templateWidth * Position) + (10 * (Position + 1)));
        ContentBetAdapter.sizeDelta = new Vector2(Width, ContentBetAdapter.rect.height);
        Position++;
        Bets.Add(bet);
        BetAdapters.Add(item);
    }

    public void ResetBets()
    {
        Bets.RemoveRange(0, Bets.Count);
    }
}
