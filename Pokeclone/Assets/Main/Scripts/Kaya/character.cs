using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{


    [SerializeField] private DialogueUI dialogueUI;

    private Rigidbody rigidbody;

    public float Speed = 2f;

    public float run = 5f;

    public bool hasshoes = false;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    void Start()
    {
        Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move == Vector3.zero)
        {
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && hasshoes)
            {
                rigidbody.AddForce(move.normalized * run, ForceMode.Force);
            }
            else
            {
                rigidbody.AddForce(move.normalized * Speed, ForceMode.Force);
            }
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
