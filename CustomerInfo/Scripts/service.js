function GetCustomers() {
    $.ajax({
        url: "Service/CustomerInfoService.svc/GetCustomers",
        type: "GET",
        dataType: "json",
        success: function (result) {
            members = result;
            drawMemberTable(result);
            console.log(result);
        }
    });
}

function AddCustomer() {

    var newCustomer = {
        "FirstName": $("#addFirstname").val(),
        "LastName": $("#addLastname").val(),
        "MemberName": $("#addMembername").val(),
        "PlaceOfBirth": $("#addPlaceOfBirth").val(), 
        "Gender": $("#addGender").val(),
        "Points": $("#addPoints").val()
    };

    $.ajax({
        url: "Service/CustomerInfoService.svc/AddCustomer",
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(newCustomer),        
        success: function () {                  
            showOverview();
        }, 
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        },
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
    });
}


function UpdateCustomer() {
    updateMember.FirstName = $("#updateFirstname").val();
    updateMember.LastName = $("#updateLastname").val();
    updateMember.MemberName = $("#updateMembername").val();
    updateMember.PlaceOfBirth = $("#updatePlaceOfBirth").val();
    updateMember.Gender = $("#updateGender").val();
    updateMember.Points = $("#updatePoints").val(); 

    $.ajax({
        url: "Service/CustomerInfoService.svc/UpdateCustomer/" + updateMember.Id,
        type: "PUT",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(updateMember),
        success: function () {
            showOverview();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        },
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
    });
}


function DeleteCustomer(customerId) {
    $.ajax({
        url: "Service/CustomerInfoService.svc/DeleteCustomer/" + customerId,
        type: "DELETE",
        dataType: "json",
        success: function (result) {
            GetCustomers();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        },
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
    });
}


function SearchCustomer() {
    var serachText = $("#searchText").val();
    
    $.ajax({
        url: "Service/CustomerInfoService.svc/SearchCustomer/" + serachText,
        type: "GET",
        dataType: "json",  
        success: function (result) {
            members = result;
            console.log(result);
            drawMemberTable(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log("The error message is " + thrownError);
            $("#customerOverview").html(thrownError);
        }
        //statusCode: {
        //    404: function () {
        //        alert("page not found");
        //    }
        //}
    });
}



function sortedMemberList(type) { 
    $.ajax({
        url: "Service/CustomerInfoService.svc/GetSortedCustomerList/" + type,
        type: "GET",
        dataType: "json",
        success: function (result) {           
            drawMemberTable(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log("The error message is " + thrownError);
        },
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
    });
}

function winner() {
    var id1 = $("#member1").val();
    var id2 = $("#member2").val();

    $.ajax({
        url: "Service/CustomerInfoService.svc/Team/" + id1 + "/" + id2,
        type: "GET",
        dataType: "json",
        success: function (result) {
            $("#countResult").html(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log("The error message is " + thrownError);
        },
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
    });
}
