using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    private int health;
    [SerializeField] private TextMeshProUGUI healthText;
    private string healthString;
    
    // Update is called once per frame
    void Update()
    {
        health = PlayerHealth.getHealth();
        healthString = "";
        for(int i = 0; i < health; i++)
        {
            healthString += "<sprite=\"Heart\" name=\"Heart\"> ";
        }
        healthText.text = healthString;
    }
}
