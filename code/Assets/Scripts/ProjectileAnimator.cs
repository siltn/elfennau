using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnimator : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] private float _leftBoundary = 20f;
    [SerializeField] private float _rightBoundary = -20f;
    [SerializeField] private float _topBoundary = -5f;
    [SerializeField] private float _bottomBoundary = 5f;
    [SerializeField] private float _speedLeft = 2f;

    public float baseSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProjectileBoundaries();

        Vector2 velocity;


        velocity = MouseInput();

        Vector3 movement = new Vector3(baseSpeed * velocity.x, baseSpeed * velocity.y);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    private Vector2 MouseInput()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        float ySpeed = (mousePosition.y > transform.position.y) ? baseSpeed : -baseSpeed;

        return new Vector2(_speedLeft * -1, ySpeed);
    }

    private void ProjectileBoundaries()
    {
        float xMovementClamp = Mathf.Clamp(transform.position.x, _leftBoundary, _rightBoundary);
        float yMovementClamp = Mathf.Clamp(transform.position.y, _bottomBoundary, _topBoundary);
        transform.position = new Vector2(xMovementClamp, yMovementClamp);
    }
}