//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MouseInput = InputController.MouseInput;

public class PlayerController : MonoBehaviour {

    ////////////////////////////////
    ///			Constants		 ///
    ////////////////////////////////
    private const float POSITION_THRESHOLD = 0.1f;
	////////////////////////////////
    ///			Statics			 ///
    ////////////////////////////////
    public static PlayerController instance;
    ////////////////////////////////
    ///	  Serialized In Editor	 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Public			 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////
    [SerializeField]
    protected Transform m_Visuals;
    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    private MouseInput m_Input;

    private float m_CharacterMovementSpeed = 10f;
    private float m_ShipRotationSpeed = 1f;

    private Vector3 m_TargetPosition = Vector3.zero;
    private Vector3 m_Direction = Vector3.zero;

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

    private void Start()
    {
        Init();
    }

    private void OnDrawGizmos()
    {
       
    }
    #endregion

    #region Public API
    protected void Update()
    {
        Move();
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    private void Init()
    {
        RegisterMouseEvents();
    }

    private void Move()
    {
        m_Direction = m_TargetPosition - transform.position;
        m_Direction = new Vector3(m_Direction.x, m_Direction.y, 0f);
        if (m_Direction.magnitude < POSITION_THRESHOLD)
        {
            m_TargetPosition = transform.position;
        }
        else
        {
            m_Direction.Normalize();
            transform.Translate(m_Direction * m_CharacterMovementSpeed * Time.deltaTime);
            m_Visuals.transform.right = m_Direction;
        }       
    }

    private void RegisterMouseEvents()
    {
        InputController.instance.OnMouseLeftDown += OnLeftClick;
        InputController.instance.OnMouseRightDown += OnRightClick;
        InputController.instance.OnMouseMiddleDown += OnMiddleClick;
    }

    private void OnLeftClick(MouseInput input)
    {

    }

    private void OnRightClick(MouseInput input)
    {
        m_TargetPosition = Camera.main.ScreenToWorldPoint( input.Position );
    }

    private void OnMiddleClick(MouseInput input)
    {

    }
    #endregion
}
