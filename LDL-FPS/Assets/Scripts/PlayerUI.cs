using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]TMP_Text healthData, AmmoData;
    [SerializeField]PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        SetData();
    }

    public void SetData()
    {
        healthData.text = playerStats.currentHealth.ToString();
    }
}
