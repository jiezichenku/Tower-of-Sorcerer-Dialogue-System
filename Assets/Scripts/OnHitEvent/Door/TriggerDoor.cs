using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDoor : OnHitEvent
{
    public int triggerNum;
    public Animator animator;
    private void Start()
    {
        EventCenter.AddListener<string, Vector2>(EventType.Trigger, TriggerCheck);
    }
    public override void onHitEvent()
    {

    }
    
    private void TriggerCheck(string floor, Vector2 position)
    {
        string sceneName = gameObject.scene.name;
        Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (sceneName == floor && pos == position)
        {
            triggerNum -= 1;
        }
        if (triggerNum <= 0)
        {
            remove();
        }
    }

    protected override float onRemoveAnime()
    {
        string sceneName = gameObject.scene.name;
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            return 0f;
        }
        else
        {
            animator = gameObject.GetComponent<Animator>();
            animator.SetBool("Open", true);
            return 0.2f;
        }
    }
}
