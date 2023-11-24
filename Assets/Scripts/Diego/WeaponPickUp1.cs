using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapons weapon;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            target.GetComponent<MoveFer>().currentWeapon = weapon;
            target.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSpr;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
