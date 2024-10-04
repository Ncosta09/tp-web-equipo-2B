let currentIndex = 0;
function showImage(index, images) {
    const sliderWrapper = document.getElementById('sliderWrapper');
    sliderWrapper.style.transform = `translateX(${-index * 500}px)`;
}

function prevImage() {
    const images = document.querySelectorAll('.slider-wrapper img');
    currentIndex = (currentIndex > 0) ? currentIndex - 1 : images.length - 1;
    showImage(currentIndex, images);
}

function nextImage() {
    const images = document.querySelectorAll('.slider-wrapper img');
    currentIndex = (currentIndex < images.length - 1) ? currentIndex + 1 : 0;
    showImage(currentIndex, images);
}
