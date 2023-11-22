using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texturaanimada : MonoBehaviour
{
    //3D Version
    public Texture2D[] textures;
    MeshRenderer rend;
    public float speed;
    public float time;

    private void Start()
    {
        rend=GetComponent<MeshRenderer>();  
    }
    void Update()
    {
        time += Time.deltaTime * speed;
        int texID = Mathf.RoundToInt(time) % textures.Length;
        rend.material.SetTexture("_MainTex", textures[texID]);
    }
}
