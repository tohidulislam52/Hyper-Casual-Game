using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ShopManager shopManager;
    [Header("Element")]

    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject LevelComplitePanel;
    [SerializeField] GameObject SattingPanel;
    [SerializeField] GameObject ShopPlanel;

    [SerializeField] Slider progressber;
    [SerializeField] Text levelText;
    void Start()
    {  
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        LevelComplitePanel.SetActive(false);
        SattingPanel.SetActive(false);
        ShopPlanel.SetActive(false);
        progressber.value = 0;
        levelText.text = "level " + (ChankManager.inistance.GetlevelNumber()+1);
        GameManager.onGameStateChenged += GameStateChange;
        // PlayerPrefs.DeleteAll();
    }
    void OnDestroy() 
    {
    GameManager.onGameStateChenged -= GameStateChange;
    }
    private void GameStateChange(GameManager.GameState gameState)
    {
        if(GameManager.GameState.Gameover == gameState)
            ShowGameOverPanel();
        else if(gameState == GameManager.GameState.LevelComplete)
            ShowLevelCompletePanel();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerPogressBer();
        
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    private void ShowGameOverPanel()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
    private void ShowLevelCompletePanel()
    {
        GamePanel.SetActive(false);
        LevelComplitePanel.SetActive(true);
    }

    private void PlayerPogressBer()
    {
        if(!GameManager.instance.isGamestate())
            return;
        float progress = PlayerControlar.instance.transform.position.z / 
                                ChankManager.inistance.GetfinishZ();
        progressber.value = progress;     

    }
    public void EnableSattingPanel()
    {
        SattingPanel.SetActive(true);
    }
    public void DisableSatttingPanel()
    {
        SattingPanel.SetActive(false);
    }
    public void showShopPlanel()
    {
        ShopPlanel.SetActive(true);
        shopManager.UpdatePurchaseButton();
        MenuPanel.SetActive(false);
    }
    public void hideShopPlanel()
    {
        ShopPlanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
