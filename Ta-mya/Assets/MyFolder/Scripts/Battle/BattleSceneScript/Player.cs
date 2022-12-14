using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // ฺฎฌx๐i[ท้ฯ
    public float speed = 1;
    // HP
    public int hp;
    [SerializeField] private Slider hp_slider;
    // eฬญหิu
    [SerializeField] private float _timeInterval;
    // o฿ิๆพpฯ
    private float _timeElapsed;
    // }EXzC[ฬ๑]ๆพpฯ
    private float MousWheel;
    // ม๊Upo฿ิi[ฯ
    private float SkillTime;
    // ม๊UฬN[^C
    [SerializeField] private float SkillInterval;
    // ม๊UI๐pฯ
    public int BulletSelect;
    // ม๊Uฬeฬvt@ui[
    //[SerializeField] private List<GameObject> BulletList = new List<GameObject>();
    [SerializeField] private GameObject[] Bullet;
    // ม๊UฬeฒฦฬN[^CmFi[p
    public List<bool> Reload = new List<bool>();
    Vector3 bulletPoint;
    public CoolDown CoolDownScript;

    void Start()
    {
        hp_slider.maxValue = hp;
        hp_slider.value = hp;
        // Listษ๎๑๐วม(ture:ญหย\Afalse:N[^C)
        Reload.Add(true);   // ม๊U1
        Reload.Add(true);   // ม๊U2
        Reload.Add(true);   // ม๊U3
        Reload.Add(true);   // ม๊U4
        //Debug.Log(Reload.Count);
    }

    void Update()
    {
        // ฺฎ
        #region ฺฎ
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        #endregion

        // ม๊UI๐
        #region ม๊U
        // }EXฬ๑]ๆพ(๑]ณน้ฝัษ1ธยธท้ ftHgอ0)
            MousWheel += Input.GetAxis("Mouse ScrollWheel");
            MousWheel = Mathf.Floor(MousWheel);
            MousWheel = Mathf.Clamp(MousWheel, 0.0f, 4.0f);
        #endregion

        // eญห
        #region eฬญห
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shot();
            // o฿ิ๐ณษ฿ท
            _timeElapsed = 0f;
        }
        #endregion
        // ม๊UฬeI๐ฦญหึฬฺฎ(}EXถNbNลญห)
        if(MousWheel > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(MousWheel);
                Debug.Log(Reload[3]);
                BulletSelect = (int)MousWheel;
                if (Reload[BulletSelect - 1] == true)
                {
                    

                    SpecialAttack(BulletSelect);
                }
            }
        }
    }

    // สํeญหึ
    public void shot()
    {
        //e๐oปณน้สu๐ๆพ
        Vector3 placePosition = this.transform.position;
        //oปณน้สu๐ธ็ทl
        Vector3 offsetGun = new Vector3(0, 0, 8);

        //ํฬ?ซษํนฤeฬ?ซเฒฎ
        Quaternion q1 = this.transform.rotation;
        //e๐90x๑]ณน้
        Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Quaternion q = q1 * q2;

        //e๐oปณน้สu๐ฒฎ
        placePosition = q1 * offsetGun + placePosition;
        //eถฌ
        Instantiate(Bullet[0], transform.position, transform.rotation);
    }

    // ม๊Uึ(๘อญหท้ม๊Uฬeฬํ?)
    public void SpecialAttack(int BulletSelection)
    {
        CoolDownScript.SetSpecialNum();

        // ญหใfalseษฯX
        Reload[BulletSelect - 1] = false;

        //e๐oปณน้สu๐ๆพ
        Vector3 placePosition = this.transform.position;
        //oปณน้สu๐ธ็ทl
        Vector3 offsetGun = new Vector3(0, 0, 8);

        //ํฬ?ซษํนฤeฬ?ซเฒฎ
        Quaternion q1 = this.transform.rotation;
        //e๐90x๑]ณน้
        Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Quaternion q = q1 * q2;

        //e๐oปณน้สu๐ฒฎ
        placePosition = q1 * offsetGun + placePosition;
        //eถฌ
        Instantiate(Bullet[BulletSelection], placePosition, Quaternion.identity);
        
        // N[^CJn
        //StartCoroutine(CoolTime());
    }

    public void P_Damage(int damage)
    {
        hp_slider.value -= damage;
    }


    // N[^CR[`
    private IEnumerator CoolTime()
    {
        // N[^CJn
        //Debug.Log("N[^CJn");

        // า@ิ
        yield return new WaitForSeconds(2);

        // false จ trueษฯX
        Reload[BulletSelect - 1] = true;
        //Debug.Log("N[^CIน");
    }

    public int GetSpecialNum()
    {
        return BulletSelect;
    }
}

