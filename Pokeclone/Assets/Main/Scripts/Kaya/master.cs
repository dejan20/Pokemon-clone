using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public int screenwidth;
    public int screenheight;
    [SerializeField] public List<GameObject> allSpiritList;

    void Start()
    {
        Screen.SetResolution(screenwidth, screenheight, true);
    }
}
