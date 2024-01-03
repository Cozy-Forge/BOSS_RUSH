using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM_System;
using System;

public enum EnumPlayerState
{

    Idle, //�������� �Ұ��� �Ҷ�
    Move, //�������� ������ ��
    Dash

}

public class PlayerController : FSM_Controller<EnumPlayerState>
{

    [field:SerializeField] public PlayerValues playerValues { get; private set; }
    [SerializeField] private EnumPlayerState startState = EnumPlayerState.Move;

    private Rigidbody2D rigid;
    private GroundSencer groundSencer;

    public PlayerInputController playerInputController { get; private set; }
    public PlayerEventSystem playerEventSystem { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        groundSencer = GetComponentInChildren<GroundSencer>();


        playerValues = Instantiate(playerValues);

        playerInputController = new();
        playerEventSystem = new();

        AddState<PlayerState>(new PlayerIdleState(this), EnumPlayerState.Idle);

        var move = new PlayerMoveState(this);
        var jump = new PlayerJumpState(this);
        var flip = new PlayerFlipState(this);
        var cam = new PlayerCameraPivotMovementState(this);
        var feedback = new PlayerMoveFeedbackState(this);

        AddState(move, EnumPlayerState.Move);
        AddState(jump, EnumPlayerState.Move);
        AddState(flip, EnumPlayerState.Move);
        AddState(cam, EnumPlayerState.Move);
        AddState(feedback, EnumPlayerState.Move);

        var dash = new PlayerDashState(this);

        AddState(dash, EnumPlayerState.Dash);

        rigid = GetComponent<Rigidbody2D>();

        ChangeState(startState);

    }

    private void Start()
    {


        if (startState == EnumPlayerState.Move && groundSencer.isGround)
        {

            ChangeIdle();
            groundSencer.OnTriggerd += Triggerd;

        }

    }

    private void Triggerd(bool obj)
    {

        if (obj)
        {

            ChangeMove();
            groundSencer.OnTriggerd -= Triggerd;

        }

    }

    protected override void Update()
    {

        if (Time.timeScale == 0) return;

        base.Update();

        playerInputController.Update();

    }

    public void ChangeIdle()
    {

        rigid.velocity = Vector2.zero;

        ChangeState(EnumPlayerState.Idle);

    }

    public void ChangeMove()
    {

        ChangeState(EnumPlayerState.Move);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        foreach(var state in GetState(currentState))
        {

            (state as PlayerState).CollisonEnter();

        }

    }

}