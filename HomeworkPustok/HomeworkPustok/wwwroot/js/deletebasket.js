
$(document).on("click", ".cross-btn", function (e) {
    e.preventDefault();
    let url = this.getAttribute("href");
    fetch(url).then(response => response.text()
    ).then(data => {
        $(".cart-dropdown-block").html(data)
    })
})