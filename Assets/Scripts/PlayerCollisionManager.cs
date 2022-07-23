using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager = null;
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
        }

		if (other.gameObject.CompareTag("Goal"))
		{
			gameManager.PlayerGoal();
		}
	}
}
