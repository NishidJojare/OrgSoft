$(document).ready(function () {
    GetTeamList();
    TeamList();
});


var SaveTeam = function () {
    /*debugger;*/

    $formData = new FormData();
    var Photo = document.getElementById('file1');
    if (Photo.files.length > 0) {
        for (var i = 0; i < Photo.files.length; i++) {
            $formData.append('file-' + i, Photo.files[i]);
        }
    }

    var id = $("#Id").val();
    var name = $("#txtName").val();
    var designation = $("#txtDesignation").val();
    var photo = $("#file1").val();
    var instagram = $("#txtInstagram").val();
    var facebook = $("#txtFacebook").val();
    var twitter = $("#txtTwitter").val();
    var linkedIn = $("#txtLinkedIn").val();

    $formData.append('Id', id);
    $formData.append('Name', name);
    $formData.append('Designation', designation);
    $formData.append('Photo', photo);
    $formData.append('Instagram', instagram);
    $formData.append('Facebook', facebook);
    $formData.append('Twitter', twitter);
    $formData.append('LinkedIn', linkedIn);


    //var model = {
    //    Id:id,
    //    Name: name,
    //    Designation: designation,
    //    Photo: photo,
    //    Instagram: instagram,
    //    Facebook: facebook,
    //    Twitter: twitter,
    //    LinkedIn: linkedIn,
    //};

    $.ajax({
        url: "/Team/SaveTeam",
        method: "post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,

        success: function (response) {
            alert("Successfully Saved");
            GetTeamList();
        }
        //error: function (response) {
        //    alert(response.Message)
        //}
    });


};

var TeamList = function () {
    //debugger;
    $.ajax({
        url: "/Team/GetTeamList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#TeamList tbody").empty();
            $.each(response.Message, function (index, elementValue) {

                html += "<div class='col-lg-4 col-md-6 thumbnail'>";
                html += "<div class='member' data-aos='fade-up' data-aos-delay='100'>";
                html += "<div class='pic'><img src='../Content/Img/" + elementValue.Photo + "' class='img-fluid' alt='#'></div>";
                html += "<div class='member-info'>";
                html += "<h4>" + elementValue.Name + "</h4>";
                html += "<span>" + elementValue.Designation + "</span>";
                html += "<div class='social'>";
                html += "<a href='" + elementValue.Twitter + "'><i class='bi bi-twitter'></i></a>";
                html += "<a href='" + elementValue.Facebook + "'><i class='bi bi-facebook'></i></a>";
                html += "<a href='" + elementValue.Instagram + "'><i class='bi bi-instagram'></i></a>";
                html += "<a href='" + elementValue.LinkedIn + "'><i class='bi bi-linkedi'></i></a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";

            });
            $("#TeamList").append(html);
        }

    });
};

var GetTeamList = function () {
    //debugger;
    $.ajax({
        url: "/Team/GetTeamList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblTeam tbody").empty();
            $.each(response.Message, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>"
                    + elementValue.Name + "</td><td><img src='../Content/Img/" + elementValue.Photo + "'style='max-width:80px;max-height:80px;'/></td><td>"
                    + elementValue.Designation + "</td><td>"
                    + elementValue.Instagram + "</td><td>"
                    + elementValue.Facebook + "</td><td>"
                    + elementValue.Twitter + "</td><td>"
                    + elementValue.LinkedIn + "</td><td><button type='button' class='btn btn-danger' onclick='DeleteTeam(" + elementValue.Id + ")'><i class='bi bi-trash-fill'></i></button>&nbsp&nbsp&nbsp<button type='button'  class='btn btn-primary' onclick='EditTeam(" + elementValue.Id + ")'><i class='bi bi-pencil-square'></i></button></td></tr>";


            });
            $("#tblTeam tbody").append(html);
        }

    });
};

var DeleteTeam = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/Team/DeleteTeam",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
            GetTeamList();
        }
    });
};


var EditTeam = function (Id) {
    var model = { Id: Id };
    $.ajax({

        url: "/Team/EditTeam",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#Id").val(response.model.Id);
            $("#txtName").val(response.model.Name);
            $("#txtDesignation").val(response.model.Designation);
            $("#file1").val(response.model.Photo);
            $("#txtInstagram").val(response.model.Instagram);
            $("#txtFacebook").val(response.model.Facebook);
            $("#txtTwitter").val(response.model.Twitter);
            $("#txtLinkedIn").val(response.model.LinkedIn);


        }

    });
};
