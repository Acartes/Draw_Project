using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class CreateLine : MonoBehaviour {

  public bool create;
  public LineRenderer line;

  public int lineSize;
  public float lineDotDistance;


  // Use this for initialization
  void Start () {
    if (EditorApplication.isPlaying)
    {
      enabled = false;
      create = false;
    }
  }

  // Update is called once per frame
  void Update () {
    if (create)
    {
      Create();
      create = false;
    }
	}

  void Create()
  {
    for (int i = 0; i < lineSize; i++)
    {
      line.SetPosition(i, Vector3.up * lineDotDistance * i);
    }
  }
}
