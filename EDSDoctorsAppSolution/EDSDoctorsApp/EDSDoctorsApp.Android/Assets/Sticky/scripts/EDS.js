//4const { forEach } = require("./underscore");

//GlobalUrl = "http://192.168.123.45:8050/patient/api/";
GlobalUrl = "https://api.edoctorgroup.com/api/";

$(document).ready(function () {
    if ($.find(':input:visible:first').length > 0) {
        $.find(':input:visible:first')[0].focus();
    }

    //var myobj = jQuery('input[errormessage]');
    //myobj.on('keyup keypress blur change input', function () {
    //    var msg = ($(this).attr('errormessage'));
    //    if (this.validity.typeMismatch) {
    //        this.setCustomValidity(msg);
    //    } else {
    //        this.setCustomValidity('');
    //    }
    //});
});

async function ShowLoader() {
    var objLoader = document["getElementById"]("preloader");
    objLoader["classList"]["remove"]("preloader-hide");
}
function HideLoader() {
    var objLoader = document["getElementById"]("preloader");
    objLoader["classList"]["add"]("preloader-hide");
}

async function LoaderShow() {
    //var objLoader = document["getElementById"]("preloader");
    //objLoader["classList"]["remove"]("preloader-hide");
}
function LoaderHide() {
    //var objLoader = document["getElementById"]("preloader");
    //objLoader["classList"]["add"]("preloader-hide");
}
function showtoastr(message = "Loading...", divname = "toast-main") {
    var objToast = document.getElementById(divname);
    objToast.getElementsByClassName("toast-message")[0].innerHTML = message;
    objToast = new bootstrap.Toast(objToast);
    objToast.show();
}

//function ShowLoader(sender, container) {
//    var loadingText = '<div class="loader"></div>';
//    if ($(container).html() !== loadingText) {
//        $(sender).attr('disabled', 'disabled');
//        $(container).data('original-text', $(container).html());
//        $(container).html(loadingText);
//    }
//}
//function HideLoader(sender, container) {
//    $(container).html($(container).data('original-text'));
//    $(sender).removeAttr("disabled");
//}

function GetQueryString(name) {
    //debugger;
    var url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function AddChat(sender) {
    debugger;
    var PGUID = $('.txtPGUID').attr('data-value');
    var RGUID = $('.txtRGUID').attr('data-value');
    var Msg = $('.txtChatMsg').val();
    if ($('.txtChatMsg').val() !== "") {
        //if ($('.txtChatMsg').attr('dat-oldvalue') !== Msg) {
        //    $('.txtChatMsg').attr('dat-oldvalue', Msg);
        var dataaa = {
            "PatientsGUID": PGUID, "PatientsDoctorsChatMsg": Msg, "PatientsDoctorsChatIsPatient": 'True', "RGUID": RGUID
        };
        $.ajax({
            type: "POst",
            async: true,
            dataType: "json",
            url: GlobalUrl + "AddChat",
            contentType: "application/json",
            data: JSON.stringify(dataaa),
            success: function (response) {
                $('.txtChatMsg').val('')
                $('.chatcontent').append('<div class="speech-icon-right"><div class="speech-bubble speech-left color-black mt-n2">' + Msg + ' </div><div class="clearfix"></div></div>');
                /*   <img src="' + $(sender).closest('.card-style').find('.Pimg').attr('src') + '" class="Rimg rounded-xl border border-black border-s">*/
            },
            error: function (error) {
                var g = error;
            },
        });
        //}
    }
}
function updateURLParameters(element) {
    var checkboxes = document.querySelectorAll('input[name=ReviewOptions]:checked');
    const values = [];
    for (const [key, value] of Object.entries(checkboxes)) {
        values.push(value.value);
        console.log(`${key}: ${value}`);
    }
    debugger;
    const Options = {
        RiskFactors: $('#RiskFactorsOptions').val(),
        ChronicDiseases: $('#ChronicOptions').val(),
        Phobias: $('#PhobiaOptions').val(),
        PatientsMedicalHistory: $('#MedicalInput').val(),
        Implants: $('#ImplantInput').val(),
        SocialHabits: $('#HabitsOptions').val(),
        SocialNotes: $('#SocialNotes').val(),
        SurgeryNotes: $('#SurgeryNotes').val(),
        Alcohol: $('#Alcohol').prop('disabled') ? "" : $('#Alcohol').val(),
        Coffee: $('#Coffee').prop('disabled') ? "" : $('#Coffee').val(),
        Tea: $('#Tea').prop('disabled') ? "" : $('#Tea').val(),
        Smoker: $('#Smoker').prop('disabled') ? "" : $('#Smoker').val(),
        RecreationalDrugs: $('#Drugs').prop('disabled') ? "" : $('#Drugs').val(),
        OccupationalHazards: $('#Occupational').prop('disabled') ? "" : $('#Occupational').val(),
        ReviewOptions: values.join(',')
    };

    for (const [key, value] of Object.entries(Options)) {
        debugger;
        var url = $(element).attr("href");
        var newAdditionalURL = "";
        var tempArray = url.split("?");
        var baseURL = tempArray[0];
        var additionalURL = tempArray[1];
        var temp = "";
        if (additionalURL) {
            tempArray = additionalURL.split("&");
            for (var i = 0; i < tempArray.length; i++) {
                if (tempArray[i].split('=')[0] != key) {
                    newAdditionalURL += temp + tempArray[i];
                    temp = "&";
                }
            }
        }

        var rows_txt = temp + "" + key + "=" + value;
        $(element).attr("href", baseURL + "?" + newAdditionalURL + rows_txt)
    }
}
const convertTime12to24 = (time12h) => {
    const [time, modifier] = time12h.split(' ');

    let [hours, minutes] = time.split(':');

    if (hours === '12') {
        hours = '00';
    }

    if (modifier === 'PM') {
        hours = parseInt(hours, 10) + 12;
    }

    return `${hours}:${minutes}`;
}