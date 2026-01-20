/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))] // Si este game object no tiene asignado un componente characterController, lo crea

public class MovimientoPersonaje : MonoBehaviour
{
    // Variables
   [Header("Variables publicas")]
    public float velocidad = 5f;
    public float velocidadAngular = 180f;
    public float velocidadDeSalto = 5f;

    [Header("Variables serializadas")]
    [SerializeField] InputActionReference mover;
    [SerializeField] InputActionReference girar;
    //[SerializeField] InputActionReference saltar;

    // Variables privadas
    private CharacterController controller;
    private Vector2 vectorMovimiento;
    private float giro;
    //private bool salto = false;

    // Métodos
    // El método Awake se llama justo antes de la ejecucion del Start
    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // El método Update se llama una vez por cada frame(cada pintada de la pantalla)
    private void Update()
    {
        Vector3 movimiento = new Vector3(vectorMovimiento.y, 0, -vectorMovimiento.x) * velocidad;
        float giroPersonaje = giro * velocidadAngular * Time.deltaTime;
        controller.SimpleMove(movimiento);
        transform.Rotate(0, giroPersonaje, 0);

        //Saltar();
    }

    public void OnEnable()
    {
        mover.action.Enable();
        girar.action.Enable();
        //saltar.action.Enable();

        mover.action.started += OnMover;
        mover.action.performed += OnMover;
        mover.action.canceled += OnMover;
        girar.action.started += OnGirar;
        girar.action.performed += OnGirar;
        girar.action.canceled += OnGirar;
        //saltar.action.started += OnSaltar;
        //saltar.action.performed += OnSaltar;
        //saltar.action.canceled += OnSaltar;
    }
    public void OnDisable()
    {
        mover.action.Disable();
        girar.action.Disable();
        //saltar.action.Disable();

        mover.action.started -= OnMover;
        mover.action.performed -= OnMover;
        mover.action.canceled -= OnMover;
        girar.action.started -= OnGirar;
        girar.action.performed -= OnGirar;
        girar.action.canceled -= OnGirar;
        //saltar.action.started -= OnSaltar;
        //saltar.action.performed -= OnSaltar;
        //saltar.action.canceled -= OnSaltar;
    }

    void OnMover(InputAction.CallbackContext context)
    {
        vectorMovimiento = context.ReadValue<Vector2>();
        //Debug.Log(vectorMovimiento);
        //Debug.Log(context.control.device.name);
    }

    void OnGirar(InputAction.CallbackContext context)
    {
        giro = context.ReadValue<float>();
        //Debug.Log(giro);
        //Debug.Log(context.control.device.name);
    }

    //void OnSaltar(InputAction.CallbackContext context) 
    //{
    //    salto = context.ReadValueAsButton();
    //    Debug.Log(context.control.device.name);
    //    Debug.Log("Ha saltado");
    //}

    //void Saltar()
    //{
    //    bool alturaMaximaSuperada = false;
    //   const float gravedadTierra = -9.8f;
    //    Vector3 saltoPersonaje = Vector3.down * velocidadDeSalto *gravedadTierra* Time.deltaTime;
    //    //bool teclaMantenida = false;
    //    if (salto && !alturaMaximaSuperada)
    //    { alturaMaximaSuperada = true;
    //        controller.transform.Translate(saltoPersonaje);
    //    }
    //}
}