using UnityEngine;

public class ChangeLayers : MonoBehaviour
{
    public LayerMask targetLayer; // El layer al que quieres cambiar los hijos del objeto actual

    void Start()
    {
        // Cambiar el layer de todos los hijos del objeto actual al layer seleccionado
        ChangeLayersInChildren(transform);
    }

    void ChangeLayersInChildren(Transform currentTransform)
    {
        foreach (Transform child in currentTransform)
        {
            child.gameObject.layer = (int)Mathf.Log(targetLayer.value, 2); // Obtener el índice del layer desde LayerMask

            // Si quieres cambiar el layer de los hijos de los hijos, puedes llamar recursivamente a la función
            // Esto se hace si los hijos tienen más descendientes y también quieres cambiarles el layer
            ChangeLayersInChildren(child);
        }
    }
}
