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
		// ���͂�x�ɑ��
		float x = Input.GetAxis("Horizontal");

		//x���ɉ����͂��i�[
		force = new Vector2(x * speed, 0);

		//Rigidbody�ɗ͂�������
		rb.AddForce(force);
	}
}
