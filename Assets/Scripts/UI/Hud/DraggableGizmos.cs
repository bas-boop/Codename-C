using Framework;
using UnityEngine;

namespace UI.Hud
{
    public partial class Draggable
    {
        private const int CANVAS_SCALER = 135;
        private const float THICKNESS = 3f;
        
        private void OnDrawGizmos()
        {
            int hash = gameObject.GetInstanceID();
            Gizmos.color = ColorArray.GetColor(Mathf.Abs(hash));

            Vector3 center = p_rectTransform.position;
            Vector3 sizeVec = p_rectTransform.localScale * (size * CANVAS_SCALER);
            Vector3 half = sizeVec * HALF;
            Vector3 topLeft = center + new Vector3(-half.x,  half.y, 0);
            Vector3 topRight = center + new Vector3( half.x,  half.y, 0);
            Vector3 bottomRight = center + new Vector3( half.x, -half.y, 0);
            Vector3 bottomLeft = center + new Vector3(-half.x, -half.y, 0);
            Vector3 horizontalSize = new ((topRight - topLeft).magnitude, THICKNESS, 0);
            Vector3 verticalSize   = new (THICKNESS, (topLeft - bottomLeft).magnitude, 0);

            Gizmos.DrawCube((topLeft + topRight) * HALF, horizontalSize);
            Gizmos.DrawCube((bottomLeft + bottomRight) * HALF, horizontalSize);
            Gizmos.DrawCube((topLeft + bottomLeft) * HALF, verticalSize);
            Gizmos.DrawCube((topRight + bottomRight) * HALF, verticalSize);
        }

    }
}