using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{

    // for movement

    public InputActionReference movement;

    private CharacterController character_Controller;

    public Vector2 value;

    [SerializeField] float speed = 5.0f;

    //for gravity and jumping
    private Vector3 velocity;

    private float gravity = -9.81f;

    public InputActionReference jumping;

    private float jumpHeight = 2.0f;

    void Start()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {

        // for movement

        value = movement.action.ReadValue<Vector2>();
        
        Vector3 raw_Movement = new Vector3(value.x, 0, value.y);

        Vector3 player_Movement = transform.TransformDirection(raw_Movement);

        player_Movement *= speed;

        //for gravity and jumping

        if (character_Controller.isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f; 
            }

            if (jumping.action.WasPressedThisFrame())
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }


        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMovement = player_Movement + velocity;

        character_Controller.Move(finalMovement * Time.deltaTime);

      
    }
}
