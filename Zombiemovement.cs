using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombiemovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer; //to display to sprite ingame
    public Transform player; // object to be tracked
    public Rigidbody2D rb; //physics component
    public bool mustalive = true;
    static float Espeeded = 5;
    private float timer = 0f;
    private float targetTime = 30f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Espeeded = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update the timer with the elapsed time
        timer += Time.deltaTime;

        // Check if the timer has reached the target time
        if (timer >= targetTime)
        {
            // Do something when 30 seconds are reached
            

            Espeeded = 3f;

        }
        if (timer >= 90f)
        {
            // Do something when 30 seconds are reached

            Debug.Log("should be fast");
            Espeeded = 3.5f;

        }
        if (timer >= 150f)
        {
            // Do something when 30 seconds are reached
           

            Espeeded = 4f;

        }
        if (timer >= 210f)
        {
            // Do something when 30 seconds are reached
           

            Espeeded = 4.5f;

        }
        if (timer >= 260f)
        {
            // Do something when 30 seconds are reached
            

            Espeeded = 5f;

        }
        if (timer >= 300f)
        {
            // Do something when 30 seconds are reached
           

            Espeeded = 5.5f;

        }
        if (timer >= 330f)
        {
            // Do something when 30 seconds are reached


            Espeeded = 5.9f;
        }
            Enemyspeed();
        
       
        //Debug.Log(midspeed);

        if (rb.velocity.x < 0)
        {   //same as the player sprite this flipes the sprites horizontal axis if sprote is moving in the negative direction
            spriteRenderer.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        


        
        

    }
    public void alivecheck(bool alive)
    {
        if (alive == false) //this is used to shut of continuous coding that isnt needed one the player dies
        {
            mustalive = false;
        }
        
    }
    public void Enemyspeed()
    {
        

        
        
        Vector3 Track = (player.position - transform.position).normalized; //subtracts the player sprite position by its own position
                                                                     //normalized returns the vector 3 with a magnitude of 1
                                                                                       //this is the direction the enemy sprite is facing in order to face the player multiplied by the adjustable enemy velocity
        rb.velocity = new Vector2(Track.x, Track.y) * Espeeded;
        
         
    }

}