using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct PlanetDefinition
{
    public string name;
    public RotateDirection orbitDirection;
    public float orbitDistance;
    public float orbitSpeed;
    public RotateDirection spinDirection;
    public float spinSpeed;

    public PlanetDefinition(string name, RotateDirection orbitDirection, float orbitDistance, float orbitSpeed, RotateDirection spinDirection, float spinSpeed)
    {
        this.name = name;
        this.orbitDirection = orbitDirection;
        this.orbitDistance = orbitDistance;
        this.orbitSpeed = orbitSpeed;
        this.spinDirection = spinDirection;
        this.spinSpeed = spinSpeed;
    }
}

public class SolarSystem : MonoBehaviour {

    public Sun sunPrefab;
    public Planet planetPrefab;

    private Sun sun;
    private List<Planet> planets = new List<Planet>();

    private const float orbitalPeriod = 50f;
    private const float AU = 5f;
    private static readonly PlanetDefinition[] planetDefinitions =
    {
        new PlanetDefinition("Mercury", RotateDirection.Clockwise, AU * 1, orbitalPeriod / 0.24f, RotateDirection.Clockwise, 50f),
        new PlanetDefinition("Venus", RotateDirection.Clockwise, AU * 2, orbitalPeriod / 0.62f, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Earth", RotateDirection.Clockwise, AU * 3, orbitalPeriod, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Mars", RotateDirection.Clockwise, AU * 4, orbitalPeriod / 1.88f, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Jupiter", RotateDirection.Clockwise, AU * 5, orbitalPeriod / 11.86f, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Saturn", RotateDirection.Clockwise, AU * 6, orbitalPeriod / 29.46f, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Uranus", RotateDirection.Clockwise, AU * 7, orbitalPeriod / 84.01f, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Neptune", RotateDirection.Clockwise, AU * 8, orbitalPeriod / 164.8f, RotateDirection.Clockwise, 25f),
        new PlanetDefinition("Pluto", RotateDirection.Clockwise, AU * 9, orbitalPeriod / 247.7f, RotateDirection.Clockwise, 25f),
    };

    // Use this for initialization
    void Start () {
        sun = Instantiate<Sun>(sunPrefab);

        for (int i = 0; i < planetDefinitions.Length; i++)
        {
            var def = planetDefinitions[i];
            var p = Instantiate<Planet>(planetPrefab);

            p.parentStar = sun;
            p.orbitDirection = def.orbitDirection;
            p.orbitDistance = def.orbitDistance;
            p.orbitSpeed = def.orbitSpeed;
            p.spinDirection = def.spinDirection;
            p.spinSpeed = def.spinSpeed;

            planets.Add(p);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
