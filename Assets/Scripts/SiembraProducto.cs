using UnityEngine;
using System.Collections;

public class SiembraProducto : MonoBehaviour
{
    //crear variables
    // public DatosSemillas datos;
    private int estado=0; //para controlar las animaciones
    private float tiempoEspera = 8f;
    private Animator animaciones;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //tiempoEspera = datos.tiempoEspera;
        animaciones = GetComponent<Animator>();
        //iniciar la Coroutine
        StartCoroutine(Siembra());

    }

    //crear IEnumerator
    IEnumerator Siembra(){
        for(int i =0;i<3;i++){
            yield return new WaitForSeconds(tiempoEspera);
            estado += 1;
            animaciones.SetInteger("estado", estado);
            Debug.Log("Estado Trigo " + estado);
        }
    }
}
