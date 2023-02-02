using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
      
    // Start is called before the first frame update
    void Start()
    {
        canvas1.GetComponent<Canvas>().enabled = false;
        canvas2.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
