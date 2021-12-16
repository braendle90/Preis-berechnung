// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.






//------------------  Order Site ------------------ /////


function addFormField() {


    var content = document.getElementById("content_background").innerHTML;


    /* document.getElementById("wrapper").style.background = "#e2e2e2";*/



    var id = document.getElementById("id").value;

    var input;

    if (id % 2 === 0) {
        var grey =
            "<div id='content_background" + id + "' class='mt - 3 ' style='background: white; '" + content + "</div>";
        input = grey;

    } else {
        var white =

            "<div id='content_background" + id + "' class='mt-3 ' style='background:#f6f6f6;'" + content + "</div>";
        /*  '<div id="content_background" style="background: "white"; ">' + content + ' </div>';*/

        input = white;

    }


    $("#first").append(input);


    $('#content_background' + id).find('#TextilId').attr('id', 'TextilId' + id);
    $('#content_background' + id).find('#inputColor').attr('id', 'inputColor' + id);
    $('#content_background' + id).find('#TextilColorId').attr('id', 'TextilColorId' + id);
    $('#content_background' + id).find('#NumberOfPieces').attr('id', 'NumberOfPieces' + id);




    id = id - 1 + 2;
    document.getElementById("id").value = id;
}

function removeFormField(idR) {
    let idRemove = "#" + idR
    $(idRemove).remove();

    id = id - 1;

    document.getElementById("id").value = id;

    reloadLogoIndex()

}

$("#addtocart").click(function (event) {
    event.preventDefault();

    var IdOffer = JsonModelShirt.idOffer;

    var arrayMyData = [];
    var mydata = {


        "TextilId": $("#TextilId option:selected").val(),
        "TextilColorId": $("#TextilColorId option:selected").val(),
        "NumberOfPieces": $("#NumberOfPieces").val(),
        "OfferId": $('#OfferId').val(),

    };

    arrayMyData.push(mydata);

    for (var i = 1; i < document.getElementById("first").childElementCount; i++) {

        let data = {

            "TextilId": $("#TextilId" + i + " option:selected").val(),
            "TextilColorId": $("#TextilColorId" + i + " option:selected").val(),
            "NumberOfPieces": $("#NumberOfPieces" + i).val(),
            "OfferId": $('#OfferId').val(),

        };



        arrayMyData.push(data);

    }




    console.log(JSON.stringify(mydata));

    $.ajax(
        {
            url: "/Order/CreateOrder",
            type: "post",
            contentType: "application/json",
            data: JSON.stringify(arrayMyData),
            success: function (response) {
                window.location.href = response.redirectToUrl + response.guid;
            }
        }
    )
});






//------------------  Logo Site ------------------ /////


function addFormFieldLogo() {





    var content = document.getElementById("content_background").innerHTML;


    /* document.getElementById("wrapper").style.background = "#e2e2e2";*/



    var id = document.getElementById("id").value;

    var input;

    if (id % 2 === 0) {
        var grey =
            "<div id='content_background" + id + "' class='mt - 3 ' style='background: white; '" + content + "</div>";
        input = grey;

    } else {
        var white =

            "<div id='content_background" + id + "' class='mt-3 ' style='background:#f6f6f6;'" + content + "</div>";
        /*  '<div id="content_background" style="background: "white"; ">' + content + ' </div>';*/

        input = white;

    }


    $("#first").append(input);




    $('#content_background' + id).find('#ColorId').attr({ "id": 'ColorId' + id, "name": "[" + id + "]" + ".ColorId" });

    $('#content_background' + id).find('#OfferId').attr({ "id": 'OfferId' + id, "name": "[" + id + "]" + ".OfferId" });

    $('#content_background' + id).find('#LogoName').attr({ "id": 'LogoName' + id, "name": "[" + id + "]" + ".LogoName" });

    $('#content_background' + id).find('#LogoSurfaceSize').attr({ "id": 'LogoSurfaceSize' + id, "name": "[" + id + "]" + ".LogoSurfaceSize" });



    //$('#content_background' + id).find('#ColorId').attr('id', 'ColorId' + id);
    //$('#content_background' + id).find('#LogoName').attr('id', 'LogoName' + id);

    //$('#content_background' + id).find('#ColorId').attr('name', "[" + id +1 + "]" + "LogoName");

    //$('#content_background' + id).find('#LogoSurfaceSize').attr('id', 'LogoSurfaceSize' + id);
    //$('#content_background' + id).find('#ColorId'   ).attr('name', "[" + id + 1+ "]" + "LogoSurfaceSize");




    id = id - 1 + 2;
    document.getElementById("id").value = id;
}

function removeFormFieldLogo(idR) {
    let idRemove = "#" + idR
    $(idRemove).remove();

    id = id - 1;

    document.getElementById("id").value = id;

    reloadLogoIndex()

}

//$("#addtoLogo").click(function (event) {
//    event.preventDefault();

//    var IdOffer = JsonModelShirt.idOffer;

//    var arrayMyData = [];
//    var mydata = {


//        "ColorId": $("#ColorId option:selected").val(),
//        "LogoName": $("#LogoName").val(),
//        "LogoSurfaceSize": $("#LogoSurfaceSize").val(),
//        "OfferId": $('#OfferId').val(),

//    };

//    arrayMyData.push(mydata);

//    for (var i = 1; i < document.getElementById("first").childElementCount; i++) {

//        let data = {

//            "ColorId": $("#ColorId" + i + " option:selected").val(),
//            "LogoName": $("#LogoName" + i).val(),
//            "LogoSurfaceSize": $("#LogoSurfaceSize" + i).val(),
//            "OfferId": $('#OfferId').val(),

//        };



//        arrayMyData.push(data);

//    }




//    console.log(JSON.stringify(mydata));

//    $.ajax(
//        {
//            url: "/Order/CreateLogo",
//            type: "post",
//            contentType: "application/json",
//            data: JSON.stringify(arrayMyData),
//            success: function (response) {


//              //  $.redirect(response.redirectToUrl, { 'TextilColorName': 'value1'});


//                var $self = response.guid;

//                $.redirect(response.redirectToUrl, { $self });
//                //debugger;

//               // window.location.href = response.redirectToUrl + response.guid;
//            }
//        }
//    )
//});







//------------------  Position Site ------------------ /////



function BackgroundToggle() {


    var readDataset = document.querySelector('#contentCopy_0').dataset.row;

    var contentIndex = 0;

    for (var i = 0; i < readDataset; i++) {

        contentIndex = "content_" + i;

        var x = document.getElementsByName(contentIndex);
        
        for (var d = 0; d < x.length; d++) {
            if (d % 2 === 0) {
                x[d].style.backgroundColor = "white";


            } else {
                x[d].style.backgroundColor = "grey";
            }
        }
    }

    return contentIndex;
}

function updateName() {

    var positionIdUpdateIndex = 0;
    var LogoIdUpdateIndex = 0;
    var OrderIdUpdateIndex = 0;

    var contentIndex = 0;

    var x = "";

    var ListClassToUpdate = document.getElementsByClassName("form-control");

    var updatePosition = document.querySelectorAll("[data-isPositionUpdate]");
    var updateLogo = document.querySelectorAll("[data-isLogoUpdate]");
    var OrderIdUpdate = document.querySelectorAll("[data-isOrderUpdate]");
   

    for (var i = 0; i < updatePosition.length; i++) {
        updatePosition[i].name = "[" + positionIdUpdateIndex + "].PositionId";

        positionIdUpdateIndex++;
    }

    for (var i = 0; i < updateLogo.length; i++) {
        updateLogo[i].name = "[" + LogoIdUpdateIndex + "].LogoId";

        LogoIdUpdateIndex++;
    }

    for (var i = 0; i < OrderIdUpdate.length; i++) {
        OrderIdUpdate[i].name = "[" + OrderIdUpdateIndex + "].OrderId";

        OrderIdUpdateIndex++;
    }


}



function addFormFieldPosition(r, index, contentIndex) {

    //var content = "content_" + index;
    //var model = "modelCount_" + count;

    //var testCount = count;

    //var content = document.getElementById(content);

    var pathContent = r.parentNode.parentNode.parentNode;

    var content = document.getElementById("contentCopy_" + contentIndex).innerHTML
    var contentID = pathContent.id;


    var newDiv = document.createElement("div");
    newDiv.style.backgroundColor = 'grey';


    var contentIndex = BackgroundToggle();

    newDiv.setAttribute("name", contentIndex);


    var newContent = document.createTextNode(content);
    newDiv.innerHTML = content; // füge den Textknoten zum neu erstellten div hinzu.


    /* document.getElementById("wrapper").style.background = "#e2e2e2";*/




    /*    $pathId = contentID;*/


    $("#model_" + index).find('#texilnameHidden').attr({ "id": 'texilnameHidden_first' });

    //Append the selectet content to the after the last row.
    $("#model_" + index).append(newDiv);



    $("#model_" + index).find('#texilnameHidden').attr("hidden", true);



    $('#content_background' + id).find('#ColorId').attr({ "id": 'ColorId' + id, "name": "[" + id + "]" + ".ColorId" });


    $('#content_background' + id).find('#ColorId').attr({ "id": 'ColorId' + id, "name": "[" + id + "]" + ".ColorId" });

    $('#content_background' + id).find('#OfferId').attr({ "id": 'OfferId' + id, "name": "[" + id + "]" + ".OfferId" });

    $('#content_background' + id).find('#LogoName').attr({ "id": 'LogoName' + id, "name": "[" + id + "]" + ".LogoName" });

    $('#content_background' + id).find('#LogoSurfaceSize').attr({ "id": 'LogoSurfaceSize' + id, "name": "[" + id + "]" + ".LogoSurfaceSize" });



    //$('#content_background' + id).find('#ColorId').attr('id', 'ColorId' + id);
    //$('#content_background' + id).find('#LogoName').attr('id', 'LogoName' + id);

    //$('#content_background' + id).find('#ColorId').attr('name', "[" + id +1 + "]" + "LogoName");

    //$('#content_background' + id).find('#LogoSurfaceSize').attr('id', 'LogoSurfaceSize' + id);
    //$('#content_background' + id).find('#ColorId'   ).attr('name', "[" + id + 1+ "]" + "LogoSurfaceSize");




    id = id - 1 + 2;
    document.getElementById("id").value = id;

    updateName();
}

function removeFormFieldLogo(idR) {
    let idRemove = "#" + idR
    $(idRemove).remove();

    id = id - 1;

    document.getElementById("id").value = id;

    reloadLogoIndex()

}



