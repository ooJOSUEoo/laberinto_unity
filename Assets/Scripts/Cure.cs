using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour
{
    public float CantidadCura;
    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && other.GetComponent<PlayerHealth>()){
            other.GetComponent<PlayerHealth>().RecibirCura(CantidadCura);
            Destroy(gameObject);
        }
    }
}
