//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverInfoPanel : MonoBehaviour {

    //struct
    public struct HoverPanelData
    {
        public PanelLayout layout;
        public string title;
        public string description;
    }

    public enum PanelLayout
    {
        Tile,
        Character,
        System,
        Ship
    }

    ////////////////////////////////
    ///			Constants		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Statics			 ///
    ////////////////////////////////
    public static HoverInfoPanel instance;
    ////////////////////////////////
    ///	  Serialized In Editor	 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Public			 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////
    [SerializeField] protected Text m_Title;
    [SerializeField] protected Text m_Description;
    [SerializeField] protected GameObject m_Holder;
    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////

    #region Unity API
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Public API
    public void OnHover(HoverPanelData data)
    {
        m_Holder.SetActive(true);
        m_Title.text = data.title;
        m_Description.text = data.description;
    }

    public void OnHoverExit()
    {
        m_Holder.SetActive(false);
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}
