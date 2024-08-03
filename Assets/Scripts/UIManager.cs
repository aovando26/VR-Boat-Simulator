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
    public GameObject player; 
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
        float AngleInRad = Mathf.Atan2(WindManager.instance.CurrentTrueWind.y, WindManager.instance.CurrentTrueWind.x);
        Debug.Log(AngleInRad);
        WindVectorUI.transform.rotation = Quaternion.Euler(0, 0, AngleInRad * Mathf.Rad2Deg);

        // the y axis is being passed in the x coordinate then Euler Angles is applied with respect to the player transform
        WindVectorUI.transform.Rotate(player.transform.eulerAngles.y, 0, 0);
        //Debug.Log(WindVectorUI);
    }

    void UpdateSailDirectionUI()
    {
        SailDirectionUI.transform.rotation = Quaternion.Euler(0, 0, -BoatManager.Player.Sail.transform.localRotation.eulerAngles.y + 90 - BoatManager.Player.transform.localRotation.eulerAngles.y);

        // rotates around x axis depending on y
        SailDirectionUI.transform.Rotate(player.transform.eulerAngles.y, 0, 0);
        //Debug.Log(SailDirectionUI);
    }

    void UpdateApparentWindUI()
    {
        float AngleInRad = Mathf.Atan2(BoatManager.Player.ApparentWind.y, BoatManager.Player.ApparentWind.x);
        Debug.Log(AngleInRad);
        ApparentWindUI.transform.rotation = Quaternion.Euler(0, 0, AngleInRad * Mathf.Rad2Deg);
        ApparentWindUI.transform.Rotate(player.transform.eulerAngles.y, 0, 0);
        //Debug.Log(ApparentWindUI);
    }
}