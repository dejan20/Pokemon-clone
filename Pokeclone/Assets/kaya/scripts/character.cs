using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class character : MonoBehaviour
{

     public PlayerINV playerInv;


    private CharacterController characterController;

    public float Speed = 5f;





    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();


    }

    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move.normalized * Time.deltaTime*Speed);


    }

    



}
