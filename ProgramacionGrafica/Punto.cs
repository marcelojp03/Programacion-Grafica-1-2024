using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Punto
    {
        //[JsonProperty("x")]
        public float x { get; set; }
        //[JsonProperty("y")]
        public float y { get; set; }
        //[JsonProperty("z")]
        public float z { get; set; }
        public Punto(float x, float y, float z)
        {
            this.x= x;
            this.y= y;
            this.z= z;
        }
        public Punto RotateY(float angle)
        {
            // Rotate around the y-axis using a rotation matrix

            //Matrix3 matriz=Matrix3.CreateRotationY(angle);
            //Vector3 vector3 = Vector3.Transform(new Vector3(this.x,this.y,this.z),matriz);
            //return new Punto(vector3.X, vector3.Y, vector3.Z);
            Matrix4 rotationMatrix = Matrix4.CreateRotationY(angle);
            Vector4 rotatedVector = Vector4.Transform(new Vector4(this.x, this.y, this.z, 1), rotationMatrix);
            return new Punto(rotatedVector.X, rotatedVector.Y, rotatedVector.Z);
        }
        public Punto RotateX(float angle)
        {
            // Rotate around the y-axis using a rotation matrix

            Matrix4 rotationMatrix = Matrix4.CreateRotationX(angle);
            Vector4 rotatedVector = Vector4.Transform(new Vector4(this.x, this.y, this.z, 1), rotationMatrix);
            return new Punto(rotatedVector.X, rotatedVector.Y, rotatedVector.Z);
        }
        public Punto RotateZ(float angle)
        {
            // Rotate around the y-axis using a rotation matrix
            Matrix4 rotationMatrix = Matrix4.CreateRotationZ(angle);
            Vector4 rotatedVector = Vector4.Transform(new Vector4(this.x, this.y, this.z, 1), rotationMatrix);
            return new Punto(rotatedVector.X, rotatedVector.Y, rotatedVector.Z);
        }
        public Punto Scale(float sx, float sy, float sz)
            // Scale using a scaling matrix
        {
            Matrix4 scalingMatrix = Matrix4.CreateScale(sx, sy, sz);
            Vector4 scaledVector = Vector4.Transform(new Vector4(this.x, this.y, this.z, 1), scalingMatrix);
            return new Punto(scaledVector.X, scaledVector.Y, scaledVector.Z);
        }

        public Punto Translate(float dx, float dy, float dz)
        {
            // Translate using a translation matrix
            Matrix4 translationMatrix = Matrix4.CreateTranslation(dx, dy, dz);
            Vector4 translatedVector = Vector4.Transform(new Vector4(this.x, this.y, this.z, 1), translationMatrix);
            return new Punto(translatedVector.X, translatedVector.Y, translatedVector.Z);
        }
    }
}
