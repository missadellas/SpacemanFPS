using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanController : MonoBehaviour {
	public static Transform target;
	public float speed=2f;
	public float health = 50f;

	void Start(){
		//set target to player
		target = GameObject.FindWithTag ("Player").transform;

	}
	void Update () {
		float step = speed * Time.deltaTime;
		transform.LookAt (target);
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}

	public void TakeDamage(float damage){
		health -= damage;
		if (health <= 0) {

			Die ();
		}
	}
	void Die(){

		Destroy (gameObject);
	}
	//if spaceman catches you, gameover!!
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Player") {

			Destroy (gameObject);
			EnemySpawner.GameOver ();

		}
	}

}
