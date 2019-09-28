using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TmPro;

//Class
///<summary> 
///     This class controls the HP Stat of the Character
///         
///     Explanation:

/// 		
///     Usage:

/// 		
///     Integration:

/// 
/// </summary>

public class MechCharStatHP : MonoBehaviour
{
    
    public float maxHP = 5f; 
    public float currentHP = 5f; 
    public Slider HPSlider;

    //    public TextMeshPro HPText; // need TmPro installed otherwise use Unity's built in Text
    public Text StatHPText;

    //Invulnerable means unable to receive damage
	private bool bIsInvulnerable;
    private Animator anim;

    public List<GameObject> objsToDisableOnDeath;
    public List<GameObject> objsToEnableOnDeath;

    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = maxHP;
        StatHPText.text = currentHP.ToString();
        HPSlider.value = currentHP/maxHP;

    }

	public bool Invulnerable{
		get {return bIsInvulnerable;}
		set {bIsInvulnerable= value;}
	}
    
    public void Heal(float HealValue){
        if(currentHP>0){
            currentHP+= HealValue;
        }
        if(currentHP>maxHP){
            currentHP = maxHP;
        }
        HPSlider.value = currentHP/maxHP;
        StatHPText.text = currentHP.ToString();
    }

    public void ApplyDamage(float DamageValue){
        if(currentHP>0 && !Invulnerable){
            currentHP-= DamageValue;
            if (gameObject.activeInHierarchy) {
                StartCoroutine (BlinkingSprite());
            }
        } 
        if(currentHP<=0){
//            anim.SetTrigger("death");

            OnDeath();

            currentHP = 0;
        }
        
        HPSlider.value = currentHP/maxHP;
        StatHPText.text = currentHP.ToString();
    }
    
    public void OnDeath()
    {
        // death code for char
        // disable all components in char
        MonoBehaviour[] components = GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour comp in components)
        {
            comp.enabled = false;
        }

        foreach (GameObject obj in objsToDisableOnDeath)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objsToEnableOnDeath)
        {
            obj.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) { //Collision Damage
        if(other.collider.tag == "Obstacle"){
            ApplyDamage(1);
        }

    }
	IEnumerator BlinkingSprite() {
		bIsInvulnerable = true;
		for(int i =0; i<5; i++){
			yield return new WaitForSeconds (0.1f);
            //disable sprite
			yield return new WaitForSeconds (0.1f);
            // enable sprite
		}
		bIsInvulnerable = false;
	}


}
