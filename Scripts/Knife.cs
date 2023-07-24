using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private string Ground_Tag = "Ground";
    //checking for solid collision
   //private void OnCollisionEnter2D(Collision2D collision) // knife collides with our player
   //{
   // if (collision.gameObject.CompareTag("Player"))
    //{
    //    Destroy(gameObject);
    //}
   //}
    
   
   //checking for non-solid collision
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if (collision.CompareTag(Ground_Tag))
    {
      Destroy(gameObject); // one way to destroy gameObjects
    }
   }
   
   

}
