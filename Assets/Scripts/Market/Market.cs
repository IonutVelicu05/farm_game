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
    private List<GameObject> orderList = new List<GameObject>(); //lista cu orderele (obiectele/butoanele) create pt ce e plasat in shop
    private List<GameObject> tomatoMarketList = new List<GameObject>();
    private List<GameObject> potatoMarketList = new List<GameObject>();
    private List<GameObject> carrotMarketList = new List<GameObject>();
    private List<GameObject> cornMarketList = new List<GameObject>();
    private List<GameObject> cucumberMarketList = new List<GameObject>();
    private List<GameObject> eggplantMarketList = new List<GameObject>();
    private List<GameObject> playerOrdersList = new List<GameObject>(); // lista cu orderele plasate de player (din meniu `See Your Orders`);
    private string[] playerOrderPriceList; // lista cu preturile la orderele plasate de player;
    private string[] playerOrderQuantityList; // lista cu cantitatiile la orderele plasate de player;
    private string[] plantOrderType; //lista cu tipu de planta la orderele plasate de player;;
    private string[] playerOrderIdList;
    //buy confirmation ;; detaliile predate scriptului php pentru a efectua operatiile SQL
    private int confirmationOrderId;
    private int selectedOrderPrice;
    //delete order from market ;; detaliile predate scriptului php pentru a efectua stergerea din SQL;
    private int deleteOrderId;
    // // // new market ???
    private string[] marketOrderId; // id comenzii (acelasi ca in database);
    private string[] marketOrderPrice; // pretul la order
    private string[] marketOrderQuantity; // cantitatea la order
    private string[] marketOrderSellerName; // numele vanzatorului comenzii respective
    private string[] marketOrderPlantType;  // tipul de planta al comenzii respective
    private int whatPlantsToShow = 0; // cand apasa in market pe ce planta vrea sa cumpere,1=rosie;2=potato;3=carrot;4=corn;5=cucumbr;6=eggplant
    private int lastOrderGot = 0; // numarul id-ului ultimului index al listei de obiecte;; de la el incepe selectia pentru urmatoarele pagini 
    [SerializeField]
    private Text pageNumberTxt;
    private int pageNumber = 1;
    private int lastOrderGotPreviousPage; //numarul de la care incepe selectia din database cand se da PreviousPage();


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
    public void ShowMarketTomato()
    {
        if (swapBuySell == true)
        {
            buyMenu.SetActive(true);
            tomatoBuyMenu.SetActive(true);
            whatPlantsToShow = 1;
            BuyFromMarket();
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
            whatPlantsToShow = 2;
            BuyFromMarket();
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
            whatPlantsToShow = 3;
            BuyFromMarket();
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
            whatPlantsToShow = 4;
            BuyFromMarket();
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
            whatPlantsToShow = 5;
            BuyFromMarket();
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
            whatPlantsToShow = 6;
            BuyFromMarket();
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
        for (int i = 0; i < 4; i++)
        {
            WWWForm form = new WWWForm();
            switch (whatPlantsToShow)
            {
                case 1:
                    form.AddField("plantType", whatPlantsToShow);

                    break;
                case 2: 
                    form.AddField("plantType", whatPlantsToShow);

                    break;
                case 3:
                    form.AddField("plantType", whatPlantsToShow);

                    break;
                case 4:
                    form.AddField("plantType", whatPlantsToShow);

                    break;
                case 5:
                    form.AddField("plantType", whatPlantsToShow);

                    break;
                case 6:
                    form.AddField("plantType", whatPlantsToShow);

                    break;
            }
            form.AddField("whatToPick", whatToPick);
            form.AddField("pageNumber", pageNumber);
            form.AddField("whereToStart", lastOrderGot);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/market/buyfrommarket.php", form);
                yield return www;
                switch (whatToPick) //1=price ;; 2=quantity ;; 3=name ;; 4=id ;;
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
                        whatToPick = 1;
                        break;
                }
            }
        }
        switch (whatPlantsToShow) //curata lista de obiecte ca sa arate doar ce e pe pagina respectiva nu si ce era inainte
        {
            case 1:
                if (tomatoMarketList.Count > 0)
                {
                    foreach (GameObject order in tomatoMarketList)
                    {
                        Destroy(order.gameObject);
                    }
                    tomatoMarketList.Clear();
                }
                break;
            case 2:
                if (potatoMarketList.Count > 0)
                {
                    foreach (GameObject order in potatoMarketList)
                    {
                        Destroy(order.gameObject);
                    }
                    potatoMarketList.Clear();
                }
                break;
            case 3:
                if (carrotMarketList.Count > 0)
                {
                    foreach (GameObject order in carrotMarketList)
                    {
                        Destroy(order.gameObject);
                    }
                    carrotMarketList.Clear();
                }
                break;
            case 4:
                if (cornMarketList.Count > 0)
                {
                    foreach (GameObject order in cornMarketList)
                    {
                        Destroy(order.gameObject);
                    }
                    cornMarketList.Clear();
                }
                break;
            case 5:
                if (cucumberMarketList.Count > 0)
                {
                    foreach (GameObject order in cucumberMarketList)
                    {
                        Destroy(order.gameObject);
                    }
                    cucumberMarketList.Clear();
                }
                break;
            case 6:
                if (eggplantMarketList.Count > 0)
                {
                    foreach (GameObject order in eggplantMarketList)
                    {
                        Destroy(order.gameObject);
                    }
                    eggplantMarketList.Clear();
                }
                break;
        }
        if(marketOrderId.Length > 0)
        {
            for(int i = 0; i < marketOrderId.Length - 1; i++)
            {
                switch (whatPlantsToShow)
                {
                    case 1:
                        GameObject tomatoOrder = Instantiate(tomatoSellTemplate);
                        tomatoOrder.name = marketOrderId[i];
                        tomatoOrder.SetActive(true);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetPrice(marketOrderPrice[i]);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        tomatoOrder.GetComponent<TomatoPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        tomatoOrder.transform.SetParent(tomatoSellTemplate.transform.parent, false);
                        tomatoMarketList.Add(tomatoOrder);
                        break;
                    case 2:
                        GameObject potatoOrder = Instantiate(potatoSellTemplate);
                        potatoOrder.name = marketOrderId[i];
                        potatoOrder.SetActive(true);
                        potatoOrder.GetComponent<PotatoPrefab>().SetPrice(marketOrderPrice[i]);
                        potatoOrder.GetComponent<PotatoPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        potatoOrder.GetComponent<PotatoPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        potatoOrder.transform.SetParent(potatoSellTemplate.transform.parent, false);
                        potatoMarketList.Add(potatoOrder);
                        break;
                    case 3:
                        GameObject carrotOrder = Instantiate(carrotSellTemplate);
                        carrotOrder.name = marketOrderId[i];
                        carrotOrder.SetActive(true);
                        carrotOrder.GetComponent<CarrotPrefab>().SetPrice(marketOrderPrice[i]);
                        carrotOrder.GetComponent<CarrotPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        carrotOrder.GetComponent<CarrotPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        carrotOrder.transform.SetParent(carrotSellTemplate.transform.parent, false);
                        carrotMarketList.Add(carrotOrder);
                        break;
                    case 4:
                        GameObject cornOrder = Instantiate(cornSellTemplate);
                        cornOrder.name = marketOrderId[i];
                        cornOrder.SetActive(true);
                        cornOrder.GetComponent<CornPrefab>().SetPrice(marketOrderPrice[i]);
                        cornOrder.GetComponent<CornPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        cornOrder.GetComponent<CornPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        cornOrder.transform.SetParent(cornSellTemplate.transform.parent, false);
                        cornMarketList.Add(cornOrder);
                        break;
                    case 5:
                        GameObject cucumberOrder = Instantiate(cucumberSellTemplate);
                        cucumberOrder.name = marketOrderId[i];
                        cucumberOrder.SetActive(true);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetPrice(marketOrderPrice[i]);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        cucumberOrder.GetComponent<CucumberPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        cucumberOrder.transform.SetParent(cucumberSellTemplate.transform.parent, false);
                        cucumberMarketList.Add(cucumberOrder);
                        break;
                    case 6:
                        GameObject eggplantOrder = Instantiate(eggplantSellTemplate);
                        eggplantOrder.name = marketOrderId[i];
                        eggplantOrder.SetActive(true);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetPrice(marketOrderPrice[i]);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetQuantity("Quantity: " + marketOrderQuantity[i]);
                        eggplantOrder.GetComponent<EggplantPrefab>().SetName("Name: " + marketOrderSellerName[i]);
                        eggplantOrder.transform.SetParent(eggplantSellTemplate.transform.parent, false);
                        eggplantMarketList.Add(eggplantOrder);
                        break;
                }
            }
        }
    }
    public void resetPageNumber()
    {
        pageNumber = 1;
    }
    public void NextPage()
    {
        pageNumberTxt.text = (int.Parse(pageNumberTxt.text) + 1).ToString();
        pageNumber++;
        switch (whatPlantsToShow)  // de la ce id sa inceapa selectia din database
        {
            case 1: 
                lastOrderGot = int.Parse(tomatoMarketList[tomatoMarketList.Count - 1].name);
                lastOrderGotPreviousPage = int.Parse(tomatoMarketList[0].name);
                break;
            case 2:
                lastOrderGot = int.Parse(potatoMarketList[potatoMarketList.Count - 1].name);
                lastOrderGotPreviousPage = int.Parse(potatoMarketList[0].name);
                break;
            case 3:
                lastOrderGot = int.Parse(cornMarketList[cornMarketList.Count - 1].name);
                lastOrderGotPreviousPage = int.Parse(carrotMarketList[0].name);
                break;
            case 4:
                lastOrderGot = int.Parse(cornMarketList[cornMarketList.Count - 1].name);
                lastOrderGotPreviousPage = int.Parse(cornMarketList[0].name);
                break;
            case 5:
                lastOrderGot = int.Parse(cucumberMarketList[cucumberMarketList.Count - 1].name);
                lastOrderGotPreviousPage = int.Parse(cucumberMarketList[0].name);
                break;
            case 6:
                lastOrderGot = int.Parse(eggplantMarketList[eggplantMarketList.Count - 1].name);
                lastOrderGotPreviousPage = int.Parse(eggplantMarketList[0].name);
                break;
        }
        BuyFromMarket();
    }
    public void PreviousPage()
    {
        if (int.Parse(pageNumberTxt.text) != 1)
        {
            pageNumberTxt.text = (int.Parse(pageNumberTxt.text) - 1).ToString();
            pageNumber--;
            lastOrderGot = lastOrderGotPreviousPage - 1;
        }
        BuyFromMarket();
    }
    public void marketBackButton() // functie care sterge toate obiectele din listele cu plante cand e apsat butonu back
    {

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
                BuyFromMarket();
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
                BuyFromMarket();
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