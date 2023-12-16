using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab del botón que deseas instanciar
    public Transform contentPanel; // Padre donde se instanciarán los botones

    void Start()
    {
        ShowLevels();
    }

    public void ShowLevels()
    {
        // foreach (string levelName in levelNames)
        // {
        //     GameObject newButton = Instantiate(buttonPrefab, contentPanel);
        //     newButton.GetComponentInChildren<Text>().text = levelName; // Cambiar el texto del botón
        //     // Puedes configurar otros atributos del botón aquí, como su posición, tamaño, eventos, etc.
        // }
        if(PlayerPrefs.GetInt("levels") > 0)
        {
            for (int i = 1; i <= PlayerPrefs.GetInt("levels"); i++)
            // for (int i = 1; i <= 10; i++)
            {
                GameObject newButton = Instantiate(buttonPrefab, contentPanel);
                newButton.GetComponentInChildren<Text>().text = "lvl " + i; // Cambiar el texto del botón
                // Puedes configurar otros atributos del botón aquí, como su duración, tamaño, eventos, etc.

                Button buttonComponent = newButton.GetComponent<Button>();
                int levelNumber = i; // Guardar el número de nivel para su uso dentro del evento
                buttonComponent.onClick.AddListener(() => LoadLevel(levelNumber));
            }
        }else{
            //poner un texto de que no hay niveles
            GameObject newButton = Instantiate(buttonPrefab, contentPanel);
            newButton.GetComponentInChildren<Text>().text = "-";
        }
    }
    
    private void LoadLevel(int levelNumber)
    {
        Debug.Log("Cargando nivel " + levelNumber); // Reemplaza esto con la lógica para cargar el nivel
        // Aquí puedes agregar la lógica para cargar el nivel correspondiente al número recibido
        SceneManager.LoadScene(levelNumber);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
