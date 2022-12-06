using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour
{
    //placeholder

    private Rigidbody rb;

    public LayerMask whatIsGrass;
    public int MaxRandomRange;
    public int MinRandomRange;

    public int battlescene;

    [SerializeField] GameObject character;
    [SerializeField] private master master = new master();


    public float DetectDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("RandomEncounterSystem", MinRandomRange, MaxRandomRange);
        master = GameObject.Find("master").GetComponent<master>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void RandomEncounterSystem()
    {

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, DetectDistance, whatIsGrass))
        {
            if (Random.Range(0, 10) < 5)
            {
                GameObject.Find("character(Clone)");
                Debug.Log("It's time to dual");
                //start battle system
                
                SceneManager.LoadScene(battlescene);
            }
            else
            {
                Debug.Log("battle not started");

            }

        }
    } 
}
