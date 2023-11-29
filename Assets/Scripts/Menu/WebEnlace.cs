using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebEnlace : MonoBehaviour
{


    public void Enlace(string enalce) 
    {
    
        Application.OpenURL (enalce);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
