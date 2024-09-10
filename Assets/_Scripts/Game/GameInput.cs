using QFramework;
using UnityEngine;

namespace Game.Core
{   
    public static class GameInput_2D
    {
        /// <summary>
        /// 获得单点触控到屏幕时对应相机的世界位置，仅鼠标左键按下或者触屏第一下
        /// </summary>
        /// <returns></returns>
        public static bool TryGetOnWorldPos(Camera camera, out Vector2 pos)
        {
            pos = default;
            
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))//鼠标按下时
            {
                pos = camera.ScreenToWorldPoint(Input.mousePosition);
                return true;
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase is TouchPhase.Began or TouchPhase.Moved)//触摸屏按下或者按住时
            {
                pos = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 某物理层级是否覆盖某个坐标
        /// </summary>
        /// <returns></returns>
        public static bool IsOnLayer(Vector3 pos, LayerMask layerMask)
        {
            var hit = Physics2D.Raycast(pos, Vector2.zero, 2f, layerMask);

            return hit.collider != null;
        }
    }
} 