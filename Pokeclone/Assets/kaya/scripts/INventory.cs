using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INventory : MonoBehaviour
{

    public GameObject prefab;
    [SerializeField] List<GameObject> Itemslist;
    public void Inv()
    {

    }


    // Start is called before the first frame update
    void Start()
    {

        Itemslist = new List<GameObject>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Itemslist.Add((GameObject)Instantiate(prefab));
            
        }

    }
}
