using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

public class UnitConverter{
    public double Convert(double value, string fromUnit, string toUnit){
        if(fromUnit=="meters" && toUnit=="Kilometers"){
            return value*0.001;
        }
        else if (fromUnit=="Kilometers"&& toUnit=="meters"){
            return value*1000;
        }
        else if(fromUnit=="miles" && toUnit=="feet"){
            return value*5280;
        }
        else if(fromUnit=="feet" && toUnit=="miles"){
            return value*(1.0/5280);
        }
        else if(fromUnit=="grams" && toUnit=="kilograms"){
            return value*0.001;
        }
        else if(fromUnit=="kilograms" && toUnit=="grams"){
            return value*1000;
        }

        else if(fromUnit=="pounds" && toUnit=="ounces"){
            return value*(16);
        }

        else if (fromUnit=="ounces" && toUnit=="pounds"){
            return value*(1.0/16);
        }

        else if(fromUnit=="celsius" && toUnit=="fahrenheit"){
            return (value*9/5)+32;
        }

        else if (fromUnit=="fahrenheit" && toUnit=="celsius"){
            return (value-32)*5/9;
        }
        else if (fromUnit=="celsius" && toUnit=="kelvin"){
            return value+273.15;
        }
        else if (fromUnit=="kelvin" && toUnit=="celsius"){
            return value-273.15;
        }
        else{
            return value;
        }
    } 
    

    public double Convert(double value, string fromUnit){
        Program.to=Program.GetDefaultUnit(Program.uType);
        string toUnit=Program.to;
        if(fromUnit=="meters" && toUnit=="kilometers"){
            return value*0.001;
        }
        else if(fromUnit=="kilometers" && toUnit=="meters"){
            return value*1000;
        }
        else if(fromUnit=="miles" && toUnit=="feet"){
            return value*5280;
        }
        else if(fromUnit=="feet" && toUnit=="miles"){
            return value*(1.0/5280);
        }
        else if(fromUnit=="grams" && toUnit=="kilograms"){
            return value*0.001;
        }
        else if(fromUnit=="kilograms" && toUnit=="grams"){
            return value*1000;
        }

        else if(fromUnit=="pounds" && toUnit=="ounces"){
            return value*(16);
        }

        else if (fromUnit=="ounces" && toUnit=="pounds"){
            return value*(1.0/16);
        }

        else if(fromUnit=="celsius" && toUnit=="fahrenheit"){
            return (value*9/5)+32;
        }

        else if (fromUnit=="fahrenheit" && toUnit=="celsius"){
            return (value-32)*5/9;
        }
        else if (fromUnit=="celsius" && toUnit=="kelvin"){
            return value+273.15;
        }
        else if (fromUnit=="kelvin" && toUnit=="celsius"){
            return value-273.15;
        }
        else{
            return value;
        }
    }
}

public class Program
{
    public static string uType{get;set;}
    public static string to{get;set;}
    public static void Main(string[] args)
    {
        uType=Console.ReadLine();
        double value=double.Parse(Console.ReadLine());
        string from=Console.ReadLine();
        to=Console.ReadLine();
        UnitConverter u=new UnitConverter();
        double valueCon=0.0;
        if(string.IsNullOrEmpty(to)||string.IsNullOrWhiteSpace(to)){
            valueCon=u.Convert(value,from);
        }
        else{
            valueCon=u.Convert(value,from,to);
        }

        Console.WriteLine($"{value} {from} is {valueCon:F2} {to}.");
    }
    public static string GetDefaultUnit(string type){
        string toUnit="";
        switch(type.ToLower()){
            case "length":
                toUnit="meters";
                break;
            case "weight":
                toUnit="kilograms";
                break;
            case "temperature":
                toUnit="celsius";
                break;
            default:
                break;
        }
        return toUnit;
    }
}
