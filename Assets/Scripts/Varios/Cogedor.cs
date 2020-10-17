using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cogedor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jugador"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("jugador"))
        {
            other.transform.SetParent(null);
        }
    }
}
