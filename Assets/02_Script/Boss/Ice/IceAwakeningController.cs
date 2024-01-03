using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;

public enum EnumIceAwakeState
{

    Pattern_1,  //��ܺ� �̵��� ���������� ���� ����
    Pattern_2,  //����콺�� ������� �̵��ϸ� ���� �ð����� �÷��̾� �������� ���� ����
    Pattern_3,  //������ �߾����� �̵� �� �����ϴ� �ھ ��ȯ
    Pattern_4,  //������ ���� ���带 �÷��̾ ���� �߻� && ī�޶� ��������
    Pattern_5,  //���� 1 && 4 ȥ����
    Pattern_6,  //â ���ƿ�
    Pattern_7,  //���� 3 && 2 ȥ����
    Pattern_8,  //���� 1�� â ����
    Pattern_9,  //�ڽ��� �ֺ��� �������� �߻��ϴ� ������Ʈ ����
    Pattern_10, //��¡�� ������ ����
    Pattern_11, //��õ� ������
    Pattern_12, //���������� ��Ƽ�� HPȸ��
    Pattern_13, //�� �پ����

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

        var p3 = new Ice_Pattern_3_State(this);
        AddState(p3, EnumIceAwakeState.Pattern_3);

        var p4 = new Ice_Pattern_4_State(this);
        AddState(p4 , EnumIceAwakeState.Pattern_4);

        var p5 = new Ice_Pattern_5_State(this);
        AddState(p5 , EnumIceAwakeState.Pattern_5);

        var p6 = new Ice_Pattern_6_State(this);
        AddState(p6, EnumIceAwakeState.Pattern_6);

        var p7 = new Ice_Pattern_7_State(this);
        AddState(p7 , EnumIceAwakeState.Pattern_7);

        var p8 = new Ice_Pattern_8_State(this);
        AddState(p8 , EnumIceAwakeState.Pattern_8);

        var p9 = new Ice_Pattern_9_State(this);
        AddState(p9 , EnumIceAwakeState.Pattern_9);

        var p10 = new Ice_Pattern_10_State(this);
        AddState(p10 , EnumIceAwakeState.Pattern_10);

        ChangeState(startState);

    }

}
