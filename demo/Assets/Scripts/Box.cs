using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisionamos con un objeto llamado "Box" y que tenga la etiqueta "Player"
        if (collision.gameObject.name == "Box" && collision.gameObject.CompareTag("Player"))
        {
            // El jugador ha chocado con el objeto Box
            // Aquí puedes agregar lógica adicional, como detener el movimiento del jugador.
            Debug.Log("¡Colisión con el objeto Box! Deteniendo el jugador.");

            // Ejemplo: Detener el movimiento del jugador
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
