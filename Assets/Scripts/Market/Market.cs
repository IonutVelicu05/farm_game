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
    private string[] plantOrderType; //lista cu tipu de planta la orderele plasate de player;;
    private string[] playerOrderIdList;
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
    //delete order from market ;; detaliile predate scriptului php pentru a efectua stergerea din SQL;
    private string deleteOrderPrice;
    private int deleteOrderId;
    private string deleteOrderQuantity;
    private int whatToDelete = 0; //1=rosie ;; 2=potato;; 3=carrot; 4=corn;; 5=cucumber;; 6=eggplant
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
    // // // new market ???
    private string[] marketOrderId;
    private string[] marketOrderPrice;
    private string[] marketOrderQuantity;
    private string[] marketOrderSellerName;
    private string[] marketOrderPlantType;
    private int whatPlantsToShow = 0;
    private int indexMarketVars;
    private int selectedOrderPrice;

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
            //BuyTomato();
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
            //BuyPotato();
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
            //BuyCarrot();
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
           // BuyCorn();
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
            //BuyCucumber();
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
            //BuyEggplant();
            confirmationWhatPlant = 6;
            Debug.Log(confirmationWhatPlant);
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            eggplantSellMenu.SetActive(true);
        }
    }
    public void SelectTomatoDelete()
    {
        whatToDelete = 1;
    }
    public void SelectPotatoDelete()
    {
        whatToDelete = 2;
    }
    public void SelectCornDelete()
    {
        whatToDelete = 3;
    }
    public void SelectCarrotDelete()
    {
        whatToDelete = 4;
    }
    public void SelectCucumberDelete()
    {
        whatToDelete = 5;
    }
    public void SelectEggplantDelete()
    {
        whatToDelete = 6;
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
    /*
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
    } */
    public void ShowMarketTomato()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            tomatoBuyMenu.SetActive(true);
            BuyFromMarket();
            whatPlantsToShow = 1;
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            tomatoSellMenu.SetActive(true);
        }
    }
    public void ShowMarketPotato()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            potatoBuyMenu.SetActive(true);
            BuyFromMarket();
            whatPlantsToShow = 2;
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            potatoSellMenu.SetActive(true);
        }
    }
    public void ShowMarketCarrot()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            carrotBuyMenu.SetActive(true);
            BuyFromMarket();
            whatPlantsToShow = 3;
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            carrotSellMenu.SetActive(true);
        }
    }
    public void ShowMarketCorn()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            cornBuyMenu.SetActive(true);
            BuyFromMarket();
            whatPlantsToShow = 4;
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            cornSellMenu.SetActive(true);
        }
    }
    public void ShowMarketCucumber()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            cucumberBuyMenu.SetActive(true);
            BuyFromMarket();
            whatPlantsToShow = 5;
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            cucumberSellMenu.SetActive(true);
        }
    }
    public void ShowMarketEggplant()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            eggplantBuyMenu.SetActive(true);
            BuyFromMarket();
            whatPlantsToShow = 6;
        }
        else if (swapBuySell == false)
        {
            sellMenu.SetActive(true);
            eggplantSellMenu.SetActive(true);
        }
    }
    public void BuyFromMarket()
    {
        StartCoroutine(BuyFromMarketEnumerator());
    }
    IEnumerator BuyFromMarketEnumerator()
    {
        for (int i = 0; i < 5; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buyfrommarket.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name ;; 4=id ;; 5=planttype;;
                {
                    case 1:
                        marketOrderPrice = www.text.Split('\t');
                        whatToPick = 2;
                        break;
                    case 2:
                        marketOrderQuantity = www.text.Split('\t');
                        whatToPick = 3;
                        break;
                    case 3:
                        marketOrderSellerName = www.text.Split('\t');
                        whatToPick = 4;
                        break;
                    case 4:
                        marketOrderId = www.text.Split('\t');
                        whatToPick = 5;
                        break;
                    case 5:
                        marketOrderPlantType = www.text.Split('\t');
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
        if (marketOrderId.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < marketOrderId.Length - 1; i++)
            {
                switch (int.Parse(marketOrderPlantType[i]))
                {
                    case 1:
                        GameObject tomatoOrder = Instantiate(tomatoSellTemplate);
                        tomatoOrder.name = marketOrderId[i];
                        tomatoOrder.SetActive(true);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetPrice(marketOrderPrice[i]);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        tomatoOrder.transform.SetParent(tomatoSellTemplate.transform.parent, false);
                        orderList.Add(tomatoOrder);
                        break;
                    case 2:
                        GameObject potatoOrder = Instantiate(potatoSellTemplate);
                        potatoOrder.name = marketOrderId[i];
                        potatoOrder.SetActive(true);
                        potatoOrder.GetComponent<PotatoPrefab>().SetPrice(marketOrderPrice[i]);
                        potatoOrder.GetComponent<PotatoPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        potatoOrder.GetComponent<PotatoPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        potatoOrder.transform.SetParent(potatoSellTemplate.transform.parent, false);
                        orderList.Add(potatoOrder);
                        break;
                    case 3:
                        GameObject carrotOrder = Instantiate(carrotSellTemplate);
                        carrotOrder.name = marketOrderId[i];
                        carrotOrder.SetActive(true);
                        carrotOrder.GetComponent<CarrotPrefab>().SetPrice(marketOrderPrice[i]);
                        carrotOrder.GetComponent<CarrotPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        carrotOrder.GetComponent<CarrotPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        carrotOrder.transform.SetParent(carrotSellTemplate.transform.parent, false);
                        orderList.Add(carrotOrder);
                        break;
                    case 4:
                        GameObject cornOrder = Instantiate(cornSellTemplate);
                        cornOrder.name = marketOrderId[i];
                        cornOrder.SetActive(true);
                        cornOrder.GetComponent<CornPrefab>().SetPrice(marketOrderPrice[i]);
                        cornOrder.GetComponent<CornPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        cornOrder.GetComponent<CornPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        cornOrder.transform.SetParent(cornSellTemplate.transform.parent, false);
                        orderList.Add(cornOrder);
                        break;
                    case 5:
                        GameObject cucumberOrder = Instantiate(cucumberSellTemplate);
                        cucumberOrder.name = marketOrderId[i];
                        cucumberOrder.SetActive(true);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetPrice(marketOrderPrice[i]);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        cucumberOrder.transform.SetParent(cucumberSellTemplate.transform.parent, false);
                        orderList.Add(cucumberOrder);
                        break;
                    case 6:
                        GameObject eggplantOrder = Instantiate(eggplantSellTemplate);
                        eggplantOrder.name = marketOrderId[i];
                        eggplantOrder.SetActive(true);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetPrice(marketOrderPrice[i]);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        eggplantOrder.transform.SetParent(eggplantSellTemplate.transform.parent, false);
                        orderList.Add(eggplantOrder);
                        break;
                }
            }
        }
    }
    // functie care preia datele orderului selectat si le stocheaza in variabilele predate scriptului php
    public void getConfirmationDetails()
    {
        int.TryParse(EventSystem.current.currentSelectedGameObject.name, out confirmationOrderId);
        switch (whatPlantsToShow)
        {
            case 1:
                selectedOrderPrice = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<TomatoPrefab>().getPrice());
                break;
            case 2:
                selectedOrderPrice = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<PotatoPrefab>().getPrice());
                break;
            case 3:
                selectedOrderPrice = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<CarrotPrefab>().getPrice());
                break;
            case 4:
                selectedOrderPrice = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<CornPrefab>().getPrice());
                break;
            case 5:
                selectedOrderPrice = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<CucumberPrefab>().getPrice());
                break;
            case 6:
                selectedOrderPrice = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<EggplantPrefab>().getPrice());
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
        form.AddField("orderId", confirmationOrderId);
        form.AddField("buyerName", MySQL.username);
        if(MySQL.money >= selectedOrderPrice)
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
    public void ShowPlayerOrders()
    {
        StartCoroutine(ShowPlayerOrdersEnumerator());
    }
    IEnumerator ShowPlayerOrdersEnumerator()
    {
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("whatToPickPO", whatToPickPO);
            form.AddField("username", MySQL.username);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/playerorderslist.php", form);
                yield return www;
                switch (whatToPickPO) //1=price ;; 2=quantity ;; 3=name ;; 4=orderId ;;
                {
                    case 1:
                        plantOrderType = www.text.Split('\t');
                        whatToPickPO = 2;
                        break;
                    case 2:
                        playerOrderPriceList = www.text.Split('\t');
                        whatToPickPO = 3;
                        break;
                    case 3:
                        playerOrderQuantityList = www.text.Split('\t');
                        whatToPickPO = 4;
                        break;
                    case 4:
                        playerOrderIdList = www.text.Split('\t');
                        whatToPickPO = 1;
                        break;
                }
            }
            else if(MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/market/playerorderslist_online.php", form);
                yield return www;
                switch (whatToPickPO) //1=price ;; 2=quantity ;; 3=name ;; 4=orderId ;;
                {
                    case 1:
                        plantOrderType = www.text.Split('\t');
                        whatToPickPO = 2;
                        break;
                    case 2:
                        playerOrderPriceList = www.text.Split('\t');
                        whatToPickPO = 3;
                        break;
                    case 3:
                        playerOrderQuantityList = www.text.Split('\t');
                        whatToPickPO = 4;
                        break;
                    case 4:
                        playerOrderIdList = www.text.Split('\t');
                        whatToPickPO = 1;
                        break;
                }
            }
        }
        if (playerOrdersList.Count > 0)
        {
            foreach (GameObject order in playerOrdersList)
            {
                Destroy(order.gameObject);
            }
            playerOrdersList.Clear();
        }
        if (playerOrderIdList.Length > 0) //daca exista date luate din database sa creeze obiectele order
        {
            for (int i = 0; i < playerOrderIdList.Length - 1; i++)
            {
                switch (int.Parse(plantOrderType[i]))
                {
                    case 1:
                        GameObject tomatoOrder = Instantiate(tomatoOrderTemplate);
                        tomatoOrder.name = playerOrderIdList[i];
                        tomatoOrder.SetActive(true);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetPrice("Price: " + playerOrderPriceList[i]);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetQuantity("Quantity: " + playerOrderQuantityList[i]);
                        tomatoOrder.transform.SetParent(tomatoOrderTemplate.transform.parent, false);
                        playerOrdersList.Add(tomatoOrder);
                        break;
                    case 2:
                        GameObject potatoOrder = Instantiate(potatoOrderTemplate);
                        potatoOrder.name = playerOrderIdList[i];
                        potatoOrder.SetActive(true);
                        potatoOrder.GetComponent<PotatoPrefab>().SetPrice("Price: " + playerOrderPriceList[i]);
                        potatoOrder.GetComponent<PotatoPrefab>().SetQuantity("Quantity: " + playerOrderQuantityList[i]);
                        potatoOrder.transform.SetParent(potatoOrderTemplate.transform.parent, false);
                        playerOrdersList.Add(potatoOrder);
                        break;
                    case 3:
                        GameObject carrotOrder = Instantiate(carrotOrderTemplate);
                        carrotOrder.name = playerOrderIdList[i];
                        carrotOrder.SetActive(true);
                        carrotOrder.GetComponent<CarrotPrefab>().SetPrice("Price: " + playerOrderPriceList[i]);
                        carrotOrder.GetComponent<CarrotPrefab>().SetQuantity("Quantity: " + playerOrderQuantityList[i]);
                        carrotOrder.transform.SetParent(carrotOrderTemplate.transform.parent, false);
                        playerOrdersList.Add(carrotOrder);
                        break;
                    case 4:
                        GameObject cornOrder = Instantiate(cornOrderTemplate);
                        cornOrder.name = playerOrderIdList[i];
                        cornOrder.SetActive(true);
                        cornOrder.GetComponent<CornPrefab>().SetPrice("Price: " + playerOrderPriceList[i]);
                        cornOrder.GetComponent<CornPrefab>().SetQuantity("Quantity: " + playerOrderQuantityList[i]);
                        cornOrder.transform.SetParent(cornOrderTemplate.transform.parent, false);
                        playerOrdersList.Add(cornOrder);
                        break;
                    case 5:
                        GameObject cucumberOrder = Instantiate(cucumberOrderTemplate);
                        cucumberOrder.name = playerOrderIdList[i];
                        cucumberOrder.SetActive(true);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetPrice("Price: " + playerOrderPriceList[i]);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetQuantity("Quantity: " + playerOrderQuantityList[i]);
                        cucumberOrder.transform.SetParent(cucumberOrderTemplate.transform.parent, false);
                        playerOrdersList.Add(cucumberOrder);
                        break;
                    case 6:
                        GameObject eggplantOrder = Instantiate(eggplantOrderTemplate);
                        eggplantOrder.name = playerOrderIdList[i];
                        eggplantOrder.SetActive(true);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetPrice("Price: " + playerOrderPriceList[i]);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetQuantity("Quantity: " + playerOrderQuantityList[i]);
                        eggplantOrder.transform.SetParent(eggplantOrderTemplate.transform.parent, false);
                        playerOrdersList.Add(eggplantOrder);
                        break;
                }
            }
        }
    }
    public void getDeleteOrderDetails()
    {
        int.TryParse(EventSystem.current.currentSelectedGameObject.name, out deleteOrderId);
    }
    public void DeleteOrderFromShop()
    {
        StartCoroutine(DeleteOrderFromShopEnum());
    }
    IEnumerator DeleteOrderFromShopEnum()
    {
        WWWForm form = new WWWForm();
        form.AddField("orderId", deleteOrderId);
        form.AddField("sellerName", MySQL.username);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/market/deleteorder.php", form);
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
            ShowPlayerOrders();
        }
        if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/market/deleteorder_online.php", form);
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
            ShowPlayerOrders();
        }
    }
}