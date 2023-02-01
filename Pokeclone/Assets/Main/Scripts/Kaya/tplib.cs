using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tplib : MonoBehaviour
{
    public int loadscene;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("character");
        character.transform.position = new Vector3(3.8f, 0.8f, -3.7f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (loadscene == 6)
            {
                Debug.Log("tpd");
                character.transform.position = new Vector3(3.8f, 0.8f, -3.7f);
            }

            SceneManager.LoadScene(loadscene);
        }
    }
}
//comments
//IMPORTANT!!!!
//colider moet groter dan playercontroller
