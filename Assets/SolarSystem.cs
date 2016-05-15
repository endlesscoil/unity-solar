using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct PlanetDefinition
{
    public string name;
    public float scale;
    public RotateDirection orbitDirection;
    public float orbitDistance;
    public float orbitSpeed;
    public RotateDirection spinDirection;
    public float spinSpeed;
    public Color materialColor;

    public PlanetDefinition(string name, float scale, RotateDirection orbitDirection, float orbitDistance, float orbitSpeed, RotateDirection spinDirection, float spinSpeed, Color materialColor)
    {
        this.name = name;
        this.scale = scale;
        this.orbitDirection = orbitDirection;
        this.orbitDistance = orbitDistance;
        this.orbitSpeed = orbitSpeed;
        this.spinDirection = spinDirection;
        this.spinSpeed = spinSpeed;
        this.materialColor = materialColor;
    }
}

public class SolarSystem : MonoBehaviour {

    public Sun sunPrefab;
    public Planet planetPrefab;
    public Material planetMaterial;

    public float basePlanetScale = 1f;
    public float orbitalPeriod = 50f;
    public float astronomicalUnit = 5f;

    private Sun sun;
    private List<Planet> planets = new List<Planet>();

    private static readonly PlanetDefinition[] planetDefinitions =
    {
        new PlanetDefinition("Mercury", 0.5f * 0.5f, RotateDirection.Clockwise, 1, 0.24f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0xf0, (float)0xff / 0xc4, (float)0xff / 0x67)),
        new PlanetDefinition("Venus", 0.5f * 0.95f, RotateDirection.Clockwise, 2, 0.62f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0x2f, (float)0xff / 0xd5, (float)0xff / 0x96)),
        new PlanetDefinition("Earth", 0.5f, RotateDirection.Clockwise, 3, 1, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0x76, (float)0xff / 0x86, (float)0xff / 0xcc)),
        new PlanetDefinition("Mars", 0.5f * 0.7f, RotateDirection.Clockwise, 4, 1.88f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0xcc, (float)0xff / 0x86, (float)0xff / 0x6a)),
        new PlanetDefinition("Jupiter", 1f, RotateDirection.Clockwise, 5, 11.86f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0x8d, (float)0xff / 0xae, (float)0xff / 0x8f)),
        new PlanetDefinition("Saturn", 0.9f, RotateDirection.Clockwise, 6, 29.46f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0xe0, (float)0xff / 0xcc, (float)0xff / 0x9f)),
        new PlanetDefinition("Uranus", 0.8f, RotateDirection.Clockwise, 7, 84.01f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0x9f, (float)0xff / 0xd6, (float)0xff / 0xe0)),
        new PlanetDefinition("Neptune", 0.7f, RotateDirection.Clockwise, 8, 164.8f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0x42, (float)0xff / 0xb6, (float)0xff / 0xf5)),
        new PlanetDefinition("Pluto", 0.5f * 0.4f, RotateDirection.Clockwise, 9, 247.7f, RotateDirection.Clockwise, 25f, new Color((float)0xff / 0xad, (float)0xff / 0xad, (float)0xff / 0xad)),
    };

    // Use this for initialization
    void Start () {
        sun = Instantiate<Sun>(sunPrefab);
        sun.transform.localScale += new Vector3(10, 10, 10);

        for (int i = 0; i < planetDefinitions.Length; i++)
        {
            var def = planetDefinitions[i];
            var p = Instantiate<Planet>(planetPrefab);

            p.parentStar = sun;
            p.orbitDirection = def.orbitDirection;
            p.orbitDistance = astronomicalUnit * def.orbitDistance;
            p.orbitSpeed = orbitalPeriod / def.orbitSpeed;
            p.spinDirection = def.spinDirection;
            p.spinSpeed = def.spinSpeed;

            var scale = basePlanetScale * def.scale;
            p.transform.localScale += new Vector3(scale, scale, scale);

            var mat = new Material(planetMaterial);
            mat.color = def.materialColor;
            p.GetComponent<MeshRenderer>().material = mat;

            planets.Add(p);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
