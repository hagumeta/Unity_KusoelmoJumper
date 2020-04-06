/// CopyLight
//  SingletonMonoBehaviour(by yuminekoStudio)
//  https://snippets.cacher.io/snippet/17ecfbc532c43cb2c0a7

using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private bool dontDestroyOnLoad = false;
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Type t = typeof(T);

                instance = (T)FindObjectOfType(t);
                if (instance == null)
                {
                    Debug.LogError(t + " をアタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    virtual protected void Awake()
    {
        // 他のGameObjectにアタッチされているか調べる.
        // アタッチされている場合は破棄する.
        if (this != Instance)
        {
            Destroy(this);
            //Destroy(this.gameObject);
            Debug.LogError(
                typeof(T) +
                " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
                " アタッチされているGameObjectは " + Instance.gameObject.name + " です.");
            return;
        }

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}