using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCreateWave : MonoBehaviour {

  Wave wave;
  Vector3 closestPos;
  Vector3[] positions;

	// Use this for initialization
	void Start () {
    wave = GetComponent<Wave>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnTriggerEnter2D(Collider2D collision)
  {
    positions = new Vector3[wave.line.positionCount];
    int posIndex = 0;
    int closestPosIndex = 0;
    wave.line.GetPositions(positions);
    closestPos = positions[0];
    foreach (Vector3 position in positions)
    {
      if(Vector3.Distance(position, collision.transform.position) < Vector3.Distance(closestPos, collision.transform.position))
      {
        closestPos = position;
        closestPosIndex = posIndex;
      }
      posIndex++;
    }
    wave.waveIndex = closestPosIndex;
    wave.sens = -collision.GetComponent<Rigidbody2D>().velocity.x;
    wave.enabled = false;
    wave.enabled = true;
  }
}
