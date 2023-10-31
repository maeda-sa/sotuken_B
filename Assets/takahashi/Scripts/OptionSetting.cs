//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionSetting : MonoBehaviour
{
	//　BGMボタンのテキスト
	[SerializeField]
	private TextMeshProUGUI bgmButtonText;
	//　SEボタンのテキスト
	[SerializeField]
	private TextMeshProUGUI seButtonText;
	//　BGM設定
	public bool BGMSettings { get; set; }
	//　SE設定
	public bool SESettings { get; set; }
	//　BGMAudioSource
	[SerializeField]
	private AudioSource bgmAudioSource;
	//　SEAudioSource
	[SerializeField]
	private AudioSource seAudioSource;

	// Start is called before the first frame update
	void Start()
	{
		InitializeOptionSettings();
	}

	//　初期状態をボタンのテキストに反映する
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

	//　BGMボタンが押された
	public void OnPushBGMButton()
	{
		//　ボタンを押した時の効果音を鳴らす
		if (SESettings)
		{
			seAudioSource.Play();
		}
		//　設定を反転させる
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

	//　SEボタンが押された
	public void OnPushSEButton()
	{
		//　設定を反転させる
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