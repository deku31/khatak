using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerrespawn : MonoBehaviour
{
    [SerializeField]private Transform currentCheckpoint;
    private Playerhealth playerHealth;


    private void Awake()
    {
        playerHealth = GetComponent<Playerhealth>();
    }

    public void Respawn()
    {
        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location

        //Move the camera to the checkpoint's room
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            
        }
    }
    
       
}
