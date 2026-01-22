/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] // Si este GameObject no tiene asignado un componente CharacterController, lo crea

public class MovimientoPersonaje : MonoBehaviour
{
    // Variables
   [Header("Variables publicas")]
    public float velocidad = 5f;
    public float velocidadAngular = 180f;
    public bool bloqueado = false;

    [Header("Variables serializadas")]
    [SerializeField] InputActionReference mover;
    [SerializeField] InputActionReference girar;

    // Variables privadas
    private CharacterController controller;
    private Vector2 vectorMovimiento;
    private float giro;

    // Métodos
    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (bloqueado)
        {
            return;
        }

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