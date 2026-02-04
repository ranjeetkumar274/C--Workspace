// Create.cshtml

@model List<Employee>

    <h2>Employee List</h2>
    <a asp-action="create" class="btn btn-primary">Create New Employee</a>
    <table class="table">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Email</th>
                <th>Date of Birth</th>
                <th>Department</th>
                <th>Salary</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            @foreach(var i in Model){
                <tr>
                    <td>@i.Id</td>
                    <td>@i.Name</td>
                    <td>@i.Email</td>
                    <td>@i.Dob.ToShortDateString()</td>
                    <td>@i.Dept</td>
                    <td>@i.Salary</td>
                    <td>
                        <a asp-action="Details" asp-route-id="@i.Id">Details</a>
                        <a asp-action="Edit" asp-route-id="@i.Id">Edit</a>
                        <a asp-action="Delete" asp-route-id="@i.Id">Delete</a>
                    </td>
                </tr>
            }
        </tbody>
    </table>




// Delete.cshtml

@model Employees.Models.Employee
<h1>Delete Employee</h1>
<div>
    <h4>Id: @Model.Id</h4>
    <h4>Name: @Model.Name</h4>
    <h4>Email: @Model.Email</h4>
    <h4>Date of Birth: @Model.Dob.ToShortDateString()</h4>
    <h4>Department: @Model.Dept</h4>
    <h4>Salary: @Model.Salary</h4></div>
<form asp-action ="Delete" asp-route-id="@Model.Id" method="post">
    <button type="submit">Delete</button>
    <a asp-action="Index">Back to List</a>
</form>    


// Details.cshtml

@model Employees.Models.Employee
<h1>Delete Employee</h1>

<div>
    <h4>Id: @Model.Id</h4>
    <h4>Name: @Model.Name</h4>
    <h4>Email: @Model.Email</h4>
    <h4>Date of Birth: @Model.Dob.ToShortDateString()</h4>
    <h4>Department: @Model.Dept</h4>
    <h4>Salary: @Model.Salary</h4>
</div>
<form asp-action="Delete" asp-route-id="Model.Id" method="post">
    <button type="submit">Delete</button>
    <a asp-action="Index">Back to List</a>
</form>


//Create.cshtml

@model Employees.Models.Employee

<h1>Create New Employees</h1>

<form asp-action="Create">
    <div>
        <label asp-for="Name"></label>
        <input asp-for="Name" class="form-control"/>
        <span asp-validation-for="Name" class ="text-danger"></span>
    </div>

    <div>
        <label asp-for="Email"></label>
        <input asp-for="Email" class="form-control"/>
        <span asp-validation-for="Email" class ="text-danger"></span>
    </div>

    <div>
        <label asp-for="Dob"></label>
        <input asp-for="Dob" class="form-control"/>
        <span asp-validation-for="Dob" class ="text-danger"></span>
    </div>

    <div>
        <label asp-for="Dept"></label>
        <input asp-for="Dept" class="form-control"/>
        <span asp-validation-for="Dept" class ="text-danger"></span>
    </div>

    <div>
        <label asp-for="Salary"></label>
        <input asp-for="Salary" class="form-control"/>
        <span asp-validation-for="Salary" class ="text-danger"></span>
    </div>

    <button type="submit" class="btn btn-primary">Create</button>

</form>


// Edit.cshtml@model Employees.Models.Employee
@model Employees.Models.Employee

<form asp-action="Edit">
    <input type="hidden" asp-for="Id"/>

    <div>
        <label asp-for="Name"></label>
        <input asp-for="Name"/>
        <span asp-validation-for="Name"></span>
    </div>

    <div>
        <label asp-for="Email"></label>
        <input asp-for="Email"/>
        <span asp-validation-for="Email" class="text-danger"></span>
    </div>

    <div>
        <label asp-for="Dob"></label>
        <input asp-for="Dob"/>
        <span asp-validation-for="Dob"  class="text-danger"></span>
    </div>

    <div>
        <label asp-for="Dept"></label>
        <input asp-for="Dept"/>
        <span asp-validation-for="Dept"  class="text-danger"></span>
    </div>

    <div>
        <label asp-for="Salary"></label>
        <input asp-for="Salary"/>
        <span asp-validation-for="Salary"  class="text-danger"></span>
    </div>
    <button type="submit" class ="btn btn-primary">Save</button>
</form>

// Index.cshtml

@model List<Employee>

    <h2>Employee List</h2>
    <a asp-action="create" class="btn btn-primary">Create New Employee</a>
    <table class="table">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Email</th>
                <th>Date of Birth</th>
                <th>Department</th>
                <th>Salary</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            @foreach(var i in Model){
                <tr>
                    <td>@i.Id</td>
                    <td>@i.Name</td>
                    <td>@i.Email</td>
                    <td>@i.Dob.ToShortDateString()</td>
                    <td>@i.Dept</td>
                    <td>@i.Salary</td>
                    <td>
                        <a asp-action="Details" asp-route-id="@i.Id">Details</a>
                        <a asp-action="Edit" asp-route-id="@i.Id">Edit</a>
                        <a asp-action="Delete" asp-route-id="@i.Id">Delete</a>
                    </td>
                </tr>
            }
        </tbody>
    </table>



