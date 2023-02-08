using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertexColorTest
{
    public class PlaneGenerator : MonoBehaviour
    {
        void Start()
        {
            Plane();
        }

        private void Plane()
        {

            List<Vector3> vertices = new List<Vector3>()
            {
                new Vector3(-1f, 0, 1f),
                new Vector3(1f,  0, 1f),
                new Vector3(1f, 0, -1f),
                new Vector3(-1f, 0, -1f)
            };

            List<int> triangles = new List<int>()
            {
                0, 1, 2,
                2, 3, 0
            };

            List<Color> colors = new List<Color>()
            {
                new Color(1f, 1f, 1f),
                new Color(0f, 1f, 1f),
                new Color(1f, 0f, 0f),
                new Color(0f, 0f, 0f)

            };

            Mesh mesh = new Mesh();
            mesh.Clear();
            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0);
            mesh.SetColors(colors);
            
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            MeshFilter meshFilter = GetComponent<MeshFilter>();
            meshFilter.mesh = mesh;

        }
    }
}
