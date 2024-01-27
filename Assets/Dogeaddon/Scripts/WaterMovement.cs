using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    void Update()
    {
        // Mover el offset del material en el eje x e y basado en el tiempo.
        float offsetX = Time.time * scrollSpeed;
        float offsetY = Time.time * scrollSpeed;

        // Crear un vector de offset y asignarlo al material.
        Vector2 offset = new Vector2(offsetX, offsetY);
        GetComponent<Renderer>().material.mainTextureOffset = offset;

        // Otra opción: Si deseas un movimiento solo en un eje (por ejemplo, solo en x):
        // float offsetX = Time.time * scrollSpeed;
        // Vector2 offset = new Vector2(offsetX, 0f);
        // GetComponent<Renderer>().material.mainTextureOffset = offset;

        // Puedes ajustar scrollSpeed para controlar la velocidad del movimiento.
    }
}
