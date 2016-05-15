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

    private const float thetaScale = 0.005f;
    private int size;
    private LineRenderer lineRenderer;
    private float theta = 0f;

	void Start () {
        transform.parent = parentStar.transform;
        transform.localPosition = new Vector3(orbitDistance, 0f, 0f);
        
        lineRenderer = GetComponent<LineRenderer>();
	}

    void Update()
    {
        theta = 0f;
        size = (int)((1f / thetaScale) + 1f);
        lineRenderer.SetVertexCount(size);
        for (int i = 0; i < size; i++)
        {
            theta += (2f * Mathf.PI * thetaScale);
            float x = orbitDistance * Mathf.Cos(theta);
            float z = orbitDistance * Mathf.Sin(theta);
            lineRenderer.SetPosition(i, new Vector3(x, 0, z));
        }
    }
	
	void FixedUpdate () {
        float orbitRotation = (float)orbitDirection * orbitSpeed * Time.deltaTime;
        float planetSpin = (float)spinDirection * spinSpeed * Time.deltaTime;

        transform.RotateAround(parentStar.transform.localPosition, Vector3.up, orbitRotation);
        transform.Rotate(0f, planetSpin, 0f);
	}
}
