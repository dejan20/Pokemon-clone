using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritParty : MonoBehaviour
{
    [SerializeField] public List<GameObject> spiritList  = new List<GameObject>(5);
    [SerializeField] private master master;
    [SerializeField] private SpiritPartyUI spiritPartyUI;

    [SerializeField] public GameObject spiritPrefabPlayer;

    public int firstSpirit;

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
        if (selectedSpirit >= 6)
        {
            selectedSpirit = 0;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AddSpirit();
        }

        if (spiritList.Count > 5)
        {
            Debug.Log("Can't have more than 5 spirits!");
            spiritList.RemoveAt(5);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            spiritPrefabPlayer = spiritList[selectedSpirit].gameObject;
            spiritPrefabPlayer.SetActive(false);

            selectedSpirit++;

            spiritPrefabPlayer = spiritList[selectedSpirit].gameObject;
            spiritPrefabPlayer.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            spiritPrefabPlayer = spiritList[selectedSpirit].gameObject;
            spiritPrefabPlayer.SetActive(false);
            
            selectedSpirit--;

            spiritPrefabPlayer = spiritList[selectedSpirit].gameObject;
            spiritPrefabPlayer.SetActive(true);
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

    public void AddSpirit()
    {
        spiritList.Add(master.allSpiritList[firstSpirit]);
        spiritPartyUI.SpiritPartyImages(i);
        spiritPrefabPlayer = spiritList[selectedSpirit].gameObject;
        spiritPrefabPlayer = Instantiate(spiritPrefabPlayer, new Vector3(-320, 1, 90), Quaternion.identity);
        //selectedSpirit++;
        spiritPrefabPlayer.transform.SetParent(master.transform);
        spiritList[selectedSpirit] = spiritPrefabPlayer;
        i++;
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
