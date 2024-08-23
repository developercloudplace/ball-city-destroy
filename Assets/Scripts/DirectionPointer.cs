using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform directionObject;
    [SerializeField] private MeshRenderer pointerMeshRenderer;
    [SerializeField] private CheckForVictory forVictory;
    [SerializeField] private float sensitivity;
    [SerializeField] private float speed;
    [SerializeField] private Pause pause;

    private float _rotationX;
    private float _rotationY;


    private void Start()
    {
        if (!joystick) joystick = FindObjectOfType<DynamicJoystick>();
        if (!pointer) pointer = FindObjectOfType<ArrowPointer>().transform;
        if (!forVictory) forVictory = FindObjectOfType<CheckForVictory>();
        if (!directionObject) directionObject = FindObjectOfType<DirectionPointerView>().transform;
        if (!forVictory) forVictory = FindObjectOfType<CheckForVictory>();
        if (!pointerMeshRenderer) pointerMeshRenderer = FindObjectOfType<PointerMesh>().GetComponent<MeshRenderer>();
        if (!pause) pause = FindObjectOfType<Pause>();


    }

    private void Update()
    {
        if (pause.activePause != false) return;
        ActiveAimCheck();


        pointer.transform.position = transform.position;

        var dirY = joystick.Horizontal * sensitivity * Time.deltaTime;
        var dirX = joystick.Vertical * sensitivity * Time.deltaTime;
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            Vector2 direction = pointer.transform.position;
            var angle = Mathf.Atan2(dirY, dirX) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.up);
            pointer.transform.rotation = rotation;
        }

    }

    private void Kick()
    {
        var direction = directionObject.position - transform.position;
        if (!Input.GetMouseButtonUp(0)) return;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(direction * speed, ForceMode.Impulse);

    }

    private void ActiveAimCheck()
    {
        if (FindObjectOfType<ActiveAim>())
        {
            pointerMeshRenderer.enabled = true;
            Time.timeScale = 0.05f;
        }
        else
        {
            pointerMeshRenderer.enabled = false;
            Kick();
            Time.timeScale = 1.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectile>())
        {
            
            forVictory.Lose();
        }
    }
}