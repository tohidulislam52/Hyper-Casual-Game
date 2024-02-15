using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public enum GameState {Menu,Game,LevelComplete,Gameover};
    private GameState gameState;
    public static Action<GameState> onGameStateChenged;
    void Awake()
    {
        if(instance!= null)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
            
        }
        else instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChenged?.Invoke(gameState);
        Debug.Log("Gamestate :" + gameState);
    }
    public bool isGamestate()
    {
        return gameState == GameState.Game;
    }
}
