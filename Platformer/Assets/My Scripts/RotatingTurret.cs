using UnityEngine;
using System.Collections;

public class RotatingTurret : MonoBehaviour {

	public float rotationSpeed;
	public int shotDelay;
	public GameObject sys;
	private int shotCounter;

	// Use this for initialization
	void Start () {
		shotCounter = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (new Vector3 (0.0f, rotationSpeed, 0.0f));

		shotCounter--;
		Fire ();
		if (shotCounter < 1)
		{
			Fire ();
			shotCounter = shotDelay;
		}
	}

	void Fire()
	{
		Ray ray = new Ray (transform.position, transform.forward); //Fire from the center
		RaycastHit info; // Info object
		if (Physics.Raycast (ray, out info)) {
			GameObject obj = info.collider.gameObject; //Get the colliding object
			Rigidbody ro = obj.rigidbody; //Physics component of the hit object
			if(ro != null){
				obj.rigidbody.AddForceAtPosition(ray.direction*100.0f,info.point); //Apply a force on the object                      
			}
			//Create an explosion object at the collision point, pointing at the normal rotation.
			GameObject explode = (GameObject)Instantiate(sys,info.point,Quaternion.LookRotation(info.normal));
			
			Destroy(explode,1.0f); //Delete the particle effect one second later.
			//If the object had some custom behavior when shot
			HitScript scpt = obj.GetComponent<HitScript>();
			
			if(scpt != null){
				scpt.onHit(); //Call the function
			}
		}
	}
}
