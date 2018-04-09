//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AtlasMap", menuName = "Materials/AtlasMap", order = 1)]
public class MaterialAtlas : ScriptableObject {

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
    public string _AtlasName;
    public Material _Material;
    public List<List<MaterialAtlasType>> _Map;
	////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

	////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////

    #region Unity API
    #endregion

    #region Public API
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}

public enum MaterialAtlasType
{
    Dirt1,
    Dirt2,
    Dirt3,
    Dirt4,
    Dirt5,
    Dirt6,
    Dirt7,
    Dirt8,
    Dirt9,
    Dirt10,
    Dirt11,
    Dirt12,
    Dirt13,
    Dirt14,
    Dirt15,
    Ground16,
    Water
}