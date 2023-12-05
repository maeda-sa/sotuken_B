using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Bike : MonoBehaviour
{
    private GameManager _gm;

    public Camera cm;
    public Transform handle;
    public List<AxleInfo> axleInfos;
    public List<GameObject> pedals;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float breake;

    private bool _back;
    private bool _backLook;
    private bool _goal = false;

    private Vector2 _look;
    private Vector2 _firstLook;
    private Vector3 _velocity;
    private Vector3 _angle;
    private Vector3 _primary_angle;
    private float stop;

    public GameObject brake;
    public GameObject back;
    public GameObject right;
    public GameObject left;

    void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        _gm = gm.GetComponent<GameManager>();

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
        if (!_goal)
        {
            float motor = maxMotorTorque * _velocity.z;
            float steering = maxSteeringAngle * _velocity.x;
            _angle = new Vector3(_angle.x - _look.y * 2, _angle.y + _look.x * 2);

            if (transform.rotation.z != 0)
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

                if (stop > 0 && axleInfo.steering)
                {
                    axleInfo.Wheel.brakeTorque = breake * stop;
                }
                if (stop == 0 && axleInfo.steering)
                {
                    axleInfo.Wheel.brakeTorque = 0;
                }

                if (_angle.y <= _primary_angle.y - 165f)
                {
                    _angle.y = _primary_angle.y - 165f;
                }
                if (_angle.y >= _primary_angle.y + 165f)
                {
                    _angle.y = _primary_angle.y + 165f;
                }
                if (_angle.x <= _primary_angle.x - 20f)
                {
                    _angle.x = _primary_angle.x - 20f;
                }
                if (_angle.x >= _primary_angle.x + 20f)
                {
                    _angle.x = _primary_angle.x + 20f;
                }

                // if (_look.x == 0 && _look.y == 0 && !_backLook) _angle = new Vector2(10, 0);

                if (_backLook) _angle = new Vector2(10, 0);

                cm.gameObject.transform.localEulerAngles = _angle;
            }

            foreach (GameObject pedal in pedals)
            {
                var rot = pedal.transform.localEulerAngles;
                rot.z += _velocity.z;
                pedal.transform.localEulerAngles = rot;
            }
        }
        if (_goal)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _velocity = new Vector3(value.x, 0, _velocity.z);

        if (value.x > 0) right.SetActive(true);
        else right.SetActive(false);
        if (value.x < 0) left.SetActive(true);
        else left.SetActive(false);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if(!_backLook) _look = context.ReadValue<Vector2>();
    }

    public void OnBackLook(InputAction.CallbackContext context)
    {
        _backLook = context.ReadValueAsButton();
    }

    public void OnStop(InputAction.CallbackContext context)
    {
        stop = context.ReadValue<float>();

        if (stop != 0) brake.SetActive(true);
        else brake.SetActive(false);
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

        if (_back) back.SetActive(true);
        else back.SetActive(false);
    }

    public void OnGoal()
    {
        _goal = true;
    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider Wheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}