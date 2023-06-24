$(document).ready(function () {
    $(".delete-product").click(function () {
        var productId = $(this).data("id");
        if (confirm("Are you sure you want to delete this product?")) {
            $.ajax({
                url: "/Products/Delete/" + productId,
                type: "Delete",
                success: function (response) {
                    alert("Product deleted successfully.");
                    window.location.href = '/Products/Index';
                },
                error: function (xhr, status, error) {
                    alert("An error occurred while deleting the product.");
                }
            });
        }
    });
});