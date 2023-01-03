using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  AFA 3 Jan 2022
//  Will report:
//  - Volume
//  - Buoyancy Force
//  - Wetted Surface Area
//  Assumes the object is convex
public class GetUnderwaterSummary : MonoBehaviour
{
    private GameObject meshObj;
    public float volume; // Debug
    public float buoyancy; // Debug
    public float WSA; // Debug


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
        CalculateWSA();
    }



    void CalculateVolume()
    {
        //Doesnt take into account the scale
        Mesh mesh = meshObj.GetComponent<MeshFilter>().mesh;
        volume = mesh.bounds.size.x * mesh.bounds.size.y * mesh.bounds.size.z;
    }
    void CalculateBuoyancy()
    {
        float rho = 1027f; // Water density
        float g = 9.81f;
        buoyancy = rho * g * volume;
    }
    void CalculateWSA()
    {
        //Calculate the volume
        int[] triangles = meshObj.GetComponent<MeshFilter>().mesh.triangles;
        Vector3[] vertices = meshObj.GetComponent<MeshFilter>().mesh.vertices;

        int i = 0;
        if (i == 0)
        {
            WSA = 0f; // reset Wetted Surface Area calculation each time new calculation of triangle starts
        }

        while (i < triangles.Length)
        {
            Vector3 p1 = vertices[triangles[i]];

            i++;

            Vector3 p2 = vertices[triangles[i]];

            i++;

            Vector3 p3 = vertices[triangles[i]];

            i++;

            //Area of the triangle
            float a = Vector3.Distance(p1, p2);

            float c = Vector3.Distance(p3, p1);

            float area = (a * c * Mathf.Sin(Vector3.Angle(p2 - p1, p3 - p1) * Mathf.Deg2Rad)) / 2f;
            WSA += area;
        }
    }
}
