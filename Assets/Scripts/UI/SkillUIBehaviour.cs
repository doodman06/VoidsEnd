using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillUIBehaviour : MonoBehaviour
{
    private int skillCount;
    [SerializeField] private TextMeshProUGUI skillText;
    [SerializeField] private GameObject currentPlayer;

    // Update is called once per frame
    void Update()
    {
        skillCount = currentPlayer.GetComponent<SkillManager>().GetActiveSkillNumber();
        skillText.text = "Skill: " + skillCount;
    }
}
