var Lang = $('.txtLang').text();

function BindMedicationsModal(Sender) {
    $('.menu-MedicationDetails').find('.MedTxtName').text($(Sender).attr('data-Name'));
    $('.menu-MedicationDetails').find('.MedTxtFrom').text($(Sender).attr('data-From'));
    $('.menu-MedicationDetails').find('.MedTxtDosage').text($(Sender).attr('data-Dosage'));
    $('.menu-MedicationDetails').find('.MedTxtFrequency').text($(Sender).attr('data-Frequency'));
    $('.menu-MedicationDetails').find('.MedTxtDuraion').text($(Sender).attr('data-Duration'));
    $('.menu-MedicationDetails').find('.MedTxtNotes').text($(Sender).attr('data-Notes'));
    LoadTakePerTreatments($(Sender).attr('data-ID'));
}
function BindInvestigationsModal(Sender) {

    $('.menu-InvestigationsDetails').find('.InvTxtType').text($(Sender).attr('data-Type'));
    $('.menu-InvestigationsDetails').find('.InvTxtName').text($(Sender).attr('data-Name'));
    $('.menu-InvestigationsDetails').find('.InvTxtResult').text($(Sender).attr('data-Result'));
    $('.menu-InvestigationsDetails').find('.InvTxtNotes').text($(Sender).attr('data-Notes'));
}
//function DownloadAttachment(sender, event) {
//    debugger;
//    event.preventDefault();
//    window.open($(sender).attr('data-href'), 'Download');
//}


$(window).on('load', function () {
    moment.locale(Lang);
    $('.txtReason').val($('.txtReason').attr('data-value'));
    $(".rateYo").rateYo({
        starWidth: "30px",
        numStars: 5,
        ratedFill: "#ef4d2c",
        rating: $('.txtrating').text(),
        fullStar: true,
        onChange: function (rating, rateYoInstance) {
            debugger;
            $('.txtrating').text(rating)

            var RatingVal = $('.txtrating').text();

            $.ajax({
                type: "post",
                async: true,
                dataType: "json",
                url: GlobalUrl + "UpdateRates",
                contentType: "application/json",
                data: JSON.stringify({
                    Rate: RatingVal, VGuid: $('.txtVGUID').attr('data-value')
                }),
                success: function (response) { },
                error: function (error) {
                    var g = error;
                },
            });

        }
    });
})
function DeleteAttachments(sender) {
    var ID = $(sender).attr('data-ID');
    

    $.ajax({
        type: "post",
        async: false,
        dataType: "json",
        url: GlobalUrl + "DeleteFile",
        contentType: "application/json",
        data: JSON.stringify({ PVAttachmentID: ID }),
        success: function (response) {
            $(sender).closest('.attachDiv').remove();
        },
        error: function (error) {
            var g = error;
        },
    });
}
function UpdateComments(sender) {
    $.ajax({
        type: "post",
        async: true,
        dataType: "json",
        url: GlobalUrl + "UpdateComments",
        contentType: "application/json",
        data: JSON.stringify({
            comment: $(sender).val(), VGuid: $('.txtVGUID').attr('data-value')
        }),
        success: function (response) { },
        error: function (error) {
            var g = error;
        },
    });
}
$(document).ready(function () {
    $('.DownloadAttachment').click(function (e) {
        e.preventDefault();  //stop the browser from following
        window.open($(sender).attr('data-href'), 'Download');
    });

});

function DoctoChat(sender) {
    $(sender).attr('href', $(sender).attr('data-href'));
}
function LoadTakePerTreatments(TreatmentsID) {
    $.ajax({
        type: "post",
        async: true,
        dataType: "json",
        url: GlobalUrl + "LoadTaks",
        contentType: "application/json",
        data: JSON.stringify({ "TID": TreatmentsID }),
        success: function (response, $Id) {
            var Takes = JSON.parse(JSON.stringify(response));
            $('.tbodyTakes').empty();
            if (Takes.length > 0) {
                $(Takes).each(function (i, item) {
                    $('.tbodyTakes').append('<tr><td scope="row">' + item["num"] + '</td><td class="color-green-dark">' + moment(new Date(item["Date"])).format("ddd DD/MM/YYYY hh:mm A") + '</td></tr>');
                });
            }
        },
        error: function (error) {
            var g = error;
        },
    });
}