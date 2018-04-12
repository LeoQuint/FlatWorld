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
    #endregion

    #region Protect
    #endregion

    #region Private
    private void LoadMapSection()
    {
        WorldBlock block = CreateWorldBlock();
        //block.Paint();
    }

    private WorldBlock CreateWorldBlock()
    {
        GameObject g = new GameObject("Block");
        return g.AddComponent<WorldBlock>();       
    }
    #endregion
}
