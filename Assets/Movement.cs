using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
	Rigidbody rb;
	SpriteRenderer sr;
	Animator anim;

	public float upForce = 100;
	public float speed = 1500;
	public float runSpeed = 2500;

	public bool isGrounded = false;

	bool isLeftShift;
	float moveHorizontal;
	float moveVertical;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		sr = GetComponentInChildren<SpriteRenderer>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		isLeftShift = Input.GetKey(KeyCode.LeftShift);
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");

		// Obsługa animacji: dowolny ruch (lewo, prawo, góra, dół) aktywuje isRunning
		if (moveHorizontal != 0 || moveVertical != 0)
		{
			anim.SetBool("isRunning", true);
		}
		else
		{
			anim.SetBool("isRunning", false);
		}

		// Obsługa obrotu postaci w lewo i prawo
		if (moveHorizontal > 0)
		{
			sr.flipX = false;
		}
		else if (moveHorizontal < 0)
		{
			sr.flipX = true;
		}

		// Skakanie
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.AddForce(Vector3.up * upForce);
			isGrounded = false;
		}
	}

	private void FixedUpdate()
	{
		float currentSpeed = isLeftShift ? runSpeed : speed;
		
		// Ustawienie prędkości postaci w zależności od ruchu poziomego i pionowego
		rb.velocity = new Vector3(
			moveHorizontal * currentSpeed * Time.deltaTime,
			rb.velocity.y,
			moveVertical * currentSpeed * Time.deltaTime
		);
	}

	private void OnCollisionEnter(Collision collision)
	{
		isGrounded = true;
	}
}
