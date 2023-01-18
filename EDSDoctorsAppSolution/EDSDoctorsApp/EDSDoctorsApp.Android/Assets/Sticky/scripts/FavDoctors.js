debugger;
var page = 2;
var pagesize = 10;
var flgStop = false;
var Lang = $('.txtLang').text();

$(document).ready(function () {
    var stxt = $('.SearchTxt').attr('data-value');
    $('.SearchTxt').val(stxt);
    if ($('.visitcards').length < pagesize) {
        $('.ShowMoreBtn').hide();
    }
    $('.Rimg').each(function (i, item) {
        if ($(item).attr("data-src") != "") {
            $(item).attr("src", $(item).attr("data-src"));
        }
    });
    moment.locale(Lang);

});

function GetResources(filterByName = false) {
    if (filterByName) {
        page = 1;
    }

    var dataaa = {
        "PGUID": $('.txtPGUID').text(), "Lang": $('.txtLang').text(), "Page": page
    };
    $('.ShowMoreBtn').hide();
    flgStop = false;
    $.ajax({
        type: "post",
        async: true,
        dataType: "json",
        url: GlobalUrl + "LoadFavDoctors",
        contentType: "application/json",
        data: JSON.stringify(dataaa),
        success: function (response, $Id) {
            debugger;
            var Doctors = JSON.parse(JSON.stringify(response));

            if (page == 2) {
                localStorage.removeItem("Favs");
            }
            if (Doctors.length > 0) {
                flgStop = false;
                localStorage.setItem("Favs", JSON.stringify(response));
                DrawData(Doctors)
                page = page + 1;
                if (Doctors.length >= pagesize)
                    $('.ShowMoreBtn').show();
            }
            else {
                debugger; flgStop = true;
            }

        },
        error: function (error) {
            var Favs = localStorage.getItem("Favs");
            Favs = JSON.parse(Favs);
            Favs = Favs.slice(((page - 1) * pagesize) - pagesize, pagesize)
            if (Favs.length > 0) {
                flgStop = false;
                DrawData(Favs);
                if (Favs.length >= pagesize) { $('.ShowMoreBtn').show(); }
                page = page + 1;
            }
            else {
                flgStop = true;

            }

            var g = error;
        },
        //beforeSend: function () {
        //    ShowLoader();
        //},
        //complete: function () {
        //    HideLoader();
        //},
    });

}
function DrawData(Doctors) {
    $(Doctors).each(function (i, item) {
        var Address = (item['Country'] == '' ? '' : item['Country'] + '- ') + (item['City'] == '' ? '' : item['City'] + '- ') + (item['District'] == '' ? '' : item['District'] + '- ') + (item['Building'] == '' ? '' : item['Building'] + '- ') + (item['Street'] == '' ? '' : item['Street'] + '');
        
        var img = "<img src='Sticky/images/avatars/2s.png' style='width: 56px;height: 56px;' class='bg-highlight rounded-xl border-s border-highlight' data-src=''>";
        if (item['UsersImage'] == '') {
            if (item['ResourcesGender'] == 'Female') img = "<img src='Sticky/images/avatars/10s.png' style='width:56px;height:56px;' class='bg-highlight rounded-xl border-s border-highlight' data-src=''>"
        }
        else {
            img = "<img src='" + item['UsersImage'] + "' style='width:56px;height:56px;' class='bg-highlight rounded-xl Rimg border-s border-highlight' >";
        }
        $('.DoctorsContent').append("<div class='content'><div class='bg-theme rounded-sm mb-n5 ms-3 overflow-hidden under-slider-btn d-inline-block shadow-l text-center'><span class='bg-orange-light font-10 d-block mb-2 px-3 line-height-xs py-1'>" + moment(new Date(item['NextAvailable'])).format('MMM') + "</span><span class='font-20 font-800 d-block mb-n3 line-height-s'>" + moment(new Date(item['NextAvailable'])).format('DD') + "</span><br/></div><div class='float-end mt-1 mb-n5 me-3 overflow-hidden under-slider-btn d-inline-block text-center'>" + img + "</div><div class='card card-style mx-0 mb-3'data-card-heightx='175'><div class='card-bottomx mt-4 p-3'><span class='d-block mt-2 lh-sm color-black font-900 font-18'>" + item['ResourcesName'] + "</span><span class='d-block lh-sm color-black font-600 font-14'>" + item['SpecialtiesName'] + "</span><span class='d-block lh-sm color-black 5 font-14'>" + item['CareerLevelsName'] + "</span><span class='d-block font-13 mb-n1'><i class='fa fa-map-marker pe-2'></i>" + Address + "</span><div class='row mt-1 mb-1'><div class='col-12'><a href=''class='btn btn-s bg-orange-light btn-full rounded-sm text-uppercase font-800 rounded-l font-14'data-SchedualData='hybrid:DoBookNearestMyFavorite?RGUID=" + item['ResourcesGUID'] + "&LGUID=" + item['LocationsGUID'] + "&SID=" + item['SID'] + "&DoctorName=" + item['ResourcesName'] + "&Speciality=" + item['SpecialtiesName'] + "&Career=" + item['CareerLevelsName'] + "&Address=" + Address + "&Start=" + item['NextAvailable'] + "&End=" + item['End'] + "'onclick='BookNearest(this)'>" + BookNow + " " + moment(new Date(item['NextAvailable'])).format('dddd DD/MM/YYYY hh:mm A') + "</a></div></div><div class='row mt-1 mb-1'><div class='col-12'><a href=''class='btn btn-s btn-border border-highlight color-highlight btn-full rounded-sm text-uppercase font-800 rounded-l font-14'data-link='hybrid:GotoDoctorDetailsMyFavorite?RGUID=" + item['ResourcesGUID'] + "&LGUID=" + item['LocationsGUID'] + "'onclick='MoreInfo(this)'>" + MoreInfoo + "</a></div></div></div></div></div>");
    });
}
function MoreInfo(sender) {
    $(sender).attr("href", $(sender).attr("data-link"));
}

function ShowMore() {
    if (flgStop == false) {
        GetResources();

    }
}
function BookNearest(sender) {
    $(sender).attr("href", $(sender).attr("data-SchedualData"));
}
function Search(sender) {
    debugger;
    var SearchText = $(sender).val().trim().trim();
    if (SearchText.length >= 3) {
        GetResources(true);
    }
    if (SearchText.length == 0) {
        GetResources(false);
    }
}