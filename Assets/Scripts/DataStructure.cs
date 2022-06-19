using System;
using UnityEngine;

namespace Ballgame
{
    [Serializable]
    public struct SVect3
    {
        public float X;
        public float Y;
        public float Z;

        public SVect3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static implicit operator SVect3(Vector3 value)
        {
            return new SVect3(value.x, value.y, value.z);
        }
        public static implicit operator Vector3(SVect3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
    }

    [Serializable]
    public struct SQuater
    {
        public float X;
        public float Y;
        public float Z; 
        public float W;


        public SQuater(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public static implicit operator SQuater(Quaternion value)
        {
            return new SQuater(value.x, value.y, value.z, value.w);
        }
        public static implicit operator Quaternion(SQuater value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }
    }

    [Serializable]
    public struct SObject
    {
        public string Name;
        public SVect3 Position;
        public SQuater Rotation;
        public SVect3 Scale;
    }
}
