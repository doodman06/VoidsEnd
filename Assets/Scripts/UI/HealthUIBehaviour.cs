using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    private static int health;
    [SerializeField] private TextMeshProUGUI healthText;
    private static TextMeshProUGUI healthTextStatic;
    private static string healthString;

    // Update is called once per frame
    private void Start()
    {
        healthTextStatic = healthText;
        UpdateHealth();
    }
    public static void UpdateHealth()
    {
        health = PlayerHealth.getHealth();
        healthString = "";
        for (int i = 0; i < health; i++)
        {
            healthString += "<sprite=\"Heart\" name=\"Heart\"> ";
        }
        healthTextStatic.text = healthString;
    }
}
