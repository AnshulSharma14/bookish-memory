var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "/Administrator/ProductType/GetAll"
        },
        "columns": [
            { "data": "title" },
            {
               "data":"isbn"
            },
            {
                "data":"author"
            },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Administrator/ProductType/Upsert/${data}" class="btn btn-info">
                     Edit
                    <a class="btn btn-danger" onclick=Delete("/Administrator/ProductType/Delete/${data}")>
                     <i class="fa fa-trash-alt"></i>
                     </a>
					</div>
                        `
                },

            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Want to Delete Data",
        text: "Delete Information!!!!",
        buttons: true,
        icon: "warning",
        dangerModel: true
    }).then(WillDelete => {
        if (WillDelete) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}