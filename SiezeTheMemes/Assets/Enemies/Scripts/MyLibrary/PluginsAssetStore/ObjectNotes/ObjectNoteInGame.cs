using UnityEngine;
using System.Collections;

[AddComponentMenu("Object Notes/Object Note In Game Build"), ExecuteInEditMode]
public class ObjectNoteInGame : ObjectNote
{
    void OnGUI()
    {
#if UNITY_EDITOR
        if(ShowInGameEditor) {
#endif
            Vector2 guiPosition = Camera.main.WorldToScreenPoint(transform.position - AnchorOffset);
            guiPosition.y = Screen.height - guiPosition.y;
            GUI.backgroundColor = Color;
            if(!string.IsNullOrEmpty(Text)) GUI.Label(new Rect(guiPosition.x, guiPosition.y, Size.x, Size.y), Text, Style);
            guiPosition = Camera.main.WorldToScreenPoint(transform.position);
            guiPosition.y = Screen.height - guiPosition.y;
            GUI.backgroundColor = Color.white;
            if(Image != null) GUI.Label(new Rect(guiPosition.x - Image.width * ImageScale.x / 2 + ImageOffset.x, guiPosition.y - Image.height * ImageScale.y / 2 + ImageOffset.y, Image.width * ImageScale.x, Image.height * ImageScale.y), "", ImgStyle);
#if UNITY_EDITOR
        }
#endif
    }
}
