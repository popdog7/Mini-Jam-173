using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameInput game_input;
    [SerializeField] private Transform player_sprite;
    private Rigidbody2D rigid_body;

    public BoxCollider2D ground_collider;
    public LayerMask ground_mask;

    public float speed = 5f;
    private bool is_grounded;
    private int jump_amount = 0;
    public int max_jump_amount = 2;

    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        game_input.on_jump_action += GameInputOnJumpAction;
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void Movement()
    {
        float x_input = game_input.GetHorizontalMovement();
        if (x_input != 0)
        {
            float direction = Mathf.Sign(x_input);
            player_sprite.localScale = new Vector3(direction, 1, 1);
        }

        rigid_body.velocity = new Vector2(x_input * speed, rigid_body.velocity.y);
    }

    private void GameInputOnJumpAction(object sender, System.EventArgs e)
    {
        if (is_grounded || jump_amount < max_jump_amount)
        {
            rigid_body.velocity = new Vector2(rigid_body.velocity.x, 1 * speed);
            jump_amount++;
        }
    }

    private void GroundCheck()
    {
        is_grounded = Physics2D.OverlapAreaAll(ground_collider.bounds.min, ground_collider.bounds.max, ground_mask).Length > 0;
        if(is_grounded)
        {
            jump_amount = 1;
        }
    }
}
