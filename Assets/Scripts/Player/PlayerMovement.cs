using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stuff")]
    [SerializeField] private Camera camera;
    [SerializeField] private CharacterController controller;

    [Header("Stats")] 
    [SerializeField] private float movSpeed;
    [SerializeField] private float mouseSens;
    [SerializeField] private float minXRot;
    [SerializeField] private float maxXRot;
    private float xRotation = 0f;

    private void Update()
    {
        Vector3 movement = CalculateMovement();
        controller.Move(movement * (Time.deltaTime * movSpeed));
        Cursor.lockState = CursorLockMode.Locked;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXRot, maxXRot);

        camera.transform.localRotation = Quaternion.Euler(xRotation, -90f, 0f);
        controller.transform.Rotate(Vector3.up * mouseX);
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        right.y = 0f;
        forward.y = 0f;

        return forward * vertical  + right * horizontal;
    }
}
