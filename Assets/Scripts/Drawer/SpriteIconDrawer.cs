using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace Game
{
    public class SpriteIconDrawer : OdinValueDrawer<Sprite>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            Rect rect = EditorGUILayout.GetControlRect();

            if (ValueEntry.SmartValue != null)
            {
                rect.width = rect.height;
                GUI.DrawTexture(rect, ValueEntry.SmartValue.texture);
                rect.x += rect.width;
                rect.width = EditorGUIUtility.labelWidth - rect.width;
            }

            GUI.Label(rect, label);

            CallNextDrawer(label);
        }
    }
}
