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
		// 入力をxに代入
		float x = Input.GetAxis("Horizontal");

		//x軸に加わる力を格納
		force = new Vector2(x * speed, 0);

		//Rigidbodyに力を加える
		rb.AddForce(force);
	}
}
