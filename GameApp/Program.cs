using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    //Named Constants
    //Constant Value is - int
    public enum Options
    {
        BASIC=1,INTERMEDIATE,ADVANCED
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Guess Game");
            
            string message = string.Format("Enter Your Choice {0}->Basic , {1}->Intermediate ,{2}->Advanced",Options.BASIC,Options.INTERMEDIATE,Options.ADVANCED);// 1->Basic,2->Intermediate
            //String Interpollation 
            string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
            Console.WriteLine(displayMessage);
            try
            {
                int attempts = 1;
                bool Option = false;
                Options _choice = (Options)Int32.Parse(Console.ReadLine());
                while (attempts <= 3 && Option == false)
                {
                    
                    int number = Convert.ToInt32(Option);
                    attempts++;
                    if (number = Option)
                    {

                        Option = true;
                        Console.WriteLine("Game started");
                    }

                    //if incorrect Option entered

                    else if (number != Option)
                    {
                        Console.WriteLine("Incorrect option");
                    }
                    else if (attempts > 3)
                    {
                        Console.WriteLine("Goodbye");

                    }



                    switch (_choice)
                    {
                      
                        case Options.BASIC:

                            Console.WriteLine("Basic Level");


                            //Use Reflection  
                            //Assembly Load
                            System.Reflection.Assembly basicLevelLib =
                            System.Reflection.Assembly.LoadFile(@"F:\c# training\latebinding-using-reflection-sumanthrshivu-main\GameApp\bin\Debug\LevelLibs\BasicLevelLib.dll");
                            // Search For Class - BasicLevelType
                            System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                            if (basicLevelTypeClassRef != null)
                            {
                                if (basicLevelTypeClassRef.IsClass)
                                {
                                    //Instantiate Type
                                    //BasicLevelLib.BasicLevelType objref=new BasicLevelLib.BasicLevelType() ; Early Binding
                                    Object objRef = System.Activator.CreateInstance(basicLevelTypeClassRef); //LateBinding Code
                                                                                                             //Discove Method
                                    System.Reflection.MethodInfo _methodRef = basicLevelTypeClassRef.GetMethod("Play");
                                    if (!_methodRef.IsStatic)
                                    {
                                        //Invoke NonStatic Method
                                        // string Play(string playerName, int earlierPoints){}
                                        //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                        object result = _methodRef.Invoke(objRef, new object[] { });
                                        Console.WriteLine(result.ToString());
                                    }

                                }

                            }
                            break;
                        case Options.INTERMEDIATE:
                            Console.WriteLine("Intermediate Level");
                            System.Reflection.Assembly intermediateLevelLib = new System.Reflection.Assembly.LoadFile(@"F:\c# training\latebinding-using-reflection-sumanthrshivu-main\GameApp\bin\Debug\LevelLibs\IntermediateLevelLib.dll");
                            System.Type intermedaiteLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                            if (intermedaiteLevelTypeClassRef != null)
                            {
                                if (intermedaiteLevelTypeClassRef.IsClass)
                                {
                                    //Instantiate Type
                                    //IntermediateLevelLib.IntermediateLevelType objref=new IntermediateLevelLib.IntermediateLevelType() ; Early Binding
                                    Object objRef = System.Activator.CreateInstance(intermedaiteLevelTypeClassRef); //LateBinding Code
                                                                                                                    //Discove Method
                                    System.Reflection.MethodInfo _methodRef = intermedaiteLevelTypeClassRef.GetMethod("Begin");
                                    if (!_methodRef.IsStatic)
                                    {
                                        //Invoke NonStatic Method
                                        // string Play(string playerName, int earlierPoints){}
                                        //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                        object result = _methodRef.Invoke(objRef, new object[] { "suhas" });
                                        Console.WriteLine(result.ToString());
                                    }

                                }

                            }
                            break;

                        case Options.ADVANCED:
                            Console.WriteLine("Advanced Level");
                            System.Reflection.Assembly advancedLevelLib = new System.Reflection.Assembly.LoadFile(@"F:\c# training\latebinding-using-reflection-sumanthrshivu-main\GameApp\bin\Debug\LevelLibs\AdvancedLevelLib.dll");
                            System.Type advacncedLevelTypeClassRef = advancedLevelLib.GetType("advancedLevelLib.advancedLevelType");
                            if (advacncedLevelTypeClassRef != null)
                            {
                                if (advacncedLevelTypeClassRef.IsClass)
                                {
                                    //Instantiate Type
                                    //advancedLevelLib.advancedLevelType objref=new advancedLevelLib.advancedLevelType() ; Early Binding
                                    Object objRef = System.Activator.CreateInstance(advacncedLevelTypeClassRef); //LateBinding Code
                                                                                                                 //Discove Method
                                    System.Reflection.MethodInfo _methodRef = advacncedLevelTypeClassRef.GetMethod("Start");
                                    if (!_methodRef.IsStatic)
                                    {
                                        //Invoke NonStatic Method
                                        // string Play(string playerName, int earlierPoints){}
                                        //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                        object result = _methodRef.Invoke(objRef, new object[] { "karthik", 300 });
                                        Console.WriteLine(result.ToString());
                                    }

                                }

                            }
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new IndexOutOfRangeException("please select the valid number " + ex);
            }
            finally{ }

        }
    }
}
