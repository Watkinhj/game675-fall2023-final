using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;

    private CharacterController controller;
    private Camera playerCamera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Player Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
        controller.Move(direction * speed * Time.deltaTime);

        // Player Rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        transform.Rotate(Vector3.up * mouseX);
        playerCamera.transform.Rotate(Vector3.left * mouseY);
    }
}