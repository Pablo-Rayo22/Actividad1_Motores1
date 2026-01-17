using UnityEngine;

public class TriggerPuerta : MonoBehaviour
{
    // Variables

    [Header("Variables serializadas")]
    [SerializeField] GameObject[] arrayPuertas = new GameObject [numPuertas];
    [SerializeField]


    // Variables privadas
    //private bool puertaAbierta = false;
    private static int numPuertas = 4;

    // Métodos
    public void AbrirPuertas ()
    {

    }
}
