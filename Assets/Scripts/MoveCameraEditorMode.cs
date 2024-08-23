using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCameraEditorMode : MonoBehaviour
{
    [SerializeField] public float mouseZoomSpeed = 15.0f,
        touchZoomSpeed = 0.1f,
        zoomMinBound = 20f,
        zoomMaxBound = 61,
        leftLimit,
        rightLimit,
        bottomLimit,
        topLimit,
        yAxisLimit;

    public BuildingPlacer BuildingPlacer;
    public float groundZ;

    private Vector3 _touchStart;
    private Camera _camera;
    public LayerMask LayerMask;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (BuildingPlacer.CurrentBuilding) return;

        
        MoveCameraFunction();
        ZoomUpdate();
    }

    private void Zoom(float deltaMagnitudeDiff, float speed)
    {
        var fieldOfView = _camera.fieldOfView;
        fieldOfView += deltaMagnitudeDiff * speed;
        _camera.fieldOfView = fieldOfView;
        _camera.fieldOfView = Mathf.Clamp(fieldOfView, zoomMinBound, zoomMaxBound);
    }


    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = _camera.ScreenPointToRay(Input.mousePosition);

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return Vector3.zero;
        }
        else
        {
            Plane ground = new Plane(Vector3.down, new Vector3(0, z, 0));
            ground.Raycast(mousePos, out var distance);
            return mousePos.GetPoint(distance);
        }
        
    }

    private void MoveCameraFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchStart = GetWorldPosition(groundZ);
        }

        if (!Input.GetMouseButton(0)) return;
        Vector3 direction = _touchStart - GetWorldPosition(groundZ);
        _camera.transform.position += direction;

        _camera.transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit), yAxisLimit,
            Mathf.Clamp(transform.position.z, bottomLimit, topLimit)); /*,
    transform.localPosition.z);*/
    }

    private void ZoomUpdate()
    {
        if (Input.touchSupported)
        {
            if (Input.touchCount == 2)
            {
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, touchZoomSpeed);
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, mouseZoomSpeed);
        }

        if (_camera.fieldOfView < zoomMinBound)
        {
            _camera.fieldOfView = 0.1f;
        }
        else if (_camera.fieldOfView > zoomMaxBound)
        {
            _camera.fieldOfView = 60f;
        }
    }
}