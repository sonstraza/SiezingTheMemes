using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

///<summary> 
///     This class spawn a projectile and manages/Limits the Weapon stats of a weapon e.g Ammo, TimeBetweenBullets
///         
///     Explanation:
///         Weapon Logic
///         - User reloads magazine, ammo in pocket reduces by the number of rounds in magazine
/// 
/// 		
///     Usage:
/// 		
///     Integration:
///         - set SpawnPoint to set where the object will spawn, default is the position of this object
///
///     Implement Later:
///     - Integrate with an inventory system
/// 
/// </summary>
/// 
public class MechExtraCharSkillRangeAtkSpwnObj : MonoBehaviour
{
    [FormerlySerializedAs("timeBetweenBullets")]
    public float fireRate = 0.15f;

    public GameObject objToSpawn;
    // public Slider playerAmmoSlider;

    // Round stands for the number of bullets in each Magazine of the weapon, to implement reload capacity // each time you reload, a new Magazine will be used 
    public int maxRoundsInMagazine = 30;
    public int roundsPerShot = 1;
    public int startingRoundsInMagazine = 30;
    public int currentRemainingRoundsInMagazine;

    // Ammo stands for the total number of bullets in the inventory // sum of all rounds in Magazine
    public int maxAmmo = 90;
    public int startingAmmoInPocket = 60;
    public int currentRemainingAmmoInPocket; //initalized as startingAmmo value

    public Transform spawnPoint;

    float nextBullet;
    Animator myAnim;

    //audio info
    AudioSource gunMuzzleAS;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    public bool bAllowManualReload;
    // Start is called before the first frame update


    void Awake()
    {
        nextBullet = 0f;
        currentRemainingAmmoInPocket = Mathf.Clamp(startingAmmoInPocket,0,maxAmmo);
        currentRemainingRoundsInMagazine = startingRoundsInMagazine;

        ReloadMagazine();

        if (!spawnPoint)
        {
            spawnPoint = transform;
        }

        // playerAmmoSlider.maxValue = maxRounds;
        // playerAmmoSlider.value = remainingRounds;
        gunMuzzleAS = GetComponent<AudioSource>();
        myAnim = transform.root.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            useWeapon();
        }

        if (bAllowManualReload)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                print(gameObject.name + ": Reload Initiated" + " Reason: ManualReloadKey Pressed ");
                ReloadMagazine();
            }
        }
    }

    public void useWeapon()
    {
        if (nextBullet < Time.time && currentRemainingRoundsInMagazine > 0)
        {
            // LMB
            nextBullet = Time.time + fireRate; // increase time between bullets for weapon delay

            if (myAnim)
                myAnim.SetTrigger("gunShoot");
            for (int i = 0; i < roundsPerShot; i++)
            {
                Vector3 rot;
                if (myAnim && myAnim.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
                {
                    rot = spawnPoint.forward;
                }
                else
                {
                    rot = spawnPoint.rotation.ToEuler();
                }

                Instantiate(objToSpawn, spawnPoint.position, Quaternion.Euler(rot));
                print(this.name + "Spawned" + objToSpawn.name);
                if (shootSound)
                    playASound(shootSound);
                currentRemainingRoundsInMagazine -= 1;
                // playerAmmoSlider.value = remainingRounds;
            }
        }
        
        // auto reload when no more rounds in magazine // just like in CS and most generic FPS shooters // or simulate cooldown mode, like in Dota in Warcraft3
        if (currentRemainingRoundsInMagazine == 0)
        {
            print(gameObject.name + ": Reload Initiated" + " Reason: NoMoreRoundsInMagazine");
            ReloadMagazine();
        }
        //Clamp
        currentRemainingAmmoInPocket = Mathf.Clamp(startingAmmoInPocket,0,maxAmmo);

    }

    public void reload()
    {
        currentRemainingRoundsInMagazine = maxRoundsInMagazine;
        // playerAmmoSlider.value = remainingRounds;
        if (reloadSound)
            playASound(reloadSound);
    }

    public void ReloadMagazine()
    {
        int initialnumOfRoundsInMagazine = currentRemainingRoundsInMagazine;
        int ammoPocketDeductValue;

        print(gameObject.name + ": Attempting to reload Magazine" + " Reason: ReloadMagazine Function Called");
        if (currentRemainingRoundsInMagazine != maxRoundsInMagazine && currentRemainingAmmoInPocket != 0)
        {
            // take all bullet rounds in magazines and put them in pocket // simulate CS reload where remaining rounds are stored in your pocket before reloading
            currentRemainingAmmoInPocket = currentRemainingAmmoInPocket + currentRemainingRoundsInMagazine;
            currentRemainingRoundsInMagazine = 0;
            // start reload animation here

            ammoPocketDeductValue = maxRoundsInMagazine -
                                    (maxRoundsInMagazine - Mathf.Clamp(currentRemainingAmmoInPocket, 0,
                                         maxRoundsInMagazine));
            currentRemainingAmmoInPocket -= ammoPocketDeductValue;

            // end reload animation, then only call this code below, using an animation event might help implement this
            currentRemainingRoundsInMagazine = ammoPocketDeductValue;

            print(gameObject.name + ": Magazine reload success" + " RoundsInMagazine: " + currentRemainingRoundsInMagazine + " AmmoInPocket: " + currentRemainingAmmoInPocket);
        }
        else
        {
            if (currentRemainingRoundsInMagazine == maxRoundsInMagazine)
                print(gameObject.name + ": Magazine reload failure" + " Reason: Magazine full");
            else if (currentRemainingAmmoInPocket == 0)
            {
                print(gameObject.name + ": Magazine reload failure" + " Reason: No more ammo in pocket");
            }

        }
    }

    void AmmoPickup(int ammoPickedUp)
    {
        //put ammo picked up in pocket
        currentRemainingAmmoInPocket = Mathf.Clamp(currentRemainingAmmoInPocket + ammoPickedUp , 0 , maxAmmo);
        
    }
    

    void playASound(AudioClip playTheSound)
    {
        if (gunMuzzleAS)
        {
            gunMuzzleAS.clip = playTheSound;
            gunMuzzleAS.Play();
        }
    }
}


/*
 *             // if not enough ammo to fully reload magazine, currentRounds in Magazine = currentammo  else currentROudns equals maxRounds
            if (currentRemainingAmmoInPocket < maxRoundsInMagazine)
            {
                if (currentRemainingRoundsInMagazine < currentRemainingAmmoInPocket)
                {
                    currentRemainingRoundsInMagazine = currentRemainingAmmoInPocket + currentRemainingRoundsInMagazine;
                
                }
            

            }
            else if (currentRemainingAmmoInPocket >= maxRoundsInMagazine)
            {
                currentRemainingRoundsInMagazine = maxRoundsInMagazine;
                currentRemainingAmmoInPocket -= currentRemainingRoundsInMagazine;
            }
*/