using UnityEngine;
using System.Collections;

[AddComponentMenu("Object Notes/Object Note"), ExecuteInEditMode]
public class ObjectNote : MonoBehaviour
{
    public bool IsNew = true;

    [SerializeField]
    protected string Text;
    public string NoteText {
        get { return Text; }
        set {
            Text = value;
            CalcSize();
        }
    }

    public Texture2D Image;
    public GUIStyle ImgStyle;
    public Vector2 ImageScale = Vector2.one;
    public Vector2 ImageOffset = Vector2.zero;

    public bool ShowWhenSelected = true;
    public bool ShowWhenUnselected = false;
    public bool ShowInGameEditor = false;

    [SerializeField]
    protected float Offset = 0f;
    public Vector3 AnchorOffset = new Vector3(0f, 0.6f, 0f);

    public bool Open = false;
    public Color Color = Color.white;
    protected Color textColor = Color.black;
    public Color TextColor { get { return textColor; } }

    public int FontSize = 9;
    public bool Bold = false;

    public Vector2 Size;

    public GUIStyle Style = null;
    public void SetStyle()
    {
        Style = new GUIStyle("Box");
        Texture2D whiteTex = new Texture2D(1, 1);
        whiteTex.SetPixel(0, 0, Color.white);
        Style.normal.background = whiteTex;
        Style.normal.textColor = (Color.r + Color.g + Color.b < 1.5f) ? Color.white : Color.black;;
        Style.fontSize = FontSize;
        Style.fontStyle = Bold ? FontStyle.Bold : FontStyle.Normal;
        Style.fixedWidth = 0;
        Style.fixedHeight = 0;
        Style.padding = new RectOffset(6, 6, 5, 5);
        Style.wordWrap = true;
        Style.alignment = TextAnchor.UpperLeft;

        ImgStyle = new GUIStyle("Box");
        ImgStyle.normal.background = Image;
        ImgStyle.fixedWidth = 0;
        ImgStyle.fixedHeight = 0;
        ImgStyle.alignment = TextAnchor.MiddleCenter;
        ImgStyle.stretchWidth = true;
        ImgStyle.stretchHeight = true;

        CalcSize();
    }

    void Awake()
    {
        if(Offset != 0f) { // Backward compatibility
            AnchorOffset.y = Offset;
            Offset = 0f;
        }
    }

    void CalcSize()
    {
        Size = Style.CalcSize(new GUIContent(Text));
    }

#if UNITY_EDITOR
    void OnGUI()
    {
        if(ShowInGameEditor) {
            Vector2 guiPosition = Camera.main.WorldToScreenPoint(transform.position - AnchorOffset);
            guiPosition.y = Screen.height - guiPosition.y;
            GUI.backgroundColor = Color;
            if(!string.IsNullOrEmpty(Text)) GUI.Label(new Rect(guiPosition.x, guiPosition.y, Size.x, Size.y), Text, Style);
            guiPosition = Camera.main.WorldToScreenPoint(transform.position);
            guiPosition.y = Screen.height - guiPosition.y;
            GUI.backgroundColor = Color.white;
            if(Image != null) GUI.Label(new Rect(guiPosition.x - Image.width * ImageScale.x / 2 + ImageOffset.x, guiPosition.y - Image.height * ImageScale.y / 2 + ImageOffset.y, Image.width * ImageScale.x, Image.height * ImageScale.y), Image);
        }
    }
#endif
}
