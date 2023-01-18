// In your Javascript (external .js resource or <script> tag)
$(document).ready(function () {

    $('.inptypeahead').tagsinput({
        typeahead: {
            source: function (query) {
                var elements = [];
                $.ajax({
                    type: "POST",
                    url: "https://api.edoctorgroup.com/api/Account/en-GB/TagInput/getTextAutoComplete",
                    dataType: 'json',
                    headers: { "Authorization": "Bearer " + Token },
                    data: '{"columnName":"ExaminationsDataValue","searchValue":"' + query + '","tableName":"ExaminationsData"}',
                    success: function (result) {
                        console.log(result)
                        return JSON.parse('["Amsterdam","Washington","Sydney","Beijing","Cairo"]');
                    }
                });
                //source: ['Amsterdam', 'Washington', 'Sydney', 'Beijing', 'Cairo']
            }
        }
    });
});
