using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    [SerializeField] GameObject muzzleFlashImageObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(MuzzleFlash());
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

    
}

public enum WeaponType
{
    SWORD = 0,
    PISTOL = 1
}
