using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class OnHitEvent : MonoBehaviour
{
    public abstract void onHitEvent();
    public bool removing = false;
    protected virtual float onRemoveAnime()
    {
        return 0f;
    }
    protected virtual void remove()
    {
        removing = true;
        float t = onRemoveAnime();
        // Sign the object as destroyed
        string currentSceneName = SceneManager.GetActiveScene().name;
        GlobalVariables.sceneDestroyedObjects.TryGetValue(currentSceneName, out List<Vector2> value);
        Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        value.Add(position);
        GlobalVariables.sceneDestroyedObjects[currentSceneName] = value;
        // Destroy object
        Destroy(this.gameObject, t);
    }
    private void Start()
    {

    }
}
