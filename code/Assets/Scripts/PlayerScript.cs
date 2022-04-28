using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] private float _leftBoundary = -10f;
    [SerializeField] private float _rightBoundary = 10f;
    [SerializeField] private float _topBoundary = 5f;
    [SerializeField] private float _bottomBoundary = -5f;

    public float baseSpeed = 4f;
    public int inputMethod = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerBoundaries();

        // float inputX = Input.GetAxis("Horizontal");
        // float inputY = Input.GetAxis("Vertical");
        Vector2 velocity;

        switch (inputMethod)
        {
            case 0:
                velocity = ArrowInput();
                break;
            case 1:
                velocity = MouseInput();
                break;
            default:
                velocity = new Vector2(0, 0);
                break;
        }

        Vector3 movement = new Vector3(baseSpeed * velocity.x, baseSpeed * velocity.y);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    private Vector2 ArrowInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return new Vector2(0, baseSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return new Vector2(0, -baseSpeed);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    private Vector2 MouseInput()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //return (mousePosition.y > transform.position.y) ? new Vector2(0, baseSpeed) : new Vector2(0, -baseSpeed);
        //transform.position = Vector2.Lerp(transform.position, mousePosition, speed.y);
        float xSpeed = (mousePosition.x > transform.position.x) ? baseSpeed : -baseSpeed;
        float ySpeed = (mousePosition.y > transform.position.y) ? baseSpeed : -baseSpeed;

        return new Vector2(xSpeed, ySpeed);
    }

    private void PlayerBoundaries()
    {
        float xMovementClamp = Mathf.Clamp(transform.position.x, _leftBoundary, _rightBoundary);
        float yMovementClamp = Mathf.Clamp(transform.position.y, _bottomBoundary, _topBoundary);
        transform.position = new Vector2(xMovementClamp, yMovementClamp);
    }
}