using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bike : MonoBehaviour
{
    public Camera cm;
    public Transform handle;
    public List<AxleInfo> axleInfos;
    public List<GameObject> pedals;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float breake;

    private Vector2 _look;
    private Vector3 _velocity;
    private Vector3 _angle;
    private Vector3 _primary_angle;
    private float stop_R;
    private float stop_L;

    void Start()
    {
        _angle = cm.gameObject.transform.localEulerAngles;
        _primary_angle = cm.gameObject.transform.localEulerAngles;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1.5f, 0.3f);
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * _velocity.z;
        float steering = maxSteeringAngle * _velocity.x;
        _angle = new Vector3(_angle.x - _look.y, _angle.y + _look.x);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.Wheel.steerAngle = steering;
                handle.localEulerAngles = new Vector3(0, steering, 0);
            }
            if (axleInfo.motor)
            {
                axleInfo.Wheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.Wheel);

            if(Input.GetAxis("Horizontal") == 0)
            {
                Quaternion rot = transform.rotation;
                Quaternion zero = new Quaternion(rot.x, rot.y, 0, rot.w);
                transform.rotation = zero;
            }

            if (stop_R > 0 && axleInfo.steering)
            {
                axleInfo.Wheel.brakeTorque = breake * stop_R;
            }
            if (stop_R ==0 && axleInfo.steering)
            {
                axleInfo.Wheel.brakeTorque = 0;
            }
            if (stop_L > 0 && axleInfo.motor)
            {
                axleInfo.Wheel.brakeTorque = breake * stop_L;
            }
            if (stop_L == 0 && axleInfo.motor)
            {
                axleInfo.Wheel.brakeTorque = 0;
            }

            if (_angle.y <= _primary_angle.y - 30f)
            {
                _angle.y = _primary_angle.y - 30f;
            }
            if (_angle.y >= _primary_angle.y + 30f)
            {
                _angle.y = _primary_angle.y + 30f;
            }
            if (_angle.x <= _primary_angle.x - 20f)
            {
                _angle.x = _primary_angle.x - 20f;
            }
            if (_angle.x >= _primary_angle.x + 20f)
            {
                _angle.x = _primary_angle.x + 20f;
            }

            cm.gameObject.transform.localEulerAngles = _angle;
        }

        foreach (GameObject pedal in pedals)
        {
            var rot = pedal.transform.localEulerAngles;
            // rot.z += _velocity.z;
            pedal.transform.localEulerAngles = rot;
        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _velocity = new Vector3(value.x, 0, value.y);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _look = context.ReadValue<Vector2>();
    }

    public void OnStop(InputAction.CallbackContext context)
    {
        stop_R = context.ReadValue<float>();
        stop_L = context.ReadValue<float>();
    }

    public void OnStop_R(InputAction.CallbackContext context)
    {
        stop_R = context.ReadValue<float>();
    }
    public void OnStop_L(InputAction.CallbackContext context)
    {
        stop_L = context.ReadValue<float>();
    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider Wheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}