using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {

    [Header("Camera Control Settings")]
    public float sensitivity;

    Transform player;
    Vector3 vel;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity, 0f, Space.World);
        transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity, 0f, 0f, Space.Self);
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref vel, 0.1f * Time.deltaTime);
    }
}
