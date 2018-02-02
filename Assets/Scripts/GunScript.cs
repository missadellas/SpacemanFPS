using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {
	public float damage = 10f;
	public float range = 100f;
	public Camera fpsCam;
	public Text scoreText;
	float score = 0f;
	public Text miss;
	public ParticleSystem muzzleflash;
	public GameObject impactEffect;
	AudioSource fireShot;

	void Start(){
		miss.enabled = false;
		miss.text = "MISS!";
		scoreText.text = "Score: " + score;
		fireShot = GetComponent<AudioSource> ();
	}
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
			
		}
	}

	void Shoot(){
			muzzleflash.Play ();
			fireShot.Play ();
			RaycastHit hit;
		//shoot from position and direction of camera and store info in the hit variable
		//returns true if it hits something and false if it doesn't 
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {

			//if we hit the spaceman increase the score
			if (hit.transform.tag == "space_man_model") {
				score += 10;
				scoreText.text = "Score: " + score;


				//instantiate hit particles
				GameObject sparks = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy (sparks, 2f);

				//cause enemy damage
				SpacemanController enemy = hit.transform.GetComponent<SpacemanController> ();
				if (enemy != null) {
					enemy.TakeDamage (damage);
				}

				//display miss message
			} else {
				miss.enabled = true;
				Invoke ("Hide", 1f);
		
			
			}
		}
	}
	//hides miss text
	void Hide(){
		miss.enabled = false;
	}



}
