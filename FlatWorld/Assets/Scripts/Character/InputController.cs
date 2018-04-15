//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {

    //Struct
    public struct MouseInput
    {
        public bool LeftMouseButton;
        public bool RightMouseButton;
        public bool MiddleMouseButton;
        public Vector3 PositionDelta;//Change in position between 2 frames.
        public Vector3 Position;
        public Vector2 ScrollDelta;
    }
    ////////////////////////////////
    ///			Constants		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Statics			 ///
    ////////////////////////////////
    public static InputController instance;
    ////////////////////////////////
    ///	  Serialized In Editor	 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Public			 ///
    ////////////////////////////////
    public Action<MouseInput> OnMouseLeftDown;
    public Action<MouseInput> OnMouseLeftUp;

    public Action<MouseInput> OnMouseRightDown;
    public Action<MouseInput> OnMouseRightUp;

    public Action<MouseInput> OnMouseMiddleDown;
    public Action<MouseInput> OnMouseMiddleUp;
    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    private MouseInput m_CurrentMouseInput;
    ///properties
    ///
    public MouseInput CurrentInput
    {
        get { return m_CurrentMouseInput; }
    }

    #region Unity API
    protected void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Public API
    public void Update()
    {
        UpdateMouseInput();
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    private void UpdateMouseInput()
    {
        SetCurrentMouseInput();
        RaiseMouseEvents();
    }

    private void SetCurrentMouseInput()
    {
        m_CurrentMouseInput.LeftMouseButton = Input.GetMouseButton(0);
        m_CurrentMouseInput.RightMouseButton = Input.GetMouseButton(1);
        m_CurrentMouseInput.MiddleMouseButton = Input.GetMouseButton(2);
        m_CurrentMouseInput.PositionDelta = Input.mousePosition - m_CurrentMouseInput.Position;
        m_CurrentMouseInput.Position = Input.mousePosition;
        m_CurrentMouseInput.ScrollDelta = Input.mouseScrollDelta;
    }

    private void RaiseMouseEvents()
    {
        if (Input.GetMouseButtonDown(0))//left
        {
            if (OnMouseLeftDown != null)
            {
                OnMouseLeftDown(m_CurrentMouseInput);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (OnMouseLeftUp != null)
            {
                OnMouseLeftUp(m_CurrentMouseInput);
            }
        }
        if (Input.GetMouseButtonDown(1))//right
        {
            if (OnMouseRightDown != null)
            {
                OnMouseRightDown(m_CurrentMouseInput);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (OnMouseRightUp != null)
            {
                OnMouseRightUp(m_CurrentMouseInput);
            }
        }
        if (Input.GetMouseButtonDown(2))//middle
        {
            if (OnMouseMiddleDown != null)
            {
                OnMouseMiddleDown(m_CurrentMouseInput);
            }
        }
        if (Input.GetMouseButtonUp(2))
        {
            if (OnMouseMiddleUp != null)
            {
                OnMouseMiddleUp(m_CurrentMouseInput);
            }
        }
    }
    #endregion
}
