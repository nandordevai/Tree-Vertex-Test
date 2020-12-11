using UnityEngine;

public class TreeBuilder : MonoBehaviour
{
    Mesh mesh;
    MeshFilter mf;
    int subDivisions = 5;
    Vector3[] vertices;
    void Start()
    {
        mesh = new Mesh();
        mf = GetComponent<MeshFilter>();
        mf.mesh = mesh;
        vertices = new Vector3[subDivisions * 2];
        GetVertices();
        int[] triangles = {
            // sides
            1, 0, 6,
            0, 5, 6,
            2, 1, 7,
            1, 6, 7,
            3, 2, 8,
            2, 7, 8,
            4, 3, 9,
            3, 8, 9,
            0, 4, 5,
            4, 9, 5,
            // top
            6, 5, 9,
            6, 9, 8,
            6, 8, 7,
            // bottom
            1, 4, 0,
            1, 3, 4,
            1, 2, 3
        };
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void GetVertices()
    {
        float theta;
        for (var i = 0; i < 2; i++)
        {
            for (var j = 0; j < subDivisions; j++)
            {
                theta = 2 * Mathf.PI / subDivisions;
                vertices[j + i * subDivisions] = new Vector3(
                    Mathf.Cos(theta * j),
                    4 * i,
                    Mathf.Sin(theta * j)
                );
            }
        }
    }

    void Update()
    {

    }
}
