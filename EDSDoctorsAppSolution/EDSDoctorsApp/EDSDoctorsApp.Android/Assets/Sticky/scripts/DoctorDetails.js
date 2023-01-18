debugger;
var page = 2;
var flgStop = false;
var Lang = $('.txtLang').text();

$(document).ready(function () {
    BindBackGroundImg();
    if ($('.d-flex').length < 3) {
        $('.ShowMoreBtn').hide();
    } 
    moment.locale(Lang);
});
function BindBackGroundImg() {
    var imageUrl = "Sticky/images/avatars/2s.png";
    if ($('.DocImage').attr("data-img") == "") {
        if ($('.DocImage').attr("data-Gender").toLowerCase() == "female") {
            imageUrl = "Sticky/images/avatars/10s.png";
        }
    }
    else {
        imageUrl = $('.DocImage').attr("data-img");
    }
    $('.DocImage').css('background-image', 'url(' + imageUrl + ')');
}
function GetScheduales() {
    var dataaa = {
        "LGUID": $('.txtLGUID').text(), "RGUID": $('.txtRGUID').text(),"Lang": $('.txtLang').text(), "Page": page
    };
    flgStop = false;
    $('.ShowMoreBtn').hide();
    $.ajax({
        type: "post",
        async: true,
        dataType: "json",
        url: GlobalUrl+"GetSchedulesCalendar",
        contentType: "application/json",
        data: JSON.stringify(dataaa),
        success: function (response) {
            debugger;
            var Scheduals = JSON.parse(JSON.stringify(response));
            if (Scheduals.length > 0) {
                flgStop = false;
                $(Scheduals).each(function (i, item) {
                    $('.SchedualsContent').append('<div class="d-flex mb-2"><div class="align-self-center"><div class="bg-white rounded-sm color-theme shadow-xl text-center me-4 overflow-hidden"><span class="bg-orange-light font-10 d-block mb-2 px-3 line-height-xs py-1">' + moment(new Date(item["Start"])).format("MMM") + '</span><span class="font-23 font-600 d-block mb-n3 line-height-s">' + moment(new Date(item["Start"])).format("DD") + '</span><br/></div></div><div class="align-self-center me-auto"><h4 class="mb-0 pt-0">' + moment(new Date(item["Start"])).format("hh:mm") + '-' + moment(new Date(item["End"])).format("hh:mm") + '</h4><p class="mb-0">' + moment(new Date(item["Start"])).format("dddd") + '</p></div><div class="align-self-center"><a data-SchedualData="hybrid:DoBookNearestDoctorDetails?RGUID=' + $('.txtRGUID').text() + '&LGUID=' + $('.txtLGUID').text() + '&SID=' + item["ID"] + '&DoctorName=' + $('.txtDoctorName').text() + '&Speciality=' + $('.txtDoctorName').attr('data-speciality') + '&Career=' + $('.txtDoctorName').attr('data-career') + '&Address=' + $('.txtAddress').text() + '&Start=' + item["Start"] + '&End=' + item["End"] + '&VGUID=' + $('.txtVGUID').text() + '"onclick="BookNearest(this)"class="btn btn-s bg-orange-light rounded-sm font-700 text-uppercase">' + BookNow +'</a></div></div><hr />');
                });
                page = page + 1;
                if (Scheduals.length >= 3)
                    $('.ShowMoreBtn').show();
            }
            else {
                flgStop = true;
            }

        },
        error: function (error) {
            //do something about the error

            var g = error;
        },
    });
    LoaderHide();

}


function ShowMore() {
    if (flgStop == false) {
        LoaderShow();
        GetScheduales();

    }
}
function BookNearest(sender) {
    $(sender).attr("href", $(sender).attr("data-SchedualData"));
}