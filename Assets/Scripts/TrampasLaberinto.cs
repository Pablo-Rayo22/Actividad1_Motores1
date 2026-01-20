using UnityEngine;

public class TrampasLaberinto : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] GameObject personaje;

    // Variables privadas
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    // Métodos

    private void Start()
    {
        posicionInicial = personaje.transform.position;
        rotacionInicial = personaje.transform.rotation;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        ActivarTrampa(hit.gameObject);
    }

    void ActivarTrampa(GameObject collider)
    {
        
        if (collider.CompareTag("Trampas"))
        {
            Debug.Log("Has muerto");
            Reaparecer();
        }
    }

    private void Reaparecer ()
    {
        personaje.transform.SetPositionAndRotation(posicionInicial, rotacionInicial);

    }
}

