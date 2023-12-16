using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CodigoMenu : MonoBehaviour
{   
    public GameObject ScrollView;

    public void NuevoJuego(string Nivel){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("lvlsecret", 1);
        PlayerPrefs.SetInt("levels", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(Nivel);
        Time.timeScale=1;
        Debug.Log("nuevo");
    }

    public void ShowLevels()
    {
        ScrollView.SetActive(!ScrollView.activeSelf);
    }
}
