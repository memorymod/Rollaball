using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour {

    public float moveSpeed = 10;
    public float jumpSpeed = 7;
    public float speedMultiplier = 100;
    public float maxVelocity = 5;
    public bool grounded;

    float h;
    float v;

    Transform cameraPivot;
    Rigidbody rb;
    PlayerJumpBoxScript jumpBox;
    AudioSource aud;

    Vector3 lastContact;
    float cooldownTime;

    private void Start()
    {
        jumpBox = GameObject.Find ("Player Jump Box").GetComponent<PlayerJumpBoxScript>();
        cameraPivot = Camera.main.transform.parent;
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxVelocity;
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        h = -Input.GetAxis("Horizontal");
        v = -Input.GetAxis("Vertical");
        grounded = jumpBox.grounded;

        Vector3 camForward = Vector3.Scale(cameraPivot.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (v * camForward + h * cameraPivot.right).normalized;

        rb.AddForce(moveDirection * moveSpeed * speedMultiplier * Time.deltaTime);

        if (Input.GetButtonDown ("Jump") && grounded)
        {
            rb.AddForce(0, jumpSpeed * speedMultiplier * Time.deltaTime, 0, ForceMode.Impulse);
        }

        cooldownTime -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 1)
        {
            aud.Play();
        }
    }
}