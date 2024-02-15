using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlar : MonoBehaviour
{
    public static PlayerControlar instance;
    [Header("Element")]
    [SerializeField] private float movespeed;
    [SerializeField] private float slideSpeed;
    [SerializeField] private float Roadwide;
    [SerializeField] private RunnerAnimation runnerAnimation;
    [Header("Satting")]
    AllPlayer allPlayer;
    private Vector3 checkedMousePosition;
    private Vector3 checkedPlayerPosition;
    public bool canmove;

    void Awake() 
    {
        allPlayer = FindObjectOfType<AllPlayer>();
        GameManager.onGameStateChenged += GameStateChanged;
        if(instance != null)
        {
            Debug.Log("Destroy");
            Destroy(gameObject); 
        }
        else instance = this;
    }
     void OnDestroy() 
    {
        GameManager.onGameStateChenged -= GameStateChanged;
        Debug.Log("Minas action");
    }
    void Update()
    {
        if(canmove)
        {
            PlayerMove();
            ControlPlayer();
        }
        
    }
    public void GameStateChanged( GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.Game)
            StartRunn();
        else if(gameState == GameManager.GameState.Gameover)
            StopRunn();
        else if(gameState == GameManager.GameState.LevelComplete)
            StopRunn();
    }
    private void StartRunn()
    {
        canmove = true;
        runnerAnimation.run();

    }
    private void StopRunn()
    {
        canmove = false;
        runnerAnimation.idel();
    }


    private void PlayerMove()
    {
        transform.position += Vector3.forward * Time.deltaTime * movespeed;
    }
    private void ControlPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            checkedMousePosition = Input.mousePosition;
            checkedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float Xdeffarent = Input.mousePosition.x - checkedMousePosition.x;
            Xdeffarent /= Screen.width;
            Xdeffarent *= slideSpeed;
            Vector3 position = transform.position;
            position.x = checkedPlayerPosition.x + Xdeffarent;
            position.x = Mathf.Clamp(position.x,-Roadwide/2+ allPlayer.getPlayerRaydius(),
            Roadwide/2 - allPlayer.getPlayerRaydius());

            transform.position = position;

        }
    }
}
