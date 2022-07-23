using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
	Spawn spawnSc;
    [SerializeField]
    GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		spawnSc = GameObject.Find("GameManager").GetComponent<Spawn>();
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
			spawnSc.playerSpawn();
		}
    }
}
