using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public int screenwidth;
    public int screenheight;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(screenwidth, screenheight, true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
