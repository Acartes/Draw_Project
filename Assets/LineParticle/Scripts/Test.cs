using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var lineparticle = GameObject.Find("LineParticle").GetComponent<LineParticle>();
		lineparticle.SetPosition(0, new Vector3(1, 2, 3));
		var posiont_1 = lineparticle.GetPosition(1);
		posiont_1.x = 0f;
		posiont_1.y = 1f;
		posiont_1.z = 0f;
		lineparticle.SetPosition(1, posiont_1);
	}
}
