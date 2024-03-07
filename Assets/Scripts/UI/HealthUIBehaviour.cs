using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    private int health;
    [SerializeField] private TextMeshProUGUI healthText;
    
    // Update is called once per frame
    void Update()
    {
        health = PlayerHealth.getHealth();
        healthText.text = "Health: " + health;
    }
}
