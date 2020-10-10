using UnityEngine;

public class Persona : MonoBehaviour
{
    public int edad;
    public string nombre;
    public float velocidad;
    public float velocidadGiro;
    public float magnitudSalto;
    public bool estaSaltando;

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
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * magnitudSalto, ForceMode.Force);
        }
    }

    void Caminar()
    {
        if (!estaSaltando)
        {
            transform.Translate(new Vector3(0, 0, 1) * velocidad * Time.deltaTime * Input.GetAxis("Vertical"));
        }
        else
        {
            if(Input.GetAxis("Vertical") == 1)
            {
                transform.Translate(new Vector3(0, 0, 1) * (velocidad / 2) * Time.deltaTime);
            }
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
        if (collision.transform.tag == "suelo")
        {
            estaSaltando = false;
        }
        else if (collision.transform.tag == "Respawn") {
            transform.position = Vector3.zero;
        }
    }

    
}
