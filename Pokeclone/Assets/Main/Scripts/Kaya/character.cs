using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    private Rigidbody rigidbody;

    public float speed = 2f;
    public float runSpeed = 5f;
    public float speedCap = 5f;
    public bool hasShoes = false;

    public Animator animator;

    public GameObject playerbodyonly;

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
            float currentSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift) && hasShoes)
            {
                currentSpeed = runSpeed;
            }

            rigidbody.velocity = move.normalized * currentSpeed;

            if (rigidbody.velocity.magnitude > speedCap)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * speedCap;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

        if (rigidbody.velocity.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(move.z, -move.x) * Mathf.Rad2Deg;

            playerbodyonly.transform.rotation = Quaternion.Euler(0f, targetangle, 0);
        }
        if (rigidbody.velocity.magnitude > 0)
        {
            animator.Play("mainwalk");
        }
        else if (rigidbody.velocity.magnitude <= 0)
        {
            animator.Play("idle");
        }
    }
}