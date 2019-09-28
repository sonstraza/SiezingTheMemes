
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class CnvAltSaveSettings : MonoBehaviour
{


    // Logic
    /// public lLogic

    // Non Viewable

    //EditorViewable
    /// public var vObj

    //Static
    public static CnvAltSaveSettings instance;

    //EditorSetRef
    /// public var rObj

    // Components in this obj
    ///public var myComp;

    // CustComponents in this obj
    ///public var myCustComp;

    // Components in Child
    ///public var _child_Comp

    // CustComponents in Child
    ///public var _child_CustComp

    // Components in External
    ///public var _ex_Comp

    // CustComponents in External
    ///public var _ex_CustComp

    // Components in External Child
    ///public var _ex_child_Comp

    // CustComponents in External Child
    ///public var _ex_child_CustComp

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    
        // if no key saved, then set default
        if (!PlayerPrefs.HasKey("save_setting_gamedifficulty_int"))
        {
            // default
            PlayerPrefs.SetInt("save_setting_gamedifficulty_int", 1);
        }



    }
    // alt
    // Save all prefs // implement code for each save prefs variable one by one for now. We will use serialization in the future
    void SavePrefs()
    {
        // e.g text = Prefs.getString
    }

    // alt
    // Load all prefs
    // Save all prefs // implement code for each save prefs variable one by one for now. We will use serialization in the future
    void LoadPrefsToObj() {
        // e.g text = Prefs.getString
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

}



