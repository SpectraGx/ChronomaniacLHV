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
        if (other.CompareTag("ArmaPistol") && !tieneCuchillo)
        {
            ActivarPistol();
            Destroy(other.gameObject);
            ActivarAtkMeleeDespuesDeDelay();
        }
        else if (other.CompareTag("ArmaShotgun") && !tieneCuchillo)
        {
            ActivarShotgun();
            Destroy(other.gameObject);
            ActivarAtkMeleeDespuesDeDelay();
        }
        else if (other.CompareTag("ArmaAR") && !tieneCuchillo)
        {
            ActivarAR();
            Destroy(other.gameObject);
            ActivarAtkMeleeDespuesDeDelay();
        }
        else if (other.CompareTag("ArmaLaser") && !tieneCuchillo)
        {
            ActivarLaser();
            Destroy(other.gameObject);
            ActivarAtkMeleeDespuesDeDelay();
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
        Invoke("ActivarAtkMelee", 10f);
    }

    private void ActivarAtkMelee()
    {
        tieneCuchillo = true;
        atkMeleeScript.enabled = true;
        pistolScript.enabled = false;
        shotgunScript.enabled = false;
        arScript.enabled = false;
        laserScript.enabled = false;
    }
}
