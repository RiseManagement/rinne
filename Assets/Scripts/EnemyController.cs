using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
	float speed = 9;

	[SerializeField, Tooltip("Acceleration while grounded.")]
	float walkAcceleration = 75;

	[SerializeField, Tooltip("Acceleration while in the air.")]
	float airAcceleration = 30;

	[SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
	float groundDeceleration = 70;

	[SerializeField]
	float movedir = 1;

	private BoxCollider2D boxCollider;

	private Vector2 velocity;

	private bool grounded;

	// Start is called before the first frame update
	void Start()
    {
		boxCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
    {
		float acceleration = grounded ? walkAcceleration : airAcceleration;
		float deceleration = grounded ? groundDeceleration : 0;

		//地面についている状態
		if (grounded)
		{
			velocity.y = 0;
			velocity.x = Mathf.MoveTowards(velocity.x, speed * movedir, acceleration * Time.deltaTime);
		}

		//重力
		velocity.y += Physics2D.gravity.y * Time.deltaTime;

		//移動
		transform.Translate(velocity * Time.deltaTime);

		grounded = false;

		// Retrieve all colliders we have intersected after velocity has been applied.
		Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

		//当たり判定？
		foreach (Collider2D hit in hits)
		{
			// Ignore our own collider.
			if (hit == boxCollider)
				continue;

			ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

			// Ensure that we are still overlapping this collider.
			// The overlap may no longer exist due to another intersected collider
			// pushing us out of this one.
			if (colliderDistance.isOverlapped)
			{
				transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

				// If we intersect an object beneath us, set grounded to true. 
				if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
				{
					grounded = true;
				}
			}

			
			if (hit.gameObject.tag.Equals("Wall"))
			{
				//movedir *= 1;
			}
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
				Debug.Log("壁に当たった");
		
	}
}
