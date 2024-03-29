using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{

    public int openSide;

    //1 need bottom door
    //2 need topp door
    //3 need left door
    //4 need right dorr 


    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    void Start()
    {
        templates=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.1f);
    }


    void Spawn()
    {
        if(spawned==false)
        {
             if (openSide==1)
            {
                rand=Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand],transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if(openSide==2)
            {
                rand=Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand],transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if(openSide==3)
            {
                rand=Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand],transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if(openSide==4)
            {
                rand=Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand],transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }

       
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("SpawnPoint"))
       {
            if (other.gameObject.GetComponent<RoomSpawn>().spawned==false && spawned==false)
            {
                Instantiate(templates.closedRoom,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
       }
    }
    
}
