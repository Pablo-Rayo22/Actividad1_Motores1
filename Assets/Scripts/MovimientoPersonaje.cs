/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] //Si no encuentra un CharacterController, lo crea

public class MovimientoPersonaje : MonoBehaviour
{
    // Variables
    [Header("Variables publicas")]
    public float velocidad = 5f;

    [Header("Variables serializadas")]
    [SerializeField] InputActionReference mover;

    //Variables privadas
    private CharacterController controller;
    private Vector2 vectorEntrada;

    //
    //Métodos
    // El método Awake se llama justo antes de la ejecucion del Start
    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();

    }

    // El método Start se llama una vez antes la primera ejecución del update y después de crear el script
    private void Start()
    {
        
    }


    // Update se llama una vez por cada frame (cada pintada de la pantalla)
    private void Update()
    {
        Vector3 movimiento = new Vector3(vectorEntrada.y, 0, -vectorEntrada.x) * velocidad; 
        controller.SimpleMove(movimiento);
    }

    public void OnEnable()
    {
        mover.action.Enable();

        mover.action.started += OnMove;
        mover.action.performed += OnMove;
        mover.action.canceled += OnMove;
    }

    public void OnDisable()
    {
        mover.action.Disable();

        mover.action.started -= OnMove;
        mover.action.performed -= OnMove;
        mover.action.canceled -= OnMove;
    }

    void OnMove (InputAction.CallbackContext context)
    {
        vectorEntrada = context.ReadValue<Vector2>();
        Debug.Log(vectorEntrada);
    }


}
