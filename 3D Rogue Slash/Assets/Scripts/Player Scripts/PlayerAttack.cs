using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;
    public Camera cam;
    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;
    //dagger attack sound
    private AudioSource dagger_Sound;
    [SerializeField]
    private AudioClip dagger_Clip;

    void Awake()
    {
        //get audio source from Player Audio's audio source
        dagger_Sound = GetComponentInChildren<AudioSource>();
        weapon_Manager = GetComponent<WeaponManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }
    void WeaponShoot()
    {
        //fire gun or using dagger
        if (Input.GetMouseButtonDown(0))
        {
            if (weapon_Manager.GetCurrentSelectedWeapon().tag == "dagger")
            {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                //play dagger attack sound
                dagger_Sound.volume = Random.Range(0.75f, 1f);
                dagger_Sound.clip = dagger_Clip;
                dagger_Sound.Play();
            }

            if (weapon_Manager.GetCurrentSelectedWeapon().tag == "gun")
            {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                //BulletFired();
            }
        }
    }
    void FireBullet()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
        }
    }
}
