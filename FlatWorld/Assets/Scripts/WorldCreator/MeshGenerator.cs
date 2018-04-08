//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    ////////////////////////////////
    ///			Constants		 ///
    ////////////////////////////////
    private static readonly Vector3 BOTTOM_LEFT     = new Vector3(-1f,-1f,0f);
    private static readonly Vector3 TOP_LEFT        = new Vector3(-1f, 1f, 0f);
    private static readonly Vector3 TOP_RIGHT       = new Vector3(1f, 1f, 0f);
    private static readonly Vector3 BOTTOM_RIGHT    = new Vector3(1f, -1f, 0f);

    private static readonly Vector2 BOTTOM_LEFT_V2  = new Vector2(0f, 0f);
    private static readonly Vector2 TOP_LEFT_V2     = new Vector2(0f, 1f);
    private static readonly Vector2 TOP_RIGHT_V2    = new Vector2(1f, 1f);
    private static readonly Vector2 BOTTOM_RIGHT_V2 = new Vector2(1f, 0f);
    ////////////////////////////////
    ///			Statics			 ///
    ////////////////////////////////

    ////////////////////////////////
    ///	  Serialized In Editor	 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Public			 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////

    #region Unity API
    #endregion

    #region Public API
    public static Mesh GenerateGridMesh(int x, int y, float size)
    {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();
        float localPointSize = size * 0.5f;

        Vector3 position = Vector3.zero;
        int quads = 0;
        for (int i = 0; i < x; ++i)
        {
            position.x = i * size;
            for (int j = 0; j < y; ++j)
            {
                /*Quads:
                    1  2   
                    0  3
                */
                quads = ((i * y) + j)*4;
                position.y = j * size;
                vertices.Add(position + (BOTTOM_LEFT * localPointSize));
                vertices.Add(position + (TOP_LEFT * localPointSize));
                vertices.Add(position + (TOP_RIGHT * localPointSize));
                vertices.Add(position + (BOTTOM_RIGHT * localPointSize));
                triangles.Add(0 + quads);
                triangles.Add(1 + quads);
                triangles.Add(2 + quads);
                triangles.Add(2 + quads);
                triangles.Add(3 + quads);
                triangles.Add(0 + quads);
                uvs.Add(BOTTOM_LEFT_V2);
                uvs.Add(TOP_LEFT_V2);
                uvs.Add(TOP_RIGHT_V2);
                uvs.Add(BOTTOM_RIGHT_V2);
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        return mesh;
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}
