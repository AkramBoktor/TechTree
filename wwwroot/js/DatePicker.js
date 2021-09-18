$(function () {
    $(".datepicker").datepicker({
        // format will be yyyy-mm-dd  and min date will be allow 10 day from the current date and max day allow 28 day of current date 
        dateFormat: 'yy-mm-dd',
        minDate: '-10D',
        maxDate: '+28D',
    });
});

