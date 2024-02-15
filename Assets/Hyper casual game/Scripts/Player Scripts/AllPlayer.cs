using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayer : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private float raydius;
    [SerializeField] private float Angel;
    [SerializeField] private Transform RunnerParent;
    [SerializeField] GameObject RunnerPrefabs;
    [SerializeField] RunnerAnimation runnerAnimation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isGamestate())
            return;
        Playerposition();
        if(RunnerParent.childCount<= 0)
            GameManager.instance.SetGameState(GameManager.GameState.Gameover);
    }
    private void Playerposition()
    {
        for (int i = 0; i < RunnerParent.childCount; i++)
        {
            Vector3 childLocalPsition = getRunnerLocalPosition(i);
            RunnerParent.GetChild(i).localPosition = childLocalPsition;
        }
    }
    private Vector3 getRunnerLocalPosition(int index)
    {
        float x = raydius* Mathf.Sqrt(index)* Mathf.Cos(Mathf.Deg2Rad*index*Angel); 
        float z = raydius* Mathf.Sqrt(index)* Mathf.Sin(Mathf.Deg2Rad*index*Angel);
        // Debug.Log(Mathf.Cos(Mathf.Deg2Rad*index*Angel));
        // Debug.Log("ssdff"+Mathf.Sin(Mathf.Deg2Rad*index*Angel));
        return new Vector3(x,0,z);
    }
    public float getPlayerRaydius()
    {      
        return raydius*Mathf.Sqrt(RunnerParent.childCount);
    }
    public void GetApplyBonus(BonusType bonusType,int bonusAmount)
    {
        switch(bonusType)
        {
            case BonusType.PointPlas:
                GetAddRunner(bonusAmount);
                break;
            case BonusType.PointMultipication:
                int runner = (RunnerParent.childCount * bonusAmount) - RunnerParent.childCount;
                GetAddRunner(runner);
                break;
            case BonusType.PointMinas:
                GetRemoveRunner(bonusAmount);
                break;

            case BonusType.PointDivition:
                int runners = RunnerParent.childCount - (RunnerParent.childCount /bonusAmount);
                GetRemoveRunner(runners);
                break;
        }
    }


    private void GetAddRunner(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(RunnerPrefabs,RunnerParent);
        }
            runnerAnimation.run();
        
    }

    private void GetRemoveRunner(int amount)
    {
        if(amount>=RunnerParent.childCount)
            amount = RunnerParent.childCount;
    
        int runnerAmount = RunnerParent.childCount;
        for (int i = runnerAmount-1; i >= runnerAmount-amount; i--)
        {
            // Debug.Log(i);
            
            Transform RunnerToDestroy = RunnerParent.GetChild(i);
            RunnerToDestroy.SetParent(null);
            Destroy(RunnerToDestroy.gameObject);
        }
    }


}
