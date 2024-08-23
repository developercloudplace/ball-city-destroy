using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public bool EditorMode = false;
    private Vector3 offset;
    public void Create()
    {
        offset = EditorMode ? new Vector3(0,.5f,0) : new Vector3(0,15,0);
        var newPrefab = Instantiate(prefab, transform.position + offset , Quaternion.identity);
        Destroy(newPrefab,1f);
    }
}
