using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;

public enum EnumIceAwakeState
{

    Pattern_1, //��ܺ� �̵��� ���������� ���� ����

}

public class IceAwakeningController : FSM_Controller<EnumIceAwakeState>
{

    protected override void Awake()
    {

        var p1 = new Ice_Pattern_1_State(this);
        AddState(p1, EnumIceAwakeState.Pattern_1);

        ChangeState(EnumIceAwakeState.Pattern_1);

    }

}
