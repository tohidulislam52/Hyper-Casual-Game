using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName ="LevelSO", fileName ="Level" )]
public class LevelSO : ScriptableObject
{
    [SerializeField] public Gigmoge[] chanks;
}
