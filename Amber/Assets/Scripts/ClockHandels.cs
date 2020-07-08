using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockHandels : MonoBehaviour
{
  private const float
    hoursToDegrees = 360f / 12f,
    minutesToDegrees = 360f / 60f,
    secondsToDegrees = 360f / 60f;
  float AccuSecond = 0;
  public Transform Hours, Minutes, Seconds;
  public Transform Handle01, Handle02, Handle03, Handle04, Handle05, Handle06, Handle07, Handle08;


  //----------------------------------------------------------------------------
  void Update()
  {
    DateTime time = DateTime.Now;
    AccuSecond = AccuSecond + Time.deltaTime;
    //Hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
    //Minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
    //Seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    Hours.localRotation = Quaternion.Euler(-90f, 0f, time.Hour * hoursToDegrees);
    Minutes.localRotation = Quaternion.Euler(-90f, 0f, time.Minute * minutesToDegrees);
    Seconds.localRotation = Quaternion.Euler(-90f, 0f, time.Second * secondsToDegrees);
    Handle01.localRotation = Quaternion.Euler(-90f, 0f, time.Second * -secondsToDegrees);
    Handle02.localRotation = Quaternion.Euler(-90f, 0f, time.Second * secondsToDegrees);
    Handle03.localRotation = Quaternion.Euler(-90f, 0f, AccuSecond * -secondsToDegrees);
    Handle04.localRotation = Quaternion.Euler(-90f, 0f, AccuSecond * secondsToDegrees);
    Handle05.localRotation = Quaternion.Euler(-90f, 0f, AccuSecond * -secondsToDegrees);
    Handle06.localRotation = Quaternion.Euler(-90f, 0f, time.Second * secondsToDegrees);
    Handle07.localRotation = Quaternion.Euler(-90f, 0f, AccuSecond * -secondsToDegrees);
    Handle08.localRotation = Quaternion.Euler(-90f, 0f, time.Second * -secondsToDegrees);
  }
}
