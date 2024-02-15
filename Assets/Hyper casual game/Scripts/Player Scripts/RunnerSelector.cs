using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSelector : MonoBehaviour
{
    [SerializeField] private Runner runner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.W))
        //     Runnerselector(Random.Range(0,2));
    }
    public void Runnerselector(int RunnerIndex)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(i == RunnerIndex)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                runner.SetAnimator(transform.GetChild(i).GetComponent<Animator>());
            }
            else
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
