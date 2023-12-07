using UnityEngine;

namespace hazethedev.Pooling
{
    public class SpriteRendererPool : ComponentPoolBase<SpriteRenderer>
    {
        protected override void OnRelease(SpriteRenderer spriteRenderer)
        {
            base.OnRelease(spriteRenderer);
            spriteRenderer.sprite = null;
        }
    }
}