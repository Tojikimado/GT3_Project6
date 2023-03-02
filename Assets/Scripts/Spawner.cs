using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _PrefabToSpawn;

    [SerializeField]
    private Transform _SpawnLocation;

    private string _PlayerTag = "GameController";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_PlayerTag))
        {
            Instantiate(_PrefabToSpawn, _SpawnLocation.position, _SpawnLocation.rotation);
            Destroy(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        BoxCollider col = GetComponent<BoxCollider>();
        if (col != null)
        {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(col.transform.position, col.transform.rotation, col.transform.lossyScale);
            Gizmos.matrix = rotationMatrix;
            Gizmos.DrawWireCube(col.center, col.size);
        }
        if (_SpawnLocation)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(_SpawnLocation.localPosition, 0.1f);
        }
    }
}
