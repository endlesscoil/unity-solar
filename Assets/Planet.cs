using UnityEngine;
using System.Collections;

public enum RotateDirection {
    Clockwise = 1,
    CounterClockwise = -1
}

public class Planet : MonoBehaviour {

    public Sun parentStar;
    public float orbitDistance = 1f;
    public float orbitSpeed = 15f;
    public float spinSpeed = 50f;
    public RotateDirection orbitDirection = RotateDirection.Clockwise;
    public RotateDirection spinDirection = RotateDirection.Clockwise;

	void Start () {
        transform.parent = parentStar.transform;
        transform.localPosition = new Vector3(orbitDistance, 0f, 0f);
	}
	
	void FixedUpdate () {
        float orbitRotation = (float)orbitDirection * orbitSpeed * Time.deltaTime;
        float planetSpin = (float)spinDirection * spinSpeed * Time.deltaTime;

        transform.RotateAround(parentStar.transform.localPosition, Vector3.up, orbitRotation);
        transform.Rotate(0f, planetSpin, 0f);
	}
}
