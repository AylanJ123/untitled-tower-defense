using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Puedes ajustar este valor en el inspector para indicar el nombre de la siguiente escena.
    public string nombreSiguienteEscena = "NombreDeTuSiguienteEscena";

    // Método que se ejecuta al hacer clic en el botón "Play".
    public void CargarSiguienteEscena()
    {
        // Cargar la siguiente escena según el nombre proporcionado.
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}
