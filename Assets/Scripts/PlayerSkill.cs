using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
	/// <summary>
	/// プレイヤー情報取得
	/// </summary>
	[SerializeField] PlayerController playerController;
	[SerializeField] PlayerCollisionManager playerCollisionManager;

	/// <summary>
	/// 重複スキルの発動フラグ
	/// </summary>
	public bool skilldupImpositionFlag = false;

	// Start is called before the first frame update
	void Start()
    {
		playerController = this.gameObject.GetComponent<PlayerController>();
		playerCollisionManager = this.gameObject.GetComponent<PlayerCollisionManager>();
	}

	// Update is called once per frame
	void Update()
	{
		//もしプレイヤーが地面に落ちたらリスポーンし落ちたからジャンプ力を2倍にする
		if (playerCollisionManager.playerfalllag)
		{
			PlayerSkillJump();
		}
	}

	public void PlayerSkillJump()
	{
		if (!skilldupImpositionFlag)
		{
			playerController.JumpForce *= 2;
			skilldupImpositionFlag = true;
		}
	}


}
