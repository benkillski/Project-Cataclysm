using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    [SerializeField] GameObject muzzleFlashImageObject;
    int weaponDamage;
    [SerializeField] Animator pistolAnimator;

    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        switch (weaponType)
        {
            case WeaponType.SWORD:
                weaponDamage = 10; break;

            case WeaponType.PISTOL:
                weaponDamage = 20; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerController>().GetPlayerVelocity().magnitude != 0)
        {
            pistolAnimator.SetBool("isWalking", true);
        }
        else
        {
            pistolAnimator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(MuzzleFlash());
            Attack();
        }
    }

   IEnumerator MuzzleFlash()
    {
        muzzleFlashImageObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlashImageObject.SetActive(false);
        yield return null;
    }

    void Attack()
    {
        audioManager.Play("PistolShot");

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        if (hit.transform.tag == "Enemy")
        {
           if(!audioManager.IsPlaying("DamageGrunt"))
           {
                audioManager.Play("DamageGrunt");
           }
           Enemy enemy = hit.transform.GetComponent<Enemy>();
           enemy.SetHealth(enemy.GetHeath() - weaponDamage);
        }
        else
        {
            Debug.Log("No Enemy Hit");
            return;
        }
    }
}


public enum WeaponType
{
    SWORD = 0,
    PISTOL = 1
}
