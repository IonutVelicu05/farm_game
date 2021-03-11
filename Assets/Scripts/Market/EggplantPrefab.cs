using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggplantPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI eggplantQuantity;
    [SerializeField]
    private TextMeshProUGUI eggplantPrice;
    [SerializeField]
    private TextMeshProUGUI eggplantName;

    public void SetPrice(string textString)
    {
        eggplantPrice.text = textString;
    }
    public void SetQuantity(string textString)
    {
        eggplantQuantity.text = textString;
    }
    public void SetName(string textString)
    {
        eggplantName.text = textString;
    }
    public string getPrice()
    {
        return eggplantPrice.text;
    }
}