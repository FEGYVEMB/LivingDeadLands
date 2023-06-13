using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;

    public PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {

        playerUI = GetComponent<PlayerUI>();

        currentHealth = maxHealth;
        playerUI.SetData();
    }
}
