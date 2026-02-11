// index.html

<!DOCTYPE html>
<html>
<head>
   
</head>
<body>
    <h1>array operations</h1>
    <div>
        <label>Enter Number 1 <span style="color: red;"></span></label>
        <Input type="number" name ="num1" id="num1">
    </div>
    <div>
        <label>Enter Number 2 <span style="color: red;"></span></label>
        <Input type="number" name ="num2" id="num2">
    </div>
    <div>
        <label>Enter Number 3 <span style="color: red;"></span></label>
        <Input type="number" name ="num3" id="num3">
    </div>
    <div>
        <label>Enter Number 4 <span style="color: red;"></span></label>
        <Input type="number" name ="num4" id="num4">
    </div>
    <div>
        <label>Enter Number 5 <span style="color: red;"></span></label>
        <Input type="number" name ="num5" id="num5">
    </div>
    <button id="calculateButton" onclick="calculate()">Calculate</button>
    <div id ="result">
        <p id ="errorMessage" style="color: red;"></p>
    </div>
        
    <div id ="maximumNo">
        <span id ="sp1"></span>
    </div>

    <div id ="minimumNo">
        <span id ="sp2"></span>
    </div>

    <div id ="sumOfAllNumbers">
        <span id ="sp3"></span>
    </div>
    
    <script src = "script.js"></script>


</body>
</html>





  // script.ts


  function calculate()
{
    var num1 = Number((<HTMLInputElement>document.getElementById("num1")).value);
    var num2 = Number((<HTMLInputElement>document.getElementById("num2")).value);
    var num3 = Number((<HTMLInputElement>document.getElementById("num3")).value);
    var num4 = Number((<HTMLInputElement>document.getElementById("num4")).value);
    var num5 = Number((<HTMLInputElement>document.getElementById("num5")).value);

    var numArr:number[] = [num1, num2, num3, num4, num5];
    if(!num1 || !num2 || !num3 || !num4 || !num5)
    {
        document.getElementById("errorMessage").innerHTML = "enter all the numbers";
        return;
    }
    let maxNum: number = MaxNumber(numArr);
    let minNum: number = MinNumber(numArr);
    let sum: number = Sum(numArr);

    document.getElementById("sp1").innerHTML = "Maximum number:"+maxNum.toString();
    document.getElementById("sp2").innerHTML = "Minimum number:"+minNum.toString();
    document.getElementById("sp3").innerHTML = "Sum of all numbers:"+sum.toString();
}
function MaxNumber(arr:number[]): number
    {
        let maxValue = Math.max(arr[0],arr[1],arr[2],arr[3],arr[4])
         return maxValue;
    }
    function MinNumber(arr:number[]): number
    {
        let minValue = Math.min(arr[0],arr[1],arr[2],arr[3],arr[4])
         return minValue;
    }
    function Sum(arr:number[]): number
    {
        var sumOfEven = 0;
        arr.forEach(e=>
            {
                sumOfEven +=e;
            });
            return sumOfEven;
    }
