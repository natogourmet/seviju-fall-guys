using UnityEngine;

public class Persona : MonoBehaviour
{
    public int edad;
    public string nombre;
    public float velocidad;
    
    void Update()
    {
        Caminar();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hablar();
        }
    }

    void Caminar()
    {
       
        transform.Translate(new Vector3(0, 0 , 1) * velocidad * Time.deltaTime * Input.GetAxis("Vertical"));
       

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);
        }

    
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * velocidad * Time.deltaTime);
        }
    }

    void Hablar()
    {
        Debug.Log("mi nombre es: " + nombre);
    }

}
