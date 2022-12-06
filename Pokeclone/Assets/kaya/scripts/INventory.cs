using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;


public class INventory : MonoBehaviour 
{
    public int INVsize;
    public GameObject item;
    public GameObject itemPickup;
    public iteminteract itemInteract;

    private float distance;
    private float minimumDistance = 2f;


    public iteminteract Interactable { get; set; }

    [SerializeField] List<GameObject> ItemsList;
    public void Inv()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        ItemsList = new List<GameObject>();

        itemPickup = GameObject.FindWithTag("Item");

    }
    private void Awake()
    {
    }


    void Update()
    {
   


        if (Input.GetKeyDown(KeyCode.I))
        {
            ItemsList.Add((GameObject)(item));
            AddItem();
        }

    }

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
                item = itemPickup;
                ItemsList.Add(item);
                AddItem();
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
    }
}
