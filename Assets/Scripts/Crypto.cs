using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Ballgame
{
    public class Crypto
    {
        public string Encript(string text, int key = 42)
        {
            StringBuilder strBuilder = new();
            foreach(char ch in text)
            {
                strBuilder.Append((char)(ch ^ key));
            }
            return strBuilder.ToString();
        }
    }
}
