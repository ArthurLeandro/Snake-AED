using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public void OnTriggerEnter2D(Collider2D other) {
		//if(other.CompareTag("Player")){
			Debug.Log(other.name);
			GameObject.Find("Head").GetComponent<Cobra>().Ate(true);
		
	}
}
