using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] GameManager gm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gm.isGamePause)
            {
                Reanude();
                gm.isGamePause = false;
            }
            else
            {
                Pausa();
                gm.isGamePause = true;
            }
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanude()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
}
