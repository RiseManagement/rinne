﻿using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

	[SerializeField]
	float dashSpeed;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Awake()
    {      
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // GetAxisRawを使用。入力が 0, 1, -1 のいずれかになる
        float moveInput = Input.GetAxisRaw("Horizontal");

		//地面についている状態
        if (grounded)
        {
            velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                // 目標とするジャンプの高さを達成するために必要な速度を計算する。
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;
		
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			dashSpeed = 3f;
		}
		else
		{
			dashSpeed = 1;
		}

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * dashSpeed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        // 速度が適用された後、接触したすべてのコライダーを取得する。
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

		//当たり判定？
        foreach (Collider2D hit in hits)
        {
            // コライダを無視
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            // コライダがまだ重なっているかを確認する。
            // 他のコライダが接触しているため、オーバーラップが存在しない場合がある。
            // 移動させ重なりを解消する。
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // 下にあるオブジェクトと接触したら、groundedをtrueにする。 
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }
    }
}
