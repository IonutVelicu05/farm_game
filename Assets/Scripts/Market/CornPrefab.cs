using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CornPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cornQuantity;
    [SerializeField]
    private TextMeshProUGUI cornPrice;
    [SerializeField]
    private TextMeshProUGUI cornName;

    public void SetPrice(string textString)
    {
        cornPrice.text = textString;
    }
    public void SetQuantity(string textString)
    {
        cornQuantity.text = textString;
    }
    public void SetName(string textString)
    {
        cornName.text = textString;
    }
    public string getPrice()
    {
        return cornPrice.text;
    }
}
