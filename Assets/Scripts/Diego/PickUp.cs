using UnityEngine;

public class ControladorScripts : MonoBehaviour
{
    private Pistol pistolScript;
    private Shotgun shotgunScript;
    private AR arScript;
    private Laser laserScript;
    private AtkMelee atkMeleeScript;

    private bool tieneCuchillo = false;

    private void Start()
    {
        atkMeleeScript = GetComponent<AtkMelee>();
        atkMeleeScript.enabled = true;

        pistolScript = GetComponent<Pistol>();
        pistolScript.enabled = false;

        shotgunScript = GetComponent<Shotgun>();
        shotgunScript.enabled = false;

        arScript = GetComponent<AR>();
        arScript.enabled = false;

        laserScript = GetComponent<Laser>();
        laserScript.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!tieneCuchillo)
        {
            if (other.CompareTag("ArmaPistol"))
            {
                ActivarPistol();
                other.gameObject.SetActive(false);
                //ActivarAtkMeleeDespuesDeDelay();
            }
            else if (other.CompareTag("ArmaShotgun"))
            {
                ActivarShotgun();
                other.gameObject.SetActive(false);
                //ActivarAtkMeleeDespuesDeDelay();
            }
            else if (other.CompareTag("ArmaAR"))
            {
                ActivarAR();
                other.gameObject.SetActive(false);
                //ActivarAtkMeleeDespuesDeDelay();
            }
            else if (other.CompareTag("ArmaLaser"))
            {
                ActivarLaser();
                other.gameObject.SetActive(false);
                ActivarAtkMeleeDespuesDeDelay();
            }
        }
    }

    private void ActivarPistol()
    {
        pistolScript.enabled = true;
        shotgunScript.enabled = false;
        arScript.enabled = false;
        laserScript.enabled = false;
        atkMeleeScript.enabled = false;
    }

    private void ActivarShotgun()
    {
        pistolScript.enabled = false;
        shotgunScript.enabled = true;
        arScript.enabled = false;
        laserScript.enabled = false;
        atkMeleeScript.enabled = false;
    }

    private void ActivarAR()
    {
        pistolScript.enabled = false;
        shotgunScript.enabled = false;
        arScript.enabled = true;
        laserScript.enabled = false;
        atkMeleeScript.enabled = false;
    }

    private void ActivarLaser()
    {
        pistolScript.enabled = false;
        shotgunScript.enabled = false;
        arScript.enabled = false;
        laserScript.enabled = true;
        atkMeleeScript.enabled = false;
    }

    private void ActivarAtkMeleeDespuesDeDelay()
    {
        CancelInvoke("ActivarAtkMelee");
        Invoke("ActivarAtkMelee", 10f);
    }

    private void ActivarPistolPerma(){
        
    }

    private void ActivarAtkMelee()
    {
        tieneCuchillo = true;
        atkMeleeScript.enabled = true;
        pistolScript.enabled = false;
        shotgunScript.enabled = false;
        arScript.enabled = false;
        laserScript.enabled = false;
       
        Invoke("RestablecerTieneCuchillo", 1f);
    }

    private void RestablecerTieneCuchillo()
    {
        tieneCuchillo = false;
    }
}
