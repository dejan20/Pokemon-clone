using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{


    [SerializeField] private DialogueUI dialogueUI;

    private Rigidbody rigidbody;

    public float Speed = 0.1f;

    public float run = 10f;

    public bool hasshoes = false;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }



    void Start()
    {
        Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rigidbody.AddForce(move.normalized * Speed, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.LeftShift) && hasshoes)
        {
            rigidbody.AddForce(move.normalized * run, ForceMode.VelocityChange);
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