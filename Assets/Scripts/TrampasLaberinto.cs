using UnityEngine;

public class TrampasLaberinto : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] LayerMask layerMask;


    // Variables privadas
    private bool activarTrampa = false;
    private bool trampaActivada = false;

   
    // Métodos

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trampas")
        {
            activarTrampa = true;
            Debug.Log("Trampa activada");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        trampaActivada = true;
        Debug.Log("Has muerto");
    }
}
