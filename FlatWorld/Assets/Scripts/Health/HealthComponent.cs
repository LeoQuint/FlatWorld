//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour {

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
    public Action<float> OnHealthChanged;
    public Action OnHealthDepleted;
    ////////////////////////////////
    ///			Protected		 ///
    ////////////////////////////////

    ////////////////////////////////
    ///			Private			 ///
    ////////////////////////////////
    private float m_CurrentHealth;
    private float m_BaseHealth;

    public float BaseHealth
    {
        get { return m_BaseHealth; }
        set { m_BaseHealth = value; }
    }
    #region Unity API
    #endregion

    #region Public API
    public void ModifyHealth(float amount)
    {
        m_CurrentHealth += amount;
        if (m_CurrentHealth <= 0f)
        {
            m_CurrentHealth = 0f;
            if (OnHealthDepleted != null)
            {
                OnHealthDepleted();
            }
        }
        else
        {
            if (OnHealthChanged != null)
            {
                OnHealthChanged(amount);
            }           
        }
    }

    public void ResetHealth()
    {
        m_CurrentHealth = m_BaseHealth;
    }
    #endregion

    #region Protect
    #endregion

    #region Private
    #endregion
}
