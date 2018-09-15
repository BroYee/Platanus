using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public Rigidbody2D rb;

    public float moveSpeed;//좌우 이동속도
    public float jumpSpeed;//점프 높이

    [HideInInspector] public bool highJumping;
    [HideInInspector] public bool idle;
    [HideInInspector] public bool falling;

    private float prevHeight;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;

        Time.timeScale = 0;

        idle = true;

        falling = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (idle)
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                GameObject startScreen = GameObject.FindGameObjectWithTag("StartScreen");
                startScreen.SetActive(false);
                idle = false;
                Time.timeScale = 1;
                rb.gravityScale = 1.5f;

                Debug.Log("Game Start");
            }
        }
        else
        {
            if (transform.position.y <= -10)
            {
                GameOver();
                return;
            }

            falling = transform.position.y < prevHeight;

            float xMoveDistance = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            transform.Translate(xMoveDistance, 0, 0);

            //if (Input.GetTouch(0).position.x < Screen.width / 2)
            //    transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            //else if (Input.GetTouch(0).position.x > Screen.width / 2)
            //    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

            highJumping = false;
        }

        prevHeight = transform.position.y;
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform") && !highJumping)
        {
            StartCoroutine(JumpAfterTime());
        }
    }

    private void OnBecameInvisible()
    {
        //
    }

    void Jump()
    {
        if (!idle)
        {
            Debug.Log("Jumped");

            GetComponent<AudioSource>().Play();

            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    public IEnumerator JumpAfterTime()
    {
        yield return new WaitForSeconds(0.0f);
        Jump();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GetChild(4).gameObject.SetActive(false);

    }
}
