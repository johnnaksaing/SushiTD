using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool<T> where T : class
{
    Queue<T> m_objPool = new Queue<T>();

    int m_count = 0;
    public delegate T Func();

    Func m_createFunc;
    public GameObjectPool(int count, Func creatorFunc)
    {
        m_count = count;
        m_createFunc = creatorFunc;
        Allocate();
    }

    void Allocate()
    {
        for (int i = 0; i < m_count; i++)
        {
            m_objPool.Enqueue(m_createFunc());
        }
    }

    public T Get()
    {
        if (m_objPool.Count > 0)
            return m_objPool.Dequeue();
        else
            return m_createFunc();
    }

    public void Set(T obj)
    {
        m_objPool.Enqueue(obj);
    }
}
