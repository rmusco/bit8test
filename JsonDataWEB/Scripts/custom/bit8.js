(function () {
    /*jshint eqeqeq:false curly:false latedef:false */
    "use strict";

    function setup($) {
        // global $ methods for blocking/unblocking the entire page

        $.bit8 = function (apiURL) {
            // init
            $.bit8.baseUrl = window.location.origin + '/';
            $.bit8.apiUrl = apiURL;
        };

        //Basic configs
        $.bit8.baseUrl = null;
        $.bit8.apiUrl = null;
        $.bit8.timer = null;
        $.bit8.siteUrl = window.location.origin;
        $.bit8.progressIsOn = 0;
        $.bit8.toastrOpt = { "closeButton": true, "showDuration": "1200", "hideDuration": "500", "timeOut": "5000", "extendedTimeOut": "0" };

        //AJAX functions
        $.bit8.doRedirect = function (url, method, params, target) {

            if (url.indexOf('/') === 0) {
                url = url.replace('/', '');
            }

            if ((method || 'post').toLowerCase() === 'get') {
                url = $.bit8.baseUrl + url;
                if (params !== null) {
                    $.each(params, function (i, item) {
                        $.each(item, function (key, value) {
                            url = url + (i === 0 ? '?' : '&') + key + '=' + encodeURIComponent(value);
                        });
                    });
                }
                if (target) {
                    window.open(url, target)
                } else {
                    window.location = url;
                }
            }
            else {
                var form = $('<form></form>');
                form.attr("method", method || 'post');
                form.attr("action", $.bit8.baseUrl + url);
                if (params !== null) {
                    $.each(params, function (key, value) {
                        var field = $('<input></input>');

                        field.attr("type", "hidden");
                        field.attr("name", key);
                        field.attr("value", value);

                        form.append(field);
                    });
                }
                if (target) {
                    form.attr("target", target)
                }
                $(form).appendTo('body').submit();
            }
        };
        $.bit8.doRequest = function (url, type, async, params, callback, errorCallback, showLoading) {
            try {
                if (showLoading) {
                    $.bit8.showLoadingModal();
                }

                if (type === 'GET') {
                    $.ajax({
                        cache: false,
                        crossDomain: true,
                        type: 'GET',
                        url: $.bit8.apiUrl + url,
                        dataType: 'json',
                        async: async,
                        traditional: true,
                        contentType: false,
                        //xhrFields: { withCredentials: true },
                        success: function (result) {
                            callback(result);
                            if (showLoading) {
                                $.bit8.hideLoadingModal();
                            }
                        },
                        error: function (result) {
                            errorCallback(result);
                            if (showLoading) {
                                $.bit8.hideLoadingModal();
                            }
                        },
                    });
                }
                else {
                    $.ajax({
                        cache: false,
                        crossDomain: true,
                        type: type,
                        url: $.bit8.apiUrl + url,
                        data: JSON.stringify(params),
                        contentType: "application/json",
                        dataType: 'json',
                        async: async,
                        xhrFields: { withCredentials: true },
                        success: function (result) {
                            callback(result);
                            if (showLoading) {
                                $.bit8.hideLoadingModal();
                            }
                        },
                        error: function (result) {
                            errorCallback(result);
                            if (showLoading) {
                                $.bit8.hideLoadingModal();
                            }
                        },
                    });
                }
            }
            catch (err) {
                errorCallback(err);
            }

        };

        //Modals, alerts and toastr
        $.bit8.showLoadingModal = function () {
            $.blockUI({ css: { opacity: "1!important" }, overlayCSS: { opacity: ".4!important" }, baseZ: 2000, message:  '<h3>Loading...</h3>' });
        };
        $.bit8.hideLoadingModal = function () {
            $.unblockUI();
        };
        $.bit8.showSuccess = function (message, title, onHidden) {
            if (title === null) title = '';
            if (onHidden) toastrOpt.onHidden = onHidden;
            toastr.success(title, message, $.bit8.toastrOpt);
        };
        $.bit8.showError = function (message, title, onHidden) {
            if (title === null) title = '';
            if (onHidden) toastrOpt.onHidden = onHidden;
            $.bit8.toastrOpt.timeOut = 10000;
            toastr.error(title, message, $.bit8.toastrOpt);
        };
        $.bit8.showWarning = function (message, title, onHidden) {
            if (title === null) title = '';
            if (onHidden) toastrOpt.onHidden = onHidden;
            toastr.warning(title, message, $.bit8.toastrOpt);
        };

        $.bit8.clone = function (src) {
            return JSON.parse(JSON.stringify(src));
        };

        $.bit8.isNullOrEmpty = function (val) {
            return (!val || val.toString().trim().length === 0);
        };
    }


    /*global define:true */
    if (typeof define === 'function' && define.amd && define.amd.jQuery) {
        define(['jquery'], setup);
    } else {
        setup(jQuery);
    }

})();



