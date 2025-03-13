using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashAmount = 3f;
    public float dashTime = 0;
    public float cooldowndashTime = 0;

    private Vector3 moveDir;

    public Rigidbody2D rb;
    public Camera cam;

    private float leftside = -39f;
    private float rightside = 49f;
    private float yRange = 28f;


    Vector2 movement;
    Vector2 mousePos;

    public bool isDashButtonDown;


    private void Start()
    {

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        moveDir = new Vector3(movement.x, movement.y).normalized;


        if (transform.position.x < leftside)
        {
            transform.position = new Vector2(leftside, transform.position.y);
        }

        if (transform.position.x > rightside)
        {
            transform.position = new Vector2(rightside, transform.position.y);
        }


        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > dashTime)
            {
                isDashButtonDown = true;
            }
        }


    }


    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (Time.time > dashTime)
        {
            if (isDashButtonDown)
            {
                dashTime = Time.time + cooldowndashTime;
                rb.MovePosition(transform.position + moveDir * dashAmount);
                isDashButtonDown = false;
            }
        }



        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
