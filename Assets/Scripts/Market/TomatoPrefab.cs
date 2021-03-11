using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TomatoPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tomatoQuantity;
    [SerializeField]
    private TextMeshProUGUI tomatoPrice;
    [SerializeField]
    private TextMeshProUGUI tomatoName;

    public void SetPrice(string textString)
    {
        tomatoPrice.text = textString;
    }
    public void SetQuantity(string textString)
    {
        tomatoQuantity.text = textString;
    }
    public void SetName(string textString)
    {
        tomatoName.text = textString;
    }
    public string getPrice()
    {
        return tomatoPrice.text;
    }
}
