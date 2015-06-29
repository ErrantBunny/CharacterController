using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {
	Color normColor; //Default material color
	// Use this for initialization
	void Start () {
		normColor = renderer.material.color; //Save the color to return to.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onHit(){
		StartCoroutine ("hitRoutine"); //Start a parallel routine to modify the color once hit.

	}
	IEnumerator hitRoutine(){
		this.renderer.material.color = new Color (255, 0, 0); //Color the object red
		yield return new WaitForSeconds(0.25f); //Wait a quarter of a second
		this.renderer.material.color = normColor; //Reset the color
	}
}
