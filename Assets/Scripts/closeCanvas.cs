using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    public void close()
    {
        canvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale=1;
    }
}
