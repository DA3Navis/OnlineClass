$(document).ready(function () {
    $('.unit').click(function (e) {
        $('.showFrameVideo iframe').attr('src', $(this).attr('url-video'));
        $('.unit:not(.classReview)').addClass('classReview');
        $(this).removeClass('classReview');
    });
});