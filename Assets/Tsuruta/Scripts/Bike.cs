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

    private bool _back;

    private Vector2 _look;
    private Vector2 _firstLook;
    private Vector3 _velocity;
    private Vector3 _angle;
    private Vector3 _primary_angle;
    private float stop_R;
    private float stop_L;

    void Start()
    {
        _angle = cm.gameObject.transform.localEulerAngles;
        _primary_angle = cm.gameObject.transform.localEulerAngles;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -3f, 1f);
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
        rotation.z = 0;
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * _velocity.z;
        float steering = maxSteeringAngle * _velocity.x;
        _angle = new Vector3(_angle.x - _look.y, _angle.y + _look.x);

        if(transform.rotation.z != 0)
        {
            Vector3 r = transform.localEulerAngles;
            // Debug.Log("修正");
            r.z = 0;
            transform.localEulerAngles = r;
        }
        

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

            if (_look.x == 0 && _look.y == 0) _angle = new Vector2(10, 0);

            cm.gameObject.transform.localEulerAngles = _angle;
        }

        foreach (GameObject pedal in pedals)
        {
            var rot = pedal.transform.localEulerAngles;
            rot.z += _velocity.z;
            pedal.transform.localEulerAngles = rot;
        }


    }


    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _velocity = new Vector3(value.x, 0, _velocity.z);
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

    public void OnAccel(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        if (_back) value *= -1;
        _velocity = new Vector3(_velocity.x, 0, value);
    }

    public void OnBack(InputAction.CallbackContext context)
    {
        _back = context.ReadValueAsButton();
    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider Wheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}