using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ChargeBar : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    private PlayerInputActions _input;

    private bool _isCharging = false;

    void Start()
    {
        _input = new PlayerInputActions();
        _input.ChargeBar.Enable();

        _input.ChargeBar.Charging.started += Charging_started;
        _input.ChargeBar.Charging.canceled += Charging_canceled;
    }

    private void Charging_started(InputAction.CallbackContext context)
    {
        _isCharging = true;
        StartCoroutine(ChargingRoutine());
    }

    private void Charging_canceled(InputAction.CallbackContext context)
    {
        _isCharging = false;
    }
    IEnumerator ChargingRoutine()
    {
        while (_isCharging == true)
        {
            _slider.value += (1 * Time.deltaTime)/3;
            yield return null;
        }
        while (_slider.value > 0)
        {
            _slider.value -= (1 * Time.deltaTime)/3;
            yield return null;
        }
       
    }
}
