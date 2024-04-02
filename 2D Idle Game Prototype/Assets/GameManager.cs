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
        storePage.SetActive(false);
    }

    void Update()
    {
        beanDisplay.text = "Beans: " + beans;
    }

    private IEnumerator GenerateBean()
    {
        beans += 1;

        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(GenerateBean());
    }
    public void Click()
    {
        beans += 1;
    }

    public void OpenStore()
    {
        storePage.SetActive(true);
    }

    public void CloseStore()
    {
        storePage.SetActive(false);
    }


}
