using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioNivelBoton : MonoBehaviour
{
    public Image Barra;

    AsyncOperation Operacion;

    public void CargarEscena(int nivel)
    {
        StartCoroutine(Cargando(nivel));
    }
IEnumerator Cargando(int nivel)
    {
        Operacion = SceneManager.LoadSceneAsync(nivel);
        
        while (!Operacion.isDone)
        {
            Barra.fillAmount = Operacion.progress;
            yield return null;
        }
    }
}