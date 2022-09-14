using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumTakenAdapter : MonoBehaviour
{
    public TextMeshProUGUI NumTakenText;

    public void Parent(Transform Parent)
    {
        transform.SetParent(Parent);
    }

    public void Location(float topX)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(topX, 0, 0);
    }
}
