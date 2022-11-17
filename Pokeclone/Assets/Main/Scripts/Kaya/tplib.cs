using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tplib : MonoBehaviour
{
    public int loadscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadscene);
            Debug.Log("tpd");
            
        }

        
    }
}
//comments
//IMPORTANT!!!!
//colider moet groter dan playercontroller
