using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  AFA 3 Jan 2022
//  Will report:
//  - Volume
//  - Buoyancy Force
//  Assumes the object is convex
public class GetObjectSummary : MonoBehaviour
{
    private GameObject meshObj;
    public float volume;
    public float buoyancy;


    void Start()
    {
        //The mesh is attached to this gameobject
        if (meshObj == null)
        {
            meshObj = gameObject;
        }


    }



    void Update()
    {
        CalculateVolume();
        CalculateBuoyancy();
    }



    void CalculateVolume()
    {
        //Doesnt take into account the scale
        Mesh mesh = meshObj.GetComponent<MeshFilter>().mesh;

        volume = mesh.bounds.size.x * mesh.bounds.size.y * mesh.bounds.size.z;

        //print(volume);
        
        //Renderer renderer = meshObj.GetComponent<Renderer>();

        //float volume = renderer.bounds.size.x * renderer.bounds.size.y * renderer.bounds.size.z;

        //print(volume);

        //float rhoWater = 1027f;

        //float densityIce = rhoWater * 0.70f;

        //float mass = densityIce * volume;

        //Always gameobject and not meshobject
        //gameObject.GetComponent<Rigidbody>().mass = mass;

        //print(volume);

        //Calculate the volume
        //int[] triangles = meshObj.GetComponent<MeshFilter>().mesh.triangles;

        //Vector3[] vertices = meshObj.GetComponent<MeshFilter>().mesh.vertices;

        //Vector3 centerOfMass = meshObj.GetComponent<Rigidbody>().centerOfMass;

        //float volume = 0f;

        //int i = 0;
        //while (i < triangles.Length)
        //{
        //    Vector3 p1 = vertices[triangles[i]];

        //    i++;

        //    Vector3 p2 = vertices[triangles[i]];

        //    i++;

        //    Vector3 p3 = vertices[triangles[i]];

        //    i++;

        //    //Area of the triangle
        //    float a = Vector3.Distance(p1, p2);

        //    float c = Vector3.Distance(p3, p1);

        //    float area = (a * c * Mathf.Sin(Vector3.Angle(p2 - p1, p3 - p1) * Mathf.Deg2Rad)) / 2f;
        //}
    }
    void CalculateBuoyancy()
    {
        float rho = 1027f; // Water density
        float g = 9.81f;

        buoyancy = rho * g * volume;

       // print(buoyancy);

        //Renderer renderer = meshObj.GetComponent<Renderer>();

        //float volume = renderer.bounds.size.x * renderer.bounds.size.y * renderer.bounds.size.z;

        //print(volume);

        //float rhoWater = 1027f;

        //float densityIce = rhoWater * 0.70f;

        //float mass = densityIce * volume;

        //Always gameobject and not meshobject
        //gameObject.GetComponent<Rigidbody>().mass = mass;

        //print(volume);

        //Calculate the volume
        //int[] triangles = meshObj.GetComponent<MeshFilter>().mesh.triangles;

        //Vector3[] vertices = meshObj.GetComponent<MeshFilter>().mesh.vertices;

        //Vector3 centerOfMass = meshObj.GetComponent<Rigidbody>().centerOfMass;

        //float volume = 0f;

        //int i = 0;
        //while (i < triangles.Length)
        //{
        //    Vector3 p1 = vertices[triangles[i]];

        //    i++;

        //    Vector3 p2 = vertices[triangles[i]];

        //    i++;

        //    Vector3 p3 = vertices[triangles[i]];

        //    i++;

        //    //Area of the triangle
        //    float a = Vector3.Distance(p1, p2);

        //    float c = Vector3.Distance(p3, p1);

        //    float area = (a * c * Mathf.Sin(Vector3.Angle(p2 - p1, p3 - p1) * Mathf.Deg2Rad)) / 2f;
        //}
    }
}
