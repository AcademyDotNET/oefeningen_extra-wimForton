using System;
using System.Numerics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLFW;
using static Glfw3Dapp.OpenGL.GL;

namespace Glfw3Dapp.Rendering.Shaders
{
    class Shader
    {
        string vertexCode;
        string fragmentCode;
        public uint ProgramID { get; set; }

        public Shader(string inVertexCode, string inFragmentCode)
        {
            vertexCode = inVertexCode;
            fragmentCode = inFragmentCode;
        }
        public void Load()
        {

            uint vs, fs;
            vs = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(vs, vertexCode);
            glCompileShader(vs);
            int[] status = glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if(status[0] == 0)
            {
                //failed to compile
                string error = glGetShaderInfoLog(vs);
                Debug.WriteLine("error compiling vertex shader" + error);
            }

            fs = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(fs, fragmentCode);
            glCompileShader(fs);
            status = glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                //failed to compile
                string error = glGetShaderInfoLog(vs);
                Debug.WriteLine("error compiling vertex shader" + error);
            }
            //use our shader in the program
            ProgramID = glCreateProgram();
            glAttachShader(ProgramID, vs);
            glAttachShader(ProgramID, fs);

            glLinkProgram(ProgramID);

            //delete shaders (we don't need them anymore)
            glDetachShader(ProgramID, vs);
            glDetachShader(ProgramID, fs);
            glDeleteShader(vs);
            glDeleteShader(fs);
        }
        public void Use()
        {
            glUseProgram(ProgramID);
        }
        public void SetMatrix4x4(string uniformName, Matrix4x4 mat)
        {
            int location = glGetUniformLocation(ProgramID, uniformName);
            glUniformMatrix4fv(location, 1, false, GetMatrix4x4Values(mat));
        }

        private float[] GetMatrix4x4Values(Matrix4x4 m)
        {
            return new float[]
            {
        m.M11, m.M12, m.M13, m.M14,
        m.M21, m.M22, m.M23, m.M24,
        m.M31, m.M32, m.M33, m.M34,
        m.M41, m.M42, m.M43, m.M44
            };
        }
    }
}
