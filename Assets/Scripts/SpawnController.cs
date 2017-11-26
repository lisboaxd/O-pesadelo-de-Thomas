using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject barreiraPrefab;
	public GameObject MonstroPrefab;
	public float rateSpawn;
	public float currentTime;
	private float alet;
	private bool objeto = false;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= rateSpawn) {
			currentTime = 0;
           	
			if (objeto == false) {
				GameObject tempPrefab = Instantiate (barreiraPrefab) as GameObject;
				tempPrefab.transform.position = new Vector3 (transform.position.x, tempPrefab.transform.position.y, tempPrefab.transform.position.z);
				//objeto = true;

			} else {
				GameObject tempPrefab = Instantiate (MonstroPrefab) as GameObject;
				tempPrefab.transform.position = new Vector3 (transform.position.x, tempPrefab.transform.position.y, tempPrefab.transform.position.z);
				//objeto = false;
			}

		}
		alet = Random.Range (1, 3);
		if (alet == 1) {
			objeto = true;
		} else {
			objeto = false;
		}
		return;
}
}
