using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grab : MonoBehaviour
{
    public bool grabbing = false;
    public GameObject grabbed;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.Q) && !grabbing)
        {
            if (other.GetComponent<Grabbable>() == null) return;
            grabbing = true;
            other.transform.SetParent(transform);
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localPosition = Vector3.zero;
            other.enabled = false;
            grabbed = other.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && grabbing)
        {
            grabbing = false;
            grabbed.transform.SetParent(null);
            grabbed.GetComponent<Rigidbody>().isKinematic = false;
            grabbed.GetComponent<Collider>().enabled = true;
            grabbed = null;
        }
    }
}
