using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimarOffText : MonoBehaviour
{
    // Scroll main texture based on time

    public float velocidad = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * velocidad;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
