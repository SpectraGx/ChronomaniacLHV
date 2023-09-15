using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePistol : MonoBehaviour
{
    public float pistolSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * pistolSpeed * Time.deltaTime);
    }
}
