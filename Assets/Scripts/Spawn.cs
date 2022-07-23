using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	//スポーン位置
	private Vector3 spawnPos;
	
	//プレイヤーObj
	public GameObject player;

	//GameManager
	GameManager gameManager;

	// Start is called before the first frame update
	void Start()
    {
		spawnPos = player.transform.position;

		gameManager = gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// プレイヤースポーン
	/// </summary>
	public void playerSpawn()
	{
		player.transform.position = spawnPos;
		gameManager.GameStart();
	}
}
