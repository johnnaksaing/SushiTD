using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBehavior : MonoBehaviour
{
    //public GameObjectPool<DestoryBehavior> m_Pool;//{ set; private get; }

    public ComboAttackManager shef { set; private get; }
    public ComboAttackManager.E_Skill m_Skill = ComboAttackManager.E_Skill.MAX;
    // Start is called before the first frame update

    public void Reuse()
    {
        time = 0.5f;
        bDead = false;
    }
    float time = 0.5f;
    bool bDead = false;
    void Start()
    {

        //Invoke("Die",0.5f);
    }
    private void Update()
    {
        if (bDead) return;
        time -= Time.deltaTime;
        Debug.Log(time);
        if (time < 0)
        {
            bDead = true;
            Die();
        }
    }
    void Die() 
    {
        //m_Pool.Set(this);
        //s
        switch (m_Skill) 
        {
            case ComboAttackManager.E_Skill.punch:
                shef.normalPool_0.Set(this.gameObject);
                break;
            case ComboAttackManager.E_Skill.kick:
                shef.normalPool_1.Set(this.gameObject);
                break;
            default:
                break;
        }

        this.gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
