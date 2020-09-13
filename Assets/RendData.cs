using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendData : MonoBehaviour {

  public GameObject prefab;
  public GameObject instantiatiedPrefab;
  public LineRenderer rend;
  public Rigidbody2D rb2D;
  public AliveElement aliveElement;

  // Use this for initialization
  public void DestroyData() {
    instantiatiedPrefab = null;
    rend = null;
    rb2D = null;
  }

  // Use this for initialization
  public void InstantiateData()
  {
    instantiatiedPrefab = (GameObject)Instantiate(prefab);
    rend = instantiatiedPrefab.GetComponent<LineRenderer>();
    rb2D = instantiatiedPrefab.GetComponent<Rigidbody2D>();
    rend.transform.position = Vector3.zero;
    aliveElement = instantiatiedPrefab.GetComponent<AliveElement>();
  }
}
