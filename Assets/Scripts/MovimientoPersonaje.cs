/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))] //Si no encuentra un CharacterController, lo crea

public class MovimientoPersonaje : MonoBehaviour
{
    // Variables
   [Header("Variables publicas")]
    public float velocidad = 5f;
    public float velocidadAngular = 180f;

    [Header("Variables serializadas")]
    [SerializeField] InputActionReference mover;
    [SerializeField] InputActionReference girar;

    // Variables privadas
    private CharacterController controller;
    private Vector2 vectorMovimiento;
    private float giro;

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

    }

    public void OnEnable()
    {
        mover.action.Enable();
        girar.action.Enable();

        mover.action.started += OnMover;
        mover.action.performed += OnMover;
        mover.action.canceled += OnMover;
        girar.action.started += OnGirar;
        girar.action.performed += OnGirar;
        girar.action.canceled += OnGirar;


    }

    public void OnDisable()
    {
        mover.action.Disable();
        girar.action.Disable();


        mover.action.started -= OnMover;
        mover.action.performed -= OnMover;
        mover.action.canceled -= OnMover;
        girar.action.started -= OnGirar;
        girar.action.performed -= OnGirar;
        girar.action.canceled -= OnGirar;

    }

    void OnMover(InputAction.CallbackContext context)
    {
        vectorMovimiento = context.ReadValue<Vector2>();
        Debug.Log(vectorMovimiento);
        Debug.Log(context.control.device.name);
    }

    void OnGirar(InputAction.CallbackContext context)
    {
        giro = context.ReadValue<float>();
        Debug.Log(giro);
        Debug.Log(context.control.device.name);
    }
}