using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;

public enum EnumIceAwakeState
{

    Pattern_1, //��ܺ� �̵��� ���������� ���� ����
    Pattern_2, //����콺�� ������� �̵��ϸ� ���� �ð����� �÷��̾� �������� ���� ���� && ī�޶� �ֵ����� �������� �Ѿ

}

public class IceAwakeningController : FSM_Controller<EnumIceAwakeState>
{

    [SerializeField] private EnumIceAwakeState startState;

    protected override void Awake()
    {

        var p1 = new Ice_Pattern_1_State(this);
        AddState(p1, EnumIceAwakeState.Pattern_1);

        var p2 = new Ice_Pattern_2_State(this);
        AddState(p2 , EnumIceAwakeState.Pattern_2);

        ChangeState(startState);

    }

}
