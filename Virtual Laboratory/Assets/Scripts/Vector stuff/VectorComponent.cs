﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorComponent : MonoBehaviour {
// DESCRIPTION - Base class for Vector Component related game objects. 
// Anything that wants to be displayed as a 3D Vector will use this class.
// REMEMBER! - Assign the vector 3d model to each object you assign this class to!

  private string _name;
  private string _units;
  private Transform _origin;
  private Vector3 _components;
  private GameObject _this;
  private LineRenderer _lineRenderer;
  private float _initialScaleMagnitude; // The initial scale magnitude of the vector model

  public GameObject VectorModel;

  //ACCESSORS
  // Vector Name
  public void SetVectorName(string newName)
  {
    _name = newName;
  }
  public string GetVectorName()
  {
    return _name;
  }
  // Vector Units
  public void SetVectorUnits(string newUnits) {
    _units = newUnits;
  }
  public string GetVectorUnits() {
    return _units;
  }
  // Vector Origin
  public void SetVectorOrigin(Transform newOrigin) {
    _origin = newOrigin;
  }
  public Transform GetVectorOrigin() {
    return _origin;
  }
  // Vector Components
  public void SetVectorComponents(Vector3 newComponents) {
    _components = newComponents;
  }
  public Vector3 GetVectorComponents() {
    return _components;
  }



  public void NewVector()
  {
    _name = "";
    _units = "";
    _origin = GetComponent<Transform>();
    _components = new Vector3(0.0f, 0.0f, 1.0f);
    _this = Instantiate(VectorModel, _origin);
  }

  public void UpdateVectorComponents(Transform newOrigin, Vector3 newComponents)
  {
    _origin = newOrigin;
    _this.transform.position = newOrigin.position;
    Vector3 differenceVector = newComponents - newComponents.normalized;
    differenceVector = new Vector3(differenceVector.x * _initialScaleMagnitude, differenceVector.y * _initialScaleMagnitude, differenceVector.z * _initialScaleMagnitude);
    _this.transform.localScale = differenceVector;
  }

}