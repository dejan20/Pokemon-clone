using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject character;

    public float x = 4.55999994f;
    public float y = 3.75999999f;
    public float z = -8.59000015f;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("character");
        character.transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
