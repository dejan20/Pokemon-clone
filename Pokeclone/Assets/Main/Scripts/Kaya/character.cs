using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    

    [SerializeField] private DialogueUI dialogueUI;

    private CharacterController characterController;

    public float Speed = 5f;

    public float run = 10f;

    public bool hasshoes = false;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set;}



    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();


    }

    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move.normalized * Time.deltaTime*Speed);

        if (Input.GetKey(KeyCode.LeftShift)&& hasshoes)
        {
            characterController.Move(move.normalized * Time.deltaTime * run);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }
    }
}
