using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CucumberPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cucumberQuantity;
    [SerializeField]
    private TextMeshProUGUI cucumberPrice;
    [SerializeField]
    private TextMeshProUGUI cucumberName;

    public void SetPrice(string textString)
    {
        cucumberPrice.text = textString;
    }
    public void SetQuantity(string textString)
    {
        cucumberQuantity.text = textString;
    }
    public void SetName(string textString)
    {
        cucumberName.text = textString;
    }
    public string getPrice()
    {
        return cucumberPrice.text;
    }
}
