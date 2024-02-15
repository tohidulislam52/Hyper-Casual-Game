using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource DoorHitSound;
    [SerializeField] private AudioSource GameOverSound;
    [SerializeField] private AudioSource LevelCompliteSound;
    [SerializeField] private AudioSource RunnerDieSound;
    [SerializeField] private AudioSource ButtonSound;
    [SerializeField] private AudioSource Coinsound;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerDetected.OnDoorHit += PlayDorrHitSound;
        GameManager.onGameStateChenged += GameStateChange;
        Enemy.OnRunnerHit +=PlayRunnerDieSound;
    }
    
    private void OnDestroy()
    {
        PlayerDetected.OnDoorHit -= PlayDorrHitSound;
        GameManager.onGameStateChenged -= GameStateChange;
        Enemy.OnRunnerHit -=PlayRunnerDieSound;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void GameStateChange(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.LevelComplete)
            LevelCompliteSound.Play();
        else if(gameState == GameManager.GameState.Gameover)
            GameOverSound.Play();
    }
    private void PlayDorrHitSound()
    {
        DoorHitSound.Play();
    }
    private void PlayRunnerDieSound()
    {
        RunnerDieSound.Play();
    }
    public void DisabledSound()
    {
        DoorHitSound.volume = 0;
        GameOverSound.volume = 0;
        LevelCompliteSound.volume = 0;
        RunnerDieSound.volume = 0;
        ButtonSound.volume = 0;
        Coinsound.volume =0;
    }
    public void EnabledSound()
    {
        DoorHitSound.volume = 1;
        GameOverSound.volume =1;
        LevelCompliteSound.volume = 1;
        RunnerDieSound.volume = 1;
        ButtonSound.volume = 1;
        Coinsound.volume =1;

    }
    public void coinSoundPlay()
    {
        Coinsound.Play();
        // Debug.Log("Sound Play");

    }
}
