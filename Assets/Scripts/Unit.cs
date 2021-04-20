using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IEquatable<Unit>, IComparable<Unit> {
    public string unitName;
    public int Damage;
    public int Speed;

    public int maxHealth;
    public int currentHealth;

    public int action;

    public int CompareTo(Unit compareUnit) {
        if (compareUnit == null)
            return 1;

        else
            return this.Speed.CompareTo(compareUnit.Speed);
    }

    public override bool Equals(object other) {
        if (other == null) return false;
        Unit objAsPart = other as Unit;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }

    public bool Equals(Unit other) {
        if (other == null) return false;
        return (this.Speed.Equals(other.Speed));
    }

    public override int GetHashCode() {
        return Speed;
    }


    public bool takeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            currentHealth = 0;
            return true;
        } else {

            return false;
        }
    }

}
