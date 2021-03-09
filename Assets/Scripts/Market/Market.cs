using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Market : MonoBehaviour
{
    [SerializeField]
    private InputField tomatoQuantityText;
    [SerializeField]
    private InputField tomatoPriceText;
    [SerializeField]
    private InputField potatoQuantityText;
    [SerializeField]
    private InputField potatoPriceText;
    [SerializeField]
    private InputField cornQuantityText;
    [SerializeField]
    private InputField cornPriceText;
    [SerializeField]
    private InputField cucumberQuantityText;
    [SerializeField]
    private InputField cucumberPriceText;
    [SerializeField]
    private InputField carrotQuantityText;
    [SerializeField]
    private InputField carrotPriceText;
    [SerializeField]
    private InputField eggplantQuantityText;
    [SerializeField]
    private InputField eggplantPriceText;
    [SerializeField]
    private Button sellTomatoesButton;
    [SerializeField]
    private GameObject sellMenu;
    [SerializeField]
    private GameObject buyMenu;
    [SerializeField]
    private GameObject tomatoSellMenu;
    [SerializeField]
    private GameObject potatoSellMenu;
    [SerializeField]
    private GameObject cornSellMenu;
    [SerializeField]
    private GameObject cucumberSellMenu;
    [SerializeField]
    private GameObject carrotSellMenu;
    [SerializeField]
    private GameObject eggplantSellMenu;
    [SerializeField]
    private GameObject sellError;
    [SerializeField]
    private GameObject sellPopup;
    [SerializeField]
    private GameObject tomatoBuyMenu;
    [SerializeField]
    private GameObject potatoBuyMenu;
    [SerializeField]
    private GameObject carrotBuyMenu;
    [SerializeField]
    private GameObject cornBuyMenu;
    [SerializeField]
    private GameObject cucumberBuyMenu;
    [SerializeField]
    private GameObject eggplantBuyMenu;
    [SerializeField]
    private GameObject tomatoSellTemplate;
    [SerializeField]
    private GameObject potatoSellTemplate;
    [SerializeField]
    private GameObject carrotSellTemplate;
    [SerializeField]
    private GameObject cucumberSellTemplate;
    [SerializeField]
    private GameObject cornSellTemplate;
    [SerializeField]
    private GameObject eggplantSellTemplate;
    [SerializeField]
    private GameObject tomatoOrderTemplate;
    [SerializeField]
    private GameObject potatoOrderTemplate;
    [SerializeField]
    private GameObject carrotOrderTemplate;
    [SerializeField]
    private GameObject cornOrderTemplate;
    [SerializeField]
    private GameObject cucumberOrderTemplate;
    [SerializeField]
    private GameObject eggplantOrderTemplate;
    private bool swapBuySell = false; // false = sell, true = buy;
    [SerializeField]
    Button buySellbtn;
    private int whatToPick = 1;
    private int whatToPickPO = 1;
    //liste cu orders values
    private List<GameObject> orderList = new List<GameObject>(); //lista cu orderele (obiectele/butoanele) create
    private string[] orderPriceList; // lista cu preturile la toate orderele in momentu cand cumperi
    private string[] orderQuantityList; // lista cu cantitatiile la toate orderele in momentu cand cumperi
    private string[] orderNameList; // lista cu numele vanzatorilor la toate orderele in momentu cand cumperi
    private List<GameObject> playerOrdersList = new List<GameObject>(); // lista cu orderele plasate de player (din meniu `See Your Orders`);
    private string[] playerOrderPriceList; // lista cu preturile la orderele plasate de player;
    private string[] playerOrderQuantityList; // lista cu cantitatiile la orderele plasate de player;
    //tomato ;; lista care detine detaliile despre orderele din market de tip tomato
    private string[] tomatoOrderName;
    private string[] tomatoOrderPrice;
    private string[] tomatoOrderQuantity;
    private string[] tomatoOrderId;
    //potato ;; lista care detine detaliile despre orderele din market de tip potato
    private string[] potatoOrderName;
    private string[] potatoOrderPrice;
    private string[] potatoOrderQuantity;
    private string[] potatoOrderId;
    //corn ;; lista care detine detaliile despre orderele din market de tip corn
    private string[] cornOrderName;
    private string[] cornOrderPrice;
    private string[] cornOrderQuantity;
    private string[] cornOrderId;
    //carrot ;; lista care detine detaliile despre orderele din market de tip carrot
    private string[] carrotOrderName;
    private string[] carrotOrderPrice;
    private string[] carrotOrderQuantity;
    private string[] carrotOrderId;
    //cucumber ;; lista care detine detaliile despre orderele din market de tip cucumber
    private string[] cucumberOrderName;
    private string[] cucumberOrderPrice;
    private string[] cucumberOrderQuantity;
    private string[] cucumberOrderId;
    //eggplant ;; lista care detine detaliile despre orderele din market de tip eggplant
    private string[] eggplantOrderName;
    private string[] eggplantOrderPrice;
    private string[] eggplantOrderQuantity;
    private string[] eggplantOrderId;
    //buy confirmation ;; detaliile predate scriptului php pentru a efectua operatiile SQL
    private string confirmationOrderName;
    private string confirmationOrderPrice;
    private string confirmationOrderQuantity;
    private int confirmationOrderId;
    private int confirmationWhatPlant = 0; //1=rosie ;; 2=potato;; 3=carrot;; 4=corn;; 5=cucumber;; 6=eggplant
    //tomato ;; lista care detine detaliile despre orderele tip tomato plasate de jucator(daca vrea sa le stearga)
    private string[] tomatoPlayerOrderName;
    private string[] tomatoPlayerOrderPrice;
    private string[] tomatoPlayerOrderQuantity;
    private string[] tomatoPlayerOrderId;
    //potato ;; lista care detine detaliile despre orderele tip potato plasate de jucator(daca vrea sa le stearga)
    private string[] potatoPlayerOrderName;
    private string[] potatoPlayerOrderPrice;
    private string[] potatoPlayerOrderQuantity;
    private string[] potatoPlayerOrderId;
    //corn ;; lista care detine detaliile despre orderele tip corn plasate de jucator(daca vrea sa le stearga)
    private string[] cornPlayerOrderName;
    private string[] cornPlayerOrderPrice;
    private string[] cornPlayerOrderQuantity;
    private string[] cornPlayerOrderId;
    //carrot ;; lista care detine detaliile despre orderele tip carrot plasate de jucator(daca vrea sa le stearga)
    private string[] carrotPlayerOrderName;
    private string[] carrotPlayerOrderPrice;
    private string[] carrotPlayerOrderQuantity;
    private string[] carrotPlayerOrderId;
    //cucumber ;; lista care detine detaliile despre orderele tip cucumber plasate de jucator(daca vrea sa le stearga)
    private string[] cucumberPlayerOrderName;
    private string[] cucumberPlayerOrderPrice;
    private string[] cucumberPlayerOrderQuantity;
    private string[] cucumberPlayerOrderId;
    //eggplant ;; lista care detine detaliile despre orderele tip eggplant plasate de jucator(daca vrea sa le stearga)
    private string[] eggplantPlayerOrderName;
    private string[] eggplantPlayerOrderPrice;
    private string[] eggplantPlayerOrderQuantity;
    private string[] eggplantPlayerOrderId;


    public void SwapBuySell()
    {
        ColorBlock btnColors = buySellbtn.colors;
        swapBuySell = !swapBuySell;
        if (swapBuySell)
        {
            btnColors.normalColor = Color.red;
            btnColors.pressedColor = Color.red;
            btnColors.highlightedColor = Color.red;
            btnColors.selectedColor = Color.red;
            btnColors.disabledColor = Color.red;
            buySellbtn.colors = btnColors;
        }
        else if(swapBuySell == false)
        {
            btnColors.normalColor = Color.green;
            btnColors.pressedColor = Color.green;
            btnColors.highlightedColor = Color.green;
            btnColors.selectedColor = Color.green;
            btnColors.disabledColor = Color.green;
            buySellbtn.colors = btnColors;
        }
    }
    public void SelectTomato()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            tomatoBuyMenu.SetActive(true);
            BuyTomato();
            confirmationWhatPlant = 1;
            Debug.Log(confirmationWhatPlant);
        }
        else if(swapBuySell == false)
        {
            sellMenu.SetActive(true);
            tomatoSellMenu.SetActive(true);
        }
    }
    public void SelectPotato()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            potatoBuyMenu.SetActive(true);
            BuyPotato();
            confirmationWhatPlant = 2;
            Debug.Log(confirmationWhatPlant);

        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            potatoSellMenu.SetActive(true);
        }
    }
    public void SelectCarrot()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            carrotBuyMenu.SetActive(true);
            BuyCarrot();
            confirmationWhatPlant = 3;
            Debug.Log(confirmationWhatPlant);
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            carrotSellMenu.SetActive(true);
        }
    }
    public void SelectCorn()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            cornBuyMenu.SetActive(true);
            BuyCorn();
            confirmationWhatPlant = 4;
            Debug.Log(confirmationWhatPlant);
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            cornSellMenu.SetActive(true);
        }
    }
    public void SelectCucumber()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            cucumberBuyMenu.SetActive(true);
            BuyCucumber();
            confirmationWhatPlant = 5;
            Debug.Log(confirmationWhatPlant);
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            cucumberSellMenu.SetActive(true);
        }
    }
    public void SelectEggplant()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            eggplantBuyMenu.SetActive(true);
            BuyEggplant();
            confirmationWhatPlant = 6;
            Debug.Log(confirmationWhatPlant);
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            eggplantSellMenu.SetActive(true);
        }
    }
    public void SellTomatoes()
    {
        if (int.Parse(tomatoQuantityText.text) <= MySQL.tomatoSeeds)
        {
            StartCoroutine(SellTomatoesEnumerator());
            MySQL.tomatoSeeds -= int.Parse(tomatoQuantityText.text);
        }
        else
        {
            sellError.SetActive(true);
        }
    }
    IEnumerator SellTomatoesEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("sellername", MySQL.username.ToString());
        form.AddField("quantity", tomatoQuantityText.text);
        form.AddField("price", tomatoPriceText.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/selltomato.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/selltomato_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
    }
    public void SellPotatoes()
    {
        if (int.Parse(potatoQuantityText.text) <= MySQL.potatoSeeds)
        {
            StartCoroutine(SellPotatoesEnumerator());
            MySQL.potatoSeeds -= int.Parse(potatoQuantityText.text);
        }
        else
        {
            sellError.SetActive(true);
        }
    }
    IEnumerator SellPotatoesEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("sellername", MySQL.username.ToString());
        form.AddField("quantity", potatoQuantityText.text);
        form.AddField("price", potatoPriceText.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/sellpotato.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/sellpotato_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
    }
    public void SellCorn()
    {
        if (int.Parse(cornQuantityText.text) <= MySQL.cornSeeds)
        {
            StartCoroutine(SellCornEnumerator());
            MySQL.cornSeeds -= int.Parse(cornQuantityText.text);
        }
        else
        {
            sellError.SetActive(true);
        }
    }
    IEnumerator SellCornEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("sellername", MySQL.username.ToString());
        form.AddField("quantity", cornQuantityText.text);
        form.AddField("price", cornPriceText.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/sellcorn.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/sellcorn_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
    }
    public void SellCarrot()
    {
        if (int.Parse(carrotQuantityText.text) <= MySQL.carrotSeeds)
        {
            StartCoroutine(SellCarrotEnumerator());
            MySQL.carrotSeeds -= int.Parse(carrotQuantityText.text);
        }
        else
        {
            sellError.SetActive(true);
        }
    }
    IEnumerator SellCarrotEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("sellername", MySQL.username.ToString());
        form.AddField("quantity", carrotQuantityText.text);
        form.AddField("price", carrotPriceText.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/sellcarrot.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/sellcarrot_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
    }
    public void SellCucumber()
    {
        if (int.Parse(cucumberQuantityText.text) <= MySQL.cucumberSeeds)
        {
            StartCoroutine(SellCucumberEnumerator());
            MySQL.cucumberSeeds -= int.Parse(cucumberQuantityText.text);
        }
        else
        {
            sellError.SetActive(true);
        }
    }
    IEnumerator SellCucumberEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("sellername", MySQL.username.ToString());
        form.AddField("quantity", cucumberQuantityText.text);
        form.AddField("price", cucumberPriceText.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/sellcucumber.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/sellcucumber_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
    }
    public void SellEggplant()
    {
        if (int.Parse(eggplantQuantityText.text) <= MySQL.eggplantSeeds)
        {
            StartCoroutine(SellEggplantEnumerator());
            MySQL.eggplantSeeds -= int.Parse(eggplantQuantityText.text);
        }
        else
        {
            sellError.SetActive(true);
            
        }
    }
    IEnumerator SellEggplantEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("sellername", MySQL.username.ToString());
        form.AddField("quantity", eggplantQuantityText.text);
        form.AddField("price", eggplantPriceText.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/selleggplant.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
        else if(MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/selleggplant_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                sellPopup.SetActive(true);
            }
            else
            {
                Debug.Log("erroaree ." + www.text);
            }
        }
    }
    public void BuyTomato()
    {
        StartCoroutine(BuyTomatoEnumerator());
    }
    IEnumerator BuyTomatoEnumerator()
    {
        for(int i=0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild == true)
            {
                WWW www = new WWW("http://localhost/connection/market/buytomato.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        tomatoOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        tomatoOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        tomatoOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        tomatoOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/buytomato_online.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        tomatoOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        tomatoOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        tomatoOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        tomatoOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }
            orderList.Clear();
        }
        if(orderNameList.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < tomatoOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(tomatoSellTemplate);
                order.SetActive(true);
                order.name = i.ToString();
                order.GetComponent<TomatoPrefab>().SetPrice("Price: " + tomatoOrderPrice[i]);
                order.GetComponent<TomatoPrefab>().SetQuantity("Quantity: " + tomatoOrderQuantity[i]);
                order.GetComponent<TomatoPrefab>().SetName("Seller: " + tomatoOrderName[i]);
                order.transform.SetParent(tomatoSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
    public void BuyPotato()
    {
        StartCoroutine(BuyPotatoEnumerator());
    }
    IEnumerator BuyPotatoEnumerator()
    {
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buypotato.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        potatoOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        potatoOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        potatoOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        potatoOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/buypotato_online.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        potatoOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        potatoOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        potatoOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        potatoOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }
            orderList.Clear();
        }
        if(potatoOrderName.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < potatoOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(potatoSellTemplate);
                order.SetActive(true);
                order.name = i.ToString();
                order.GetComponent<PotatoPrefab>().SetPrice("Price: " + potatoOrderPrice[i]);
                order.GetComponent<PotatoPrefab>().SetQuantity("Quantity: " + potatoOrderQuantity[i]);
                order.GetComponent<PotatoPrefab>().SetName("Seller: " + potatoOrderName[i]);
                order.transform.SetParent(potatoSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
    public void BuyCorn()
    {
        StartCoroutine(BuyCornEnumerator());
    }
    IEnumerator BuyCornEnumerator()
    {
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buycorn.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        cornOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        cornOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        cornOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        cornOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/buycorn_online.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        cornOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        cornOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        cornOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        cornOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }
            orderList.Clear();
        }
        if(cornOrderName.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < cornOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(cornSellTemplate);
                order.SetActive(true);
                order.name = i.ToString();
                order.GetComponent<CornPrefab>().SetPrice("Price: " + cornOrderPrice[i]);
                order.GetComponent<CornPrefab>().SetQuantity("Quantity: " + cornOrderQuantity[i]);
                order.GetComponent<CornPrefab>().SetName("Seller: " + cornOrderName[i]);
                order.transform.SetParent(cornSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
    public void BuyCarrot()
    {
        StartCoroutine(BuyCarrotEnumerator());
    }
    IEnumerator BuyCarrotEnumerator()
    {
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buycarrot.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        carrotOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        carrotOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        carrotOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        carrotOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/buycarrot_online.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        carrotOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        carrotOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        carrotOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        carrotOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }
            orderList.Clear();
        }
        if(carrotOrderName.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < carrotOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(carrotSellTemplate);
                order.SetActive(true);
                order.name = i.ToString();
                order.GetComponent<CarrotPrefab>().SetPrice("Price: " + carrotOrderPrice[i]);
                order.GetComponent<CarrotPrefab>().SetQuantity("Quantity: " + carrotOrderQuantity[i]);
                order.GetComponent<CarrotPrefab>().SetName("Seller: " + carrotOrderName[i]);
                order.transform.SetParent(carrotSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
    public void BuyCucumber()
    {
        StartCoroutine(BuyCucumberEnumerator());
    }
    IEnumerator BuyCucumberEnumerator()
    {
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buycucumber.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        cucumberOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        cucumberOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        cucumberOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        cucumberOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/buycucumber_online.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        cucumberOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        cucumberOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        cucumberOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        cucumberOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }
            orderList.Clear();
        }
        if(cucumberOrderName.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < cucumberOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(cucumberSellTemplate);
                order.SetActive(true);
                order.name = i.ToString();
                order.GetComponent<CucumberPrefab>().SetPrice("Price: " + cucumberOrderPrice[i]);
                order.GetComponent<CucumberPrefab>().SetQuantity("Quantity: " + cucumberOrderQuantity[i]);
                order.GetComponent<CucumberPrefab>().SetName("Seller: " + cucumberOrderName[i]);
                order.transform.SetParent(cucumberSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
    public void BuyEggplant()
    {
        StartCoroutine(BuyEggplantEnumerator());
    }
    IEnumerator BuyEggplantEnumerator()
    {
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buyeggplant.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        eggplantOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        eggplantOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        eggplantOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        eggplantOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
            else if(MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/buyeggplant_online.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        eggplantOrderPrice = www.text.Split('\t');
                        orderPriceList = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        eggplantOrderQuantity = www.text.Split('\t');
                        orderQuantityList = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        eggplantOrderName = www.text.Split('\t');
                        orderNameList = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        eggplantOrderId = www.text.Split('\t');
                        whatToPick = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }            
            orderList.Clear();
        }
        if(eggplantOrderName.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < eggplantOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(eggplantSellTemplate);
                order.name = i.ToString();
                order.SetActive(true);
                order.GetComponent<EggplantPrefab>().SetPrice("Price: " + eggplantOrderPrice[i]);
                order.GetComponent<EggplantPrefab>().SetQuantity("Quantity: " + eggplantOrderQuantity[i]);
                order.GetComponent<EggplantPrefab>().SetName("Seller: " + eggplantOrderName[i]);
                order.transform.SetParent(eggplantSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
    // functie care preia datele orderului selectat si le stocheaza in variabilele predate scriptului php
    public void getConfirmationDetails()
    {
        int.TryParse(EventSystem.current.currentSelectedGameObject.name, out confirmationOrderId);
        confirmationOrderName = orderNameList[confirmationOrderId];
        confirmationOrderPrice = orderPriceList[confirmationOrderId];
        confirmationOrderQuantity = orderQuantityList[confirmationOrderId];
    }
    //functie care updateaza ecranul shopului ( un refresh la orderele care au ramas in shop )
    public void updateOrdersAfterBuy()
    {
        switch (confirmationWhatPlant)
        {
            case 1: BuyTomato();
                break;
            case 2: BuyPotato();
                break;
            case 3: BuyCarrot();
                break;
            case 4: BuyCorn();
                break;
            case 5: BuyCucumber();
                break;
            case 6: BuyEggplant();
                break;
        }
    }
    //cand apesi pe butonul buy executa scriptul php care sterge orderul din shop si da playerilor banii/semintele luate
    public void ConfirmBuyOrder()
    {
        StartCoroutine(ConfirmBuyOrderEnumerator());
    }
    IEnumerator ConfirmBuyOrderEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("orderPrice", confirmationOrderPrice);
        form.AddField("orderId", confirmationOrderId);
        form.AddField("orderQuantity", confirmationOrderQuantity);
        form.AddField("whatPlant", confirmationWhatPlant);
        form.AddField("sellerName", orderNameList[confirmationOrderId]);
        form.AddField("buyerName", MySQL.username);
        if(MySQL.money >= int.Parse(confirmationOrderPrice))
        {
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/confirmBuy.php", form);
                yield return www;
                MySQL.level = int.Parse(www.text.Split('\t')[1]);
                MySQL.money = int.Parse(www.text.Split('\t')[2]);
                MySQL.playerExperience = int.Parse(www.text.Split('\t')[3]);
                MySQL.experienceNeeded = int.Parse(www.text.Split('\t')[4]);
                MySQL.tomatoSeeds = int.Parse(www.text.Split('\t')[5]);
                MySQL.cornSeeds = int.Parse(www.text.Split('\t')[6]);
                MySQL.carrotSeeds = int.Parse(www.text.Split('\t')[7]);
                MySQL.cucumberSeeds = int.Parse(www.text.Split('\t')[8]);
                MySQL.potatoSeeds = int.Parse(www.text.Split('\t')[9]);
                MySQL.eggplantSeeds = int.Parse(www.text.Split('\t')[10]);
                MySQL.newAccount = int.Parse(www.text.Split('\t')[11]);
            }
            else if (MySQL.localBuild = false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/confirmBuy_online.php", form);
                yield return www;
                MySQL.level = int.Parse(www.text.Split('\t')[1]);
                MySQL.money = int.Parse(www.text.Split('\t')[2]);
                MySQL.playerExperience = int.Parse(www.text.Split('\t')[3]);
                MySQL.experienceNeeded = int.Parse(www.text.Split('\t')[4]);
                MySQL.tomatoSeeds = int.Parse(www.text.Split('\t')[5]);
                MySQL.cornSeeds = int.Parse(www.text.Split('\t')[6]);
                MySQL.carrotSeeds = int.Parse(www.text.Split('\t')[7]);
                MySQL.cucumberSeeds = int.Parse(www.text.Split('\t')[8]);
                MySQL.potatoSeeds = int.Parse(www.text.Split('\t')[9]);
                MySQL.eggplantSeeds = int.Parse(www.text.Split('\t')[10]);
                MySQL.newAccount = int.Parse(www.text.Split('\t')[11]);
            }
        }
        else
        {
            Debug.Log("nai bani ba poor");
        }
    }
    public void TomatoPlayerOrders()
    {
        StartCoroutine(TomatoPlayerOrderEnumerator());
    }
    IEnumerator TomatoPlayerOrderEnumerator()
    {
        for (int i = 0; i < 3; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPickPO", whatToPickPO);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/playerorderstmt.php", form);
                yield return www;
                switch (whatToPickPO) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        tomatoPlayerOrderPrice = www.text.Split('\t');
                        playerOrderPriceList = www.text.Split('\t');
                        whatToPickPO = 2;
                        break;
                    case 2:
                        tomatoPlayerOrderQuantity = www.text.Split('\t');
                        playerOrderQuantityList = www.text.Split('\t');
                        whatToPickPO = 3;
                        break;
                    case 3:
                        eggplantOrderId = www.text.Split('\t');
                        whatToPickPO = 1;
                        break;
                }
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/playerorderstmt_online.php", form);
                yield return www;
                switch (whatToPickPO) //1=price ;; 2=quantity ;; 3=name
                {
                    case 1:
                        tomatoPlayerOrderPrice = www.text.Split('\t');
                        playerOrderPriceList = www.text.Split('\t');
                        whatToPickPO = 2;
                        break;
                    case 2:
                        tomatoPlayerOrderQuantity = www.text.Split('\t');
                        playerOrderQuantityList = www.text.Split('\t');
                        whatToPickPO = 3;
                        break;
                    case 3:
                        eggplantOrderId = www.text.Split('\t');
                        whatToPickPO = 1;
                        break;
                }
            }
        }
        if (orderList.Count > 0)
        {
            foreach (GameObject order in orderList)
            {
                Destroy(order.gameObject);
            }
            orderList.Clear();
        }
        if (eggplantOrderName.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < eggplantOrderName.Length - 1; i++)
            {
                GameObject order = Instantiate(eggplantSellTemplate);
                order.name = i.ToString();
                order.SetActive(true);
                order.GetComponent<EggplantPrefab>().SetPrice("Price: " + eggplantOrderPrice[i]);
                order.GetComponent<EggplantPrefab>().SetQuantity("Quantity: " + eggplantOrderQuantity[i]);
                order.GetComponent<EggplantPrefab>().SetName("Seller: " + eggplantOrderName[i]);
                order.transform.SetParent(eggplantSellTemplate.transform.parent, false);
                orderList.Add(order);
            }
        }
    }
}