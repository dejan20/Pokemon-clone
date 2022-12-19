using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritParty : MonoBehaviour
{
    [SerializeField] public List<GameObject> spiritList  = new List<GameObject>(5);
    [SerializeField] private master master;
    [SerializeField] private SpiritPartyUI spiritPartyUI;
    public static int i;
    public int selectedSpirit;

    void Awake()
    {
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Switching Spirit");
            selectedSpirit++;
        }
    }

    public void IPlus()
    {
        i++;
    }
}
