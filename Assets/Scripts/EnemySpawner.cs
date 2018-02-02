using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	
	public float spawnTime = 3f;
	public GameObject spaceman;
	public Transform spawnPoint;
	static GameObject[] clones;
	public Text gameoverText;
	static bool gameEnd = false;


	void Start(){
		InvokeRepeating ("SpawnSpaceman", spawnTime, spawnTime);
		gameoverText.text = "";
	}

	void Update(){
		if (gameEnd) {
			CancelInvoke ();
			gameoverText.text = "Game Over!";
		}

	}
	//spawns additional spacemen 
	void SpawnSpaceman(){

		Instantiate (spaceman,spawnPoint.position, spawnPoint.rotation);
	}
	//ends game and destroys all clones
	public static void GameOver(){
		gameEnd = true;
		clones = GameObject.FindGameObjectsWithTag ("space_man_model");
		foreach (GameObject clone  in clones) {
			Destroy (clone);

		}
	}


}
