using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritParty : MonoBehaviour
{
    [SerializeField] public List<GameObject> spiritList  = new List<GameObject>(5);
    [SerializeField] private master master;
    [SerializeField] private SpiritPartyUI spiritPartyUI;

    [SerializeField] private GameObject spiritSelector1;
    [SerializeField] private GameObject spiritSelector2;
    [SerializeField] private GameObject spiritSelector3;
    [SerializeField] private GameObject spiritSelector4;
    [SerializeField] private GameObject spiritSelector5;

    public static int i;
    public int selectedSpirit;

    void Awake()
    {
        Debug.Log("Test35");
        spiritPartyUI = GameObject.Find("Spirit Inventory").GetComponent<SpiritPartyUI>();
    }
    
    void Update()
    {
        if (selectedSpirit >= 5)
        {
            selectedSpirit = 0;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            spiritList.Add(master.allSpiritList[1]);
            spiritPartyUI.SpiritPartyImages(i);
            i++;
        }

        if (spiritList.Count > 5)
        {
            Debug.Log("Can't have more than 5 spirits!");
            spiritList.RemoveAt(5);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            selectedSpirit++;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            selectedSpirit--;
        }

        if (selectedSpirit == 0)
        {
            SelecterOff();

            spiritSelector1.SetActive(true);
        }
        else if (selectedSpirit == 1)
        {
            SelecterOff();

            spiritSelector2.SetActive(true);
        }
        else if (selectedSpirit == 2)
        {
            SelecterOff();

            spiritSelector3.SetActive(true);
        }
        else if (selectedSpirit == 3)
        {
            SelecterOff();

            spiritSelector4.SetActive(true);
        }
        else if (selectedSpirit == 4)
        {
            SelecterOff();

            spiritSelector5.SetActive(true);
        }
    }

    public void IPlus()
    {
        i++;
    }

    public void SelecterOff()
    {
        spiritSelector1.SetActive(false);
        spiritSelector2.SetActive(false);
        spiritSelector3.SetActive(false);
        spiritSelector4.SetActive(false);
        spiritSelector5.SetActive(false);
    }
}
