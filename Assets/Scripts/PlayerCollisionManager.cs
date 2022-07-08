using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager = null;

	/// <summary>
	/// プレイヤーが地面に落ちているかフラグ
	/// </summary>
	public bool playerfalllag = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            Debug.Log("Hole");
            gameManager.GameOver();
			playerfalllag = true;

		}
    }
}
