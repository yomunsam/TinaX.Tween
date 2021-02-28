using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace TinaXEditor.Tween.CustomEditors
{
    public class TweenEditorUIStyles
    {
        private GUIStyle _Title;
        public GUIStyle Title
        {
            get
            {
                if(_Title == null)
                {
                    _Title = new GUIStyle(EditorStyles.boldLabel);
                    _Title.fontSize += 2;
                }
                return _Title;
            }
        }
    }
}
