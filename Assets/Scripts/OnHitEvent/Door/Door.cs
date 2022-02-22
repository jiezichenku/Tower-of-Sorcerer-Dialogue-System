using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : OnHitEvent
{
    public int doorID;
    private Repository repository;
    //public Animator animator;
    public override void onHitEvent()
    {
        repository = Repository.GetInstance();
        // Door open with keys
        if (doorID > 0)
        {
            if (repository.CheckItem(doorID, 1))
            {
                repository.UpdateItem(doorID, -1);
                remove();
            }
        }
        // Door free to open
        if (doorID == 0)
        {
            remove();
        }
    }

    protected override float onRemoveAnime()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Open", true);
        return 0.2f;
    }
}
