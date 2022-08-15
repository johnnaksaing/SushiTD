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
        Invoke("Die", 0.5f);
    }
    void Start()
    {
        Reuse();
    }

    void Die() 
    {
        switch (m_Skill) 
        {
            case ComboAttackManager.E_Skill.punch:
                shef.normalPool_0.Set(this);
                break;
            case ComboAttackManager.E_Skill.kick:
                shef.normalPool_1.Set(this);
                break;
            default:
                break;
        }

        this.gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
