//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreatorTest : MonoBehaviour {

    ////////////////////////////////
    ///			Constants		 ///
    ////////////////////////////////
    private const float UV_SIZE = 0.25f;
    ////////////////////////////////
    ///			Statics			 ///
    ////////////////////////////////

    ////////////////////////////////
    ///	  Serialized In Editor	 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Public			 ///
    ////////////////////////////////
    public int x;
    public int y;
    public float size;
    public Material material;
    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    private Mesh mesh;
    #region Unity API
    private void Awake()
    {
        
    }
    #endregion

    #region Public API
    [ContextMenu("Generate Grid")]
    public void GenerateGrid()
    {
        GameObject g = new GameObject("Grid");

        MeshFilter mf = g.AddComponent<MeshFilter>();
        MeshRenderer mr = g.AddComponent<MeshRenderer>();
        mr.material = material;
        mf.mesh = MeshGenerator.GenerateGridMesh(x, y, size);
        mesh = mf.sharedMesh;
    }

    [ContextMenu("Paint")]
    public void Paint()
    {
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < x; ++i)
        {
            for (int j = 0; j < y; ++j)
            {
                float row = Mathf.Round(Random.Range(0f, 3f) )/ 4f;
                float col = Mathf.Round(Random.Range(0f, 3f)) / 4f;
                uvs.Add(new Vector2(row, col));
                uvs.Add(new Vector2(row , col + UV_SIZE));
                uvs.Add(new Vector2(row + UV_SIZE, col + UV_SIZE));
                uvs.Add(new Vector2(row + UV_SIZE, col));
            }
        }

        mesh.uv = uvs.ToArray();
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}
