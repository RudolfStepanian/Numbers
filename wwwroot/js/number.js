const formElem = document.querySelector('#numberConverterForm');
console.log(formElem);


document.querySelector("#numberConverterForm").addEventListener("submit", function (e) {
    e.preventDefault();
    var url = window.location.href + 'Number/Get';
    console.log(url);
    var data = {
        number: $("#number").val()
    };
    $.ajax({
        type: 'GET',
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#result").html(response);
        },
        error: function (request, error) {
            console.log(arguments);
            aler(error);
        },
    });
});