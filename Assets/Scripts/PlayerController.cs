using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody2D rigidbody2D;
    [SerializeField] float TorqueAmount = 1f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Vector is just two floats, x and y
        //x,y
        //Vector2 moveVector;
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
            rigidbody2D.AddTorque(TorqueAmount);
        if (moveVector.x > 0)
            rigidbody2D.AddTorque(-TorqueAmount);
        //rigidbody2D.AddTorque(TorqueAmount);
    }
}
