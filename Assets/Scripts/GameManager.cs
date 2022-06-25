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

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
}
