using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class PlayerDetected : MonoBehaviour
{
    [SerializeField] AllPlayer allPlayer;
    [SerializeField] Transform RunnerParent;
    [SerializeField] private SoundManager soundManager;
     private Runner runner;
     public static Action OnDoorHit;
     
    // Start is called before the first frame update
    void Start()
    {
        runner = FindObjectOfType<Runner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGamestate())
            detectedPlayer();
    }
    private void detectedPlayer()
    {
        Collider[] colideDoors= Physics.OverlapSphere(transform.position,allPlayer.getPlayerRaydius());

        for (int i = 0; i < colideDoors.Length; i++)
        {
            if(colideDoors[i].TryGetComponent(out Doors doors))
            {
                Debug.Log("hit some colider");
                int bonusAmount =doors.GetbonusNumber(transform.position.x);
                BonusType bonusType= doors.GetBonusType(transform.position.x);
                doors.disabal();
                OnDoorHit?.Invoke();
                allPlayer.GetApplyBonus(bonusType,bonusAmount);
                
            }

            if(colideDoors[i].tag == "Finish")
            {
                Debug.Log("You are Finish");

                PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level")+1);

                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
                // SceneManager.LoadScene(0);
            }
            
            else if(colideDoors[i].tag == "coin")
            {
                Destroy(colideDoors[i].gameObject);
                soundManager.coinSoundPlay();
                DataManager.instance.Addcoins(1);
            }
        }
    }

    
}
