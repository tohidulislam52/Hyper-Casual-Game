using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private enum EnemyState{Idle,Runing}
    [SerializeField] private float SearchRadius;
    [SerializeField] private float speed;
    private Transform TergetRunner;
    private EnemyState enemyState;
    [Header("Events")]
    public static Action OnRunnerHit;

    void Update()
    {
       ManageState(); 
    }
    private void ManageState()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                SearchForTerget();
            break;
            case EnemyState.Runing:
                RunTOTarget();
            break;
        }
    }
    private void SearchForTerget()
    {
        Collider[] EnemyCollider = Physics.OverlapSphere(transform.position,SearchRadius);
        for (int i = 0; i < EnemyCollider.Length; i++)
        {
            if(EnemyCollider[i].TryGetComponent(out Runner runner))
            {
                if(runner.isterget())
                    continue;
                runner.SetTerget();
                TergetRunner = runner.transform;
                IdleStateToRunnerState();
                return;
                
            }
        }
    }
    private void IdleStateToRunnerState()
    {
        enemyState = EnemyState.Runing;
       GetComponent<Animator>().Play("Run");
    }
    private void RunTOTarget()
    {
        if(TergetRunner == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position,TergetRunner.position,
        Time.deltaTime * speed);
        if(Vector3.Distance(transform.position,TergetRunner.position) < .01f)
        {
            OnRunnerHit?.Invoke();

            Destroy(TergetRunner.gameObject);
            Destroy(gameObject);
        }
    }
}
