using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensivity = 10f;

    [SerializeField] Transform playerBody;

    [SerializeField] float xRotationClampRange = 90;

    float xRotation = 0f;

    void Update()
    {
        MouseMovement();
    }

    private void MouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * 100f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationClampRange, xRotationClampRange);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
