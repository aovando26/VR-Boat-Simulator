using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UIManager : MonoBehaviour
{
    public GameObject WindVectorUI;
    public GameObject SailDirectionUI;
    public GameObject ApparentWindUI;
    public GameObject playerMainCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateWindVectorUI();
        UpdateSailDirectionUI();
        UpdateApparentWindUI();
    }

    void UpdateWindVectorUI()
    {
        float angleInRad = Mathf.Atan2(WindManager.instance.CurrentTrueWind.y, WindManager.instance.CurrentTrueWind.x);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;
        WindVectorUI.transform.rotation = Quaternion.Euler(angleInDeg, playerMainCamera.transform.eulerAngles.y, 0);
    }

    void UpdateSailDirectionUI()
    {
        float sailAngle = -BoatManager.Player.Sail.transform.localRotation.eulerAngles.y + 90 - BoatManager.Player.transform.localRotation.eulerAngles.y;
        SailDirectionUI.transform.rotation = Quaternion.Euler(0, playerMainCamera.transform.eulerAngles.y, sailAngle);
    }

    void UpdateApparentWindUI()
    {
        float angleInRad = Mathf.Atan2(BoatManager.Player.ApparentWind.y, BoatManager.Player.ApparentWind.x);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;
        ApparentWindUI.transform.rotation = Quaternion.Euler(angleInDeg, playerMainCamera.transform.eulerAngles.y, 0);
    }
}
