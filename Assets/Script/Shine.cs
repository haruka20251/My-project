using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    public Material myMaterial;
    public Material myMaterial2;

    private Color defaultColor = Color.red;
    private float elapsedTime = 0f;

    void Start()
    {
        this.defaultColor = Color.red;

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);

        if (elapsedTime >= 20f)
        {
            if (elapsedTime < 21f)
            {

                Color fixedColor = this.defaultColor * 20.0f;
                
                myMaterial.SetColor("_EmissionColor", fixedColor);

                
                myMaterial2.SetColor("_EmissionColor", fixedColor);
            }
        }
    }
}
