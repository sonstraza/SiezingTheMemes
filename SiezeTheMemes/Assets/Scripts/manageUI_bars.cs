using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageUI_bars : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int maxHealthBarSize;
    public GameObject healthStretch;
    public GameObject healthLeftEnd;
    public GameObject healthRightEnd;
    public int power;
    public int maxPower;
    public int maxPowerBarSize;
    public GameObject powerStretch;
    public GameObject powerLeftEnd;
    public GameObject powerRightEnd;
    public int materials;
    public int maxMaterials;
    public int maxMaterialsBarSize;
    public GameObject materialsStretch;
    public GameObject materialsLeftEnd;
    public GameObject materialsRightEnd;

    // Start is called before the first frame update
    void Start()
    {
        //healthStretch.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        int tempStretchedLength = 0;
        // check health

        // calclulate stretch number (length of image) 
        tempStretchedLength = CalcStretch(health, maxHealthBarSize, maxHealth); //(health, total bar length , max health)
        healthStretch.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, tempStretchedLength);
        // move right end into place
        healthRightEnd.transform.position = new Vector3(healthStretch.transform.position.x + tempStretchedLength,
            healthRightEnd.transform.position.y,
            healthRightEnd.transform.position.z);



        //check power

        // calclulate stretch number (length of image) 
        tempStretchedLength = CalcStretch(power, maxPowerBarSize, maxPower); //(power, total bar length , max power)
        powerStretch.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, tempStretchedLength);
        // move right end into place
        powerRightEnd.transform.position = new Vector3(powerStretch.transform.position.x + tempStretchedLength,
            powerRightEnd.transform.position.y,
            powerRightEnd.transform.position.z);

        //check materials

        // calclulate stretch number (length of image) 
        tempStretchedLength = CalcStretch(materials, maxMaterialsBarSize, maxMaterials); //(materials, total bar length , max materials)
        materialsStretch.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, tempStretchedLength);
        // move right end into place
        materialsRightEnd.transform.position = new Vector3(materialsStretch.transform.position.x + tempStretchedLength,
            materialsRightEnd.transform.position.y,
            materialsRightEnd.transform.position.z);


        //

    }

    /*
     * Calculates the required stretch on the center portion of a bar based on passed in params
     * 
     * params
     * current legnth 
     * total possible bar legnth,
     * and a capacity that the base can't exceed (value when full)
     * 
     * returns the new length of the sprite used to stretch the UI middle bar to the correct legnth
     */
    int CalcStretch(int current, int totalBarLength, int Capacity)
    {
        double ratio = ((double)current) / Capacity;
        if ((int)((ratio * totalBarLength) + .5) > totalBarLength)
        {
            return totalBarLength;
        }
        return (int)((ratio * totalBarLength) + .5);
    }
}
