let currentSlide = 0;
const slides = document.querySelector('.slides');
const totalSlides = document.querySelectorAll('.slide').length;
const prevButton = document.getElementById('prev');
const nextButton = document.getElementById('next');

function moveSlide(direction) {
    currentSlide += direction;

    if (currentSlide <= 0) {
        currentSlide = 0;
        prevButton.disabled = true;
    } else {
        prevButton.disabled = false;
    }

    if (currentSlide >= totalSlides - 1) {
        currentSlide = totalSlides - 1;
        nextButton.disabled = true;
    } else {
        nextButton.disabled = false;
    }

    slides.style.transform = `translateX(-${currentSlide * 100}%)`;