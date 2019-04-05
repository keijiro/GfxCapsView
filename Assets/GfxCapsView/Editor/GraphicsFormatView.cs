using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using System;
using System.Collections.Generic;

namespace GfxCapsView
{
    sealed class GraphicsFormatView : EditorWindow
    {
        string _text;
        Vector2 scroll;

        [MenuItem("Help/GfxCapsView/Graphics Formats")]
        static void Init()
        {
            GetWindow<GraphicsFormatView>(true, "Graphics Formats").Show();
        }

        void OnGUI()
        {
            if (_text == null) _text = GenerateText();
            var rect = new Rect(0, 0, position.width, position.height);
            EditorGUI.TextArea(rect, _text, EditorStyles.wordWrappedLabel);
        }

        string GenerateText()
        {
            var names = new List<string>();
            foreach (GraphicsFormat format in Enum.GetValues(typeof(GraphicsFormat)))
            {
                if (format == GraphicsFormat.None) continue;
                if (!SystemInfo.IsFormatSupported(format, FormatUsage.Render)) continue;
                names.Add(format.ToString());
            }

            var s = "The following graphics formats are available for rendering: ";
            s += string.Join(", ", names);

            return s;
        }
    }
}
