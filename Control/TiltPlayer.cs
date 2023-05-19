using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPlayer : MonoBehaviour
{
    public GameObject Handle;
    float _oldZ;
    float _zDifference;
    [SerializeField] float _maxLeftYRotation, _maxRightYRotation, _ySensitivity, _zSensitivity, _wheelSensitivity, _recoverSpeed;
    private void Start() => StartCoroutine(RotationTick());
    private void Update()
    {
        float z = transform.localPosition.z;
        _zDifference = _oldZ - z;

        Quaternion intermediate = transform.rotation;
        Quaternion intermediateHandle = Handle.transform.localRotation;

        if (_zDifference < 0)
        {
            Vector3 target = new Vector3(0f, transform.rotation.eulerAngles.y + (_zDifference * Time.deltaTime * _ySensitivity), transform.rotation.eulerAngles.z + (_zDifference * Time.deltaTime * _zSensitivity));
            Vector3 wheelTarget = new Vector3(0f, 0f, Handle.transform.localRotation.eulerAngles.z + (_zDifference * Time.deltaTime * _wheelSensitivity));

            if (target.y > _maxRightYRotation)
                target.y = _maxRightYRotation;

            intermediate = Quaternion.Lerp(transform.rotation, Quaternion.Euler(target), 10f * Time.deltaTime);
            intermediateHandle = Quaternion.Lerp(Handle.transform.localRotation, Quaternion.Euler(wheelTarget), 10f * Time.deltaTime);
        }
        else if (_zDifference > 0)
        {
            Vector3 target = new Vector3(0f, transform.rotation.eulerAngles.y + (_zDifference * Time.deltaTime * _ySensitivity), transform.rotation.eulerAngles.z + (_zDifference * Time.deltaTime * _zSensitivity));
            Vector3 wheelTarget = new Vector3(0f, 0f, Handle.transform.localRotation.eulerAngles.z + (_zDifference * Time.deltaTime * _wheelSensitivity));

            if (target.y < _maxLeftYRotation)
                target.y = _maxLeftYRotation;

            intermediate = Quaternion.Lerp(transform.rotation, Quaternion.Euler(target), 10f * Time.deltaTime);
            intermediateHandle = Quaternion.Lerp(Handle.transform.localRotation, Quaternion.Euler(wheelTarget), 10f * Time.deltaTime);
        }

        _oldZ = transform.localPosition.z;
        transform.rotation = Quaternion.Lerp(intermediate, Quaternion.Euler(0f, 270f, 0f), _recoverSpeed * Time.deltaTime);
        Handle.transform.localRotation = Quaternion.Lerp(intermediateHandle, Quaternion.Euler(0f, 0f, 0f), _recoverSpeed * Time.deltaTime);
    }


    IEnumerator RotationTick()
    {

        for (int i = 0; i < Mathf.Infinity; i++)
        {
            //print(_zDifference);
            yield return new WaitForSeconds(Time.deltaTime);


            yield return new WaitForSeconds(Time.deltaTime);


        }
    }
}
