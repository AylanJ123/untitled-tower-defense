using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Puedes ajustar este valor en el inspector para indicar el nombre de la siguiente escena.
    public string nombreSiguienteEscena = "NombreDeTuSiguienteEscena";

    // M�todo que se ejecuta al hacer clic en el bot�n "Play".
    public void CargarSiguienteEscena()
    {
        // Cargar la siguiente escena seg�n el nombre proporcionado.
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}
