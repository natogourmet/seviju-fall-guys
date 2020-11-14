using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float tiempo;
    public bool vaADesaparecer;
    public float tiempoDeVida;
    public Animator animator;

    void Start()
    {
        vaADesaparecer = false;
    }

    void Update()
    {
        //if (vaADesaparecer)
        //{
        //    contarTiempo();
        //}

        //if (tiempo >= tiempoDeVida)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    //void contarTiempo()
    //{
    //    tiempo = tiempo + Time.deltaTime;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //vaADesaparecer = true;
        animator.SetBool("morir", true);
    }

    void morir()
    {
        Destroy(this.gameObject);
    }

}
