using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("character");
        character.transform.position = new Vector3(3.8f, 1.8f, -3.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
