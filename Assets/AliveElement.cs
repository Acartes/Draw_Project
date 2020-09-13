using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveElement : MonoBehaviour {

  public float resilience;
  public float minimumDamage;


  // Update is called once per frame
  void Update () {
    if (resilience <= 0)
      Destroy(gameObject);
	}
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.relativeVelocity.magnitude >= minimumDamage)
    resilience -= collision.relativeVelocity.magnitude;
  }
}
