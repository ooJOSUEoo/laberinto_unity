using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public Canvas canvas;
    public void ActivateDoor()
    {
        // door.GetComponent<Transform>().position = new Vector3(0, 2, 0); 
        door.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvas.gameObject.SetActive(true);
        Time.timeScale=0;
    }
}
