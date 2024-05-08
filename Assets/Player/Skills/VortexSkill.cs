using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class VortexSkill : Skill
{
    [SerializeField] private GameObject vortexPrefab;
    private Vector2 vortexPosition;

    private PlayerBehaviour player;

    private void Awake()
    {
        player = GetComponent<PlayerBehaviour>();
    }

    public void UseSkillAtPosition(Vector2 pos)
    {
        if(skillNumber > 0)
        {
            UseSkill();
            vortexPosition = pos;
            Instantiate(vortexPrefab, vortexPosition, Quaternion.identity);
            
        }
    }

    public override void StartSkill()
    {
        Debug.Log("Vortex skill started");
        Time.timeScale = 0.1f;
    }

    public override void EndSkill()
    {
        Debug.Log("Vortex skill ended");
        Time.timeScale = 1f;
    }

    public override bool UpdateSkill(PlayerInputEnum input)
    {
        if (input == PlayerInputEnum.MouseClick)
        {
            UseSkillAtPosition(player.getMousePos());
            player.Notify(EventEnum.VortexClick);
            return true;

        }
        return false;
    }
}
