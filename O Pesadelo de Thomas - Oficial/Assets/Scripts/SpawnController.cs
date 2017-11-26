using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject barreiraPrefab;
	public float rateSpawn;
	public float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if(currentTime >= rateSpawn) {
			currentTime = 0;
			GameObject tempPrefab = Instantiate(barreiraPrefab) as GameObject;
			tempPrefab.transform.position = new Vector3(transform.position.x,tempPrefab.transform.position.y, tempPrefab.transform.position.z);
		}
	}
}
