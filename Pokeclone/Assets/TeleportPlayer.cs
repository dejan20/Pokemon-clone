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
        character.transform.position = new Vector3(4.55999994f, 3.75999999f, -8.59000015f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
