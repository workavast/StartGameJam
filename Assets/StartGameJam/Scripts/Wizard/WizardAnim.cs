using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnim : MonoBehaviour
{
    private  Animator anim;
    // Start is called before the first frame update


    IEnumerator RunAnim()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("isRunning", true);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RunAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
