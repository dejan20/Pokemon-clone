using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerINV : MonoBehaviour  
{
    public class Items : ScriptableObject
    {
        [SerializeField]
        GameObject[] itemsinInv;

        
        public string itemname = ("itemname");
        public int amount = 0;
        public void iNV()
        {

            Debug.Log("invvoid");

        }

    } 

    [SerializeField]
    GameObject[] INVitems;
    // Start is called before the first frame update
    void Start()
    {
        

        

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
