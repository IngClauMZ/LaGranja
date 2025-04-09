using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    private float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 entrada;
    private Animator animator;

    [Header("PreFabs")]
    public GameObject trigo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = entrada * velocidad;
    }

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
            Debug.Log("Presionaste C");
            Instantiate(trigo, transform.position, Quaternion.identity);
        }
    }
}
