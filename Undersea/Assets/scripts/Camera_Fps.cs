using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_Fps : MonoBehaviour
{
    public Transform camera;

    public InputActionReference look;

    [SerializeField] private float sensitivity = 20.0f;

    private float verticalRotation = 0f;

    //for escaping

    public InputActionReference espace_Button;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look_Axis = look.action.ReadValue<Vector2>();

        transform.Rotate(Vector3.up * look_Axis.x * sensitivity * Time.deltaTime);

        verticalRotation -= look_Axis.y * sensitivity * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        camera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        if (espace_Button.action.WasPressedThisFrame())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
