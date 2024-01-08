using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;

public enum EnumRobotBossState
{

    Pattern_1, //�ϴÿ��� �̻��� ������
    Pattern_2, //������ ���ƴٴ�
    Pattern_3, //���� �̻��� �߻�
    Pattern_4, //���� �̻��� �߻�
    Pattern_5, //�̻��� ����

}

public class RobotBossController : FSM_Controller<EnumRobotBossState>
{

    [SerializeField] private EnumRobotBossState startState;

    protected override void Awake()
    {

        base.Awake();

        ChangeState(startState);

    }

}
