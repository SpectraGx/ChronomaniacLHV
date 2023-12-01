using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCam : MonoBehaviour
{
    public GameObject enemigos;
    public CinemachineVirtualCamera vcam;
    private void Start()
    {
        vcam = GetComponentInParent<CinemachineVirtualCamera>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PJ"))
        {
            vcam.gameObject.SetActive(false);
            vcam.gameObject.SetActive(true);
            enemigos.SetActive(true);
        }
    }
}
