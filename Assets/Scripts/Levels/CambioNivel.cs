using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public int Nivel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(PlayerPrefs.GetInt("lvlsecret") != 0 && Nivel == 11){
                //enviar al nivel secreto
                SaveNumber("levels", Nivel);
                SceneManager.LoadScene(Nivel);

            }else{
                if (Nivel <= 10)
                {
                    //niveles del 1 al 10
                    SaveNumber("levels", Nivel);
                    SceneManager.LoadScene(Nivel);
                } 
                else
                {
                    //niveles del 11 a adelante
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene(12);
                }
            }
        }
    }

    void SaveNumber(string key, int number)
    {
        PlayerPrefs.SetInt(key, number);
        PlayerPrefs.Save(); // Guardar los cambios
    }

}