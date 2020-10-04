var members = {};
var updateMember = null;

function drawMemberTable(memberList) {
    $tbody = $("#table-body");
    $tbody.empty();
    for (var i = 0; i < memberList.length; i++) {
        $tr = $("<tr>");
        $("<td>").html(memberList[i].FirstName).appendTo($tr);
        $("<td>").html(memberList[i].LastName).appendTo($tr);
        $("<td>").html(memberList[i].MemberName).appendTo($tr);
        $("<td>").html(memberList[i].PlaceOfBirth).appendTo($tr);
        $("<td>").html(memberList[i].Gender).appendTo($tr);
        $("<td>").html(memberList[i].Points).appendTo($tr);
        $("<td>").appendTo($tr).append("<button onclick='editMember(" + memberList[i].Id + ")'>Edit</button>");
        $("<td>").appendTo($tr).append("<button onclick='DeleteCustomer(" + memberList[i].Id + ")'>Delete</button>");
        $tbody.append($tr);
    }
}

function showOverview() {
    $("#customerOverview").show();
    $("#addCustomerForm").hide();
    $("#teamfield").hide();
    $("#updateCustomerForm").hide();

    GetCustomers();
}

function showAdd() {
    $("#customerOverview").hide();
    $("#addCustomerForm").show();
    $("#teamfield").hide();
    $("#updateMemberForm").hide();
}

function editMember(memberId) {
    showUpdate();
    console.info("Edit " + memberId);
    for (var i = 0; i < members.length; i++)
    {
        if (members[i].Id == memberId)
        {
            updateMember = members[i];
            break;
        }
    }

    if (updateMember == null)
    {
        alert("Member not found!");
        return;
    }
    
    $("#updateFirstname").val(updateMember.FirstName);
    $("#updateLastname").val(updateMember.LastName);
    $("#updateMembername").val(updateMember.MemberName);
    $("#updatePlaceOfBirth").val(updateMember.PlaceOfBirth);
    $("#updateGender").val(updateMember.Gender);
}

function showUpdate() {
    $("#customerOverview").hide();
    $("#addCustomerForm").hide();
    $("#teamfield").hide();
    $("#updateCustomerForm").show();
}

function showTeamField() {
    $("#customerOverview").hide();
    $("#addCustomerForm").hide();
    $("#teamfield").show();
    $("#updateCustomerForm").hide();
    $("#memberSelection").empty();
    $("#countResult").empty();

    var s1 = $('<select id="member1" />');
    var s2 = $('<select id="member2" />');
    for (var i = 0; i < members.length; i++)
    {
        $('<option />', { value: members[i].Id, text: members[i].MemberName }).appendTo(s1);
        $('<option />', { value: members[i].Id, text: members[i].MemberName }).appendTo(s2);
    }
    s1.appendTo($("#memberSelection"));
    s2.appendTo($("#memberSelection"));
}

$(document).ready(function () {
    GetCustomers();
});