using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
}
