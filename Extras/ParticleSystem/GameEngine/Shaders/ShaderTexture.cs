﻿using System;
using System.Numerics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLFW;
using static GameEngine.OpenGL.GL;

namespace GameEngine
{
    class ShaderTextured
    {
        private string vertexCode;
        private string fragmentCode;
        public uint ProgramID { get; set; }

        public ShaderTextured()
        {
            vertexCode = @"#version 330 core 
 
                        // Input vertex data, different for all executions of this shader.
                        layout(location = 0) in vec3 vertexPosition_modelspace; 
                        layout(location = 1) in vec2 vertexUV; 
 
                        // Output data ; will be interpolated for each fragment. 
                        out vec2 UV; 
 
                        // Values that stay constant for the whole mesh.
                        uniform mat4 MVP; 
 
                        void main(){ 
 
                            // Output position of the vertex, in clip space : MVP * position
                            gl_Position = MVP * vec4(vertexPosition_modelspace,1); 
 
                            // UV of the vertex. No special space for this one. 
                            UV = vertexUV; 
                        }";

            fragmentCode = @"#version 330 core 
 
                            // Interpolated values from the vertex shaders
                            in vec2 UV; 
 
                            // Ouput data
                            out vec3 color;                    
                            // Values that stay constant for the whole mesh.
                            uniform sampler2D myTextureSampler; 
                            void main(){ 
                                // Output color = color of the texture at the specified UV
                                color = texture( myTextureSampler, UV ).rgb; 
                            }";
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
