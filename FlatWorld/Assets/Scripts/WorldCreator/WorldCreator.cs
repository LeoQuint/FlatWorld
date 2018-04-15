//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

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
    public MaterialAtlas _Atlas;
    public Texture2D _WorldMap;
    public int _TextureWidth;
    public int _TextureHeight;
    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////
     
    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////

    #region Unity API
    private void Awake()
    {
        LoadMapSection();
    }
    #endregion

    #region Public API
    public void Update()
    {
        
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    private void LoadMapSection()
    {
        Color c;

        List<Vector3> uvs = new List<Vector3>();
        for (int i = 0; i < _TextureHeight; ++i)
        {
            for (int j = 0; j < _TextureWidth; ++j)
            {
                c = _WorldMap.GetPixel(i, j);
                if (c.b != 1f)
                {
                    uvs.Add(_Atlas.GetUVs("Grass"));
                }
                else
                {
                    uvs.Add(_Atlas.GetUVs("WhiteSand"));
                }
            }
        }
        WorldBlock block = CreateWorldBlock();
        block.BlockSize = _TextureWidth;
        block.Instantiate();
        block.Paint(uvs, _Atlas._Material);
    }

    private WorldBlock CreateWorldBlock()
    {
        GameObject g = new GameObject("Block");
        return g.AddComponent<WorldBlock>();       
    }
    #endregion
}
