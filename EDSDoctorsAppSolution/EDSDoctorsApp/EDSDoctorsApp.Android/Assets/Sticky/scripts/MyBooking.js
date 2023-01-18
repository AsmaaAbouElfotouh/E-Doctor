debugger;
var page = 2;
var flgStop = false;
var Lang = $('.txtLang').text();

$(document).ready(function () {
    if ($('.visitcards').length < 10) {
        $('.ShowMoreBtn').hide();
    }
    $('.Rimg').each(function (i, item) {
        if ($(item).attr("data-src") != "") {
            $(item).attr("src", $(item).attr("data-src"));
        }
    });
    moment.locale(Lang);

});

function GetMyBooking() {
    $('.ShowMoreBtn').hide();

    var dataaa = {
        "PatientsGuid": $('.txtPatientsGuid').text(), "Lang": $('.txtLang').text(), "Page": page
    };
    flgStop = false;

    $.ajax({
        type: "post",
        async: true,
        dataType: "json",
        url: GlobalUrl + "GetPatientVisits",
        contentType: "application/json",
        data: JSON.stringify(dataaa),
        success: function (response, $Id) {
            if (page == 2) {
                localStorage.removeItem("Bookings");
            }
            debugger;
            var Bookings = JSON.parse(JSON.stringify(response));
            if (Bookings.length > 0) {
                localStorage.setItem("Bookings", JSON.stringify(response));
                flgStop = false;
                DrawData(Bookings);
                if (Bookings.length >= 10) $('.ShowMoreBtn').show();
                page = page + 1;

            }
            else { debugger; flgStop = true; }

        },
        error: function (error) {
            var Bookings = localStorage.getItem("Bookings");
            Bookings = JSON.parse(Bookings);
            Bookings = Bookings.slice(((page - 1) * 10) - 10, 10)
            if (Bookings.length > 0) {
                DrawData(Bookings);
                flgStop = false;
                if (Bookings.length >= 10) { $('.ShowMoreBtn').show(); }
                page = page + 1;

            }
            else {
                flgStop = true;

            }
            var g = error;
        },
    });
    LoaderHide();

}
function DrawData(Bookings) {
    $(Bookings).each(function (i, item) {
        var Address = (item['Country'] == '' ? '' : item['Country'] + ' - ') + (item['City'] == '' ? '' : item['City'] + ' - ') + (item['District'] == '' ? '' : item['District'] + ' - ') + (item['Building'] == '' ? '' : item['Building'] + ' - ') + (item['Street'] == '' ? '' : item['Street'] + '');

        var img = "<img src='Sticky/images/avatars/2s.png' style='width: 56px;height: 56px;' class='bg-highlight rounded-xl border-s border-highlight' data-src=''>"; if (item['UsersImage'] == '') { if (item['ResourcesGender'] == 'Female') img = "<img src='Sticky/images/avatars/10s.png' style ='width:56px;height:56px;' class='bg-highlight rounded-xl border-s border-highlight' data-src=''>" } else { img = "<img src='" + item['UsersImage'] + "' style ='width:56px;height:56px;' class='bg-highlight rounded-xl Rimg border-s border-highlight' >"; } var btns = "<div class='col-12'> <a href='' onclick ='VisitDetails(this)' data-link='hybrid:GotoVisitDetails?RGUID=" + item['PatientsVisitsResourceID'] + "&LGUID=" + item['PatientsVisitsLocationsID'] + "&ID=" + item['SchedulesID'] + "&Doctor=" + item['Name'] + "&Specialty=" + item['SpecialityName'] + "&CareerLevelsName=" + item['CareerLevelsName'] + "&Address=" + item['Address'] + "&Start=" + item['PatientsVisitsGetVisitDate'] + "&End=" + item['SchedulesEndTime'] + "&VGUID=" + item['PatientsVisitsGUID'] + "' class='btn btn-s btn-border border-highlight color-highlight btn-full rounded-sm text-uppercase font-800 rounded-l font-14' onclick='ShowDetails(this)'>" + txtShowDetails + "</a> </div>"; if (item['Status'] == 'New' || item['Status'] == 'Planned') { btns = "<div class='col-6'> <a href='' class='btn btn-s bg-highlight btn-full rounded-sm text-uppercase font-800 rounded-l font-14' onclick='Reschedule(this)' data-link='hybrid:GotoDoctorDetailsMyBookings?RGUID=" + item['PatientsVisitsResourceID'] + "&LGUID=" + item['PatientsVisitsLocationsID'] + "&VGUID=" + item['PatientsVisitsGUID'] + "&IsFav=" + item['AddStatus'] + "' > " + txtReschedule + "</a> </div> <div class='col-6'> <a href='' data-link='hybrid:DoCancel?VGUID=" + item['PatientsVisitsGUID'] + "' class='btn btn-s btn-border border-highlight color-highlight btn-full rounded-sm text-uppercase font-800 rounded-l font-14' onclick='Cancel(this)'>" + txtCancel + "</a> </div>"; }
        $('.BookingsContent').append("<div class='content visitcards'> <div class='bg-theme rounded-sm mb-n5 ms-3 overflow-hidden under-slider-btn d-inline-block shadow-l text-center'> <span class='bg-highlight font-10 d-block mb-2 px-3 line-height-xs py-1'>" + moment(new Date(item['PatientsVisitsGetVisitDate'])).format('MMM') + "</span> <span class='font-20 font-800 d-block mb-n3 line-height-s'>" + moment(new Date(item['PatientsVisitsGetVisitDate'])).format('DD') + "</span><br /> </div>  <div class='float-end mt-1 mb-n5 me-3 overflow-hidden under-slider-btn d-inline-block text-center'>" + img + "  </div>  <div class='card card-style mx-0 mb-3' data-card-heightx='175'> <div class='card-bottomx mt-4 p-3'> <span class='d-block mt-2 lh-sm color-black font-900 font-18'>" + item['Name'] + "</span> <span class='d-block lh-sm color-black font-600 font-14'>" + item['SpecialityName'] + "</span> <span class='d-block lh-sm color-black 5 font-14'>" + item['CareerLevelsName'] + "</span> <span class='d-block font-13 mb-n1'><i class='fa fa-map-marker pe-2'></i>" + Address + "</span> <span class='badge btn-full mt-1 me-1 mb-1 font-14 color-black bg-gray-light text-uppercase font-600 rounded-l'>" + moment(new Date(item['PatientsVisitsGetVisitDate'])).format('ddd DD/MM/YYYY hh:mm A') + "</span> <div class='row mb-0'> " + btns + " </div> </div>  </div> </div>");
    });

}
function Reschedule(sender) {
    $(sender).attr("href", $(sender).attr("data-link"));
}
function Cancel(sender) {
    $(sender).attr("href", $(sender).attr("data-link"));
}
function ShowDetails(sender) {
    $(sender).attr("href", $(sender).attr("data-link"));
} function VisitDetails(sender) {
    $(sender).attr("href", $(sender).attr("data-link"));
}
function ShowMore() {
    if (flgStop == false) {
        LoaderShow();
        GetMyBooking();

    }
}
