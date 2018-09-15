using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dew : MonoBehaviour {

    private PlayerMove player;

    public float jumpSpeed;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.GetComponent<PlayerMove>();
            player.rb.velocity = Vector3.zero;
            player.highJumping = true;
            player.rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
