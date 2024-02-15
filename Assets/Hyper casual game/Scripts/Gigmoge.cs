using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigmoge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 size;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetLengrh()
    {
        return size.z;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position,size);
    }
}
