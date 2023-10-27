using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image : MonoBehaviour
{
    public Sprite baseSprite; // 元のスプライト
    public Sprite overlaySprite; // 上に重ねるスプライト

    void Start()
    {
        // 元のスプライトを表示するSpriteRendererコンポーネントを追加
        SpriteRenderer baseRenderer = gameObject.GetComponent<SpriteRenderer>();

        // 上に重ねるスプライトを表示するSpriteRendererコンポーネントを追加
        baseRenderer.sprite = overlaySprite;
        baseRenderer.sortingOrder = 101; // ソートオーダーを調整して元のスプライトより手前に表示
    }
}





