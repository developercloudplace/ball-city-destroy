using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class EditorMode : MonoBehaviour
{
    public MoveCameraEditorMode MoveCameraEditorMode;
    public Button CreateButton;
    public Button NextButton;
    public TMP_InputField InputFieldX;
    public TMP_InputField InputFieldZ;
    private List<GameObject> _listPlatform = new List<GameObject>();
    private TMP_Text _text;
    public int XSize;
    public int ZSize;
    public Transform StartPoint;
    public GameObject Platform;
    public GameObject PanelBuildPlatform;
    public GameObject PanelPrefab;
    public GameObject PrefabStartPoint;
    private GameObject viewStartPoint;



    private void LateUpdate()
    {
        InteractableButton();
    }

    private void InteractableButton()
    {
        if (InputFieldX.text != null || InputFieldZ.text != null)
        {
            CreateButton.interactable = true;
            if (InputFieldX.text == null)
                XSize = 0;
            if (InputFieldZ.text == null)
                ZSize = 0;
        }
        else
        {
            CreateButton.interactable = false;
        }
        NextButton.gameObject.SetActive(_listPlatform.Count > 0);
        CreateButton.interactable = (_listPlatform.Count <= 0);
    }

    [ContextMenu("MapGenerator")]
    public void MapGenerator()
    {
        XSize = Convert.ToInt32(InputFieldX.text);
        ZSize = Convert.ToInt32(InputFieldZ.text);
        for (int x = 0; x < XSize; x++)
        {
            for (int z = 0; z < ZSize; z++)
            {
                var go = Instantiate(Platform, new Vector3(x, -.5f, z), quaternion.identity);
                Platform setup = go.GetComponent<Platform>();
                SetupSize(z, setup, x);
                _listPlatform.Add(go);
            }
        }

        CreateStartPoint();
        CenterCamera(XSize, ZSize);
    }

    private void CreateStartPoint()
    {
       // viewStartPoint =  Instantiate(PrefabStartPoint, new Vector3(0, 0.2f, 0),quaternion.identity);
    }

    public void Next()
    {
        PanelBuildPlatform.SetActive(false);
        PanelPrefab.SetActive(true);
    }
    
    public void ClenPlatform()
    {
        foreach (var platform in _listPlatform)
        {
            Destroy(platform);
        }

        _listPlatform.RemoveRange(0, _listPlatform.Count);
        PanelBuildPlatform.SetActive(true);
        PanelPrefab.SetActive(false);
        Destroy(viewStartPoint);
    }

    private void CenterCamera(int x, int z)
    {
        if (Camera.main != null)
        {
            if (XSize < 10 && ZSize < 10)
            {
                if (XSize >= 15 || ZSize >= 15)
                {
                    Camera.main.fieldOfView = 150;
                }
                else if (XSize <= 10 || ZSize <= 10)
                    Camera.main.fieldOfView = 90;
            }
            else
                Camera.main.fieldOfView = 120;

            Camera.main.transform.position = new Vector3(x / 2, 6, z / 2);
        }
    }

    private void SetupSize(int z, Platform setup, int x)
    {
        if (z <= 0)
        {
            setup.isWellDown = true;
        }

        if (x <= 0 && z >= 0)
        {
            setup.isWellLeft = true;
        }

        if (x == 0 && z == 0)
        {
            setup.isWellDown = true;
            setup.isWellLeft = true;
        }

        if (x == XSize - 1 && z >= 0)
        {
            setup.isWellRight = true;
        }

        if (x == XSize - 1 && z == 0)
        {
            setup.isWellDown = true;
            setup.isWellRight = true;
        }

        if (x >= 0 && z == ZSize - 1)
        {
            setup.isWellTop = true;
        }

        if (x == 0 && z == ZSize - 1)
        {
            setup.isWellTop = true;
            setup.isWellLeft = true;
        }

        if (x == XSize - 1 && z == ZSize - 1)
        {
            setup.isWellTop = true;
            setup.isWellRight = true;
        }
    }
}