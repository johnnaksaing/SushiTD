using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerScript : MonoBehaviour
{

    protected GameObject m_Target;

    protected float m_AttackSpeed;
    public Transform m_TargetEnemy;
    protected abstract void Attack();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack",0.5f, m_AttackSpeed);
        m_TargetEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_TargetEnemy); 
    }
}
