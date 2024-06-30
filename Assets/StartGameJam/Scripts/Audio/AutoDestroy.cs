using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

namespace StartGameJam.Scripts.Audio
{
    public class AutoDestroy : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(Des());
        }


        IEnumerator Des()
        {
            yield return new WaitForSeconds(10f);
            
            Destroy(gameObject);
        }
    }
}