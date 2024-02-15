using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankManager : MonoBehaviour
{
    public static ChankManager inistance;
    [SerializeField] private Gigmoge[] chunkPrefabs;
    // [SerializeField] private Gigmoge[] level;
    [SerializeField] private LevelSO[] levels;

    private GameObject finisLine;
    // [SerializeField] private GameObject nani;
    void Awake() 
    {
        if(inistance != null)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }  
        else inistance = this;
    }
    void Start()
    {
        // Getlavel();
        // RandomeLevel(chunkPrefabs);
        Getlavel();
        finisLine = GameObject.FindWithTag("Finish");
    }

    private void Getlavel()
    {
        int currentLevel = GetlevelNumber();
        Debug.Log(GetlevelNumber());
        Debug.Log(levels.Length);
        if(currentLevel >= levels.Length)
            currentLevel = Random.Range(0,levels.Length);
        // currentLevel = currentLevel % levels.Length;
        LevelSO level= levels[currentLevel];
        // NormalLevel(levels[currentLevel].chanks);
        NormalLevel(level.chanks);
    }

    private void NormalLevel(Gigmoge[] level)
    {
        Vector3 chankPosition = Vector3.zero;
        for (int i = 0; i < level.Length; i++)
        {
            Gigmoge chunkToCreate = level[i];
            if (i > 0)
            {
                chankPosition.z += chunkToCreate.GetLengrh() / 2;
            }
            Gigmoge chunkinstantiate = Instantiate(chunkToCreate, chankPosition, Quaternion.identity, transform);

            chankPosition.z += chunkinstantiate.GetLengrh() / 2;
        }
    }

    private void RandomeLevel(Gigmoge[] chunkPrefabs)
    {
        Vector3 chankPosition = Vector3.zero;
        for (int i = 0; i < chunkPrefabs.Length; i++)
        {
            // Gigmoge chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
            Gigmoge chunkToCreate = chunkPrefabs[i];
            if (i > 0)
            {
                chankPosition.z += chunkToCreate.GetLengrh() / 2;
            }
            Gigmoge chunkinstantiate = Instantiate(chunkToCreate, chankPosition, Quaternion.identity, transform);

            chankPosition.z += chunkinstantiate.GetLengrh() / 2;

            //    Debug.Log("dd"+chunkToCreate.GetLengrh());
            //    chankPosition.z += chunkinstantiate.GetLength();

        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetfinishZ()
    {
        return finisLine.transform.position.z;
    }
    public int GetlevelNumber()
    {
        return PlayerPrefs.GetInt("level");
    }
}
