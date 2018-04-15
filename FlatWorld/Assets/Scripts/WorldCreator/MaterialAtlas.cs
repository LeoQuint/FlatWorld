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

    //properties
    public float SizeUV
    {
        get { return 1f / (float)_Size; }
    }

    #region Public API
    //Returns the uvs of the specific type of texture + the size (z)
    public Vector3 GetUVs(string type)
    {
        float uvSize = 1f / (float)_Size;
        for (int x = 0; x < _Size; ++x)
        {
            for (int y = 0; y < _Size; ++y)
            {
                if (type == _Types[(x * _Size) + y])
                {
                    return new Vector3((float)x* uvSize, (float)y * uvSize, uvSize);
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