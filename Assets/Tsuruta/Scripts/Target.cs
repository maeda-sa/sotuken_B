using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private MiniMap _mm;

    [SerializeField] private Camera minimapCamera;              // ミニマップ用カメラ
    [SerializeField] private Transform iconTarget;              // アイコンに対応するオブジェクト（建造物等）
    [SerializeField] private float rangeRadiusOffset = 1.0f;    // 表示範囲のオフセット

    // 必要なコンポーネント
    private SpriteRenderer spriteRenderer;

    private float minimapRangeRadius;   // ミニマップの表示範囲
    private float defaultPosY;          // アイコンのデフォルトY座標
    const float normalAlpha = 1.0f;     // 範囲内のアルファ値
    const float outRangeAlpha = 0.5f;   // 範囲外のアルファ値

    private void Start()
    {
        iconTarget = _mm.GetGoal();

        minimapRangeRadius = minimapCamera.orthographicSize;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultPosY = transform.position.y;
    }

    private void Update()
    {
        DispIcon();
    }

    /// <summary>
    /// アイコン表示を更新する
    /// </summary>
    private void DispIcon()
    {
        // アイコンを表示する座標
        var iconPos = new Vector3(iconTarget.position.x, defaultPosY, iconTarget.position.z);

        // ミニマップ範囲内の場合はそのまま表示する
        if (CheckInsideMap())
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, normalAlpha);
            transform.position = iconPos;
            return;
        }

        // マップ範囲外の場合、ミニマップ端までのベクトルを求めて半透明で表示する
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, outRangeAlpha);
        var centerPos = new Vector3(minimapCamera.transform.position.x, defaultPosY, minimapCamera.transform.position.z);
        var offset = iconPos - centerPos;
        // Debug.Log(offset);
        // Debug.Log(centerPos + Vector3.ClampMagnitude(offset, minimapRangeRadius - rangeRadiusOffset));
        transform.position = centerPos + Vector3.ClampMagnitude(offset, minimapRangeRadius - rangeRadiusOffset);
    }

    /// <summary>
    /// オブジェクトがミニマップ範囲内にあるか確認する
    /// </summary>
    /// <returns>ミニマップ範囲内の場合、trueを返す</returns>
    private bool CheckInsideMap()
    {
        var cameraPos = minimapCamera.transform.position;
        var targetPos = iconTarget.position;

        // 直線距離で判定するため、yは0扱いにする
        cameraPos.y = targetPos.y = 0;

        return Vector3.Distance(cameraPos, targetPos) <= minimapRangeRadius - rangeRadiusOffset;
    }
}
