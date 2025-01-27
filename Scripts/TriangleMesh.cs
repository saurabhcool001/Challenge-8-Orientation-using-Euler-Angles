using UnityEngine;

public class TriangleMesh : MonoBehaviour
{
    void Start()
    {
        // Create a triangle mesh
        Mesh mesh = new Mesh();

        // Define vertices
        mesh.vertices = new Vector3[]
        {
            new Vector3(0, 1, 0),   // Top vertex
            new Vector3(-1, -1, 0), // Bottom-left vertex
            new Vector3(1, -1, 0)   // Bottom-right vertex
        };

        // Define the triangle by connecting vertices
        mesh.triangles = new int[]
        {
            0, 1, 2 // Triangle indices
        };

        // Assign the mesh to the MeshFilter component
        GetComponent<MeshFilter>().mesh = mesh;
    }
}