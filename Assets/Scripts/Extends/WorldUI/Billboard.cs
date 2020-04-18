using UnityEngine;

//参考：https://qiita.com/flankids/items/2d92d1ed66752205fcae

/// <summary>
/// 常にカメラの方を向くオブジェクト回転をカメラに固定
/// </summary>

namespace Extends.WorldUI
{
    public class Billboard : MonoBehaviour
    {
        void LateUpdate()
        {
            // 回転をカメラと同期させる
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
