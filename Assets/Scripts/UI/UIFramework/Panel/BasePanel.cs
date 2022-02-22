using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Father of every UI panel
public class BasePanel
{
    public UIType Type { get; private set; }
    public UITool tool = UITool.GetInstance();
    public PanelManager manager = PanelManager.GetInstance();
    public BasePanel(UIType uiType)
    {
        Type = uiType;
    }

    // Operation when UI first called
    public virtual void OnEnter()
    {

    }
    // Operation when UI paused
    public virtual void OnPause()
    {

    }
    // Operation when UI resumed
    public virtual void OnResume()
    {

    }
    // Operation when UI exited
    public virtual void OnExit()
    {

    }
}
