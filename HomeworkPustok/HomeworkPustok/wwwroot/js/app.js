$(document).on("click", ".modal-btn", function (e) {

    e.preventDefault();
    let url = $(this).attr("href")
    fetch(url).then(response => response.text()).then(data => {
        $("#quickModal .modal-dialog").html(data)
    })

    $("#quickModal").modal("show")

})



$(document).on("click", ".basket-add-btn", function (e) {
    e.preventDefault();
    let url = this.getAttribute("href");
    fetch(url).then(response => response.text()
    ).then(data => {
        $(".cart-dropdown-block").html(data)
    })
})
