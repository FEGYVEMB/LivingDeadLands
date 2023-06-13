using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]TMP_Text healthData, AmmoData;
    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public void SetData()
    {
        healthData.text = playerStats.currentHealth.ToString();
    }
}
