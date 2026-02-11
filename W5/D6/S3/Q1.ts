// index.html


<!DOCTYPE html>
<html>
<head>
   
</head>
<body>
   <h1>Library Management System</h1>
   <div id ="bookGrid">
    <div class = "box">
        <p> 1984 by George Orwell</p>
        <p> is borrowed <span id="sp0"></span></p>
        <div class ="grid">
            <button Id = "borrowButton-0" class="borrow">Borrow</button>
            <button Id = "returnButton-0" class="return">Return</button>
        </div>
    </div>
<div class ="box">
    <p> To Kill Some Bird</p>
    <p> Is Borrowed: <span Id ="sp1"></span></p>
    <div class = "grid">
        <button Id = "borrowButton-1" class="borrow">Borrow</button>
        <button Id = "returnButton-1" class="return">Return</button>
    </div>
</div>
<div class ="box">
    <p> The Great Gatsby</p>
    <p> Is borrowed: <span Id ="sp2"></span></p>
    <div class = "grid">
        <button Id = "borrowButton-2" class="borrow">Borrow</button>
        <button Id = "returnButton-2" class="return">Return</button>
    </div>
</div>
</div>
</div>
<script src ="script.js"></script>
</body>
</html>





 //script.ts

  document.getElementById("borrowButton-0").addEventListener("click", (e)=>{
    document.getElementById("sp0").innerHTML = "True";
    let a =<HTMLInputElement>document.getElementById("returnButton-0");
    a.disabled = false;
    let b =<HTMLInputElement>document.getElementById("borrowButton-0");
    b.disabled = true;

});

document.getElementById("borrowButton-1").addEventListener("click", (e)=>{
    document.getElementById("sp1").innerHTML = "True";
    let a =<HTMLInputElement>document.getElementById("returnButton-1");
    a.disabled = false;
    let b =<HTMLInputElement>document.getElementById("borrowButton-1");
    b.disabled = true;

});
document.getElementById("borrowButton-2").addEventListener("click", (e)=>{
    document.getElementById("sp2").innerHTML = "True";
    let a =<HTMLInputElement>document.getElementById("returnButton-2");
    a.disabled = true;
    let b =<HTMLInputElement>document.getElementById("borrowButton-2");
    b.disabled = false;

});
document.getElementById("returnButton-0").addEventListener("click", (e)=>{
    document.getElementById("sp0").innerHTML = "True";
    let a =<HTMLInputElement>document.getElementById("returnButton-0");
    a.disabled = true;
    let b =<HTMLInputElement>document.getElementById("borrowButton-0");
    b.disabled = false;

});
document.getElementById("returnButton-1").addEventListener("click", (e)=>{
    document.getElementById("sp1").innerHTML = "True";
    let a =<HTMLInputElement>document.getElementById("returnButton-1");
    a.disabled = true;
    let b =<HTMLInputElement>document.getElementById("borrowButton-1");
    b.disabled = false;

});
document.getElementById("returnButton-2").addEventListener("click", (e)=>{
    document.getElementById("sp2").innerHTML = "True";
    let a =<HTMLInputElement>document.getElementById("returnButton-2");
    a.disabled = true;
    let b =<HTMLInputElement>document.getElementById("borrowButton-2");
    b.disabled = false;

});







  // 
