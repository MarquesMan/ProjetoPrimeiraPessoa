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

    private DecalController decalController;

    // Start is called before the first frame update
    void Start()
    {
        decalController = GetComponent<DecalController>();

        if (currentWeapon)
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

        if (hasWeapon)
        {   
            if (Input.GetButton("Fire1") && currentTime > nextFireTime)
            {
                nextFireTime = currentTime + currentWeaponRateOfFire;
                RaycastHit hit = currentWeapon.Fire(); // Dispare a arma

                if(hit.distance > 0)
                    decalController.SpawnDecal(hit);
            }
            else if (Input.GetButtonUp("Fire2") || Input.GetButtonDown("Fire2") || Input.GetButton("Fire2"))
            {
                currentWeapon.SecondaryFire(Input.GetButtonDown("Fire2") || Input.GetButton("Fire2"));
            }
        }
    }
}
