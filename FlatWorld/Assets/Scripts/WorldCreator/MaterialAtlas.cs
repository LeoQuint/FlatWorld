//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AtlasMap", menuName = "ScriptableObject/AtlasMap", order = 1)]
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
    public int _Size;//Atlases need to be square. 4X4, 3X3, etc
    public string[]  _Types;
    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    #region Public API
    //Returns the uvs of the specific type of texture + the size (z)
    public Vector3 GetUVs(string type)
    {
        for (int i = 0; i < _Size; ++i)
        {
            for (int j = 0; j < _Size; ++j)
            {
                if (type == _Types[(i * _Size) + j])
                {
                    float uvSize = 1f / (float)_Size;
                    return new Vector3((float)i, (float)j, uvSize);
                }
            }
        }
        Debug.LogError("Type not found. " + type);
        return Vector3.zero;
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}