using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField]
    Weapon currentWeapon;

    bool hasWeapon = false;
    float currentWeaponRateOfFire = 0.4f;

    private float nextFireTime = 0f;

    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if(currentWeapon)
        {
            hasWeapon = true;
            currentWeaponRateOfFire = currentWeapon.fireRate;
            //currentWeapon pegar a cadencia de tiro aqui
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if (hasWeapon && Input.GetButton("Fire1") && currentTime > nextFireTime)
        {
            nextFireTime = currentTime + currentWeaponRateOfFire;
            currentWeapon.Fire(); // Dispare a arma
        }
    }
}
