using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject>rooms;


    public GameObject boss;
    public GameObject simpleEnemies;

    private void Start()
    {
        Invoke("SpawnEnemies",2f);
    }

    void SpawnEnemies()
    {
        Instantiate(boss,rooms[rooms.Count - 1].transform.position,quaternion.identity);
        for(int i = 0; i < rooms.Count-1; i++)
        {
            Instantiate(simpleEnemies,rooms[i].transform.position,quaternion.identity);
        }
    }



}
