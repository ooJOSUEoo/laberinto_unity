using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    public float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    //This function is where we will design our interaction using code
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        if (doorOpen)
        {
            // StartCoroutine(CloseDoorAfterDelay(delay)); // Cierra la puerta después de 2 segundos
        }
    }
    private IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorOpen = false;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}