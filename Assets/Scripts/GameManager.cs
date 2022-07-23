using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Canvas gameOverCanvas = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void Death()
    {
        // 残機1減らす。
        // プレイヤーキャラ消す。
        // なんか押されたら GameStart()
    }

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

	/// <summary>
	/// プレイヤーとゴールとの判定後の処理
	/// </summary>
	public void PlayerGoal()
	{
		Debug.Log("ゴール");
	}
}
