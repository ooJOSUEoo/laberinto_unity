using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=0;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        if(text){
            if(PlayerPrefs.GetInt("lvlsecret") == 0)
            {
                text.text = "GANASTE!  Aunque pudiste hacerlo mejor";
            }else{
                text.text = "GANASTE!  Eres el mejor de todos";
            }
        }
        PlayerPrefs.SetInt("levels", 11);
        PlayerPrefs.Save(); 

        AudioSource[] sonidos=FindObjectsOfType<AudioSource>();

        for (int i=0; i < sonidos.Length; i++) {
            // sonidos[i].Pause();
            Destroy(sonidos[i]);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
