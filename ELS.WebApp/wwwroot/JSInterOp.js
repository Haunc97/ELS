function PrevenDefaultEvent(selector) {

    document.getElementById(selector).addEventListener("click", function (event) {
        console.log(event);
        event.preventDefault();
        return false;
    });
}