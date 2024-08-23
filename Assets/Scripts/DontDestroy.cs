using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    private string _tag = "Sound";

    private void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag(_tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}