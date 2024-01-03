using FSM_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Pattern_2_State : IceAwakeState
{
    public Ice_Pattern_2_State(FSM_Controller<EnumIceAwakeState> controller) : base(controller)
    {
    }

    private float mainRadius = 5f; // �� ���� ������
    private float smallRadius = 1f; // ���� ���� ������
    private float speed = 1f; // �̵� �ӵ�

    protected override void UpdateState()
    {

        MoveMobiusStrip();

    }

    private void MoveMobiusStrip()
    {
        float t = Time.time * speed;

        float x = (mainRadius + smallRadius * Mathf.Cos(0.5f * t)) * Mathf.Cos(t);
        float y = (mainRadius + smallRadius * Mathf.Cos(0.5f * t)) * Mathf.Sin(t);
        float z = smallRadius * Mathf.Sin(0.5f * t);

        transform.position = new Vector3(x, y, z);
    }

}
