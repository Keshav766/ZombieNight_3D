using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] float playerMaxHealth = 100f;
    [SerializeField] float playerHealth = 100f;

    public void PlayerUpdateHealth(float health)
    {
        playerHealth += health;
        if(playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
        if(playerHealth <= 0)
        {
            FindObjectOfType<SceneHandler>().GameOver();
        }
    }

}
