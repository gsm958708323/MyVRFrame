//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEngine;
///// <summary>
///// 查看元数据
///// 使用反射可以查看特性（attribute）信息
///// </summary>

//[AttributeUsage(AttributeTargets.All)]
/////我的特性类
//sealed class MyAttribute : System.Attribute
//{
//    /*
//     *特性类，后缀以Attribute结尾
//     * 需要继承自System.Attribute
//     * 一般声明为sealed
//     * 一般情况下特性类用来表示目标结构的一些状态，定义一些字段，属性，不定义方法
//     */
//    public string Desctiption { get; set; }
//    public string VersionNumber { get; set; }
//    public int ID { get; set; }

//    //构造函数
//    public MyAttribute(string str)
//    {
//        this.Desctiption = str;
//    }
//}

//[My("有关MyClass类的信息")]
//class MyClass
//{
//    public string name1;
//    public string name2;
//    public string Name
//    {
//        get; set;
//    }

//    public void GetName()
//    {

//    }
//}

//[My("自定义特性类", ID = 111)]
//public class AttributeTest : MonoBehaviour
//{
//    private void Start()
//    {
//        //Fun2();

//        //Method1();
//        //Method2();
//        //Method1();

//        //Fun3("GSM");

//        Fun4();
//    }

//    void Fun4()
//    {
//        Type type = typeof(AttributeTest);
//        object[] objarr = type.GetCustomAttributes(false);//获取用户自定义的特性类

//        //获取本类使用到的特性
//        MyAttribute my = objarr[0] as MyAttribute;
//        Debug.LogWarning(my.Desctiption + " ID:" + my.ID);
//    }

//    static void Fun3(string str, [CallerFilePath] string fileName = "",
//        [CallerLineNumber]int lineNumber = 0,
//        [CallerMemberName]string methodName = "")
//    {
//        Debug.Log("用户输入的参数：" + str);
//        Debug.Log("调用的目录：" + fileName);
//        Debug.LogFormat("在第{0}行调用的", lineNumber);
//        Debug.LogFormat("在{0}方法中调用的", methodName);
//    }

//    [System.Diagnostics.Conditional("Method1")]
//    static void Method1()
//    {
//        Debug.Log("Method1");
//    }
//    [System.Diagnostics.Conditional("Method2")]
//    static void Method2()
//    {
//        Debug.Log("Method2");
//    }

//    void Fun2()
//    {
//        OldFun();
//    }
//    [Obsolete("此方法已经过时，请使用新NewFun")]
//    static void OldFun()
//    {
//        Debug.Log("Old");
//    }
//    static void NewFun()
//    {
//        Console.WriteLine("NewFun");
//    }

//    void Fun1()
//    {
//        MyClass myclass = new MyClass();
//        Type type = myclass.GetType();
//        var assembly = type.Assembly;
//        //获取共有字段
//        var fieldinfos = type.GetFields();
//        //获取类的属性
//        var properinfos = type.GetProperties();
//        //获取类的方法
//        var method = type.GetMembers();
//        foreach (var file in fieldinfos)
//        {
//            Debug.Log("共有字段：" + file);
//        }
//        foreach (var pro in properinfos)
//        {
//            Debug.Log("属性：" + pro);
//        }
//        foreach (var m in method)
//        {
//            Debug.Log("方法名称：" + m);
//        }
//        Debug.LogWarning("程序集：" + assembly);
//    }
//}