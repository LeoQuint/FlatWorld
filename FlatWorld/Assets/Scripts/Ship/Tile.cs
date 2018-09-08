//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hit;
using System;

public class Tile : MonoBehaviour, IHittable
{

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

    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    private HealthComponent m_HealthComponent;

    #region Unity API
    protected virtual void OnMouseOver()
    {
        HoverInfoPanel.HoverPanelData data = new HoverInfoPanel.HoverPanelData();
        data.title = "Tile";
        data.description = "Wooden Tile.";
        HoverInfoPanel.instance.OnHover(data);
    }

    protected virtual void OnMouseExit()
    {
        HoverInfoPanel.instance.OnHoverExit();
    }
    #endregion

    #region Public API
    public void OnHit(HitData data)
    {
        
    }   
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion

}
