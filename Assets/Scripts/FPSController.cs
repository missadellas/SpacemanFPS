using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {
	public float speed = 10f;
	float moveFB;
	float moveLR;
	float rotationX;
	float rotationY;
	public float sensitivity = 10f;
	CharacterController player;
	public GameObject eyes;


	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	void Update () {
		//move horizontal and vertical with keyboard
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;
		Vector3 movement = new Vector3 (moveLR, 0f, moveFB);
		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);

		//rotatecamera
		rotationX = Input.GetAxis("Mouse X")*sensitivity;
		rotationY = Input.GetAxis ("Mouse Y") * sensitivity;
		transform.Rotate (0f, rotationX, 0f);

		eyes.transform.Rotate (-rotationY, 0f, 0f);
	}
}
