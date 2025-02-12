using UnityEngine;

public class ControladorVR : MonoBehaviour
{

    public Transform controladorDerecho; // Asigna el Right Controller en el Inspector

    public void Disparar()
    {
        if (controladorDerecho == null)
        {
            Debug.LogError("No se ha asignado el controlador derecho en el Inspector.");
            return;
        }

        Ray rayo = new Ray(controladorDerecho.position, controladorDerecho.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit))
        {
            hit.collider.gameObject.GetComponent<EnemigoShooter>()?.DestruirObjetivo();
        }
    }
}
