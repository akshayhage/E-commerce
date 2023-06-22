

    $(document).ready(function ()
    {
        loadDataTable();
    })

    function loadDataTable()
    {
        dataTable = $('#tblData').DataTable({
            "ajax": {
                url: '/admin/product/getall'
            },
 
            processing: true,
            serverSide: true,
            filter: true,
     
            "columns": [
                
                { data: 'title' ,"width":"25%"},
                { data: 'isbn', "width": "15%" },
                { data: 'listPrice', "width": "10%" },
                { data: 'author', "width": "15%" },
                { data: 'category.name', "width": "10%" },
                {
                    data: 'id',
                    "render": function (data) {
                        //alert(data);
                        return `<div class="W-75 btn-group" role="group">
                                <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                                <a href="/admin/product/delete/${data}"  class="btn btn-danger mx-2"> <i class="bi bi-trash"></i>Delete</a>
                                </div>`
                    },
                    "width": "25%"
                }
            ]

        });
    }






