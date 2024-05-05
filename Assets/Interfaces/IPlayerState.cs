using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public IPlayerState Tick(PlayerBehaviour playerBehaviour, PlayerInputEnum input);
    public void Enter(PlayerBehaviour playerBehaviour);
    public void Exit(PlayerBehaviour playerBehaviour);
}
