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

    ////////////////////////////////
    ///	  Serialized In Editor	 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Public			 ///
    ////////////////////////////////
    public int BlockSize = 10;
    public float SquareSize = 1f;
    public float UV_SIZE = 0.25f;
    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    private Mesh m_Mesh;
    private MeshRenderer m_Renderer;
    private float MaxEnd_UV;
    private float MaxStart_UV;

    #region Unity API
    #endregion

    #region Public API
    public void Instantiate()
    {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        m_Renderer = gameObject.AddComponent<MeshRenderer>();
        m_Mesh = MeshGenerator.GenerateGridMesh(BlockSize, BlockSize, SquareSize);
        mf.mesh = m_Mesh;    
    }

    public void Paint(List<Vector3> uvMap, Material mat)
    {
        m_Renderer.material = mat;
        if (m_Mesh != null)
        {
            List<Vector2> uvs = new List<Vector2>();

            for (int i = 0; i < BlockSize; ++i)
            {
                for (int j = 0; j < BlockSize; ++j)
                {
                    int uv = i * BlockSize + j;
                    uvs.Add(new Vector2(uvMap[uv].x, uvMap[uv].y));
                    uvs.Add(new Vector2(uvMap[uv].x, uvMap[uv].y + uvMap[uv].z));
                    uvs.Add(new Vector2(uvMap[uv].x + uvMap[uv].z, uvMap[uv].y + uvMap[uv].z));
                    uvs.Add(new Vector2(uvMap[uv].x + uvMap[uv].z, uvMap[uv].y));
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
