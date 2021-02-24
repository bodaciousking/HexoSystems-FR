using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGfx : MonoBehaviour
{
    public Color myColor;

    public void ReturnToOgColor()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = myColor;
    }
}
