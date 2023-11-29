using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool isPlayerInRange;
    private Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("Gameplay");
            Time.timeScale=1f;
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.N))
        {
            Input.GetKeyDown(KeyCode.E);
            Time.timeScale=1f;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PJ"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PJ"))
        {
            isPlayerInRange = false;
        }
    }
}
