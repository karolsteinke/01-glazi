using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public bool dying {get; private set;}
    private SpriteRenderer _sprite;
    private Shader _shaderGUIText;
    private Shader _shaderSpritesDefault;
    private Color _startColor;
    
    void Start() {
        _sprite = GetComponent<SpriteRenderer>();
        _shaderGUIText = Shader.Find("GUI/Text Shader");
        _shaderSpritesDefault = Shader.Find("Sprites/Default");
        _startColor = _sprite.color;
        dying = false;
    }

    public void ReactToHit() {
        if (!dying) {
            dying = true;
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die() {
        //blink 3x
        whiteSprite();  yield return new WaitForSeconds(.1f);
        normalSprite(); yield return new WaitForSeconds(.2f);
        whiteSprite();  yield return new WaitForSeconds(.1f);
        normalSprite(); yield return new WaitForSeconds(.2f);
        whiteSprite();  yield return new WaitForSeconds(.1f);

        Destroy(this.gameObject);
    }

    private void whiteSprite() {
        _sprite.material.shader = _shaderGUIText;
        _sprite.color = Color.white;
    }

    private void normalSprite() {
        _sprite.material.shader = _shaderSpritesDefault;
        _sprite.color = _startColor;
    }
}
