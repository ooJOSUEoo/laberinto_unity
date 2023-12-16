using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harm : MonoBehaviour
{

    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().RecibirDaño(CantidadDaño);
        }
    }
}
