using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{

}
public interface IPlaceable
{
    public void Place();
    public bool CanBePlaced();
}

public interface IClickable
{
    public void OnPointer();
    public void OffPointer();
    public void OnClick();
}
