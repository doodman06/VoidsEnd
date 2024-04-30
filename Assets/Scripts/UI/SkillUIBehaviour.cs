using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillUIBehaviour : MonoBehaviour
{
    private static int skillCount;
    [SerializeField] private TextMeshProUGUI skillText;
    private static TextMeshProUGUI skillTextStatic;
    [SerializeField] private GameObject currentPlayer;
    private static string skillString;
    private static  SkillEnum skillType;
    private static PlayerBehaviour playerBehaviour;

    private void Start()
    {
        skillTextStatic = skillText;
        playerBehaviour = currentPlayer.GetComponent<PlayerBehaviour>();
        UpdateSkill();
    }


    private static void getSkillInfo()
    {
        skillCount = playerBehaviour.GetActiveSkillNumber();
        skillType = playerBehaviour.GetActiveSkillType();
        if (skillType == SkillEnum.Vortex)
        {
            skillString = "<sprite=\"VortexIcon\" name=\"VortexIcon\"> " + skillCount;
        }
        else if (skillType == SkillEnum.Dash)
        {
            skillString = "<sprite=\"DashIcon\" name=\"DashIcon\"> " + skillCount;
        }
        else
        {
            skillString = "Current Skill: " + skillCount + " None";
        }
    }
    public static void UpdateSkill()
    {
        getSkillInfo();
        skillTextStatic.text = skillString;
    }
}
