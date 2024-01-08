using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;

public enum EnumRobotBossState
{

    Pattern_1, //�ϴÿ��� �̻��� ������
    Pattern_2, //������ ���ƴٴ�
    Pattern_3, //���� �̻��� �߻�
    Pattern_4, //�Ŵ� ���� �̻��� �߻�
    Pattern_5, //�̻��� ����

}

public class RobotBossController : FSM_Controller<EnumRobotBossState>
{

    [SerializeField] private EnumRobotBossState startState;

    protected override void Awake()
    {

        base.Awake();

        var p1 = new Robot_Pattern_1_State(this);
        AddState(p1, EnumRobotBossState.Pattern_1);

        ChangeState(startState);

    }

}
