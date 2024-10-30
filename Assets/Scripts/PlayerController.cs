using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float boostSpeed = 40f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    private bool canCollide = true;
    private float collisionCooldown = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canCollide) return;

        if (other.CompareTag("Star"))
        {
            ScoreAndHP.scoreAndHP.AddScore();
            StartCoroutine(CollisionCooldown());
        }
        else if (other.CompareTag("Rock"))
        {
            Debug.Log("Đã vào hàm");
            ScoreAndHP.scoreAndHP.MisusHP();
            ScoreAndHP.scoreAndHP.MisusScore();
            StartCoroutine(CollisionCooldown());
        }
    }
    private IEnumerator CollisionCooldown()
    {
        canCollide = false;
        yield return new WaitForSeconds(collisionCooldown);
        canCollide = true;
    }
}
