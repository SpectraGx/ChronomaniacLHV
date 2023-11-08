using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCam : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    private void Start()
    {
        vcam=GetComponentInChildren<CinemachineVirtualCamera>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        vcam.gameObject.SetActive(false);
        vcam.gameObject.SetActive(true); 
    }
}
