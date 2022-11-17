using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SP_Use4 : MonoBehaviour
{
    public Image UIobj;
    public bool Use;
    public float CoolTime;
    private int SpecialNum;
    private float Now;

    public CreateShip createShip;
    private Special_info specialInfo;
    public Player PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
            CoolTime = createShip.CT[3];
            //Debug.Log(i+"��CT:"+CoolTime[i]);
    }

    // Update is called once per frame
    void Update()
    {
        UIobj.fillAmount += 1.0f / CoolTime * Time.deltaTime;
        if (UIobj.fillAmount == 1)
        {
            PlayerScript.Reload[3] = true;
        }
    }


    public void SetSpecialNum()
    {
        Debug.Log("SpecialNum:" + SpecialNum);

        SpecialNum = PlayerScript.GetSpecialNum() - 1;
        UIobj.fillAmount = 0;
    }

}
