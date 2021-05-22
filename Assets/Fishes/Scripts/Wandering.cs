using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System ;

public class Wandering : MonoBehaviour
{
    public float speed = 1;
	public int channge = 1;
	public float time = 1f;
	
	public float height = 5f;
	public float right = 0f;
	public float left = 20f;

	public float start = 10f;
	public float end = 10f;

	public int ok;
	// Use this for initialization;
	void Start () {
		transform.position = new Vector3 (UnityEngine.Random.Range (start, end), height, UnityEngine.Random.Range (start, end));
	}
	
	// Update is called once per frame
	void Update () {
		time += 0.01f;
		if(time %2f<=0.1f){
			ok = UnityEngine.Random.Range (1, 10);
			if(ok==1)
			channge = UnityEngine.Random.Range (1, 4);
		}
		if (channge == 1) {
			transform.position += new Vector3 (speed * Time.deltaTime,0,0);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (1f, 0, 0));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (channge == 2) {
			transform.position -= new Vector3 (speed * Time.deltaTime,0,0);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (-1f,0,0));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (channge == 3) {
			transform.position+= new Vector3 (0,0,speed * Time.deltaTime);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (0,0,1f));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (channge == 4) {
			transform.position -= new Vector3 (0,0,speed * Time.deltaTime);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (0,0,-1f));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (transform.position.x > left) {
			transform.position = new Vector3 (left, transform.position.y, transform .position .z);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
		if (transform.position.x < right) {
			transform.position = new Vector3 (right, transform.position.y, transform .position .z);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
		if (transform.position.z> left) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, left);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
		if (transform.position.z< right) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, right);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
 
	}
	void OnCollisionEnter(Collision  collision){
		channge = UnityEngine.Random.Range (1, 4);
	}
}