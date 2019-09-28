using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectNote))]
public class ObjectNoteEditor : Editor
{
    ObjectNote note;

    [DrawGizmo(GizmoType.InSelectionHierarchy)]
    static void DrawSelectedNote(Transform transform, GizmoType gizmoType)
    {
        DrawObjectNote(transform, gizmoType, true);
    }
    [DrawGizmo(GizmoType.NotInSelectionHierarchy)]
    static void DrawUnselectedNote(Transform transform, GizmoType gizmoType)
    {
        DrawObjectNote(transform, gizmoType, false);
    }

    static void DrawObjectNote(Transform transform, GizmoType gizmoType, bool selected)
    {
        ObjectNote ognote = transform.GetComponent<ObjectNoteInGame>();
        ObjectNote onote = transform.GetComponent<ObjectNote>();
        if (onote != null && ognote == null && onote.enabled)
        {
            if (onote.Style == null || onote.Size.x == 0f) {
                onote.SetStyle();
            }

            if ((selected && onote.ShowWhenSelected) || (!selected && onote.ShowWhenUnselected))
            {
                Handles.BeginGUI();
                GUI.backgroundColor = onote.Color;
                Vector2 guiPosition = HandleUtility.WorldToGUIPoint(transform.position - onote.AnchorOffset);
                if(!string.IsNullOrEmpty(onote.NoteText)) GUI.Label(new Rect(guiPosition.x, guiPosition.y, onote.Size.x, onote.Size.y), onote.NoteText, onote.Style);
                guiPosition = HandleUtility.WorldToGUIPoint(transform.position);
                GUI.backgroundColor = Color.white;
                if(onote.Image != null) GUI.Label(new Rect(guiPosition.x - onote.Image.width * onote.ImageScale.x / 2 + onote.ImageOffset.x, guiPosition.y - 38f - onote.Image.height * onote.ImageScale.y / 2 + onote.ImageOffset.y, onote.Image.width * onote.ImageScale.x, onote.Image.height * onote.ImageScale.y), "", onote.ImgStyle);
                Handles.EndGUI();
            }
        }
    }

    public void OnEnable()
    {
        note = (ObjectNote)target;
        if (note != null && note.IsNew) {
            note.NoteText = target.name;
            int comps = note.gameObject.GetComponents<Component>().Length;
            for (int i = 0; i < comps; i++)
            {
                UnityEditorInternal.ComponentUtility.MoveComponentUp(note);
            }
            note.IsNew = false;
        }
    }

    public override void OnInspectorGUI()
    {
        if (note != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            EditorGUI.BeginChangeCheck();
            string text = EditorGUILayout.TextArea(note.NoteText);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note");
                note.NoteText = text;
                SceneView.RepaintAll();
            }
            EditorGUI.BeginChangeCheck();
            Texture2D img = (Texture2D)EditorGUILayout.ObjectField("Image", note.Image, typeof(Texture), false);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Image");
                note.Image = img;
                note.SetStyle();
                SceneView.RepaintAll();
            }
            GUILayout.Label("Image Scale:", GUILayout.Width(140));
            EditorGUI.BeginChangeCheck();
            Vector3 imgScale = EditorGUILayout.Vector2Field("", note.ImageScale);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Image Scale");
                note.ImageScale = imgScale;
                SceneView.RepaintAll();
            }
            GUILayout.Label("Image Offset:", GUILayout.Width(140));
            EditorGUI.BeginChangeCheck();
            Vector3 imgOffset = EditorGUILayout.Vector2Field("", note.ImageOffset);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Image Offset");
                note.ImageOffset = imgOffset;
                SceneView.RepaintAll();
            }
            GUILayout.EndVertical();
            GUILayout.BeginVertical(GUILayout.MaxWidth(50));
            GUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            bool show = EditorGUILayout.Toggle(note.ShowWhenSelected, GUILayout.Width(16));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Visibility");
                note.ShowWhenSelected = show;
                SceneView.RepaintAll();
            }
            GUILayout.Label("Show when selected", GUILayout.Width(140));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
            EditorGUI.BeginChangeCheck();
            bool showUnsel = EditorGUILayout.Toggle(note.ShowWhenUnselected, GUILayout.Width(16));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Unselected Visibility");
                note.ShowWhenUnselected = showUnsel;
                SceneView.RepaintAll();
            }
            GUILayout.Label("Show when unselected", GUILayout.Width(140));
            GUILayout.EndHorizontal();
            if(note is ObjectNoteInGame) {
                GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                EditorGUI.BeginChangeCheck();
                bool showGameEditor = EditorGUILayout.Toggle(note.ShowInGameEditor, GUILayout.Width(16));
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(note, "Changed Object Note In Game Editor Visibility");
                    note.ShowInGameEditor = showGameEditor;
                    SceneView.RepaintAll();
                    UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
                }
                GUILayout.Label("Show in game in Editor", GUILayout.Width(140));
                GUILayout.EndHorizontal();
                if(!showGameEditor) {
                    GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                    GUILayout.Label("(Shows in built game!)", GUILayout.Width(140));
                    GUILayout.EndHorizontal();
                    UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
                }
            }
            else {
                GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                EditorGUI.BeginChangeCheck();
                bool showGameEditor = EditorGUILayout.Toggle(note.ShowInGameEditor, GUILayout.Width(16));
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(note, "Changed Object Note Game View Visibility");
                    note.ShowInGameEditor = showGameEditor;
                    SceneView.RepaintAll();
                }
                GUILayout.Label("Show in Game View", GUILayout.Width(140));
                GUILayout.EndHorizontal();
                if(showGameEditor) {
                    GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                    GUILayout.Label("(Not in built game!)", GUILayout.Width(140));
                    GUILayout.EndHorizontal();
                    UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
                }
            }
            GUILayout.Label("Anchor Offset:", GUILayout.Width(140));
            EditorGUI.BeginChangeCheck();
            Vector3 offset = EditorGUILayout.Vector3Field("", note.AnchorOffset, GUILayout.Width(150));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Offset");
                note.AnchorOffset = offset;
                SceneView.RepaintAll();
            }
            GUILayout.Label("Background color:", GUILayout.Width(140));
            EditorGUI.BeginChangeCheck();
            Color col = EditorGUILayout.ColorField(note.Color, GUILayout.Width(150));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Color");
                note.Color = col;
                note.SetStyle();
                SceneView.RepaintAll();
            }
            GUILayout.Label("Font size:", GUILayout.Width(140));
            EditorGUI.BeginChangeCheck();
            int size = EditorGUILayout.IntSlider(note.FontSize, 6, 20, GUILayout.Width(150));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Font Size");
                note.FontSize = size;
                note.SetStyle();
                SceneView.RepaintAll();
            }
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
            EditorGUI.BeginChangeCheck();
            bool bold = EditorGUILayout.Toggle(note.Bold, GUILayout.Width(16));
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(note, "Changed Object Note Bold text");
                note.Bold = bold;
                note.SetStyle();
                SceneView.RepaintAll();
            }
            GUILayout.Label("Bold text", GUILayout.Width(140));
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
    }
}
