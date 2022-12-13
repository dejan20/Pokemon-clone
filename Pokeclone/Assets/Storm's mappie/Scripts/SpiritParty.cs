using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritParty : MonoBehaviour
{

    //List<GameObject> spiritList;
    [SerializeField] public List<GameObject> spiritList  = new List<GameObject>(5);
    [SerializeField] private master master;
    [SerializeField] private SpiritPartyUI spiritPartyUI;
    public static int i;

    void Awake()
    {
        //spiritList = new List<GameObject>(5);
        Debug.Log("Test35");
        spiritPartyUI = GameObject.Find("Spirit Inventory").GetComponent<SpiritPartyUI>();
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("You added a Spirit");
            spiritList.Add(master.allSpiritList[1]);
            spiritPartyUI.SpiritPartyImages(i);
            i++;
        }
        if (spiritList.Count > 5)
        {
            Debug.Log("Can't have more than 5 spirits!");
            spiritList.RemoveAt(5);
        }
    }

    public void IPlus()
    {
        i++;
    }
}
