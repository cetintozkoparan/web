﻿$(function () {
 
    $("#LanguageList").change(function () {
        var lang = $("#LanguageList option:selected").val();
        window.location.href = "/yonetim/projereferanslari/" + lang;
    });

    SortOrder("/ProjectReference/SortRecords");
});
