using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GameLevelsLib
{
    public class GameLevelsType
    {
        public static void GameLevel(string getPath, string getType, string getMethod)
        {
            Assembly executingAssembly = Assembly.LoadFile(getPath);
            Type _levelsType = executingAssembly.GetType(getType);
            if (_levelsType != null || _levelsType.IsClass)
            {
                object _levelsTypeInstance = Activator.CreateInstance(_levelsType);
                
                MethodInfo _getMethodRef = _levelsType.GetMethod("getMethod");
                if (!_getMethodRef.IsStatic)
                {
                    if (getMethod == "Play")
                    {
                        object[] _parameters = new object[0];
                        string play = (string)_getMethodRef.Invoke(_levelsTypeInstance, _parameters);
                        Console.WriteLine($"{play} started, Level:Basic ");
                    }
                    if (getMethod == "Begin")
                    {
                        object[] _parameters = new object[1];
                        _parameters[0] = "sumanth";
                        string begin = (string)_getMethodRef.Invoke(_levelsTypeInstance, _parameters);
                        Console.WriteLine($"{begin} started, Level:Intermediate ");
                    }
                    if (getMethod == "Start")
                    {
                        object[] _parameters = new object[2];
                        _parameters[0] = "sumanth";
                        _parameters[1] = "619";
                        string start = (string)_getMethodRef.Invoke(_levelsTypeInstance, _parameters);
                        Console.WriteLine($"{start} started, Level:Advanced ");
                    }
                }
            }
        }
       
    }
    
}
