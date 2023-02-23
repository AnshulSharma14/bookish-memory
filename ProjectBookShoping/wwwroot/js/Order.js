var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess")
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed")
        }
        else {
            if (url.includes("approved")) {
                loadDataTable("approved")
            }
            else {
                loadDataTable("all")
            }
        }
    }

});

function loadDataTable(status) {
    dataTable = $('#tbldata').DataTable({
        reponsive: true,
        "ajax": {
            "url": "/Administrator/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "14%" },
            { "data": "name", "width": "14%" },
            { "data": "phoneNumber", "width": "14%" },
            { "data": "applicationUser.email", "width": "14%" },
            { "data": "orderStatus", "width": "14%" },
            {
                "data": "orderTotal", "width": "14%"
            },
            {
                "data": "id", "width": "14%",
                "render": function (data) {
                    return `
                        <div class=" btn-group" role="group">
                        <a href="/Administrator/Order/Details?orderId=${data}" class="btn btn-info">
                                  Details
                        </a>
					</div>
                        `
                },

            }
        ]
    });
}
