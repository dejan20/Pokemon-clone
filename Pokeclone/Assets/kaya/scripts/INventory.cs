using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INventory : MonoBehaviour
{
    public int INVsize;
    public GameObject item;
    
    [SerializeField] List<GameObject> ItemsList;
    public void Inv()
    {

    }


    // Start is called before the first frame update
    void Start()
    {

        
        ItemsList = new List<GameObject>();



    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ItemsList.Add((GameObject)(item));
            
            if (ItemsList.Count > INVsize)
            {
                Debug.Log("bigger than MAX SIZE");
                ItemsList.RemoveAt(INVsize);
            }
        }

    }
}
