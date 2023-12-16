using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidad de rotación, puedes ajustar este valor en el editor de Unity

    void Update()
    {
        // Girar el objeto sobre su propio eje en cada fotograma
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
