﻿#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Scripts.Camera
{
    public class VerticalBlock : IDisposable
    {
        public VerticalBlock(params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(options);
        }

        public VerticalBlock(GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(style, options);
        }

        public void Dispose()
        {
            GUILayout.EndVertical();
        }
    }

    public class ScrollviewBlock : IDisposable
    {
        public ScrollviewBlock(ref Vector2 scrollPos, params GUILayoutOption[] options)
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos, options);
        }

        public void Dispose()
        {
            GUILayout.EndScrollView();
        }
    }

    public class HorizontalBlock : IDisposable
    {
        public HorizontalBlock(params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(options);
        }

        public HorizontalBlock(GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(style, options);
        }

        public void Dispose()
        {
            GUILayout.EndHorizontal();
        }
    }

    public class ColoredBlock : IDisposable
    {
        public ColoredBlock(UnityEngine.Color color)
        {
            GUI.color = color;
        }

        public void Dispose()
        {
            GUI.color = UnityEngine.Color.white;
        }
    }

    [Serializable]
    public class TabsBlock
    {
        public int curMethodIndex = -1;
        private Action currentGuiMethod;
        private Dictionary<string, Action> methods;

        public TabsBlock(Dictionary<string, Action> _methods)
        {
            methods = _methods;
            SetCurrentMethod(0);
        }

        public void Draw()
        {
            var keys = methods.Keys.ToArray();
            using (new VerticalBlock(EditorStyles.helpBox))
            {
                using (new HorizontalBlock())
                {
                    for (var i = 0; i < keys.Length; i++)
                    {
                        var btnStyle = i == 0 ? EditorStyles.miniButtonLeft :
                            i == keys.Length - 1 ? EditorStyles.miniButtonRight : EditorStyles.miniButtonMid;
                        using (new ColoredBlock(currentGuiMethod == methods[keys[i]] ? UnityEngine.Color.grey : UnityEngine.Color.white))
                        {
                            if (GUILayout.Button(keys[i], btnStyle))
                                SetCurrentMethod(i);
                        }
                    }
                }

                GUILayout.Label(keys[curMethodIndex], EditorStyles.centeredGreyMiniLabel);
                currentGuiMethod();
            }
        }

        public void SetCurrentMethod(int index)
        {
            curMethodIndex = index;
            currentGuiMethod = methods[methods.Keys.ToArray()[index]];
        }
    }
}
#endif