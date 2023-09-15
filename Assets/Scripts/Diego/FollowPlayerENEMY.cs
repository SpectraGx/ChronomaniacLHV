using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerENEMY : MonoBehaviour
{
    public string playerTag = "Player";
    public float moveSpeed = 6f;

    private Transform playerTransform;

    private void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag(playerTag);


        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Falta tag del objeto al que el Enemigo perseguirá");
        }
    }

    private void Update()
    {

        if (playerTransform != null)
        {

            Vector3 direction = playerTransform.position - transform.position;

            direction.Normalize();

            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;


            transform.position = targetPosition;
        }
    }
}
