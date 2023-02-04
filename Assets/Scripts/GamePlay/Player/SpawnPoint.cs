using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Spawnpoint", menuName = "Data/SpawnPoint")]
public class SpawnPoint : ScriptableObject
{
    public string scnName;

    public float x;
    public float y;
    public float z;

}
