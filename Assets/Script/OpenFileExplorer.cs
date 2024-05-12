using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFileExplorer : MonoBehaviour
{
    public void OpenExplorer()
    {
        System.Diagnostics.Process.Start(Application.dataPath+"/Stage");
    }
}
