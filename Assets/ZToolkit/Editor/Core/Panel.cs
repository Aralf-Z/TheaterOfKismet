/*

*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ZToolKit.Editor
{
    public class PanelWindow : EditorWindow
    {
        private PanelBase[] mPanels;
        private Vector2 mScrollBtn;

        [MenuItem("ZToolKit/ToolPanel #P", false, 1)]
        private static void OpenSelf()
        {
            var w = GetWindow<PanelWindow>("ConfigPanel");
            w.maxSize = new(360, 540);
            w.minSize = w.maxSize;
        }

        private void OnEnable()
        {
            var panels = new List<PanelBase>();
            var ts = typeof(PanelBase).Assembly
                .GetTypes()
                .Where(t => typeof(PanelBase).IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var t in ts)
            {
                if (Activator.CreateInstance(t) is not PanelBase panel) continue;
                panel.Init();
                panels.Add(panel);
            }

            mPanels = new PanelBase[panels.Count];
            mPanels = panels.OrderBy(p => p.Priority).ToArray();
        }

        private void OnGUI()
        {
            mScrollBtn = GUILayout.BeginScrollView(mScrollBtn, GUILayout.Width(position.width), GUILayout.Height(position.height));
            
            var titleFont = new GUIStyle {fontSize = 15, normal = new GUIStyleState{textColor = Color.cyan}};
            
            foreach (var p in mPanels)
            {
                using (new GUILayout.VerticalScope("HelpBox"))
                {
                    GUILayout.Label(p.PanelName, titleFont);
                    p.DrawPanel();
                }
            }
            
            GUILayout.EndScrollView();
        }
    }
}