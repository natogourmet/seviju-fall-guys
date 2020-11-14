using UnityEngine;

public class Persona : MonoBehaviour
{
    public int edad;
    public string nombre;
    public float velocidad;
    public float velocidadGiro;
    public float magnitudSalto;
    public bool estaSaltando;
    public Animator animator;
    public float velocidadActual;

    void Start()
    {
        estaSaltando = false;
    }

    void Update()
    {
        Caminar();
        Saltar();
        Hablar();
    }

    void Saltar()
    {
        if (!estaSaltando && Input.GetKeyDown(KeyCode.Space))
        {
            estaSaltando = true;
            animator.SetBool("EstaCayendo", estaSaltando);
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * magnitudSalto, ForceMode.Force);
        }
    }

    void Caminar()
    {
        if (!estaSaltando)
        {
            velocidadActual = velocidad * Time.deltaTime * Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, 1) * velocidadActual);
        }
        else
        {
            if(Input.GetAxis("Vertical") == 1)
            {
                transform.Translate(new Vector3(0, 0, 1) * (velocidad / 2) * Time.deltaTime);
            }
        }

        if (velocidadActual > 0.01)
        {
            animator.SetBool("EstaCaminando", true);
        }
        else
        {
            animator.SetBool("EstaCaminando", false);
        }

        transform.Rotate(new Vector3(0, 1, 0) * velocidadGiro * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    void Hablar()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("mi nombre es: " + nombre);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "suelo" || collision.transform.tag == "plataforma")
        {
            estaSaltando = false;
            animator.SetBool("EstaCayendo", estaSaltando);
        }
        else if (collision.transform.tag == "Respawn") {
            transform.position = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "suelo" || collision.transform.tag == "plataforma")
        {
            estaSaltando = true;
            animator.SetBool("EstaCayendo", estaSaltando);
        }
    }
}
