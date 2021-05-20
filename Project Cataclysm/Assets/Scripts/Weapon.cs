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

    private bool isAttacking;

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
        pistolAnimator.SetBool("isWalking", transform.GetComponent<PlayerController>().isMoving);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!isAttacking)
            {
                StartCoroutine(MuzzleFlash());
                StartCoroutine(Attack());
            }
        }
    }

   IEnumerator MuzzleFlash()
    {
        pistolAnimator.SetTrigger("shoot");
        muzzleFlashImageObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlashImageObject.SetActive(false);
        pistolAnimator.SetTrigger("shoot");
        yield return null;
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        audioManager.Play("PistolShot");
   
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        if (hit.transform != null && hit.transform.tag == "Enemy")
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
        }
        yield return new WaitForSeconds(.2f);
        isAttacking = false;
        yield return null;
    }
}


public enum WeaponType
{
    SWORD = 0,
    PISTOL = 1
}
