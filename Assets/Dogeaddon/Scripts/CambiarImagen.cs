using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CambiarImagen : MonoBehaviour
{
    public RawImage rawImage;
    public Texture[] imagenes; // Aseg�rate de asignar las im�genes desde el Inspector.

    void Start()
    {
        if (rawImage == null || imagenes == null || imagenes.Length == 0)
        {
            Debug.LogError("Aseg�rate de asignar el objeto RawImage y al menos una imagen en el inspector.");
            return;
        }

        // Llama a la funci�n para cambiar la imagen al iniciar la escena.
        CambiarImagenAleatoria();
    }

    // Llamada por alg�n evento, puedes usarla en un bot�n, por ejemplo.
    public void CambiarImagenAleatoria()
    {
        // Selecciona una imagen aleatoria del array.
        Texture imagenSeleccionada = imagenes[Random.Range(0, imagenes.Length)];

        // Cambia la textura de la imagen cruda (RawImage).
        rawImage.texture = imagenSeleccionada;
    }
}
