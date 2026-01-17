using System.Security.Cryptography.X509Certificates;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerInterruptor : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] int distanciaMaxima = 5;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Canvas detectarCanvas;
    [SerializeField] InputActionReference disparar;
    [SerializeField] TriggerPuerta puerta;

    //Variables privadas
    private bool disparo = false;
    //private bool puertaAbierta = false;
    //private static int numPuertas = 4;

    // El método update se llama cada frame (cada pintada de pantalla)

    private void Update()
    {
        detectarCanvas.gameObject.SetActive(false);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distanciaMaxima, layerMask))
        {
            if (hit.collider)
            {
                //Debug.Log("Hay un interruptor cerca");
                detectarCanvas.gameObject.SetActive (true);
                DispararRayo();
            }
            puerta.AbrirPuertas();

        }

    }

    private void OnEnable()
    {
        disparar.action.Enable();

        disparar.action.started += OnDisparar;
        disparar.action.performed += OnDisparar;
        disparar.action.canceled += OnDisparar;
    }

    private void OnDisable()
    {
        disparar.action.Disable();

        disparar.action.started -= OnDisparar;
        disparar.action.performed -= OnDisparar;
        disparar.action.canceled -= OnDisparar;
    }

    private void OnDisparar(InputAction.CallbackContext context)
    {
        disparo = context.ReadValueAsButton();
        Debug.Log(context.control.device.name);
    }

    private void DispararRayo()
    {
        if (disparo)
        {
            Debug.Log("Interruptor accionado");
        }
    }
}