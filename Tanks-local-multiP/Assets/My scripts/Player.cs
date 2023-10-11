using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public Transform turret;
    public Transform body;
    public Transform shotingPoint;
    public GameObject bulletPrefab;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public float bodyrotationSpeed = 9f;
    public float cooldown = 0.5f;

    private float lastShot = 1f;
    private Vector2 movementInput;
    private Vector2 rotationInput;
    public AudioClip Shootsound;
    private AudioSource audioSource;

    private void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
        float rotation = rotationInput.x * rotationSpeed * Time.deltaTime;
        turret.Rotate(Vector3.up, rotation);
    }
    void Update()
    {
        var direction = new Vector3(movementInput.x, 0, movementInput.y);
        transform.position += /*(direction.x * turret.right + direction.z )*/direction * speed * Time.deltaTime;

        if(direction != Vector3.zero)
        {
            var targetrotation = Quaternion.LookRotation(direction);
            body.rotation = Quaternion.Slerp(body.rotation, targetrotation, bodyrotationSpeed * Time.deltaTime);
        }

        float rotation = rotationInput.x * rotationSpeed * Time.deltaTime;
        turret.Rotate(Vector3.up, rotation);
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        movementInput = value.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext value)
    {
       rotationInput = value.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext value)
    {
        if(Time.time >lastShot+ cooldown)
        {
            audioSource.PlayOneShot(Shootsound,  100f);
            Instantiate(bulletPrefab, shotingPoint.position, turret.rotation);

            lastShot = Time.time;
        }
           
    }
}
