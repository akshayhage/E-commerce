

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
                
                { data: 'title' },
                { data: 'isbn' },
                { data: 'listPrice' },
                { data: 'author' },
                { data: 'category.name' }
            ]

        });
    }






