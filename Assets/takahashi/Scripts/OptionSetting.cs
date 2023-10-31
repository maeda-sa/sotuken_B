//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionSetting : MonoBehaviour
{
	//�@BGM�{�^���̃e�L�X�g
	[SerializeField]
	private TextMeshProUGUI bgmButtonText;
	//�@SE�{�^���̃e�L�X�g
	[SerializeField]
	private TextMeshProUGUI seButtonText;
	//�@BGM�ݒ�
	public bool BGMSettings { get; set; }
	//�@SE�ݒ�
	public bool SESettings { get; set; }
	//�@BGMAudioSource
	[SerializeField]
	private AudioSource bgmAudioSource;
	//�@SEAudioSource
	[SerializeField]
	private AudioSource seAudioSource;

	// Start is called before the first frame update
	void Start()
	{
		InitializeOptionSettings();
	}

	//�@������Ԃ��{�^���̃e�L�X�g�ɔ��f����
	public void InitializeOptionSettings()
	{
		if (BGMSettings)
		{
			bgmAudioSource.Play();
			bgmButtonText.text = "ON";
		}
		else
		{
			bgmAudioSource.Stop();
			bgmButtonText.text = "OFF";
		}

		if (SESettings)
		{
			seButtonText.text = "ON";
		}
		else
		{
			seButtonText.text = "OFF";
		}
	}

	//�@BGM�{�^���������ꂽ
	public void OnPushBGMButton()
	{
		//�@�{�^�������������̌��ʉ���炷
		if (SESettings)
		{
			seAudioSource.Play();
		}
		//�@�ݒ�𔽓]������
		BGMSettings = !BGMSettings;
		if (BGMSettings)
		{
			bgmAudioSource.Play();
			bgmButtonText.text = "ON";
		}
		else
		{
			bgmAudioSource.Stop();
			bgmButtonText.text = "OFF";
		}
	}

	//�@SE�{�^���������ꂽ
	public void OnPushSEButton()
	{
		//�@�ݒ�𔽓]������
		SESettings = !SESettings;
		if (SESettings)
		{
			seAudioSource.Play();
			seButtonText.text = "ON";
		}
		else
		{
			seAudioSource.Stop();
			seButtonText.text = "OFF";
		}
	}
}