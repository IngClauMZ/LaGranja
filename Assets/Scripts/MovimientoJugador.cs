using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    //variables
    private float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 entrada;
    private Animator animator;

    [Header("PreFabs")]
    public GameObject trigo;

    // Start es llamada cuando se inicia el script
    void Start()
    { // enlazar componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update es llamada un vez por frame
    void Update()
    {
        rb.linearVelocity = entrada * velocidad;
    }

    // funciones creadas por nosotros
    public void Moverse(InputAction.CallbackContext contexto){
        animator.SetBool("estaCaminando", true);

        if(contexto.canceled){
            animator.SetBool("estaCaminando", false);
            animator.SetFloat("ultimaDirX", entrada.x);
            animator.SetFloat("ultimaDirY", entrada.y);
        }

        entrada =  contexto.ReadValue<Vector2>();
        animator.SetFloat("entradaX", entrada.x);
        animator.SetFloat("entradaY", entrada.y);

        // Debug.Log(entrada.x + " " + entrada.y);

    }

    public void Sembrar(InputAction.CallbackContext contexto){
        if(contexto.started){
            // Debug.Log("Presionaste C");

            //obtener la última dirección en la que se movió el jugador
            float dirX = animator.GetFloat("entradaX");
            float dirY = animator.GetFloat("entradaY");

            // Normalizar para que sea constante
            Vector2 direccion = new Vector2(dirX,dirY).normalized;

            // posicion final
            Vector2 posicionFinal = (Vector2)transform.position + direccion * 1f;

            Instantiate(trigo, posicionFinal, Quaternion.identity);
        }
    }
}
