using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;

public enum EnumPlayerState
{

    Idle, //�������� �Ұ��� �Ҷ�
    Move, //�������� ������ ��

}

public class PlayerController : FSM_Controller<EnumPlayerState>
{

    [field:SerializeField] public PlayerValues playerValues { get; private set; }
    [SerializeField] private EnumPlayerState startState = EnumPlayerState.Move;

    public PlayerInputController playerInputController { get; private set; }
    public PlayerEventSystem playerEventSystem { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        playerValues = Instantiate(playerValues);

        playerInputController = new();
        playerEventSystem = new();

        ChangeState(startState);

    }


}