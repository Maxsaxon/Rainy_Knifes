using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training 
{
   private float speed = 50f;
   private float health = 8000f;
   private bool canBeat = true;
   private int mana = 100;
   private string playerName = "Overly exited GAY";

   public string PlayerName
   {
      set
      {
         playerName = value;
      }
      get 
      {
         return playerName;
      }
   }

  
   public Training() // constructors
   {
      Debug.Log("This value is " + speed);
      health = 10000f;
      Debug.Log("This new value is " + speed);
   }

   public Training(int _speed, string _playerName)
   {
      Debug.Log("This value is " + speed);
      Debug.Log("This name is " + playerName);

      speed = _speed;
      playerName = _playerName;

      Debug.Log("This new value is " + speed);
      Debug.Log("This new name is " + playerName);
   }
    public void SetPlayerName(string newName) // one way to access private variables (getters and setters)
    {
       playerName = newName;
    }

    public string GetPlayerName()
    {
      return playerName;
    }

   public virtual void Go() { // void does not return anything, only code inside, virtual - used for overriding function
      Debug.Log(playerName + " is moving with the speed of 5");
   }

   float CalculateDistance() // returns variables
   {
      return 13.5f;
   }

   float CalculateDamage(float damage)
   {
      health -= damage;
      return health;
   }
}
