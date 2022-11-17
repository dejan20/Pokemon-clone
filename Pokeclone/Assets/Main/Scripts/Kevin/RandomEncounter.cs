using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomEncounter : MonoBehaviour
{
    //placeholder

    private Rigidbody rb;

    public LayerMask whatIsGrass;
    public int MaxRandomRange;
    public int MinRandomRange;

    public float DetectDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("RandomEncounterSystem", 0, 2);


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
                Debug.Log("It's time to dual");
                //start battle system
            }
            else
            {
                Debug.Log("battle not started");

            }

        }
    } 
}
