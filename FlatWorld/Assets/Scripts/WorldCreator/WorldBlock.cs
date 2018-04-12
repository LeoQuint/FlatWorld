//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBlock : MonoBehaviour {

    ////////////////////////////////
    ///			Constants		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Statics			 ///
    ////////////////////////////////
    public static int BlockSize = 10;
    public static float SquareSize = 1f;
    private const float UV_SIZE = 0.25f;
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
    private Mesh m_Mesh;

    #region Unity API
    #endregion

    #region Public API
    public void Instantiate()
    {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();       
        mf.mesh = MeshGenerator.GenerateGridMesh(BlockSize, BlockSize, SquareSize);       
    }

    public void Paint(List<Vector3> uvMap)
    {
        if (m_Mesh != null)
        {
            List<Vector2> uvs = new List<Vector2>();

            for (int i = 0; i < BlockSize; ++i)
            {
                for (int j = 0; j < BlockSize; ++j)
                {
                    float row = Mathf.Round(Random.Range(0f, 3f)) / 4f;
                    float col = Mathf.Round(Random.Range(0f, 3f)) / 4f;
                    uvs.Add(new Vector2(row, col));
                    uvs.Add(new Vector2(row, col + UV_SIZE));
                    uvs.Add(new Vector2(row + UV_SIZE, col + UV_SIZE));
                    uvs.Add(new Vector2(row + UV_SIZE, col));
                }
            }

            m_Mesh.uv = uvs.ToArray();
        }       
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}
