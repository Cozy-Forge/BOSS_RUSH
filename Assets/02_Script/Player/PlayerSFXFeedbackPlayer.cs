using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXFeedbackPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landingSound;
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private AudioClip attackSound;

    private Rigidbody2D rigid;
    private PlayerEventSystem playerEventSystem;
    private GroundSencer groundSencer;

    private void Start()
    {

        playerEventSystem = GetComponent<PlayerController>().playerEventSystem;
        groundSencer = GetComponentInChildren<GroundSencer>();
        rigid = GetComponent<Rigidbody2D>();

        playerEventSystem.JumpEvent += HandleJumpSoundPlay;
        playerEventSystem.DashEvent += HandleDashSoundPlay;
        playerEventSystem.AttackEvent += HandleAttackSoundPlay;
        groundSencer.OnTriggerd += HandleLandingSoundPlay;

    }

    private void HandleAttackSoundPlay(float obj)
    {

        SoundManager.Instance.SFXPlay("Player_Attack", attackSound);

    }

    private void HandleDashSoundPlay()
    {

        SoundManager.Instance.SFXPlay("Player_Dash", dashSound);

    }

    private void HandleLandingSoundPlay(bool obj)
    {

        if (obj && rigid.velocity.y <= 0)
        {

            SoundManager.Instance.SFXPlay("Player_Landing", landingSound);

        }

    }

    private void HandleJumpSoundPlay()
    {

        SoundManager.Instance.SFXPlay("Player_Jump", jumpSound);

    }
}
