$(document).ready(function () {

    $("#AddChoose").click(function () {

        $.ajax({

            url: "/Admin/Event/GetSpeaker",
            type: "get",
            dataType: "html",

            success: function (response) {
                
                $("#forSpeakers").html(response);
            },

            error: function (error) {
                console.log(error);
            }
        });
    });

    CKEDITOR.replace('cktext');

});