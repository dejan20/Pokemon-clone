using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platfromrise : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition1 = new Vector3(2.45099998f, 1.27600002f, 1.82700002f);
    public Vector3 CurrentPosition;
    public GameObject platform;

    bool SwitchActivated = false;
    private void Awake()
    {
        CurrentPosition = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("player detected");
            SwitchActivated = true;
        }
    }

    void Update()
    {
        if (SwitchActivated)
        {
            CurrentPosition = Vector3.Lerp(CurrentPosition, EndPosition1, Time.deltaTime);
            gameObject.transform.position = CurrentPosition;
        }
    }
}
