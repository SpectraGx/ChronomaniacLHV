using UnityEngine;

public class ControladorScripts : MonoBehaviour
{
    private Pistol pistolScript;
    private Shotgun shotgunScript;
    private AR arScript;
    private Laser laserScript;
    private AtkMelee atkMeleeScript;

    private void Start()
    {
        // Asegúrate de que el script AtkMelee esté activado por defecto
        atkMeleeScript = GetComponent<AtkMelee>();
        atkMeleeScript.enabled = true;

        // Desactiva los demás scripts inicialmente
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
        if (other.CompareTag("ArmaPistol"))
        {
            ActivarPistol();
        }
        else if (other.CompareTag("ArmaShotgun"))
        {
            ActivarShotgun();
        }
        else if (other.CompareTag("ArmaAR"))
        {
            ActivarAR();
        }
        else if (other.CompareTag("ArmaLaser"))
        {
            ActivarLaser();
        }
        else if (other.CompareTag("ArmaAtkMelee"))
        {
            ActivarAtkMelee();
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

    private void ActivarAtkMelee()
    {
        pistolScript.enabled = false;
        shotgunScript.enabled = false;
        arScript.enabled = false;
        laserScript.enabled = false;
        atkMeleeScript.enabled = true;
    }
}
