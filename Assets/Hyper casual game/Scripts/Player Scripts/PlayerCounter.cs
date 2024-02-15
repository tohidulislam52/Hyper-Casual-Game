using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshPro PlayerCounterText;
    [SerializeField] Transform RunerParent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCounterText.text = RunerParent.childCount.ToString();
        if(RunerParent.childCount <= 0)
            Destroy(gameObject);
        
    }
    private void OnDestroy() 
    {
        Debug.Log("palyer counter");
    }
}
