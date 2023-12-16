using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    public void ProcessLook(float x, float y)
    {
        float mouseX = x;
        float mouseY = y;
        //Calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //Apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}