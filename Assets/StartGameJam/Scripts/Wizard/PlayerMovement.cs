using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playetAnim;
    public float acceleration = 5f;  // Ускорение по X
    public float maxSpeed = 3f;      // Максимальная скорость по X
    public bool isJumpOff = false;
    private float jumpCooldown = 0.8f; // Время ожидания между прыжками
    private float lastJumpTime;      // Время последнего прыжка
    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundCheckLayers;
    [SerializeField] private Vector2 groundCheckPointSize;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastJumpTime = Time.time - jumpCooldown;
    }

    private void Update()
    {
        CheckGround();
    }

    void FixedUpdate()
    {
        if (!playetAnim.GetBool("isRunning"))
        {
            Stop();
            return;
        }

        if (rb.velocity.x < maxSpeed)
        {
            rb.AddForce(new Vector2(acceleration, 0), ForceMode2D.Force);
        }
        
        if (!isJumpOff && CheckGround())
        {
            Vector2 rayStart = new Vector2(transform.position.x, transform.position.y - 0.1f);
            RaycastHit2D[] hits = Physics2D.RaycastAll(rayStart, Vector2.right, 2f);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Obstacle") && Time.time - lastJumpTime >= jumpCooldown)
                {
                    rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
                    lastJumpTime = Time.time; // Обновляем время последнего прыжка
                    break; // Если мы уже применили прыжок, нет смысла продолжать проверку
                }
            }
        }
    }

    private bool CheckGround()
    {
        var result = Physics2D.BoxCast(groundCheckPoint.position, groundCheckPointSize, 0,
            Vector2.down, 0, groundCheckLayers);

        return result;
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
    }
}