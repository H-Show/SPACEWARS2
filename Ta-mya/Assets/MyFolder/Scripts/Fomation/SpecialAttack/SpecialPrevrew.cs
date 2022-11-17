using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialPrevrew : MonoBehaviour
{
    private Special_info specialInfo;
    [SerializeField] private int SpecialNum;
    // �ǂ̓���U���ɃX�e�[�^�X�������邩�I������ϐ�(0�`3�̂S��)
    private int count = 0;
    // �ǂ̓���U�����I�΂ꂽ���i�[����ϐ� (�퓬�V�[���J�n���Ɏg��)
    private int[] SelectNum = new int[3];
    //�@�X�e�[�^�X�i�[�ϐ� (�I���V�[���A�퓬�V�[���J�n���Ɏg��)
    private int[] StatusIn = new int[3];
    public int Count;
    // ����U���̊i�[��
    public string[] Name = new string[30];
    public int[] Attack = new int[4];
    public float[] CT = new float[4];
    public int[] Range = new int[4];
    public string[] Explanatory = new string[30];
    [SerializeField] private Image[] image;
    [SerializeField] private Image[] SelectImage;
    // �ǂ̃{�^���������ꂽ�����肷��ϐ�
    private int number;
    // �����ꂽ�ԍ��𑗐M����p�ϐ�
    public static int ShipNumber;
    // �e�L�X�g�i�[
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI ATKText;
    [SerializeField] private TextMeshProUGUI CTText;
    [SerializeField] private TextMeshProUGUI RANGEText;


    void Start()
    {
        // CSV�f�[�^�̎Q��
        count = 0;
        specialInfo = new Special_info();
        Debug.Log("SpcialPrevrew_Start");
        specialInfo.Init();
        for (int i = 0; i < SpecialNum; i++)
        {
            SelectImage[i].sprite = Resources.Load<Sprite>(specialInfo.Image[i+1]);
        }
       
        //CreateShip();
    }

    // �퓬�V�[���J�n���ɖ����@�𐶐�����ۂɎg�p
    private void CreateShip()
    {
        // StatusIn�ɂ͑�����邾���ASelectNum��count�ԖڂɑI�����ꂽ�ԍ��̏���ǂݍ���
        Name[count] = specialInfo.Name[SelectNum[count]];
        Attack[count] = specialInfo.Attack[SelectNum[count]];
        CT[count] = specialInfo.CT[SelectNum[count]];
        Range[count] = specialInfo.Range[SelectNum[count]];
        count++;
        //}
    }


    // �v���r���[�ɕ\�����邽�߂̏���
    public void Display(int number)
    {
        NameText.text = specialInfo.Name[number];
        //NameText.SetText("{0}", statusInfo.Name[number]);
        ATKText.SetText("ATK:{0}", specialInfo.Attack[number]);
        CTText.SetText("CT:{0}", specialInfo.CT[number]);
        RANGEText.SetText("RANGE:{0}", specialInfo.Range[number]);
    }
    public void DisplayImage(int Num)
    {
        // CSV����摜�������Ă��ĕ\��
        image[Count].sprite = Resources.Load<Sprite>(specialInfo.Image[Num]);
        // �J�E���g��i�߂�
        Count++;
        if (Count >= 4)
        {
            Count = 0;
        }
    }

    // �l�̑������
    private void SetData(int SelectNum)
    {
        ShipNumber = SelectNum;
    }
}