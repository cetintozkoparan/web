$(function () {
    var screenheight = screen.height;
    $("#page").css("min-height", screenheight-200);

});

jQuery(function ($) {
    $.datepicker.regional['tr'] = {
        closeText: 'kapat',
        prevText: '&#x3c;geri',
        nextText: 'ileri&#x3e',
        currentText: 'bugÃ¼n',
        monthNames: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran',
		'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'],
        monthNamesShort: ['Oca', 'Şub', 'Mar', 'Nis', 'May', 'Haz',
		'Tem', 'Ağu', 'Eyl', 'Eki', 'Kas', 'Ara'],
        dayNames: ['Pazar', 'Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi'],
        dayNamesShort: ['Pz', 'Pt', 'Sa', 'Ça', 'Pe', 'Cu', 'Ct'],
        dayNamesMin: ['Pz', 'Pt', 'Sa', 'Ça', 'Pe', 'Cu', 'Ct'],
        dateFormat: 'dd.mm.yy', firstDay: 1,
        isRTL: false
    };
    $.datepicker.setDefaults($.datepicker.regional['tr']);
});
$(document).ready(function () {
    smallBrowserSize(jQuery(window).width());
    $('.lbox-container').corners("5px bottom");
    $('.lbox h4').corners("5px top");
    $('ul.tab-menu li a').corners("5px top");
    
    $("#calendar").datepicker();/** jquery ui calendar/date picker - see jquery ui docs for help: http://jqueryui.com/demos/ **/
    var start = new Date;

    setInterval(function () {
        var now = new Date();
        var timetext = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();

        $('.hour').text(timetext);

        //var month = now.getMonth() + 1;
        //var day = now.getDate();

        //var output = (day < 10 ? '0' : '') + day + '/' +
        //             (month < 10 ? '0' : '') + month + '/' +
        //              now.getFullYear();
        //$('.date').text(output);

    }, 1000);
});


$(window).resize(function () {
    smallBrowserSize(jQuery(window).width());
});

function smallBrowserSize(e) {
    if (e <= 960) { $("#logo").hide(); } else { $("#logo").show(); }
}

/* hava durumu */
$(function () {
    $.simpleWeather({
        location: 'Istanbul',
        unit: 'c',
        success: function (weather) {
            var current = setCurrentWeatherInfo(weather.currently);
            var updated = setUpdateInfo(weather.updated);
            var direction = setDirection(weather.wind.direction);

            var markup = '<div style="width:90px;height:60px;float:left"><img src="' + weather.image + '" width=125 height=90/></div>';
            markup += '<div id="havadurumuil" style="width:100px;float:left; text-align:center;">' + weather.city;
            markup += '<br><span style="font-size:18px; color:#333">' + weather.temp + '°' + weather.units.temp + ' ' + current + '</span></div>';
           
            //markup = '<div class="tab" id="tempDetail">' +
            //             '<div class="prop high"><div class="header">Yüksek</div> ' + weather.high + '° ' + weather.units.temp + ' </div>' +
            //             '<div class="prop low"><div class="header">Düşük </div> ' + weather.low + '° ' + weather.units.temp + ' </div>' +
            //             '<div class="prop humidty"><div class="header">Nem </div> %' + weather.humidity + ' </div>' +
            //             '<div class="prop pressure"><div class="header">Basınç </div> ' + weather.pressure + ' ' + weather.units.pressure + ' </div>' +
            //             '<div class="prop visibility"><div class="header">Görüş </div> ' + weather.visibility + ' ' + weather.units.distance + ' </div>' +
            //         '</div>' +
            //         '<div class="tab" id="tempInfo">' +
            //             '<div class="cityName"> ' + weather.city + ' </div>' +
            //             '<div class="tempImg">' +
            //                 '<img src="' + weather.image + '"/>' +
            //             '</div>' +
            //             '<div class="temp"> ' + weather.temp + '° ' + weather.units.temp + ' </div>' +
            //             '<div class="tempType"> ' + current + ' </div>' +
            //         '</div>' +
            //         '<div class="tab" id="weatherDetail">' +
            //             '<div class="prop sunrise"><div class="header">Gün Doğumu </div> ' + weather.sunrise + ' </div>' +
            //             '<div class="prop sunset"><div class="header">Gün Batımı </div> ' + weather.sunset + ' </div>' +
            //             '<div class="prop wind">' +
            //                 '<div class="header"> Rüzgar </div>' +
            //                 '<div class="chill"> <span> Soğukluk : </span> ' + weather.wind.chill + '° ' + weather.units.temp + ' </div>' +
            //                 '<div class="direction"> <span> Yön : </span> ' + direction + ' </div>' +
            //                 '<div class="speed"> <span> Hız : </span> ' + weather.wind.speed + ' ' + weather.units.speed + ' </div>' +
            //             '</div>' +
            //             '<div class="update"> Güncellenme <br/> ' + updated + ' </div>' +
            //         '</div>';

            $('#weather').html(markup);

        },
        error: function (error) {
            $("#weather").html('<p>' + error + '</p>');
        }
    });
});

var setCurrentWeatherInfo = function (current) {
    switch (current) {
        case 'Partly Cloudy': return 'Parçalı Bulutlu'; break;
        case 'Fair': return 'Açık'; break;
        case 'Cloudy': return 'Bulutlu'; break;
        case 'Mostly Cloudy': return 'Çok Bulutlu'; break;
        case 'Showers in the Vicinity': return 'Sağanak Yağışlı'; break;
        case 'Rain': return 'Yağmurlu'; break;
        case 'Light Rain': return 'Hafif Yağmurlu'; break;
        case 'Sunny': return 'Güneşli'; break;
        default: return current; break;
    }
};

var setUpdateInfo = function (update) {
    var updates = update.split(',');

    var dayString = updates[0];
    var date = updates[1].split(' ');
    var day = date[1];
    var month = date[2];
    var year = date[3];
    var time = date[4];
    var exec = date[5];

    dayString = setDay(dayString);
    month = setMonth(month);
    time = setTime(time, exec);

    return day + ' ' + month + ' ' + year + ' ' + time + ' ' + dayString;
};

var setDay = function (day) {
    switch (day) {
        case 'Sun': return 'Pazar'; break;
        case 'Mon': return 'Pazartesi'; break;
        case 'Tue': return 'Salı'; break;
        case 'Wed': return 'Çarşamba'; break;
        case 'Thu': return 'Perşembe'; break;
        case 'Fri': return 'Cuma'; break;
        case 'Sat': return 'Cumartesi'; break;
        default: return day; break;
    }
};

var setMonth = function (month) {
    switch (month) {
        case 'Jan': return 'Ocak'; break;
        case 'Feb': return 'Şubat'; break;
        case 'Mar': return 'Mart'; break;
        case 'Apr': return 'Nisan'; break;
        case 'May': return 'Mayıs'; break;
        case 'Jun': return 'Haziran'; break;
        case 'Jul': return 'Temmuz'; break;
        case 'Aug': return 'Ağustos'; break;
        case 'Sep': return 'Eylül'; break;
        case 'Oct': return 'Ekim'; break;
        case 'Nov': return 'Kasım'; break;
        case 'Dec': return 'Aralık'; break;
        default: return month; break;
    }
};

var setTime = function (time, exec) {
    var hour = time.split(':')[0];
    var minute = time.split(':')[1];
    if (exec == 'am') {
        if (hour < 10)
            hour = '0' + hour;
    } else if (exec == 'pm') {
        hour = Number(hour) + 12;
    }

    return hour + ':' + minute;
};

var setDirection = function (direction) {

    switch (direction) {
        case 'N': return 'Kuzey'; break;
        case 'S': return 'Güney'; break;
        case 'E': return 'Doğu'; break;
        case 'W': return 'Batı'; break;
        case 'NE': return 'Kuzey Doğu'; break;
        case 'NW': return 'Kuzey Batı'; break;
        case 'SE': return 'Güney Doğu'; break;
        case 'SW': return 'Güney Batı'; break;
        case 'NNE': return 'Kuzey Doğu'; break;
        case 'NNW': return 'Kuzey Batı'; break;
        case 'SSE': return 'Güney Doğu'; break;
        case 'SSW': return 'Güney Batı'; break;
        default: return direction; break;
    }
};
/****************/