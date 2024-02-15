using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    private bool vibration;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDetected.OnDoorHit += Vibration;
        GameManager.onGameStateChenged += GameStateChange;
        Enemy.OnRunnerHit +=Vibration;
    }
    private void OnDestroy()
    {
        PlayerDetected.OnDoorHit -= Vibration;
        GameManager.onGameStateChenged -= GameStateChange;
        Enemy.OnRunnerHit -=Vibration;
    }


    private void GameStateChange(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.LevelComplete)
            Vibration();
        else if(gameState == GameManager.GameState.Gameover)
            Vibration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Vibration()
    {
        if(vibration)
            Taptic.Light();
    }
    public void EnableVibration()
    {
        vibration = true;
    }
    public void DisableVibration()
    {
        vibration = false;
    }

}
