Ques 2 index.html=>  <!DOCTYPE html>
<html lang="en">
<head>
    <link href="styles.css">
</head>
<body>
   <div>
      <h1>BMI Calculator</h1>
      <form id="bmi-form">
        <label for="gender">Gender:</label>
        <select id="gender">
            <option>Select Gender</option>
            <option value="Male">Male</option>
            <option value="Female">Female</option>
        </select>
        <br>
 
        <label for="weight">Weight (kg):</label>
        <input id="weight">
        <br>
 
        <label for="height">Height (cm):</label>
        <input id="height">
        <br>
 
        <button type="button" onclick="calculateBMI()">Calculate</button>
      </form>
      <p id="result" class="result">Please fill out all fields.</p>
   </div>
   <script src="script.js"></script>
</body>
</html>
 
 
script.js=>  function calculateBMI()
{
    let genderSe= document.getElementById("gender");
 
    let weight= parseInt(document.getElementById("weight").value);
    let height= parseInt(document.getElementById("height").value)
 
    height= height/100;
 
    let bmi= weight/(height*height);
    let resultLab= document.getElementById("result");
 
    let bmiText;
    let flag= true;
    bmi= parseFloat(bmi).toFixed(2);
 
    if(bmi<18.5)
    {
        bmiText="Underweight";
        resultLab.style.color="blue";
    }
    else if(bmi>=18.5 && bmi<24.9)
    {
        bmiText="Normal weight";
        resultLab.style.color="green";
    }
    else if(bmi>=25 && bmi<29.9)
    {
        bmiText="Overweight";
        resultLab.style.color="orange";
    }
    else if(bmi>=30)
    {
        bmiText="Obese";
        resultLab.style.color="red";
    }
    else
    {
        flag=false;
    }
 
    let resText=`Your BMI is ${bmi} (${bmiText}).<br>
                  For men, a BMI between 18.5 and 24.9 is considered healthy.`;
 
    if(flag)
    {
        resultLab.innerHTML=resText;
    }
}
 
