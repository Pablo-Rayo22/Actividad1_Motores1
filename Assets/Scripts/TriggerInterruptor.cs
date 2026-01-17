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
    [SerializeField] GameObject[] arrayPuertas = new GameObject[numPuertas];

    //Variables privadas
    private bool disparo = false;
    //private bool puertaAbierta = false;
    private static int numPuertas = 3; // hnblkefdjvbñlkjhfsks
    
    // Update is called once per frame

    void Update()
    {
        detectarCanvas.gameObject.SetActive(false);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit choque, distanciaMaxima, layerMask))
        {
            if (choque.collider)
            {
                //Debug.Log("Hay un interruptor cerca");
                detectarCanvas.gameObject.SetActive (true);
            }
            DispararRayo();
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
    
    private void AbrirPuerta()
    {
        for (int i = 0; i < arrayPuertas.Length; i++)
        {
            
        }
    }
}