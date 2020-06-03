using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

[ExecuteInEditMode]
public class ShaderTest : MonoBehaviour
{
	public int CherryValue;

	#region Variables
	public Shader curShader;
	public float grayScaleAmountAim;
	public float grayScaleAmount = 1.0f;
	public float speed;
	private Material curMaterial;
	#endregion

	#region Properties
	public Material material
	{
		get
		{
			if (curMaterial == null)
			{
				curMaterial = new Material(curShader);
				curMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return curMaterial;
		}
	}
	#endregion

	// Use this for initialization
	void Start()
	{

		if (SystemInfo.supportsImageEffects == false)
		{
			enabled = false;
			return;
		}

		if (curShader != null && curShader.isSupported == false)
		{
			enabled = false;
		}
	}

	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (curShader != null)
		{
			material.SetFloat("_LuminosityAmount", grayScaleAmount);

			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	// Update is called once per frame
	void Update()
	{
		grayScaleAmount = Mathf.Clamp(grayScaleAmount, 0.0f, 1.0f);
		CherryValue = GameObject.Find("Player").GetComponent<PlayerController>().CherryValue;
		CherryValue = CherryValue < 5 ? CherryValue : 5;

		grayScaleAmountAim = 1.0f - CherryValue / 5.0f;

		grayScaleAmount = (float)System.Math.Round(grayScaleAmount, 5);
		grayScaleAmountAim = (float)System.Math.Round(grayScaleAmountAim, 5);

		if (grayScaleAmount != grayScaleAmountAim)
		{
			grayScaleAmount -= speed;
		}
	}

	void OnDisable()
	{
		if (curMaterial != null)
		{
			DestroyImmediate(curMaterial);
		}
	}
}