using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private Transform runnerParent;
    [SerializeField] private RunnerSelector runnerSelector;
    // Start is called before the first frame update
    void Start()
    {
        ShopManager.onSelectSkin += skinSelect;
    }
    private void OnDestroy() {
        ShopManager.onSelectSkin -= skinSelect;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown("w")){
        //     skinSelect(Random.Range(0,2));
        //     Debug.Log("dklfjlds");
        // }
            
    }
    public void skinSelect(int SkinIndex)
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            runnerParent.GetChild(i).GetComponent<RunnerSelector>()
                                        .Runnerselector(SkinIndex);
            runnerSelector.Runnerselector(SkinIndex);
        }
            // runnerSelector.Runnerselector(SkinIndex);

    }
}
