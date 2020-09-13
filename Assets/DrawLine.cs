using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
  RendData rendData;

  public Slider mana;
  public MonoBehaviour nextStep;

  int i = 0;
  bool firstObj = true;

  public void OnEnable()
  {
    rendData = GetComponent<RendData>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0) && mana.value > 0)
    {
      setUpDraw();
    }
    if (Input.GetMouseButton(0) && mana.value > 0)
    {
      draw();
    }
    if (Input.GetMouseButtonUp(0))
    {
      EndEffect();
    }

    mana.value += 0.0001f;
  }

  private void setUpDraw()
  {
    rendData.InstantiateData();
    i = 0;
    firstObj = true;
  }

  private void draw()
  {
    if (i > 1 &&
  rendData.rend.GetPosition(i - 1) == Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 100)))
    {
      return;
    }
    rendData.rend.positionCount = i + 1;
    rendData.rend.SetPosition(i, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 100)));
    AddColliderToLine(rendData.rend, rendData.rend.GetPosition(i - 1), rendData.rend.GetPosition(i));
    i++;
    mana.value -= 0.01f;
  }

  private void AddColliderToLine(LineRenderer line, Vector3 startPoint, Vector3 endPoint)
  {
    if (firstObj)
    {
      firstObj = false;
      return;
    }
    //create the collider for the line
    BoxCollider2D lineCollider = new GameObject("LineCollider").AddComponent<BoxCollider2D>();
    //set the collider as a child of your line
    lineCollider.transform.parent = line.transform;
    // get width of collider from line 
    float lineWidth = line.endWidth;
    // get the length of the line using the Distance method
    float lineLength = Vector2.Distance(startPoint, endPoint);
    // size of collider is set where X is length of line, Y is width of line
    //z will be how far the collider reaches to the sky
    lineCollider.size = new Vector3(lineLength, lineWidth, 1f);
    // get the midPoint
    Vector3 midPoint = (startPoint + endPoint) / 2;
    // move the created collider to the midPoint
    lineCollider.transform.position = midPoint;

    var dir = endPoint - lineCollider.transform.position;
    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    angle -= lineCollider.transform.position.z - 90;
    lineCollider.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

  }

  void EndEffect()
  {
    rendData.rb2D.mass = rendData.instantiatiedPrefab.transform.childCount;
    nextStep.enabled = true;
    enabled = false;
  }
}
