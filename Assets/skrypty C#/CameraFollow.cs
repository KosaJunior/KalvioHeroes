using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject m_Target;

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(m_Target.transform.position.x, m_Target.transform.position.y + 0.7f, transform.position.z);
	}
}
