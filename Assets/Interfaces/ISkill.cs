using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    void UseSkill();

    void AddUses(int amount);

    int GetUses();

    IPlayerState GetState();
}
