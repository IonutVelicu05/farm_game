using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotatoPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI potatoQuantity;
    [SerializeField]
    private TextMeshProUGUI potatoPrice;
    [SerializeField]
    private TextMeshProUGUI potatoName;

    public void SetPrice(string textString)
    {
        potatoPrice.text = textString;
    }
    public void SetQuantity(string textString)
    {
        potatoQuantity.text = textString;
    }
    public void SetName(string textString)
    {
        potatoName.text = textString;
    }
    public string getPrice()
    {
        return potatoPrice.text;
    }
}
