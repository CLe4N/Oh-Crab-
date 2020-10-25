using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveScene : MonoBehaviour
{
    public Save_con Active_scene;
    Scene m_scene;
    void Start()
    {
        m_scene = SceneManager.GetActiveScene();
        Active_scene.data.Scen_name = m_scene.name;
    }
}
