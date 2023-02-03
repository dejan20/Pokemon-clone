using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStat : MonoBehaviour
{
    Unit unit;
    [SerializeField] SpiritParty spiritParty = new SpiritParty();
    int j;

    // Start is called before the first frame update
    void Start()
    {
        spiritParty = GameObject.Find("character").GetComponent<SpiritParty>();

        for (int i = 0; i < spiritParty.spiritList.Count; i++)
        {
            unit = spiritParty.spiritList[j].gameObject.GetComponent<Unit>();

            unit.maxHP += 10;
            unit.attack += 5;

            j++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
