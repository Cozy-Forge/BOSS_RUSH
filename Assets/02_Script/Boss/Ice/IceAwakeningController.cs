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
    Pattern_13, //������ ������
    Pattern_14, //�������� ��
    Pattern_15, //�������� å

}

public class IceAwakeningController : FSM_Controller<EnumIceAwakeState>
{

    [SerializeField] private EnumIceAwakeState startState;
    [SerializeField] private ParticleSystem movePtc;

    private SpriteRenderer spriteRenderer;
    private Transform target;

    protected override void Awake()
    {

        SoundManager.Instance.BgStop();

        target = FindObjectOfType<PlayerController>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

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

        var p11 = new Ice_Pattern_11_State(this);
        AddState(p11 , EnumIceAwakeState.Pattern_11);

        var p12 = new Ice_Pattern_12_State(this);
        AddState(p12 , EnumIceAwakeState.Pattern_12);

        var p13 = new Ice_Pattern_13_State(this);
        AddState(p13 , EnumIceAwakeState.Pattern_13);

        var p14 = new Ice_Pattern_14_State(this);
        AddState(p14 , EnumIceAwakeState.Pattern_14);
        
        var p15 = new Ice_Pattern_15_State(this);
        AddState(p15 , EnumIceAwakeState.Pattern_15);

        ChangeState(startState);

    }

    protected override void Update()
    {

        base.Update();

        bool b = target.position.x > transform.position.x;

        spriteRenderer.flipX = b;
        movePtc.transform.localScale = b ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

    }

    public void Die()
    {

        PlayerPrefs.SetInt("TotalClear", PlayerPrefs.GetInt("TotalClear", 0) + 1);
        PlayerPrefs.SetInt("TotalBossClear", PlayerPrefs.GetInt("TotalBossClear", 0) + 1);
        if (DataManager.Instance != null)
            DataManager.Instance.InitData();
    }

}
