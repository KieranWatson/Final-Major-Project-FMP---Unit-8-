﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Script : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;

    public int damage = 40;

    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        animator.SetTrigger("Shoot");

        // Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            Enemy_Health enemy =  hitInfo.transform.GetComponent<Enemy_Health>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        //wait one frame
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}
