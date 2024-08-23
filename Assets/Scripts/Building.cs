using UnityEngine;

public class Building : MonoBehaviour
{
    private CheckForVictory _checkForVictory;
    public bool Well;

    private void Awake()
    {
        if (Well) return;
        _checkForVictory = FindObjectOfType<CheckForVictory>();
        _checkForVictory.buildings.Add(this);
    }

    public void ClearList()
    {
        if (Well) return;
        _checkForVictory.buildings.Remove(this);
    }
}