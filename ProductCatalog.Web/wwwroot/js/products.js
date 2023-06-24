$(document).ready(function () {
    $("#categoryFilter").change(function () {
        var selectedCategory = $(this).val();
        filterProductsByCategory(selectedCategory);
    });

    function filterProductsByCategory(category) {
        var rows = $("tbody tr");
        if (category === "") {
            rows.show();
        } else {
            rows.hide();
            rows.each(function () {
                //Select ProductCategory that represent in secound td
                var productCategory = $(this).find("td:nth-child(2)").text();
                if (productCategory === category) {
                    $(this).show();
                }
            });
        }
    }
});