using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private float waitTime;
	[SerializeField] private GameObject obstaclePrefabs;
	private float tempTime;
	private float lastY;
	private int countObstacle;

	void Start(){
		tempTime = waitTime - Time.deltaTime;
		countObstacle = 0;
		lastY = 0;
	}

	void LateUpdate () {
		if(GameManager.Instance.GameState()){
			tempTime += Time.deltaTime;
			if(tempTime > waitTime){
				// Wait for some time, create an obstacle, then set wait time to 0 and start again
				tempTime = 0;
				
				SpawnObjectObstacle();
			}
		}
	}
	void SpawnObjectObstacle()
	{

		countObstacle += 1;
		GameObject pipeClone = Instantiate(obstaclePrefabs, transform.position, transform.rotation);
		float newY = 0;
		float addY = 0;
		if (IsHardObstacle())
		{
			//hard was diff each obstacle rd form 1.8-2.5
			addY = (Random.Range(180, 250) * 0.01f) * (Random.value > 0.5f ? 1 : -1);
			//Debug.LogError("Spawn Hard + addY: " + addY);
		}
		else
		{
			addY = (Random.Range(30, 100) * 0.01f) * (Random.value > 0.5f ? 1 : -1);
			// easy was diff 0.3-1.00
			//Debug.LogError("Spawn Easy + addY: " + addY);
		}
		newY = lastY +  addY;
		//Max 2.5, change direction when top or down the map.
		if (newY > 2.5f)
		{
			newY -= Mathf.Abs(addY) * 2;
		} 
		if (newY < -2.5f)
		{
			newY += Mathf.Abs(addY)  * 2;
		} 
		Vector3 localPosition = pipeClone.transform.localPosition;
		localPosition = new Vector3(localPosition.x,newY,localPosition.z);
		pipeClone.transform.localPosition = localPosition;
		lastY = newY;
	}

	bool IsHardObstacle()
	{
		if (countObstacle <=3)
		{
			//0 1 2 is Easy
			return false;
		}
		else
		{
			if (countObstacle >= 5) countObstacle = 0;
			return true;
		}


	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.transform.parent != null){
			Destroy(col.gameObject.transform.parent.gameObject);
		}else{
			Destroy(col.gameObject);
		}
	}

}
