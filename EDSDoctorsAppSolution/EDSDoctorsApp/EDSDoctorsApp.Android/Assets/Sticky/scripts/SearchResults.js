

debugger;
var page = 1;
var flgStop = false;
/*var Lang = $('.txtLang').text();*/
$(window).on('load', function () {
    var stxt = $('.SearchTxt').attr('data-value');
    $('.SearchTxt').val(stxt);
    $('.SearchTxt').attr('placeholder', $('.SearchTxt').attr('data-placeholder'));
    $('.btnback').attr("href", $('.btnback').attr("data-href"));
    moment.locale(Lang);

});
$(document).ready(function () {
    moment.locale(Lang);
    if ($('.visitcards').length < 10) {
        $('.ShowMoreBtn').hide();
    }
    $('.Rimg').each(function (i, item) {
        if ($(item).attr("data-src") != "") {
            $(item).attr("src", $(item).attr("data-src"));
        }
    });
});

function GetResources(DataRequest, TotalPages, Token, RequestPage, SearchTerm, filterByName = false) {
    if (filterByName) {
    }
    debugger;
    DataRequest["start"] = page * 10 || 0;
    DataRequest["columns"].push(
        {
            "data": "Name",
            "name": "Name",
            "searchable": true,
            "orderable": true,
            "search": {
                "value": SearchTerm,
                "regex": false
            }
        });
    flgStop = false;
    $.ajax({
        type: "post",
        async: false,
        dataType: "json",
        url: GlobalUrl + "Account/en-GB/MainDatas/getMainData",
        contentType: "application/json",
        data: JSON.stringify(DataRequest),
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'Bearer ' + Token);
        },
        success: function (response, $Id) {
            var VisitsArray = JSON.parse(JSON.stringify(response))["result"]["data"];
            var RecordsFiltered = JSON.parse(JSON.stringify(response))["result"]["recordsFiltered"];
            TotalPages = Math.ceil(RecordsFiltered / 10);
            var bookingcontent = "";
            if (RequestPage == "TodayVisits")
                bookingcontent = ".BookingContent";
            else if (RequestPage == "AllVisits")
                bookingcontent = ".BookingContent2";
            else if (RequestPage == "PatientsPage")
                bookingcontent = ".PatientsContent";

            debugger;
            if (VisitsArray.length > 0) {
                flgStop = false;
                if (RequestPage == "TodayVisits")
                    $('#TodayNoSearch').addClass('disabled');
                else if (RequestPage == "AllVisits")
                    $('#AllNoSearch').addClass('disabled');
                else if (RequestPage == "PatientsPage")
                    $('#PatientNoSearch').addClass('disabled');
                if (filterByName) {
                    $('.PatientsContent').empty();
                }
                $(VisitsArray).each(function (i, item) {
                    //console.log(img);
                    if (bookingcontent != ".PatientsContent") {
                        $(bookingcontent).append(`<div class="card card-style mt-5 overflow-visible" style="margin:0" data-filter-item data-filter-name="all"><div class="content"> <div class="row mb-0"> <div class="col-9"> <p> <h6 class="color-gray-dark mb-n3">${$.trim(item["SND"])}</h6><h4 class="color-dark-light font-700 font-22 mt-3">${$.trim(item["Name"])}</h4> </p> <h6> <span class="me-3"><span><b>${$.trim(item["VisitsStatus"])}</b></span></span></h6><h6><span class="me-3"><span class="fa fa-clock"></span><span><b> ${$.trim(new Date(item["VisitsScheduleDateTime"]).toLocaleDateString())} ${$.trim(new Date(item["VisitsScheduleDateTime"]).toLocaleTimeString())}</b></span></span></h6><h6><span class="me-3"><span class="fa fa-map-pin me-3 font-11"></span><span><b>${$.trim(item["Location"])}</b></span></span></h6></div><p><div class="col-12"><div class="d-flex flex-row gap-1 justify-content-end"><a href="hybrid:gotopatientsemrfrombooking?PatientID=${$.trim(item["PK"])}&PatientName=${$.trim(item["Name"])}&PatientMRno=${item["PatientsMRNo"]}" class="btn rounded-m bg-dark-dark font-700 text-uppercase line-height-sm">Details</a></div></div></p></div></div></div>`);
                    }
                    else {
                        var PGender = (item["Gender"] === 'Male') ? 'blue' : 'pink';
                        $(bookingcontent).append(`<div class="card card-style overflow-visible mt-5" style="margin:0" data-filter-item data-filter-name="all"> <div class="content"> <div class="d-flex"> <div class=" d-inline-block mb-n5 ms-auto mt-n5 overflow-hidden rounded-sm text-center under-slider-btn"> <h1 class="align-items-center bg-${PGender}-dark d-flex flex-column font-20 justify-content-center mt-1 rounded-circle" style="width: 80px;height: 80px;"> <span class="mt-4 font-18">${$.trim(item["Gender"])}</span> <i class="fa fa-mars mt-n4"></i> </h1> </div> </div> <div class="row mb-0 mt-5"> <div class="col"> <h6 class="color-gray-dark mb-n3">${$.trim(item["PatientsMRNo"])}</h6> <h4 class="color-dark-light font-700 font-22 text-truncate mt-3"> ${item["Name"]} </h4> <div class="mt-n4"> <span class="me-3"> <i class="fa fa-clock"></i> <span>${$.trim(new Date(item["Created"]).toLocaleDateString())} ${$.trim(new Date(item["Created"]).toLocaleTimeString())}</span> </span> </div> <div class="mt-n4"> <span class="me-3"> <p>${$.trim(new Date(item["DOB"]).toLocaleDateString())}</p> </span> </div> <div class="mt-n4"> <span class="me-3"> <p>${item["Nationality"]}</p> </span> </div> </div> <div class="col-12 px-3"> <div class="d-flex flex-row gap-1 justify-content-end"> <a href="hybrid:gotopatientsemr?PatientID=${$.trim(item["PK"])}&PatientName=${$.trim(item["Name"])}&PatientMRno=${item["PatientsMRNo"]}" class="btn rounded-m bg-dark-dark font-700 text-uppercase line-height-sm">Details</a> </div> </div> </div> </div> </div>`)
                    }
                });
                page++;
                debugger;
                if (page < TotalPages) {
                    if (RequestPage == "TodayVisits")
                        var ShowMoreBtn = "#TodayVisitsShowMoreBtn";
                    else if (RequestPage == "AllVisits")
                        var ShowMoreBtn = "#AllVisitsShowMoreBtn";
                    else if (RequestPage == "PatientsPage")
                        var ShowMoreBtn = "#PatientsShowMoreBtn";
                    $(ShowMoreBtn).show();
                }
                else {
                    if (RequestPage == "TodayVisits")
                        var ShowMoreBtn = "#TodayVisitsShowMoreBtn";
                    else if (RequestPage == "AllVisits")
                        var ShowMoreBtn = "#AllVisitsShowMoreBtn";
                    else if (RequestPage == "PatientsPage")
                        var ShowMoreBtn = "#PatientsShowMoreBtn";
                    $(ShowMoreBtn).hide();
                }
            }
            else {
                debugger;
                if (RequestPage == "TodayVisits") {
                    $('#TodayNoSearch').removeClass('disabled');
                    var ShowMoreBtn = "#TodayVisitsShowMoreBtn";
                }
                else if (RequestPage == "AllVisits") {
                    $('#AllNoSearch').removeClass('disabled');
                    var ShowMoreBtn = "#AllVisitsShowMoreBtn";
                }
                else if (RequestPage == "PatientsPage") {
                    $('#PatientNoSearch').removeClass('disabled');
                    var ShowMoreBtn = "#PatientsShowMoreBtn";
                }
                $(ShowMoreBtn).hide();
                flgStop = true;
            }
            LoaderHide();

        },
        error: function (error) {
            //do something about the error
            debugger;
            LoaderHide();

            var g = error;
        },
    });

}
function MoreInfo(sender) {
    $(sender).attr("href", $(sender).attr("data-link"));
}

function ShowMore() {
    if (flgStop == false) {
        LoaderShow();
        GetResources();

    }
}
function BookNearest(sender) {
    $(sender).attr("href", $(sender).attr("data-SchedualData"));
}
async function Search(Sender, DataRequest, TotalPages, Token, RequestPage, SearchTerm = "", filterByName = false) {
    debugger;
    var SearchText = $(Sender).val().replace(/[^A-Zء-يa-z0-9]/g, " ").trim();
    if (RequestPage == "TodayVisits")
        $('.BookingContent').empty();
    else if (RequestPage == "AllVisits")
        $('.BookingContent2').empty();
    else if (RequestPage == "PatientsPage")
        $('.PatientsContent').empty();
    page = 0;
    await GetResources(DataRequest, TotalPages, Token, RequestPage, SearchText);
}