using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimation : MonoBehaviour
{
    [SerializeField] Transform RunnerParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void run()
    {
        for (int i = 0; i < RunnerParent.childCount; i++)
        {
            Transform runner = RunnerParent.GetChild(i);
            Animator runneranimation = runner.GetComponent<Runner>().GetAnimator();
            runneranimation.Play("Run");
        
        }
    }

    public void idel()
    {
        for (int i = 0; i < RunnerParent.childCount; i++)
        {
            Transform runner = RunnerParent.GetChild(i);
            Animator runneranimation = runner.GetComponent<Runner>().GetAnimator();
            runneranimation.Play("Idle");
        
        }
    }
}
