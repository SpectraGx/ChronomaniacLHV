using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float hp;

    public void TakeDamage(float damage){
        hp-=damage;
    }
}
