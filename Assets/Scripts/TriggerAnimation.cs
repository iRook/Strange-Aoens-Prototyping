using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator anim;

    [SerializeField] string triggerEnterName;
    [SerializeField] string triggerExitName;

    [SerializeField] string animEnterName;
    [SerializeField] string animExitName;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName(animExitName))
        {
            anim.SetTrigger(triggerEnterName);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName(animEnterName))
    //    {
    //        anim.SetTrigger(triggerExitName);
    //    }
    //}
}
