function getUserAjax(request, successCB, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'VolenteersWS.asmx/getUsers',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}


function getPatientAjax(request, successCB, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'patientWS.asmx/getPatients',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}


function getdestinationAjax(request, successCB, errorCB) {

    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'destinationWS.asmx/getdestination',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getPatienHospitaltAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'patientWS.asmx/getPatientInHospitals',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getvolAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'VolenteersWS.asmx/insertVol',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function insertVolAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'VolenteersWS.asmx/insertVol',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function insertPatAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'patientWS.asmx/insertpat',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function insertEscAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'EscortedWS.asmx/insertEscorted',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getdestinationAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'destinationWS.asmx/insertDestination',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getDestAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'destinationWS.asmx/getdestination',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getrespListAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'VolenteersWS.asmx/getrespList',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getEscortedAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'EscortedWS.asmx/getescorted',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}


function getAdditionAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'patientWS.asmx/getAdditionOfPatient',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}


function insertridePatAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'ridePatWS.asmx/insertRidePat',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}


function getUserByPhoneNumberAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'VolenteersWS.asmx/geUser',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}

function getPatientByPhoneNumberAjax(request, successCB, errorCB) {
    var dataString = JSON.stringify(request);

    $.ajax({ // ajax call starts
        url: 'patientWS.asmx/gePatient',   // server side web service method
        data: dataString,                          // the parameters sent to the server
        type: 'POST',                              // can be also GET
        dataType: 'json',                          // expecting JSON datatype from the server
        contentType: 'application/json; charset = utf-8', // sent to the server
        success: successCB,                // data.d id the Variable data contains the data we get from serverside
        error: errorCB
    }) // end of ajax call
}