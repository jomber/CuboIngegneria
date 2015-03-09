var totalSlides = 0;
var totalThumbs = 0;
var currentSlide = 1;
var contentSlides = "";
var contentThumbs = "";

$(document).ready(function () {
    $("#slideshow-previous").click(showPreviousSlide);
    $("#slideshow-next").click(showNextSlide);
   
    var totalWidth = 0;
   
    contentSlides = $(".slideshow-content");
    contentSlides.each(function (i) {
        totalWidth += this.clientWidth;
        totalSlides++;
        var srcImg = $('#imgSlide-' + totalSlides).attr('src');
        $('#thumbnail').append('<div ' + 'id=t-' + totalSlides + ' class="thumb"></div>');
        var idThumb = "#t-" + totalSlides;
        $(idThumb).append('<img id="img-'+ totalSlides +'" src="' + srcImg + '" class="imgThumb"/>');
        $(idThumb).append('<img id="imgHover-' + totalSlides + '" src="images/t01.png" class="imgThumbHover"/>');
    });

    $("#thumb-scroller").width(totalWidth / totalSlides);
    $("#slideshow-holder").width(totalWidth);
    $("#slideshow-scroller").attr({ scrollLeft: 0 });
    updateButtons();
    updateWidthDescription();
});

//Thumbs
$(document).ready(function () {
    $(".thumb").click(function (event) {
        var slide = event.target.id;
        slide = slide.split("-").pop();
        moveSlideTo(slide);
    });
});

function moveSlideTo(num) {
    currentSlide = num;
    updateContentHolder();
    updateButtons();
}

function showPreviousSlide() {
    currentSlide--;
    updateContentHolder();
    updateButtons();
}

function showNextSlide() {
    currentSlide++;
    updateContentHolder();
    updateButtons();
}

function updateContentHolder() {
    var scrollAmount = 0;
    contentSlides.each(function (i) {
        if (currentSlide - 1 > i) {
            scrollAmount += this.clientWidth;
        }
    });
    //$("#slideshow-scroller").fadeOut();
    //$(".slide").fadeOut();
    $("#slideshow-scroller").animate({ scrollLeft: scrollAmount }, 500);
}

function updateButtons() {
    if (currentSlide < totalSlides) {
        $("#slideshow-next").show();
    } else {
        $("#slideshow-next").hide();
    }
    if (currentSlide > 1) {
        $("#slideshow-previous").show();
    } else {
        $("#slideshow-previous").hide();
    }
}

function updateWidthDescription() {
    var slideShow = $("#slideshow-holder").height();
    var thumbScroller = $("#thumb-scroller").height();
    $("#projectDescription").height(slideShow + thumbScroller);
}