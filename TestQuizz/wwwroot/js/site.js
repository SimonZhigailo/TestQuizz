// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#quiz1btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz1Input").val();
        let warning = $("#q1warning");
            $.ajax({
                type: "POST",
                url: MyAppUrlSettings.Quiz1,
                data: {
                    quizInput: val
                },
                success: function (result) {
                    $("#quiz1Answer").val(result)
                    warning.hide();
                },
                error: function (result) {
                    warning.show();
                    warning.text(result.responseText);
                }
            });
    });

    $("#quiz2btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz2Input").val();
        let warning = $("#q2warning");
        $.ajax({
            type: "POST",
            url: MyAppUrlSettings.Quiz2,
            data: {
                quizInput: val
            },
            success: function (result) {
                $("#quiz2Answer").val(result)
                warning.hide();
            },
            error: function (result) {
                warning.show();
                warning.text(result.responseText);
            }
        });
    });

    $("#quiz3btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz3Input").val();
        let warning = $("#q3warning");
        $.ajax({
            type: "POST",
            url: MyAppUrlSettings.Quiz3,
            data: {
                quizInput: val
            },
            success: function (result) {
                $("#quiz3Answer").val(result)
                warning.hide();
            },
            error: function (result) {
                warning.show();
                warning.text(result.responseText);
            }
        });
    });

    $("#quiz4btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz4Input").val();
        let warning = $("#q4warning");
        $.ajax({
            type: "POST",
            url: MyAppUrlSettings.Quiz4,
            data: {
                quizInput: val
            },
            success: function (result) {
                $("#quiz4Answer").val(result)
                warning.hide();
            },
            error: function (result) {
                warning.show();
                warning.text(result.responseText);
            }
        });
    });


    $("#quiz5btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz5Input").val();
        let warning = $("#q5warning");
        $.ajax({
            type: "POST",
            url: MyAppUrlSettings.Quiz5,
            data: {
                quizInput: val
            },
            success: function (result) {
                $("#quiz5Answer").val(result)
                warning.hide();
            },
            error: function (result) {
                warning.show();
                warning.text(result.responseText);
            }
        });
    });

    $("#quiz6btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz6Input").val();
        let warning = $("#q6warning");
        $.ajax({
            type: "POST",
            url: MyAppUrlSettings.Quiz6,
            data: {
                quizInput: val
            },
            success: function (result) {
                $("#quiz6Answer").val(result)
                warning.hide();
            },
            error: function (result) {
                warning.show();
                warning.text(result.responseText);
            }
        });
    });

    $("#quiz7btn").click(function (e) {
        e.preventDefault();
        let val = $("#quiz7Input").val();
        let warning = $("#q7warning");
        $.ajax({
            type: "POST",
            url: MyAppUrlSettings.Quiz7,
            data: {
                quizInput: val
            },
            success: function (result) {
                $("#quiz7Answer").val(result)
                warning.hide();
            },
            error: function (result) {
                warning.show();
                warning.text(result.responseText);
            }
        });
    });
});