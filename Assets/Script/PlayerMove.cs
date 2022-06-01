using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	public Vector2 force;

	// Start is called before the first frame update
	void Start()
    {
		speed = 5.0f;
		rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

	}

	private void FixedUpdate()
	{
		// “ü—Í‚ðx‚É‘ã“ü
		float x = Input.GetAxis("Horizontal");

		//xŽ²‚É‰Á‚í‚é—Í‚ðŠi”[
		force = new Vector2(x * speed, 0);

		//Rigidbody‚É—Í‚ð‰Á‚¦‚é
		rb.AddForce(force);
	}
}
