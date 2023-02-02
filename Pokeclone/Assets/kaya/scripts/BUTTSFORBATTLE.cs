using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUTTSFORBATTLE : MonoBehaviour
{
    INventory inventory;

    public master master = new master();
    public SpiritParty spiritParty = new SpiritParty();
    
    public GameObject item;
    public GameObject test;

    public GameObject spirit;

    public Potion potion;


    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("master").GetComponent<master>();
        spiritParty = GameObject.Find("character").GetComponent<SpiritParty>();
        inventory = GameObject.Find("character").GetComponent<INventory>();
        potion = item.GetComponent<Potion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void butt1()
    {

        spirit = master.transform.GetChild(0).gameObject;
        spirit.GetComponent<Unit>().currentHP += potion.heal;

        //Destroy(inventory.ItemsList[0]);

    }
    public void butt2()
    {

    }
    public void butt3()
    {

    }
}
