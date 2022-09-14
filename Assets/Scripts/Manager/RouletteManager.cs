using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RouletteManager : MonoBehaviour
{
    public int Position = 0;

    public int TimeRouletteCurrent;

    public float WaitForSecondsNewCurrent = 0;

    public float WaitForSecondsNew = 0.01f;

    public TextMeshProUGUI RouletteText;

    public GameObject BlockGameObject;

    public List<string> TextsList;

    public NumTakenAdapter NumTakenAdapter;

    public RectTransform ContentNumTaken;

    public GameManager GameManager;

    public PayManager PayManager;

    private bool IsFinish = false;

    private int TimeRoulette = 3;

    // Start is called before the first frame update
    void Start()
    {
        TimeRouletteCurrent = TimeRoulette;
        WaitForSecondsNewCurrent = WaitForSecondsNew;
    }

    public void CallTime()
    {
        BlockGameObject.SetActive(true);
        StartCoroutine(MoveRoulette());
        InvokeRepeating("TimeRouletteUpdate", 1,1);
    }

    public IEnumerator MoveRoulette()
    {
        int Count = 0;
        while (true)
        {
            RouletteText.text = TextsList[Count];
            yield return new WaitForSeconds(WaitForSecondsNewCurrent);
            Count++;
            if(Count >= TextsList.Count)
            {
                Count = 0;
            }
            if (IsFinish)
            {
                RouletteText.text = TextsList[Count];
                AddContentNumTaken(TextsList[Count]);
                PayManager.Win(TextsList[Count]);
                break;
            }
        }
    }

    public void TimeRouletteUpdate()
    {
        TimeRouletteCurrent--;
        WaitForSecondsNewCurrent = WaitForSecondsNewCurrent + Mathf.Abs((WaitForSecondsNew * Mathf.Log10(Random.Range(0.1f,1))));
        Debug.Log(WaitForSecondsNewCurrent + " " + Time.deltaTime);
        if(TimeRouletteCurrent == 0)
        {
            IsFinish = true;
            CancelInvoke("TimeRouletteUpdate");
        }
    }

    public void AddContentNumTaken(string NumTaken)
    {
        var NumRectTransform = NumTakenAdapter.GetComponent<RectTransform>();
        float templateWidth = NumRectTransform.rect.width;
        var item = Instantiate(NumTakenAdapter);
        item.name = "NumTaken " + (Position + 1);
        item.NumTakenText.text = NumTaken;
        item.Parent(ContentNumTaken);
        var TopX = ((templateWidth * Position) + (10 * (Position + 1)));
        Debug.Log(TopX);
        item.Location(TopX);
        item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        var Width = ((templateWidth * Position) + (10 * (Position + 1)));
        ContentNumTaken.sizeDelta = new Vector2(Width, ContentNumTaken.rect.height);
        Position++;
    }

    public void ResetRoulette()
    {
        BlockGameObject.SetActive(false);
        TimeRouletteCurrent = TimeRoulette;
        WaitForSecondsNewCurrent = WaitForSecondsNew;
        IsFinish = false;
    }
}
