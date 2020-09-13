using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocity : MonoBehaviour {

  RendData rendData;
  public Sprite arrowSprite;
  public MonoBehaviour nextStep;

  // Use this for initialization
  public void OnEnable () {
    rendData = GetComponent<RendData>();
    enabled = true;
    transform.position = rendData.rb2D.worldCenterOfMass;
    GetComponentInChildren<SpriteRenderer>().sprite = arrowSprite;
	}
	
	// Update is called once per frame
	void Update () {
      Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      diff.Normalize();

      float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    Vector2 mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 100));
    float distance = Vector2.Distance(transform.position, mousePoint);
    transform.localScale = new Vector3(1, distance / 5.2f, 1);

    if (Input.GetMouseButtonDown(0))
    {
      EndEffect();
    }
  }

  private void EndEffect()
  {
    GetComponentInChildren<SpriteRenderer>().sprite = null;
    rendData.rb2D.velocity = transform.up * transform.localScale.y * 5;
    nextStep.enabled = true;
    enabled = false;
  }
}
