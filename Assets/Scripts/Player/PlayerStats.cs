using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        // Debug.Log("Player:" + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
        else
        {
            //send broadcast that was hit
            
        }
        Messenger<int>.Broadcast(GameEvent.HEALTH_CHANGED, currentHealth);


    }
}
