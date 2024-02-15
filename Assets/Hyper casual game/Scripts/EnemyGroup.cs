using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private int amount;
    [SerializeField] private Enemy EnemyPrefabs;
    [SerializeField] private Transform EnemyParent;

    [Header("Satting")]
    [SerializeField] private float raydius;
    [SerializeField] private float Angel;
    // Start is called before the first frame update
    void Start()
    {
        enemyGroup();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void enemyGroup()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 enemyLocalPosition = getRunnerLocalPosition(i);
            enemyLocalPosition = transform.TransformPoint(enemyLocalPosition);
            Instantiate(EnemyPrefabs,enemyLocalPosition,Quaternion.Euler(0,180,0),EnemyParent);
            
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

    

}
