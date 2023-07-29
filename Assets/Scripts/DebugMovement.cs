using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMovement : MonoBehaviour
{
    public enum MovementEnum {
        PosOnAbsoluteTime = 0,
        VelIgnoringFramerate = 1,
        VelIncludingFramerate = 2,
        PosOnFrames =3
    }
    public MovementEnum movementType = MovementEnum.PosOnAbsoluteTime;
    private Rigidbody2D _body;
    private float prevClock = 0.0f;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
        if (movementType == MovementEnum.VelIgnoringFramerate) {
            //vel = 0.76f should mean it moves 0.76f distance every sec, so 6,08f on 8sec?
            //theoretically it lags more if framerate is lower?
            _body.velocity = new Vector2(0.76f, 0.0f);
        }
    }

    void Update() {
        float clock = Time.time % 8.0f;
        
        //move to start at full clock cycle
        if (prevClock > clock) {
            _body.position = new Vector2(-3.04f, _body.position.y);
        }
        prevClock = clock;

        if (movementType == MovementEnum.PosOnAbsoluteTime) {
            //it's alway on accurate position based on time passed since scene start
            //6.08f is distance to be travelled
            float posX = clock / 8.0f * 6.08f - 3.04f;
            _body.position = new Vector2(posX,_body.position.y);
        }
        else if (movementType == MovementEnum.VelIncludingFramerate) {
            //velocity is adjusted constantly to include fluctuating framerate
            //vel shoud be 0.76f when deltaTime is 0.0166sec (60fps)
            _body.velocity = new Vector2(45.6f * Time.deltaTime, 0.0f);
        }
        else if (movementType == MovementEnum.PosOnFrames) {
            //it changes position every frame by const value
            //0.0126f is distance for 1 frame (6.08units / (8sec * 60frames))
            float posX = _body.position.x + 0.0126f;
            _body.position = new Vector2(posX, _body.position.y);
        }
    }
}
