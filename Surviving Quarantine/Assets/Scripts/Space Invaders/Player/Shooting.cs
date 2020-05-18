using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public void CreateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
