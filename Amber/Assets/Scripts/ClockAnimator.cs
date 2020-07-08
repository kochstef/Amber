using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour
{
  private const float
      hoursToDegrees = 360f / 12f,
      minutesToDegrees = 360f / 60f,
      secondsToDegrees = 360f / 60f,
      minutesHourToDegrees = 360f / 720f;


  [SerializeField]
  private Transform hours, minutes, seconds;


  //----------------------------------------------------------------------------
  void Update()
  {
    DateTime time = DateTime.Now;

    hours.localRotation = Quaternion.Euler(90f, 180f, -(time.Hour * hoursToDegrees) + 
                                           (time.Minute * minutesHourToDegrees));
    minutes.localRotation = Quaternion.Euler(90f, 180f, -time.Minute * minutesToDegrees);
    seconds.localRotation = Quaternion.Euler(90f, 180f, -time.Second * secondsToDegrees);
  }
}