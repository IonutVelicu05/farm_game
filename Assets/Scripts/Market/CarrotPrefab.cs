using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarrotPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI carrotQuantity;
    [SerializeField]
    private TextMeshProUGUI carrotPrice;
    [SerializeField]
    private TextMeshProUGUI carrotName;

    public void SetPrice(string textString)
    {
        carrotPrice.text = textString;
    }
    public void SetQuantity(string textString)
    {
        carrotQuantity.text = textString;
    }
    public void SetName(string textString)
    {
        carrotName.text = textString;
    }
    public string getPrice()
    {
        return carrotPrice.text;
    }
}
