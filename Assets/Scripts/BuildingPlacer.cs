using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public Building CurrentBuilding;
    public Camera RaycastCamera;
    private Plane _plane;

    private void Start()
    {
        _plane = new Plane(Vector3.up, Vector3.zero);
    }

    private void Update()
    {
        if (!CurrentBuilding) return;

        Ray ray = RaycastCamera.ScreenPointToRay(Input.mousePosition);
        float distance;
        _plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        CurrentBuilding.transform.position = point;

        if (Input.GetMouseButtonDown(0))
            CurrentBuilding = null;
    }

    public void CreateBuilding(GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        CurrentBuilding = go.GetComponent<Building>();
    }

   
}