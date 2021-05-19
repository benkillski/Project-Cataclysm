using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    [SerializeField] GameObject muzzleFlashImageObject;
    int weaponDamage;

    [SerializeField] AudioManager audioManager;

    [Header("Weapon Sounds")]
    public AudioClip pistolShot;

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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(MuzzleFlash());
            Attack();
        }
    }

   IEnumerator MuzzleFlash()
    {
        Debug.Log("Player Attack");
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
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy.SetHealth(enemy.GetHeath() - weaponDamage);
        }
    }    
}


public enum WeaponType
{
    SWORD = 0,
    PISTOL = 1
}
