using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFer : MonoBehaviour
{ 
    public float speedMove = 5f;
    public Transform weapon;

    private void Update()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVerti = Input.GetAxis("Vertical");
        Vector3 direcMove = new Vector3(moveHori, moveVerti, 0f);
        direcMove.Normalize();
        transform.Translate(direcMove * speedMove * Time.deltaTime);

        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
