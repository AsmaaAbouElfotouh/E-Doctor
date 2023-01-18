
var AddressesLength = 0;
var Step = -1;

var ProfileData = { "DoctorDetails": [], "Addresses": [] };

function SaveDoctorProfileData() {
    debugger;
    data = {};
    $("#DoctorProfileForm").serializeArray().map(function (x) {
        data[x.name] = x.value;
    });
    ProfileData.DoctorDetails = data;
    console.log(ProfileData);
}

function SaveDoctorAddresses() {

    Next();

}

function AddAddress(index) {
    var data = [];

    var Addresses = $("#DoctorAddressesForm").serializeArray();

    data.LocationsCountry = Addresses.findIndex(x => x.name == 'LocationsCountry') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsCountry')].value

    data.LocationsCity = Addresses.findIndex(x => x.name == 'LocationsCity') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsCity')].value
    data.LocationsDistrict = Addresses.findIndex(x => x.name == 'LocationsDistrict') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsDistrict')].value

    data.LocationsBuilding = Addresses.findIndex(x => x.name == 'LocationsBuilding') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsBuilding')].value
    data.LocationsStreet = Addresses.findIndex(x => x.name == 'LocationsStreet') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsStreet')].value
    data.LocationsPostalCode = Addresses.findIndex(x => x.name == 'LocationsPostalCode') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsPostalCode')].value
    data.LocationsLandmark = Addresses.findIndex(x => x.name == 'LocationsLandmark') == -1 ? "" : Addresses[Addresses.findIndex(x => x.name == 'LocationsLandmark')].value

    var Schedule = [];
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[0].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[0].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[0].EndTime')].value
        });
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[1].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[1].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[1].EndTime')].value
        });
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[2].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[2].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[2].EndTime')].value
        });
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[3].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[3].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[3].EndTime')].value
        });
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[4].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[4].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[4].EndTime')].value
        });
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[5].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[5].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[5].EndTime')].value
        });
    Schedule.push(
        {
            "Days": Addresses[Addresses.findIndex(x => x.name == 'Schedule[6].Days')].value,
            "StartTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[6].StartTime')].value,
            "EndTime": Addresses[Addresses.findIndex(x => x.name == 'Schedule[6].EndTime')].value
        });

    data.Schedule = Schedule;
    debugger;
    ProfileData.Addresses[index] = data;
    AddressesLength = ProfileData.Addresses.length;
    //$("#DoctorAddressesForm")[0].reset()
}

function Prev() {
    event.preventDefault();
    debugger;
    AddAddress(Step);

    Step--;

    if (Step == -1) {
        ClearAndFillDoctorForm();
        $("#PrevBtn").attr("data-menu", "menu-wizard-step-0")

    }
    else {
        ClearAndFillAddressForm(Step)
        $("#PrevBtn").attr("data-menu", "menu-wizard-step-1");
        $("#NextBtn").show();
        $("#NextBtn").attr("data-menu", "menu-wizard-step-1")
        $("#AddAddressBtn").hide();

    }
    if (AddressesLength == Step) {
        $("#NextBtn").hide();
        $("#AddAddressBtn").show();
        $("#NextBtn").attr("data-menu", "menu-wizard-step-1")

    }
}

function Next() {
    debugger;
    event.preventDefault();
    if (Step == -1) {
        SaveDoctorProfileData();
        $("#PrevBtn").show();
        $("#PrevBtn").attr("data-menu", "menu-wizard-step-1");
        $("#NextBtn").hide();

    }
    else {
        AddAddress(Step)
    }

    Step++;

    if (Step != AddressesLength) {
        SaveDoctorAddresses(Step)
        ClearAndFillAddressForm(Step);

    }

    if (Step == AddressesLength) {
        $("#NextBtn").attr("data-menu", "menu-wizard-step-1")
        $("#NextBtn").hide();
        $("#AddAddressBtn").show();
    }

}

function SaveCompleteProfile() {
    debugger;
}

function ClearAndFillAddressForm(index) {
    debugger;
    $("#DoctorAddressesForm")[0].reset();
    var prevAddress = ProfileData.Addresses[index];
    if (prevAddress) {

        $("#LocationsCountry").val(prevAddress.LocationsCountry);
        $("#LocationsCity").val(prevAddress.LocationsCity);
        $("#LocationsDistrict").val(prevAddress.LocationsDistrict);
        $("#LocationsBuilding").val(prevAddress.LocationsBuilding);
        $("#LocationsStreet").val(prevAddress.LocationsStreet);
        $("#LocationsPostalCode").val(prevAddress.LocationsPostalCode);
        $("#LocationsLandmark").val(prevAddress.LocationsLandmark);

        $("input[id='Schedule[0].Days'").val(prevAddress.Schedule[0].Days);
        $("input[id='Schedule[0].StartTime'").val(prevAddress.Schedule[0].StartTime);
        $("input[id='Schedule[0].EndTime'").val(prevAddress.Schedule[0].EndTime);

        $("input[id='Schedule[1].Days'").val(prevAddress.Schedule[1].Days);
        $("input[id='Schedule[1].StartTime'").val(prevAddress.Schedule[1].StartTime);
        $("input[id='Schedule[1].EndTime'").val(prevAddress.Schedule[1].EndTime);

        $("input[id='Schedule[2].Days'").val(prevAddress.Schedule[2].Days);
        $("input[id='Schedule[2].StartTime'").val(prevAddress.Schedule[2].StartTime);
        $("input[id='Schedule[2].EndTime'").val(prevAddress.Schedule[2].EndTime);

        $("input[id='Schedule[3].Days'").val(prevAddress.Schedule[3].Days);
        $("input[id='Schedule[3].StartTime'").val(prevAddress.Schedule[3].StartTime);
        $("input[id='Schedule[3].EndTime'").val(prevAddress.Schedule[3].EndTime);

        $("input[id='Schedule[4].Days'").val(prevAddress.Schedule[4].Days);
        $("input[id='Schedule[4].StartTime'").val(prevAddress.Schedule[4].StartTime);
        $("input[id='Schedule[4].EndTime'").val(prevAddress.Schedule[4].EndTime);

        $("input[id='Schedule[5].Days'").val(prevAddress.Schedule[5].Days);
        $("input[id='Schedule[5].StartTime'").val(prevAddress.Schedule[5].StartTime);
        $("input[id='Schedule[5].EndTime'").val(prevAddress.Schedule[5].EndTime);

        $("input[id='Schedule[6].Days'").val(prevAddress.Schedule[6].Days);
        $("input[id='Schedule[6].StartTime'").val(prevAddress.Schedule[6].StartTime);
        $("input[id='Schedule[6].EndTime'").val(prevAddress.Schedule[6].EndTime);
    }
}

function ClearAndFillDoctorForm() {
    debugger;
    $("#DoctorName").val(ProfileData.DoctorDetails.DoctorName);
    $("#OrganizationName").val(ProfileData.DoctorDetails.OrganizationName);
    $("#DoctorGender").val(ProfileData.DoctorDetails.DoctorGender);
    $("#DoctorDegree").val(ProfileData.DoctorDetails.DoctorDegree);
    $("#DoctorSpeciality").val(ProfileData.DoctorDetails.DoctorSpeciality);

}


function CountryChange(event, index) {
    debugger;

}

