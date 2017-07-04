using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpBoxScript : MonoBehaviour {

    public bool grounded;
    public Vector3 offset = new Vector3(0, -0.4f, 0);

    Transform player;

    private void Start()
    {
        player = transform.parent;
        transform.parent = null;
    }

    private void Update()
    {
        transform.position = player.position + offset;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger)
            grounded = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.isTrigger)
            grounded = false;
    }
}
