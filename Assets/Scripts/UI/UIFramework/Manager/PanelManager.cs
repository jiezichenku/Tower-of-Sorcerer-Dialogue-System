using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage panels by stack structure
public class PanelManager
{
    private Stack<BasePanel> panelStack;
    private UIManager UIManager;

    private static PanelManager singleIntance;
    public static PanelManager GetInstance()
    {
        if (singleIntance == null)
        {
            singleIntance = new PanelManager();
        }
        return singleIntance;
    }

    private PanelManager()
    {
        panelStack = new Stack<BasePanel>();
        UIManager = UIManager.GetInstance();
    }

    // Push panel into stack to display the panel
    public void Push(BasePanel nextPanel)
    {
        if (panelStack.Count > 0)
        {
            panelStack.Peek().OnPause();
        }
        panelStack.Push(nextPanel);
        GameObject panelObject = UIManager.GetSingleUI(nextPanel.Type);
        UITool.GetInstance().activePanel = panelObject;
        nextPanel.OnEnter();
    }

    // Pop panel to dismiss the panel
    public void Pop()
    {
        if (panelStack.Count > 0)
        {
            panelStack.Peek().OnExit();
            UIManager.DestroyUI(panelStack.Peek().Type);
            panelStack.Pop();
        }
        if (panelStack.Count > 0)
        {
            panelStack.Peek().OnResume();
        }
    }

    // Get peek element
    public BasePanel Peek()
    {
        if (panelStack.Count > 0)
        {
            return panelStack.Peek();
        }
        else
        {
            return null;
        }
    }
}
