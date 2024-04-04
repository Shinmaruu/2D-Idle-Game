using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] int beans;
    [SerializeField] TextMeshProUGUI beanDisplay;
    [SerializeField] GameObject storePage;
    private bool storePageBool;

    [SerializeField] TextMeshProUGUI fishPrice;
    [SerializeField] TextMeshProUGUI empPrice;
    [SerializeField] TextMeshProUGUI cmPrice;



    public string saleString = "Beans: ";


    public int clickMultiplier = 1;
    public int generateMultipler = 1;


    public int fishCost = 50;
    public int empCost = 10;
    public int cmCost = 20;



    // singleton code
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // ------------------------------------------------

    void Start()
    {
        StartCoroutine(GenerateBean());
        storePageBool = false;

        fishPrice.text = fishCost.ToString();
        empPrice.text = empCost.ToString();
        cmPrice.text = cmCost.ToString();



    }

    void Update()
    {
        beanDisplay.text = saleString + beans.ToString();
    }

    private IEnumerator GenerateBean()
    {
        beans += 1 * generateMultipler;

        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(GenerateBean());
    }
    public void Click()
    {
        beans += 1 * clickMultiplier;
    }

    public void StoreButton()
    {
        if (storePageBool == false)
        {
            storePage.SetActive(true);
            storePageBool = true;
        } else
        {
            storePage.SetActive(false);
            storePageBool = false;
        }
    }

    public void BuyFish()
    {
        if (beans < fishCost)
        {
            saleString = "Fish: ";
            fishPrice.text = "Sold Out";

        }
    }

    public void BuyCM()
    {
        if (beans < cmCost)
        {
            return;
        } else
        {
            beans -= cmCost;
            generateMultipler += 1;
            cmCost += 20;
            cmPrice.text = cmCost.ToString();
        }
    }

    public void BuyEmp()
    {
        if (beans < empCost)
        {
            return;
        }
        else
        {
            beans -= empCost;
            generateMultipler += 1;
            empCost += 30;
            empPrice.text = empCost.ToString();
        }
    }


}
