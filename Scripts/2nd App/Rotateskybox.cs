using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateskybox : MonoBehaviour
{
    public float Rotatespeed = 1.0f;

    // Update is called once per frame
    void Update()
    {

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * Rotatespeed);
        
    }
}
