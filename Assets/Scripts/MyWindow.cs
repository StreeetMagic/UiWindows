using UnityEngine;
using UnityEngine.UI.Windows.Components;
using UnityEngine.UI.Windows.WindowTypes;

public class MyWindow : LayoutWindowType
{
    private ButtonComponent button;

    public override void OnInit()
    {
        GetLayoutComponent(out button);
        base.OnInit();
        
        Debug.Log("работаем братья");
        Debug.Log($"{button == null} пздц");
    }
}