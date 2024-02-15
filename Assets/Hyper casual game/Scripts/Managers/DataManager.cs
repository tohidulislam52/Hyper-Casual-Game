using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] CoinText;
    public static DataManager instance;

    private int Coins;
    // Start is called before the first frame update
    private void Awake() {
        if(instance != null)
            Destroy(gameObject);
        else
            instance =this;


        Coins = PlayerPrefs.GetInt("coin",200);
    }
    void Start()
    {
        UpdateCointext();
        // Addcoins(500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateCointext()
    {
        foreach(TextMeshProUGUI coin in CoinText)
        {
            coin.text = Coins.ToString();
        }
    }
    public void Addcoins(int coin)
    {
        Coins +=coin;
        PlayerPrefs.SetInt("coin",Coins);
        UpdateCointext();
    }
    public void removeCoins(int coin)
    {
        if(Coins >= coin)
        {
            Coins -=coin;
            PlayerPrefs.SetInt("coin",Coins);
            UpdateCointext();
        }
        
    }
    public int getconi()
    {
        return Coins;
    }
}
