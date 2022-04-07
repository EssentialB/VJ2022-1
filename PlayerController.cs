using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;

    private static readonly string Animator_State = "Estado";

    private static readonly int Animation_Run = 0;
    private static readonly int Animation_Jump = 1;
    private static readonly int Animation_Slice = 2;
    private static readonly int Rigth = 1;
    private static readonly int Left = -1;

    private SpriteRenderer spriteRenderer; 
    private Rigidbody2D rigidbody; 
    private Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var velocidadActualX = rigidbody.velocity.x;
        var velocidadActualY = rigidbody.velocity.y;

        rigidbody.velocity = new Vector2(Velocity, rigidbody.velocity.y);
        Change_Animation(Animation_Run);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            Change_Animation(Animation_Jump);
        }

        if (Input.GetKey(KeyCode.C))
        {
            Deslizarse();
        } 
    }

    private void Deslizarse()
    {
        Change_Animation(Animation_Slice);
    }
    private void Desplazarse(int Position)
    {
        rigidbody.velocity = new Vector2(Velocity * Position, rigidbody.velocity.x); 
        Change_Animation(Animation_Run);
    }

    private void Change_Animation(int Animation)
    {
        animator.SetInteger(Animator_State, Animation);
    }
}
