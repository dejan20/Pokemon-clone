using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class INventory : MonoBehaviour 
{
    public int INVsize;
    public GameObject item1;
    public GameObject itemPickup;
    public iteminteract itemInteract;
    public itemgenerator itemgenerator;
    private float distance;
    private float minimumDistance = 2f;
    public int currentsize;
    public Image iimg;

    InventoryUI inventoryUI = new InventoryUI();

 

    [SerializeField]public List<GameObject> ItemsList;
    


    // Start is called before the first frame update
    void Start()
    {
        ItemsList = new List<GameObject>();

        

    }
 


    void Update()
    {
        itemPickup = GameObject.FindWithTag("Item");
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            ItemsList.Add((GameObject)(item1));
            AddItem();
        }*/
        currentsize = ItemsList.Count;

    }
    //pickup
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("trigger");
        
        if (other.CompareTag("Item"))
        {
            distance = Vector3.Distance(itemPickup.transform.position, transform.position);
            Debug.Log("Work1?");

            if (distance <= minimumDistance)
            {
                Debug.Log("Work?");
                item1 = itemPickup;
                ItemsList.Add(item1);
                AddItem();
                
                
                
                
                iimg = itemPickup.GetComponent<Image>();
                
            }


        }
    }

    private void AddItem()
    {
            if (ItemsList.Count > INVsize)
            {
                Debug.Log("bigger than MAX SIZE");
                ItemsList.RemoveAt(INVsize);
            }
            inventoryUI.Pickup();
    }
}
