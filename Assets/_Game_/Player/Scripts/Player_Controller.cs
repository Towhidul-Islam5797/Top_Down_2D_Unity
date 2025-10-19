using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private enum Direction {UP, Down, Right,Left}

    [Header("Movement Attributes")]
    [SerializeField] public float moveSpeed = 5f;

    private Vector2 moveInput;

    [Header("Dependecies")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    // Private fields use an underscore prefix to clearly differentiate them
    // from local variables and method parameters. This improves code readability 
    // and helps avoid naming conflicts, serving as a shorthand for 'this.'
    private Direction _facingDirection = Direction.Right;

    // Cache the hash of the "Anim_Move_Right" parameter for the Animator.
    // Using Animator.StringToHash improves performance by avoiding repeated string lookups at runtime.
    // This makes animation state changes faster and less error-prone.
    //For this is "READ ONLY" that Means I don't want to change it Accidentally
    //Also I need This So that my animation transition neatly.
    private readonly int _animMoveRight = Animator.StringToHash("Anim_Move_Right");

    //Same for the IDLE animation
    private readonly int _animIdleRight = Animator.StringToHash("Anim_Idle_Right");

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        //Getting Input
        Get_Input();
        Calculate_Direction();
        Update_Animation();
    }

   
    void FixedUpdate()
    {
        //Set the Input Logic
        Set_Input_Logic();
    }

    private void Set_Input_Logic()
    {
        // Apply smooth physics movement
        Vector2 targetPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPos);
    }

    private void Get_Input()
    {
        // Cache input values here only (no movement)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
    }

    private void Calculate_Direction()
    {
        if(moveInput.x != 0)
        {
            //If goes Right then moveInput.x = + 1
            if (moveInput.x > 0)
            {
                _facingDirection = Direction.Right;
            }
            else if (moveInput.x < 0)
            {
                _facingDirection = Direction.Left;
            }
        }
    }
    private void Update_Animation()
    {
        if (_facingDirection == Direction.Left)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_facingDirection == Direction.Right)
        {
            _spriteRenderer.flipX = false;
        }

        //Moving to different Anims
        //sqrmagnitude is vector distance comparison function
        if (moveInput.sqrMagnitude > 0) // that means Character is moving 
        {
            _animator.CrossFade(_animMoveRight, 0);
        }
        else
            _animator.CrossFade(_animIdleRight, 0);
    }

}
