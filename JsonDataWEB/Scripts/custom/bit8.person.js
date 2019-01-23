/// <reference path="bit8.js" />
$.bit8.person = function (id) {

    $.bit8.doRequest("/Person/" + id, 'GET', true, null, getSuccess, getError, true);

    function getSuccess(obj) {
        if (obj.ActionSucceeded) {
            $('#lbl-name').html(obj.Result.Name);
            $('#lbl-age').html(obj.Result.Age);
            $('#lbl-gender').html(obj.Result.Gender);
            $('#lbl-email').html(obj.Result.Email);
            $('#lbl-isactive').html((obj.Result.IsActive ? 'Yes' : 'No'));
        }
        else {
            $.bit8.showError('Failed to get person. ' + obj.Messages[0]);
        }
    }

    function getError(obj) {
        $.bit8.showError('Failed to get person.');
        console.log(JSON.stringify(obj));
    }
};



