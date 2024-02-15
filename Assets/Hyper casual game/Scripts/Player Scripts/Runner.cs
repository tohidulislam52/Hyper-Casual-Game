using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public bool IsTarget;
    
    private float number;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(isbool)
        // {
        //     SerTegerFalse();
        //     isbool =false;
        // }
        // if(IsTarget == true)
        // {
        //     float time = Time.deltaTime *5;
        //     number = 1*Time.deltaTime;
        //     if(number >.1)
        //         IsTarget = false;
        //     Debug.Log(number);
        // }
    }
    public void SetTerget()
    {
        IsTarget = true;
    }
    public bool isterget()
    {
        return IsTarget;
    }
     public  void SerTegerFalse()
    {
        IsTarget = false;
    }
    public Animator GetAnimator()
    {
        return animator;
    }
    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }
}
