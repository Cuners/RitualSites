var modal = document.getElementById("contactModal");

// Get the button that opens the modal
var btn = document.getElementById("openModalBtn");

// Get the <span> element that closes the modal
var span = document.getElementById("closebut");

// Get the navigation panel
var navPanel = document.querySelector(".navigation-panel2");

// When the user clicks on the button, open the modal and remove sticky position
btn.onclick = function () {
    modal.style.display = "block";
    navPanel.classList.add("no-sticky");
}

// When the user clicks on <span> (x), close the modal and restore sticky position
span.onclick = function () {
    modal.style.display = "none";
    navPanel.classList.remove("no-sticky");
}

// When the user clicks anywhere outside of the modal, close it and restore sticky position
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        navPanel.classList.remove("no-sticky");
    }
}
