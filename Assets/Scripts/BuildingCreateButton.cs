using UnityEngine;

public class BuildingCreateButton : MonoBehaviour
{
    public BuildingPlacer BuildingPlacer;
    public GameObject BuildingPrefab;

    public void Create() =>
        BuildingPlacer.CreateBuilding(BuildingPrefab);
}