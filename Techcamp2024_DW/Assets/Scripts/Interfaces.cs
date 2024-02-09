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
